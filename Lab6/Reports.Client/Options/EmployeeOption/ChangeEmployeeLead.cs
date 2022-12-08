using System;
using Reports.Business.Services;
using Reports.Data.Accounts;

namespace Reports.Client.Options.EmployeeOption
{
    public class ChangeEmployeeLead : IOption
    {
        public void StartOption()
        {
            Console.WriteLine("Enter employee id:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter new lead id:");
            int leadId = Convert.ToInt32(Console.ReadLine());
            
            Employee employee = EmployeeService.ChangeLeader(id, LeaderService.GetById(leadId));

            Console.WriteLine("[!] Successful");
        }
    }
}