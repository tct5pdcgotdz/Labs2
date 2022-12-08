using System;
using Reports.Business.Services;
using Reports.Data.Accounts;

namespace Reports.Client.Options.AdminOption;

public class CreateAdmin : IOption
{
    public void StartOption()
    {
        Console.WriteLine("Enter name:");
        string name = Console.ReadLine() ?? "";
        Console.WriteLine("Enter login:");
        string login = Console.ReadLine() ?? "";
        Console.WriteLine("Enter password");
        string password = Console.ReadLine() ?? "";
 
        //Admin admin = AdminService.Create(name ,login, password);

        Console.WriteLine("[!] Successful");
    }
}