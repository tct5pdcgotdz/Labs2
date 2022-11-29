using Banks.Entities;

namespace Banks.Temp;

public class Transaction
{
    public Transaction(BaseAccount? fromAccount, BaseAccount? toAccount, decimal amount, Bank? fromBank = null, Bank? toBank = null)
    {
        FromAccount = fromAccount;
        ToAccount = toAccount;
        Amount = amount;
        FromBank = fromBank;
        ToBank = toBank;
    }

    public BaseAccount? FromAccount { get; }
    public BaseAccount? ToAccount { get; }
    public Bank? FromBank { get; }
    public Bank? ToBank { get; }
    public decimal Amount { get; }
}