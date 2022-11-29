namespace Banks.Tools;

public class ReachDoubtClientTransactionsException : Exception
{
    public ReachDoubtClientTransactionsException()
        : base("Reach Limit Transaction for Doubt Client")
    {
    }
}