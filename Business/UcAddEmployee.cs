using System;

namespace EmployeeManager.Business
{
    public class UcAddEmployee
    {
        private readonly IGateway gateway;

        public UcAddEmployee(IGateway gateway)
        {
            this.gateway = gateway;
        }

        public bool Execute(string firstName, string lastName, DateTime birthDay, int birthCityId, out Employee e)
        {
            if (!gateway.LoadCity(birthCityId, out var birthCity))
            {
                e = null;
                return false;
            }

            e = new Employee(firstName, lastName, birthDay, birthCity);
            gateway.InsertEmployee(e);

            return true;
        }
    }
}