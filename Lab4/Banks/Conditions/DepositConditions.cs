namespace Banks.Entities;

public class DepositConditions
{
    private Dictionary<decimal, float> _deposAccountPercnet;

    public DepositConditions(decimal minAmount, float percent)
    {
        _deposAccountPercnet = new Dictionary<decimal, float>();
        _deposAccountPercnet.Add(minAmount, percent);
    }

    public delegate void AccountHandler(string message);
    public event AccountHandler? Notify;

    public IReadOnlyDictionary<decimal, float> DeposAccountPercnet => _deposAccountPercnet;

    public void AddDepositConditional(decimal minAmount, float percent)
    {
        _deposAccountPercnet.Add(minAmount, percent);
        Notify?.Invoke("Deposit Conditions Has Changed");
    }

    public void RemoveDepositConditional(decimal minAmount, float percent)
    {
        _deposAccountPercnet.Remove(minAmount);
        Notify?.Invoke("Deposit Conditions Has Changed");
    }
}