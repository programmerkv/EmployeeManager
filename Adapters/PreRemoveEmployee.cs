using EmployeeManager.Business;
using EmployeeManager.Extensions;

namespace EmployeeManager.Adapters
{
    public class PreRemoveEmployee
    {
        private readonly UcRemoveEmployee uc;

        public PreRemoveEmployee(UcRemoveEmployee uc)
        {
            this.uc = uc;
        }

        public void Execute(string[] args)
        {
            if (args.Length != 1)
            {
                "Invalid number of args, must be 1".WriteError();
                return;
            }

            if (!int.TryParse(args[0], out var employeeId))
            {
                "Invalid employeeId, must be an integer".WriteError();
                return;
            }

            if (!uc.Execute(employeeId))
                "The employeeId is not existed".WriteError();
            else
                "The employee has been removed".WriteInfo();
        }
    }
}