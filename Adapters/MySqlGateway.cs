using System;
using System.Collections.Generic;
using EmployeeManager.Business;
using MySql.Data.MySqlClient;

namespace EmployeeManager.Adapters
{
    public class MySqlGateway : IGateway, IDisposable
    {
        private static readonly string SERVER = "localhost";
        private static readonly int PORT = 3306;
        private static readonly string USERNAME = "root";
        private static readonly string PASSWORD = "root";
        private static readonly string DATABASE_NAME = "empmana";

        private static readonly string CONNECTION_STRING =
            $"Server={SERVER}; Port={PORT}; UserID={USERNAME}; Password={PASSWORD}; Database={DATABASE_NAME}";

        private readonly MySqlConnection connection;

        public MySqlGateway()
        {
            connection = new MySqlConnection(CONNECTION_STRING);
            connection.Open();
        }

        public void Dispose()
        {
            connection.Close();
        }

        //==================================================================================================
        // Employee
        //==================================================================================================

        public void InsertEmployee(Employee e)
        {
            var script =
                "INSERT INTO employee (first_name, last_name, birth_day, birth_city_id) " +
                "VALUES (@FN, @LN, @BD, @BCI)";
            using (var command = MakeCommand(script))
            {
                command.Prepare();
                command.Parameters.AddWithValue("@FN", e.FirstName);
                command.Parameters.AddWithValue("@LN", e.LastName);
                command.Parameters.AddWithValue("@BD", e.BirthDay);
                command.Parameters.AddWithValue("@BCI", e.BirthCity.Id);
                command.ExecuteNonQuery();
                e.__SetId((int) command.LastInsertedId);
            }
        }

        public bool DeleteEmployee(int id)
        {
            var script = "DELETE FROM employee WHERE id = @I";
            using (var command = MakeCommand(script))
            {
                command.Prepare();
                command.Parameters.AddWithValue("@I", id);
                return command.ExecuteNonQuery() > 0;
            }
        }

        public void UpdateEmployee(Employee e)
        {
            var script = "UPDATE employee " +
                         "SET first_name = @FN, last_name = @LN, birth_day = @BD, birth_city_id = @BCI " +
                         "WHERE id = @I";
            using (var command = MakeCommand(script))
            {
                command.Prepare();
                command.Parameters.AddWithValue("@I", e.Id);
                command.Parameters.AddWithValue("@FN", e.FirstName);
                command.Parameters.AddWithValue("@LN", e.LastName);
                command.Parameters.AddWithValue("@BD", e.BirthDay);
                command.Parameters.AddWithValue("@BCI", e.BirthCity.Id);
                command.ExecuteNonQuery();
            }
        }

        public List<Employee> LoadAllEmployees()
        {
            var script =
                "SELECT E.id AS e_id, E.first_name, E.last_name, E.birth_day, " +
                "C.id AS c_id, C.name as c_name " +
                "FROM employee AS E, city AS C " +
                "WHERE E.birth_city_id = C.id " +
                "ORDER BY E.first_name";
            using (var command = MakeCommand(script))
            {
                using (var reader = command.ExecuteReader())
                {
                    var employees = new List<Employee>();
                    var cities = new Dictionary<int, City>();
                    while (reader.Read())
                    {
                        var cityId = reader.GetInt32("c_id");
                        if (!cities.TryGetValue(cityId, out var city))
                        {
                            city = new City(reader.GetInt32("c_id"), reader.GetString("c_name"));
                            cities.Add(cityId, city);
                        }
                        var e = new Employee(
                            reader.GetInt32("e_id"),
                            reader.GetString("first_name"),
                            reader.GetString("last_name"),
                            reader.GetDateTime("birth_day"),
                            city);
                        employees.Add(e);
                    }
                    return employees;
                }
            }
        }

        public bool LoadEmployee(int id, out Employee e)
        {
            var script =
                "SELECT E.id AS e_id, E.first_name, E.last_name, E.birth_day, " +
                "C.id AS c_id, C.name as c_name " +
                "FROM employee AS E, city AS C " +
                "WHERE E.birth_city_id = C.id AND E.id = @I";
            using (var command = MakeCommand(script))
            {
                command.Parameters.AddWithValue("@I", id);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var city = new City(reader.GetInt32("c_id"), reader.GetString("c_name"));
                        e = new Employee(
                            reader.GetInt32("e_id"),
                            reader.GetString("first_name"),
                            reader.GetString("last_name"),
                            reader.GetDateTime("birth_day"),
                            city);
                        return true;
                    }
                    e = null;
                    return false;
                }
            }
        }

        //==================================================================================================
        // City
        //==================================================================================================

        public void InsertCity(City c)
        {
            var script =
                "INSERT INTO city (name) " +
                "VALUES (@N)";
            using (var command = MakeCommand(script))
            {
                command.Prepare();
                command.Parameters.AddWithValue("@N", c.Name);
                command.ExecuteNonQuery();
                c.__SetId((int) command.LastInsertedId);
            }
        }

        public bool DeleteCity(int id)
        {
            var script = "DELETE FROM city WHERE id = @I";
            using (var command = MakeCommand(script))
            {
                command.Prepare();
                command.Parameters.AddWithValue("@I", id);
                return command.ExecuteNonQuery() > 0;
            }
        }

        public void UpdateCity(City c)
        {
            var script = "UPDATE city " +
                         "SET name = @N " +
                         "WHERE id = @I";
            using (var command = MakeCommand(script))
            {
                command.Prepare();
                command.Parameters.AddWithValue("@I", c.Id);
                command.Parameters.AddWithValue("@N", c.Name);
                command.ExecuteNonQuery();
            }
        }

        public List<City> LoadAllCities()
        {
            var script =
                "SELECT C.id, C.name, (SELECT COUNT(*) FROM employee AS E WHERE C.id = E.birth_city_id) AS noe " +
                "FROM city AS C";
            using (var command = MakeCommand(script))
            {
                using (var reader = command.ExecuteReader())
                {
                    var cities = new List<City>();
                    while (reader.Read())
                    {
                        var city = new City(reader.GetInt32("id"), reader.GetString("name"), reader.GetInt32("noe"));
                        cities.Add(city);
                    }
                    return cities;
                }
            }
        }

        public bool LoadCity(int id, out City c)
        {
            var script = "SELECT * FROM city WHERE id = @I";
            using (var command = MakeCommand(script))
            {
                command.Prepare();
                command.Parameters.AddWithValue("@I", id);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        c = new City(reader.GetInt32("id"), reader.GetString("name"));
                        return true;
                    }
                    c = null;
                    return false;
                }
            }
        }

        private MySqlCommand MakeCommand(string command)
        {
            return new MySqlCommand(command, connection);
        }
    }
}