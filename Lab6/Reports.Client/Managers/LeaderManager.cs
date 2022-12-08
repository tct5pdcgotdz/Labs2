using System;
using Reports.Client.Options;
using Reports.Client.Options.LeaderOption;

namespace Reports.Client.Managers;

public class LeaderManager : IManager
{
    public void StartManager()
    {
        Console.WriteLine("---Leader Manager---");
        Console.WriteLine("1. Create Leader");
        Console.WriteLine("2. Get Leader");
        Console.WriteLine("3. Reports Manager");
        Console.WriteLine("4. Return to start menu");
        int choice = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();

        IOption option = null;
        switch (choice)
        {
            case 1:
                option = new CreateLeader();
                break;
            case 2:
                option = new GetLeader();
                break;
            case 3:
                new ReportManager().StartManager();
                return;
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