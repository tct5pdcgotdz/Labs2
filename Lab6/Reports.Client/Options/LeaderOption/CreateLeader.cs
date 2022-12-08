using System;
using Reports.Business.Services;
using Reports.Data.Accounts;

namespace Reports.Client.Options.LeaderOption;

public class CreateLeader : IOption
{
    public void StartOption()
    {
        Console.WriteLine("Enter name:");
        string name = Console.ReadLine() ?? "";
        Console.WriteLine("Enter login");
        string login = Console.ReadLine() ?? "";
        Console.WriteLine("Enter password");
        string password = Console.ReadLine() ?? "";
 
        //Leader leader = LeaderService.Create(name, login, password);

        Console.WriteLine("[!] Successful");
    }
}