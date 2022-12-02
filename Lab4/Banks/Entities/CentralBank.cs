using Banks.Condiitons;
using Banks.Temp;
using Banks.Tools;

namespace Banks.Entities;

public class CentralBank
{
    private static CentralBank? _centralBank;

    private readonly List<Bank> _bankList;

    private CentralBank()
    {
        _bankList = new List<Bank>();
    }

    public IReadOnlyCollection<Bank> Banks => _bankList;

    public static CentralBank GetInstance()
    {
        return _centralBank ??= new CentralBank();
    }

    public Bank CreateBank(string name, BankCondition bankCondition)
    {
        var bank = new Bank(name, bankCondition);
        _bankList.Add(bank);
        return bank;
    }

    public void SetTimeMachine(int days)
    {
        Time.AddDays(days);
        foreach (Bank bank in _bankList)
        {
            foreach (BaseAccount bankAccount in bank.AccountList)
            {
                bankAccount.ChangeBalanceAfterTime();
            }
        }
    }

    public void SBP(Bank fromBank, BaseAccount fromAccount, Bank toBank, BaseAccount toAccount, decimal amount)
    {
        if (!fromBank.AccountList.Contains(fromAccount) || !toBank.AccountList.Contains(toAccount))
        {
            throw new AccountNotRegisteredInBankException();
        }

        fromAccount.Withdrawal(fromAccount, toAccount, amount, fromBank, toBank);
        toAccount.Replenishment(fromAccount, toAccount, amount, fromBank, toBank);
    }

    public Bank? GetBankByName(string? name)
    {
        return _bankList.Find(bank => bank.Name.Equals(name));
    }
}