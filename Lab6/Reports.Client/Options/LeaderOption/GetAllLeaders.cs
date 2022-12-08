using System;
using System.Collections.Generic;
using Reports.Business.Services;
using Reports.Data.Accounts;
using Reports.Data.Models;

namespace Reports.Client.Options.LeaderOption;

public class GetAllLeaders : IOption
{
    public void StartOption()
    {
        List<Leader> leaders = LeaderService.GetAll();

        Console.WriteLine("All leaders:");
        foreach (Leader leader in leaders)
        {
            Account.ConsoleOutput(leader);
        }
    }
}