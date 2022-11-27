namespace Banks.Temp;

public class History
{
    private List<Transaction> _listTransaction;

    public History()
    {
        _listTransaction = new List<Transaction>();
    }

    public void AddTransaction(Transaction transaction)
    {
        _listTransaction.Add(transaction);
    }

    public void RemoveTransaction(Transaction transaction)
    {
        _listTransaction.Remove(transaction);
    }
}