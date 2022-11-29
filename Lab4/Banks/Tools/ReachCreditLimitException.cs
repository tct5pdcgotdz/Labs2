namespace Banks.Tools;

public class ReachCreditLimitException : Exception
{
    public ReachCreditLimitException()
        : base("Reach The Credit Limit")
    {
    }
}