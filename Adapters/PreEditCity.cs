using EmployeeManager.Business;
using EmployeeManager.Extensions;

namespace EmployeeManager.Adapters
{
    public class PreEditCity
    {
        private readonly UcEditCity uc;

        public PreEditCity(UcEditCity uc)
        {
            this.uc = uc;
        }

        public void Execute(params string[] args)
        {
            if (args.Length < 2)
            {
                "Invalid number of args, must be equal or greater than 2".WriteInfo();
                return;
            }

            if (!int.TryParse(args[0], out var cityId))
            {
                "Invalid cityId, must be an integer".WriteError();
                return;
            }

            var cityName = string.Join(" ", args.MakeTail());

            if (!uc.Execute(cityId, cityName))
            {
                "The cityId is not existed".WriteError();
                return;
            }

            "The city information was updated successfully".WriteInfo();
        }
    }
}