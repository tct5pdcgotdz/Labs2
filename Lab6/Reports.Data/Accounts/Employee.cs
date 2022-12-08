using System;
using Reports.Data.Entities;
using Reports.Data.Models;

namespace Reports.Data.Accounts
{
    [Serializable]
    public class Employee : Account
    {
        public Employee(string name, string login, string password,string email, string phone, Leader leader)
            : base(name,login, password,email,phone, AccountType.Employee)
        {
            Leader = leader;
        }
        
        public Leader Leader { get; set; }
    }
}