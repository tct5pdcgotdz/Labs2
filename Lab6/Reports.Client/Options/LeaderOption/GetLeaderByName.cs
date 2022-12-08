using System;
using Reports.Business.Services;
using Reports.Data.Accounts;

namespace Reports.Client.Options.LeaderOption;


public class GetLeaderByName : IOption
{
    public void StartOption()
    {
        Console.WriteLine("Enter leader name:");
        string name = Console.ReadLine();
        
        Leader leader = LeaderService.FindByName(name);

        Account.ConsoleOutput(leader);
    }
}