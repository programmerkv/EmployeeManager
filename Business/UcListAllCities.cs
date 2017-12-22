using System.Collections.Generic;

namespace EmployeeManager.Business
{
    public class UcListAllCities
    {
        private readonly IGateway gateway;

        public UcListAllCities(IGateway gateway)
        {
            this.gateway = gateway;
        }

        public List<City> Execute()
        {
            return gateway.LoadAllCities();
        }
    }
}