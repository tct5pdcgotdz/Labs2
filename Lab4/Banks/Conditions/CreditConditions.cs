namespace Banks.Conditions;

public class CreditConditions
{
    private decimal _creditLimit;
    private float _creditPercent;
    public CreditConditions(decimal creditLimit, float creditPercent)
    {
        _creditLimit = creditLimit;
        _creditPercent = creditPercent;
    }

    public delegate void AccountHandler(string message);
    public event AccountHandler? Notify;

    public decimal CreditLimit
    {
        get => _creditLimit;
        set
        {
            _creditLimit = value;
            Notify?.Invoke("Credit Limit has Changed");
        }
    }

    public float CreditPercent
    {
        get => _creditPercent;
        set
        {
            _creditPercent = value;
            Notify?.Invoke("Credit Percent has Changed");
        }
    }
}