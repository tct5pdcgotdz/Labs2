#nullable enable
using System;
using Reports.Client.Options;
using Reports.Client.Options.ReportOption;

namespace Reports.Client.Managers
{
    public class ReportManager : IManager
    {
        public void StartManager()
        {
            Console.WriteLine("---Report Manager---");
            Console.WriteLine("1. Create new report");
            Console.WriteLine("2. Get report");
            Console.WriteLine("3. Delete report");
            Console.WriteLine("4. Return to start menu");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            IOption? option = null;
            switch (choice)
            {
                case 1:
                    option = new CreateReport();
                    break;
                case 2:
                    option = new GetReport();
                    break;
                case 3:
                    option = new DeleteReport();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Wrong command");
                    StartManager();
                    return;
            }
            
            option.StartOption();
            StartManager();
        }
    }
}