using EmployeeManager.Business;
using EmployeeManager.Extensions;

namespace EmployeeManager.Adapters
{
    public class PreViewEmployee
    {
        private readonly UcViewEmployee uc;

        public PreViewEmployee(UcViewEmployee uc)
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

            if (!uc.Execute(employeeId, out var e))
            {
                "The employeeId is not existed".WriteError();
                return;
            }

            $"[Id: {e.Id}] [FullName: {e.FullName}] [Age: {e.Age}] [BirthCity: {e.BirthCity.Name}]".WriteInfo();
        }
    }
}