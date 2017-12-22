namespace EmployeeManager.Business
{
    public class UcEditCity
    {
        private readonly IGateway gateway;

        public UcEditCity(IGateway gateway)
        {
            this.gateway = gateway;
        }

        public bool Execute(int cityId, string cityName)
        {
            if (!gateway.LoadCity(cityId, out var c))
                return false;

            c.Name = cityName;
            gateway.UpdateCity(c);

            return true;
        }
    }
}