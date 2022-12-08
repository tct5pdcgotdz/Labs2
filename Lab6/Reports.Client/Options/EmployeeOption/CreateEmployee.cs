using System;
using Reports.Business.Services;
using Reports.Data.Accounts;
using Reports.Data.Entities;

namespace Reports.Client.Options.EmployeeOption
{
    public class CreateEmployee : IOption
    {
        public void StartOption()
        {
            Console.WriteLine("Enter employee name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter login");
            string login = Console.ReadLine();
            Console.WriteLine("Enter password");
            string password = Console.ReadLine();
            Console.WriteLine("Enter leader id:");
            int leaderId = Convert.ToInt32(Console.ReadLine());
            
            //Employee employee = EmployeeService.Create(name, LeaderService.GetById(leaderId),login, password);

            Console.WriteLine("[!] Successful");
        }
    }
}