using System;
using Reports.Business.Services;
using Reports.Data.Accounts;

namespace Reports.Client.Options.LeaderOption;

public class GetLeaderById : IOption
{
    public void StartOption()
    {
        Console.WriteLine("Enter leader Id:");
        int id = Convert.ToInt32(Console.ReadLine());

        Leader leader = LeaderService.FindById(id);

        Account.ConsoleOutput(leader);
    }
}