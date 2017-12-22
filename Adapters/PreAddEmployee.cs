using EmployeeManager.Business;
using EmployeeManager.Extensions;

namespace EmployeeManager.Adapters
{
    public class PreAddEmployee
    {
        private readonly UcAddEmployee uc;

        public PreAddEmployee(UcAddEmployee uc)
        {
            this.uc = uc;
        }

        public void Execute(string[] args)
        {
            if (args.Length != 4)
            {
                "Invalid number of args, must be 4".WriteError();
                return;
            }

            var firstName = args[0];
            var lastName = args[1];

            if (!args[2].ConvertToDateTime(out var birthDay))
            {
                "Invalid birthDay, must be in format dd/MM/yyyy".WriteError();
                return;
            }

            if (!int.TryParse(args[3], out var birthCityId))
            {
                "Invalid birthCityID, must be an integer".WriteError();
                return;
            }

            if (!uc.Execute(firstName, lastName, birthDay, birthCityId, out var e))
            {
                "The birthCityId is not existed".WriteError();
                return;
            }

            $"OK! New employee id = {e.Id}".WriteError();
        }
    }
}