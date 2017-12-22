using System.Collections.Generic;

namespace EmployeeManager.Business
{
    public class UcListAllEmployees
    {
        private readonly IGateway gateway;

        public UcListAllEmployees(IGateway gateway)
        {
            this.gateway = gateway;
        }

        public List<Employee> Execute()
        {
            return gateway.LoadAllEmployees();
        }
    }
}