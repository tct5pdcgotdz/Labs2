using System;
using Reports.Data.Models;

namespace Reports.Data.Accounts;

public abstract class Account
{
    private static int _id = 0;

    public Account(string name, string login, string password, string email, string pho, AccountType accountType)
    {
        Name = name;
        Login = login;
        Password = password;
        AccountType = accountType;

        Id = ++_id;
    }
    
    public int Id { get; }
    public string Name{ get; }
    public string Login{ get; }
    public string Password{ get; }
    public AccountType AccountType{ get; }

    public static void ConsoleOutput(Account account)
    {
        Console.WriteLine($"ID: {account.Id}");
        Console.WriteLine($"Name: {account.Name}");
        Console.WriteLine($"Login: {account.Login}");
        Console.WriteLine($"Password: {account.Password}");
        Console.WriteLine();
    }
}