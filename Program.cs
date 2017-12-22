using System;
using EmployeeManager.Adapters;
using EmployeeManager.Business;
using EmployeeManager.Extensions;

namespace EmployeeManager
{
    internal class Khoa_Vo
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                "Invalid args".WriteError();
            }
            else
            {
                var cmd = args[0];
                var tail = args.MakeTail();
                using (var gw = new MySqlGateway())
                {
                    Handle(gw, cmd, tail);
                }
            }

            "Press any key to exit...".WriteInfo();
            Console.ReadKey(true);
        }

        private static void Handle(IGateway gw, string cmd, string[] args)
        {
            switch (cmd)
            {
                case "add-emp":
                {
                    var uc = new UcAddEmployee(gw);
                    var pre = new PreAddEmployee(uc);
                    pre.Execute(args);
                }
                    break;
                case "rem-emp":
                {
                    var uc = new UcRemoveEmployee(gw);
                    var pre = new PreRemoveEmployee(uc);
                    pre.Execute(args);
                }
                    break;
                case "edit-emp":
                {
                    var uc = new UcEditEmployee(gw);
                    var pre = new PreEditEmployee(uc);
                    pre.Execute(args);
                }
                    break;
                case "view-emp":
                {
                    var uc = new UcViewEmployee(gw);
                    var pre = new PreViewEmployee(uc);
                    pre.Execute(args);
                }
                    break;
                case "list-all-emp":
                {
                    var uc = new UcListAllEmployees(gw);
                    var pre = new PreListAllEmployees(uc);
                    pre.Execute();
                }
                    break;
                case "add-city":
                {
                    var uc = new UcAddCity(gw);
                    var pre = new PreAddCity(uc);
                    pre.Execute(args);
                }
                    break;
                case "rem-city":
                {
                    var uc = new UcRemoveCity(gw);
                    var pre = new PreRemoveCity(uc);
                    pre.Execute(args);
                }
                    break;
                case "edit-city":
                {
                    var uc = new UcEditCity(gw);
                    var pre = new PreEditCity(uc);
                    pre.Execute(args);
                }
                    break;
                case "view-city":
                {
                    var uc = new UcViewCity(gw);
                    var pre = new PreViewCity(uc);
                    pre.Execute(args);
                }
                    break;
                case "list-all-ct":
                {
                    var uc = new UcListAllCities(gw);
                    var pre = new PreListAllCities(uc);
                    pre.Execute(args);
                }
                    break;
                default:
                    "Could not recognize the command".WriteError();
                    break;
            }
        }
    }
}