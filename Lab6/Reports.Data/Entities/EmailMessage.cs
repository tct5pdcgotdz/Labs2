using System;
using Reports.Data.Accounts;

namespace Reports.Data.Entities;

public class EmailMessage : Message
{
    public EmailMessage(string text, Account fromAcc, Account toAcc, DateTime dateTime) : base(text, fromAcc, toAcc, dateTime)
    {
    }
}