namespace EmployeeManager.Business
{
    public class UcViewCity
    {
        private readonly IGateway gateway;

        public UcViewCity(IGateway gateway)
        {
            this.gateway = gateway;
        }

        public bool Execute(int cityId, out City c)
        {
            return gateway.LoadCity(cityId, out c);
        }
    }
}