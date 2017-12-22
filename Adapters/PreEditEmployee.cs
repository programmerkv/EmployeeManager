using EmployeeManager.Business;
using EmployeeManager.Extensions;

namespace EmployeeManager.Adapters
{
    public class PreEditEmployee
    {
        private readonly UcEditEmployee uc;

        public PreEditEmployee(UcEditEmployee uc)
        {
            this.uc = uc;
        }

        public void Execute(string[] args)
        {
            if (args.Length != 5)
            {
                "Invalid number of args, must be 5".WriteError();
                return;
            }

            if (!int.TryParse(args[0], out var employeeId))
            {
                "Invalid employeeId, must be an integer".WriteError();
                return;
            }

            var firstName = args[1];
            var lastName = args[2];

            if (!args[3].ConvertToDateTime(out var birthDay))
            {
                "Invalid birthDay, must be in format dd/MM/yyyy".WriteError();
                return;
            }

            if (!int.TryParse(args[4], out var birthCityId))
            {
                "Invalid birthCityID, must be an integer".WriteError();
                return;
            }

            if (!uc.Execute(employeeId, firstName, lastName, birthDay, birthCityId))
            {
                uc.Error.WriteError();
                return;
            }

            "The employee information was updated successfully".WriteInfo();
        }
    }
}