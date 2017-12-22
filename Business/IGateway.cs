using System.Collections.Generic;

namespace EmployeeManager.Business
{
    public interface IGateway
    {
        void InsertEmployee(Employee e);
        bool DeleteEmployee(int id);
        void UpdateEmployee(Employee e);
        List<Employee> LoadAllEmployees();
        bool LoadEmployee(int id, out Employee e);

        //================================================

        void InsertCity(City c);
        bool DeleteCity(int id);
        void UpdateCity(City c);
        List<City> LoadAllCities();
        bool LoadCity(int id, out City c);
    }
}