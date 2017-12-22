namespace EmployeeManager.Business
{
    public class UcRemoveEmployee
    {
        private readonly IGateway gateway;

        public UcRemoveEmployee(IGateway gateway)
        {
            this.gateway = gateway;
        }

        public bool Execute(int employeeId)
        {
            return gateway.DeleteEmployee(employeeId);
        }
    }
}