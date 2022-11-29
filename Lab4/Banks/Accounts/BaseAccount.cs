using Banks.Conditions;
using Banks.Entities;

namespace Banks.Temp;

public abstract class BaseAccount
{
    private static int _id = 0;
    public BaseAccount(string name, Client client, DoubtClientConditions debtClientConditions)
    {
        Client = client;
        DoubtClientConditions = debtClientConditions;
        Name = name;
        Money = 0;

        History = new History();
        DateCreated = Time.GetTimeNow();
        _id++;
    }

    public decimal Money { get; protected set; }

    public History History { get; }

    public DateTime DateCreated { get; protected set;  }

    public Client Client { get; }

    public string Name { get; }

    public int ID => _id;

    public DoubtClientConditions DoubtClientConditions { get; }

    public Transaction Replenishment(BaseAccount fromAccount, BaseAccount toAccount, decimal amount, Bank fromBank, Bank toBank)
    {
        Money += amount;
        var transiton = new Transaction(fromAccount, toAccount, amount, fromBank, toBank);
        History.AddTransaction(transiton);
        return transiton;
    }

    public void Replenishment(decimal money)
    {
        Money += money;
        var transiton = new Transaction(null, this, money);
        History.AddTransaction(transiton);
    }

    public Transaction Withdrawal(BaseAccount fromAccount, BaseAccount toAccount, decimal amount, Bank fromBank, Bank toBank)
    {
        CheckPossibleWithdraw(amount);

        Money -= amount;
        var transiton = new Transaction(fromAccount, toAccount, amount, fromBank, toBank);
        History.AddTransaction(transiton);
        return transiton;
    }

    public Transaction Withdrawal(decimal money)
    {
        CheckPossibleWithdraw(money);

        Money -= money;
        var transiton = new Transaction(this, null, money);
        History.AddTransaction(transiton);
        return transiton;
    }

    public abstract void CheckPossibleWithdraw(decimal money);
    public abstract void ChangeBalanceAfterTime();
}