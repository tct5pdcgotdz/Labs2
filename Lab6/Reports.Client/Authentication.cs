#nullable enable
using System;
using Reports.Business.Services;
using Reports.Client.Options.AdminOption;
using Reports.Data.Accounts;
using Reports.Data.Entities;

namespace Reports.Client;

public static class Authentication
{
    public static Account? StartAuthentication()
    {
        Console.WriteLine("Login: ");
        string login = Console.ReadLine() ?? "";
        Console.WriteLine("Password: ");
        string password = Console.ReadLine() ?? "";
        
        
        Employee? employee = EmployeeService.FindByLoginPassword(login, password);
        if (employee is not null)
            return employee;
        
        Leader? leader = LeaderService.FindByLoginPassword(login, password);
        if (leader is not null)
            return leader;
        
        Admin? admin = AdminService.FindByLoginPassword(login, password);
        if (admin is not null)
            return admin;

        return null;
    }
}