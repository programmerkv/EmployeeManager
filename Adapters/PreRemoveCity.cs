using EmployeeManager.Business;
using EmployeeManager.Extensions;

namespace EmployeeManager.Adapters
{
    public class PreRemoveCity
    {
        private readonly UcRemoveCity uc;

        public PreRemoveCity(UcRemoveCity uc)
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

            if (!int.TryParse(args[0], out var cityId))
            {
                "Invalid cityId, must be an integer".WriteError();
                return;
            }

            if (!uc.Execute(cityId))
            {
                "The cityId is not existed".WriteError();
                return;
            }

            "The city has been removed successfully".WriteInfo();
        }
    }
}