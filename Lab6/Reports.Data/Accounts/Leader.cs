using System;
using Reports.Data.Entities;
using Reports.Data.Models;

namespace Reports.Data.Accounts
{
    [Serializable]
    public class Leader : Account
    {
        public Leader(string name, string login, string password, string email, string phone)
            : base(name, login, password,email,phone, AccountType.Leader)
        {
        }
    }
}