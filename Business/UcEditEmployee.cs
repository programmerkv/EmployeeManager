using System;

namespace EmployeeManager.Business
{
    public class UcEditEmployee
    {
        private readonly IGateway gateway;

        public UcEditEmployee(IGateway gateway)
        {
            this.gateway = gateway;
        }

        public string Error { get; private set; }

        public bool Execute(int employeeId, string firstName, string lastName, DateTime birthDay, int birthCityId)
        {
            if (!gateway.LoadEmployee(employeeId, out var e))
            {
                Error = "The employeeId is not existed";
                return false;
            }

            if (!gateway.LoadCity(birthCityId, out var c))
            {
                Error = "The birthCityId is not existed";
                return false;
            }

            e.FirstName = firstName;
            e.LastName = lastName;
            e.BirthDay = birthDay;
            e.BirthCity = c;

            gateway.UpdateEmployee(e);

            return true;
        }
    }
}