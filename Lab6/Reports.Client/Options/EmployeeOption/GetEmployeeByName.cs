using System;
using Reports.Business.Services;
using Reports.Data.Accounts;
using Reports.Data.Entities;


namespace Reports.Client.Options.EmployeeOption
{
    public class GetEmployeeByName : IOption
    {
        public void StartOption()
        {
            Console.WriteLine("Enter employee name:");
            string name = Console.ReadLine();


            Employee employee = EmployeeService.FindByName(name);
            
            Account.ConsoleOutput(employee);
        }
    }
}