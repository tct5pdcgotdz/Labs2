using System;
using Reports.Business.Services;
using Reports.Data.Entities;

namespace Reports.Client.Options.ReportOption
{
    public class DeleteReport : IOption
    {
        public void StartOption()
        {
            Console.WriteLine("Enter report id:");
            int id = Convert.ToInt32(Console.ReadLine());


            Report report = ReportService.Delete(id);

            Console.WriteLine("[!] Successful");
        }
    }
}