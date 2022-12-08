using System;
using Reports.Business.Services;
using Reports.Data.Accounts;
using Reports.Data.Entities;


namespace Reports.Client.Options.EmployeeOption
{
    public class GetEmployeeById : IOption
    {
        public void StartOption()
        {
            Console.WriteLine("Enter employee id:");
            int id = Convert.ToInt32(Console.ReadLine());

            Employee employee = EmployeeService.FindById(id);
            
            Account.ConsoleOutput(employee);
        }
    }
}