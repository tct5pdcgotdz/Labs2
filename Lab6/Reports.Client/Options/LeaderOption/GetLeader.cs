#nullable enable
using System;

namespace Reports.Client.Options.LeaderOption;

public class GetLeader : IOption
{
    public void StartOption()
    {
        Console.WriteLine("---Get Leader---");
        Console.WriteLine("1. Get leader by name");
        Console.WriteLine("2. Get leader by id");
        Console.WriteLine("3. Get all leaders");
        int choice = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();

        IOption? option = null;
        switch (choice)
        {
            case 1:
                option = new GetLeaderByName();
                break;
            case 2:
                option = new GetLeaderById();
                break;
            case 3:
                option = new GetAllLeaders();
                break;
            default:
                Console.WriteLine("Wrong option!");
                return;
        }
        option.StartOption();
    }
}