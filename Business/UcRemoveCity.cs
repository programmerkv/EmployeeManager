namespace EmployeeManager.Business
{
    public class UcRemoveCity
    {
        private readonly IGateway gateway;

        public UcRemoveCity(IGateway gateway)
        {
            this.gateway = gateway;
        }

        public bool Execute(int cityId)
        {
            var employees = gateway.LoadAllEmployees();

            foreach (var e in employees)
                if (e.BirthCity.Id == cityId)
                    gateway.DeleteEmployee(e.Id);

            return gateway.DeleteCity(cityId);
        }
    }
}