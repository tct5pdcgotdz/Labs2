using System;
using Reports.Business.Services;
using Reports.Client.Managers;
using Reports.Data.Entities;

namespace Reports.Client.Options.ReportOption
{
    public class CreateReport : IOption
    {
        public void StartOption()
        {
            Console.WriteLine("Enter report content");
            string reportContent = Console.ReadLine();
            Console.WriteLine("Enter task id");
            int taskId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter employee id");
            int employeeId = Convert.ToInt32(Console.ReadLine());


            Report report = ReportService.Create(taskId, employeeId, reportContent);

            Console.WriteLine("[!] Successful");
        }
    }
}