using System.Linq;
using EmployeeManager.Business;
using EmployeeManager.Extensions;

namespace EmployeeManager.Adapters
{
    public class PreListAllEmployees
    {
        private readonly UcListAllEmployees uc;

        public PreListAllEmployees(UcListAllEmployees uc)
        {
            this.uc = uc;
        }

        public void Execute()
        {
            var employees = uc.Execute().OrderBy(e => e.FirstName).ToList();

            $"Total number of employees = {employees.Count}".WriteInfo();

            foreach (var e in employees)
                $"[Id: {e.Id}] [FullName: {e.FullName}] [Age: {e.Age}] [BirthCity: {e.BirthCity.Name}]".WriteInfo();
        }
    }
}