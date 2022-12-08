#nullable enable
using System;
using Reports.Client.Options.AdminOption;

namespace Reports.Client.Managers
{

    public class AdminManager : IManager
    {
        public void StartManager()
        {
            Console.WriteLine("---Admin Manager---");
            Console.WriteLine("1. Employee manager");
            Console.WriteLine("2. Message manager");
            Console.WriteLine("3. Report manager");
            Console.WriteLine("4. Create new admin");
            Console.WriteLine("5. Leader manager");
            Console.WriteLine("6. Exit Menu");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            IManager? manager = null;
            switch (choice)
            {
                case 1:
                    manager = new EmployeeManager();
                    break;
                case 2:
                    //manager = new TaskManager();
                    break;
                case 3:
                    manager = new ReportManager();
                    break;
                case 4:
                    new CreateAdmin().StartOption();
                    StartManager();
                    return;
                case 5:
                    manager = new LeaderManager();
                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("Wrong command");
                    StartManager();
                    return;
            }

            manager.StartManager();
            StartManager();
        }
    }
}