#nullable enable
using System;

namespace Reports.Client.Options.ReportOption
{
    public class GetReport : IOption
    {
        public void StartOption()
        {
            Console.WriteLine("---Get Report---");
            Console.WriteLine("1. Get report by id");
            Console.WriteLine("2. Get all reports");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            IOption? option = null;
            switch (choice)
            {
                case 1:
                    option = new GetReportById();
                    break;
                case 2:
                    option = new GetAllReports();
                    break;
                default:
                    Console.WriteLine("Wrong command");
                    return;
            }
            option.StartOption();
        }
    }
}