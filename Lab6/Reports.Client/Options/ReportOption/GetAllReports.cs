using System;
using Reports.Business.Services;
using Reports.Data.Entities;

namespace Reports.Client.Options.ReportOption
{
    public class GetAllReports : IOption
    {
        public void StartOption()
        {
            Report[] reports = ReportService.GetAll();

            Console.WriteLine("All reports:");
            foreach (Report report in reports)
            {
                Report.ConsoleOutput(report);
            }
        }
    }
}