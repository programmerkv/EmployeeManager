using System;

namespace EmployeeManager.Business
{
    public class Employee
    {
        public Employee(string firstName, string lastName, DateTime birthDay, City birthCity)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDay = birthDay;
            BirthCity = birthCity;
        }

        public Employee(int id, string firstName, string lastName, DateTime birthDay, City birthCity)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthDay = birthDay;
            BirthCity = birthCity;
        }

        public int Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public City BirthCity { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public int Age => DateTime.Now.Year - BirthDay.Year;

        //================================================

        public void __SetId(int id)
        {
            Id = id;
        }
    }
}