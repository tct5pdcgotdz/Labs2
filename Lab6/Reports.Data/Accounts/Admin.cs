using System;
using Reports.Data.Models;

namespace Reports.Data.Accounts
{
    [Serializable]
    public class Admin : Account
    {
        public Admin(string name, string login, string password, string email, string phone)
            : base(name, login, password, email,phone, AccountType.Admin)
        {
        }
    }
}