using EmployeeManager.Business;
using EmployeeManager.Extensions;

namespace EmployeeManager.Adapters
{
    public class PreListAllCities
    {
        private readonly UcListAllCities uc;

        public PreListAllCities(UcListAllCities uc)
        {
            this.uc = uc;
        }

        public void Execute(string[] args)
        {
            if (args.Length != 0)
            {
                "Invalid number of args, must be 0".WriteError();
                return;
            }

            var cities = uc.Execute();

            $"Total number of cities = {cities.Count}".WriteInfo();

            foreach (var c in cities)
                $"[Id: {c.Id}] [Name: {c.Name}] [Employees: {c.Noe}]".WriteInfo();
        }
    }
}