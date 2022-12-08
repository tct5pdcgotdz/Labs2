using System;
using Reports.Data.Accounts;
using Reports.Data.Models;

namespace Reports.Data.Entities;

public class Message
{
    private int _id = 0;
    public Message(string text, Account fromAcc, Account toAcc, DateTime dateTime)
    {
        Id = ++_id;
        Text = text;
        State = MessageState.New;
        FromAccount = fromAcc;
        ToAccount = toAcc;
        Date = dateTime;
    }
    public int Id { get;}
    public string Text { get;}
    public MessageState State { get; }
    public Account FromAccount { get; }
    public Account ToAccount { get; }
    public DateTime Date { get; }
        
    public static void ConsoleOutput(Message message)
    {
        Console.WriteLine($"Id: {message.Id}");
        Console.WriteLine($"Text: {message.Text}");
        Console.WriteLine($"From Account: {message.FromAccount.Name}");
        Console.WriteLine($"To Account: {message.ToAccount.Name}");
        Console.WriteLine($"Date: {message.Date}");
        Console.WriteLine();
    }
}