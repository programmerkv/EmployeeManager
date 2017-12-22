namespace EmployeeManager.Business
{
    public class UcViewEmployee
    {
        private readonly IGateway gateway;

        public UcViewEmployee(IGateway gateway)
        {
            this.gateway = gateway;
        }

        public bool Execute(int employeeId, out Employee e)
        {
            return gateway.LoadEmployee(employeeId, out e);
        }
    }
}