using EmployeeManager.Business;
using EmployeeManager.Extensions;

namespace EmployeeManager.Adapters
{
    public class PreAddCity
    {
        private readonly UcAddCity uc;

        public PreAddCity(UcAddCity uc)
        {
            this.uc = uc;
        }

        public void Execute(params string[] args)
        {
            if (args.Length < 1)
            {
                "Invalid number of args, must be equal or greater than 1".WriteInfo();
                return;
            }

            var cityName = string.Join(" ", args);

            if (!uc.Execute(cityName, out var c))
            {
                "The cityName is existed".WriteInfo();
                return;
            }

            $"The city {cityName} id = {c.Id} has been added successfully".WriteInfo();
        }
    }
}