namespace Banks.Conditions;

public class DoubtClientConditions
{
    private decimal _transfersLimit;
    public DoubtClientConditions(decimal transferLimit)
    {
        TransfersLimit = transferLimit;
    }

    public delegate void AccountHandler(string message);
    public event AccountHandler? Notify;

    public decimal TransfersLimit
    {
        get => _transfersLimit;
        set
        {
            _transfersLimit = value;
            Notify?.Invoke("Debit Percent has Changed");
        }
    }
}