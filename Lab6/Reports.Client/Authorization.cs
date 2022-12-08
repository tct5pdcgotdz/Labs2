using Reports.Client.Managers;
using Reports.Data.Accounts;
using Reports.Data.Entities;
using Reports.Data.Models;

namespace Reports.Client;

public static class Authorization
{
    public static void StartAuthorization(Account account)
    {
        IManager manager = account.AccountType switch
        {
            AccountType.Employee => new EmployeeManager(),
            AccountType.Leader => new LeaderManager(),
            AccountType.Admin => new AdminManager(),
            _ => null
        };
        manager.StartManager();
    }
}