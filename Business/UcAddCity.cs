namespace EmployeeManager.Business
{
    public class UcAddCity
    {
        private readonly IGateway gateway;

        public UcAddCity(IGateway gateway)
        {
            this.gateway = gateway;
        }

        public bool Execute(string cityName, out City c)
        {
            var cities = gateway.LoadAllCities();

            foreach (var city in cities)
                if (city.Name == cityName)
                {
                    c = null;
                    return false;
                }

            c = new City(cityName);
            gateway.InsertCity(c);

            return true;
        }
    }
}