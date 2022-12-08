using System;
using System.Collections.Generic;
using Reports.Business.Services;
using Reports.Data.Accounts;
using Reports.Data.Entities;


namespace Reports.Client.Options.EmployeeOption
{
    public class GetAllEmployee : IOption
    {
        public void StartOption()
        {
            List<Employee> employees = EmployeeService.GetAll();

            Console.WriteLine("All employees:");
            foreach (Employee employee in employees)
            {
                Account.ConsoleOutput(employee);
            }
        }
    }
}