#nullable enable
using System;
using Reports.Data.Accounts;
using Reports.Data.Entities;

namespace Reports.Client;

public static class Enter
{
    public static void StartEnter()
    {
        
        
        Account? account = Authentication.StartAuthentication();
        if (account is null)
        {
            Console.WriteLine("Invalid login or password");
            StartEnter();
        }
        
        Authorization.StartAuthorization(account);
        StartEnter();
    }
}