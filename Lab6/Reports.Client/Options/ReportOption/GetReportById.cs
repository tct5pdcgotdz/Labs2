using System;
using Reports.Business.Services;
using Reports.Client.Managers;
using Reports.Data.Entities;

namespace Reports.Client.Options.ReportOption
{
    public class GetReportById : IOption
    {
        public void StartOption()
        {
            Console.WriteLine("Enter report id:");
            int id = Convert.ToInt32(Console.ReadLine());
            
            Report report = ReportService.FindById(id);

            Report.ConsoleOutput(report);
        }
    }
}