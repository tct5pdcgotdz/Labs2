namespace Banks.Entities;

public class DebitConditions
{
    private float _debitPercent;
    public DebitConditions(float debitPercent)
    {
        _debitPercent = debitPercent;
    }

    public delegate void AccountHandler(string message);
    public event AccountHandler? Notify;

    public float DebitPercent
    {
        get => _debitPercent;
        set
        {
            _debitPercent = value;
            Notify?.Invoke("Debit Percent has Changed");
        }
    }
}