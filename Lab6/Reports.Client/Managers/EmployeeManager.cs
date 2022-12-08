using System;
using Reports.Client.Options;
using Reports.Client.Options.EmployeeOption;

namespace Reports.Client.Managers
{
    public class EmployeeManager : IManager
    {
        public void StartManager()
        {
            Console.WriteLine("---Employee Manager---");
            Console.WriteLine("1. Create new employee");
            Console.WriteLine("2. Get employee");
            Console.WriteLine("3. Change leader");
            Console.WriteLine("4. Delete employee");
            Console.WriteLine("5. Return to start menu");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            IOption? option = null;
            switch (choice)
            {
                case 1:
                    option = new CreateEmployee();
                    break;
                case 2:
                    option = new GetEmployee();
                    break;
                case 3:
                    option = new ChangeEmployeeLead();
                    break;
                case 4:
                    option = new DeleteEmployee();
                    break;
                case 5:
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