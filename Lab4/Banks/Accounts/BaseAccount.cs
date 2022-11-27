namespace Banks.Temp;

public abstract class BaseAccount
{
    private static int _id;
    public BaseAccount()
    {
        Money = 0;
        _id++;

        History = new History();
    }

    public decimal Money { get; private set; }

    public History History { get; }

    public void Withdrawal(decimal money, BaseAccount toAccount)
    {
        if (!IsPossibleWithdraw(money))
        {
            Money -= money;
            History.AddTransaction(new Transaction(this, toAccount, money));
        }
    }

    public void Replenishment(decimal money, BaseAccount fromAccount)
    {
        if (!IsPossibleReplenishment(money))
        {
            Money += money;
            History.AddTransaction(new Transaction(fromAccount, this, money));
        }
    }

    public abstract bool IsPossibleWithdraw(decimal money);
    public abstract bool IsPossibleReplenishment(decimal money);
}