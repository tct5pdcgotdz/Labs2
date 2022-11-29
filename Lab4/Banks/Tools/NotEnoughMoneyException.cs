namespace Banks.Tools;

public class NotEnoughMoneyException : Exception
{
    public NotEnoughMoneyException()
        : base("Not Enough Money")
    {
    }
}