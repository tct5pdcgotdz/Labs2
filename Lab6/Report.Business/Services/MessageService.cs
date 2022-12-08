using Reports.Data.Accounts;
using Reports.Data.Entities;
using Reports.Data.Storage;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reports.Business.Services
{
    public class MessageService
    {
        public Message Create(Account fromAccount, Account toAccount, string text)
        {
            var message = new Message(text, fromAccount, toAccount, DateTime.Now);

            List<Message> messages = GetAll();
            messages.Add(message);
            JsonStorage.Save(messages);

            return message;
        }
        public static List<Message> GetAll()
        {
            var messages = JsonStorage.GetMessages();
            return messages is null ? new List<Message>() : messages.ToList();
        }
    }
}
