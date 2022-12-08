using System;
using Reports.Business.Services;
using Reports.Data.Accounts;

namespace Reports.Client.Options.LeaderOption;

public class DeleteLeader : IOption
{
    public void StartOption()
    {
        Console.WriteLine("Enter leader id:");
        int id = Convert.ToInt32(Console.ReadLine());
        
        Leader leader =  LeaderService.Delete(id);

        Console.WriteLine("[!] Successful");
    }
}