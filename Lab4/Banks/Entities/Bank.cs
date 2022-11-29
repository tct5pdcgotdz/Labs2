using Banks.Accounts;
using Banks.Condiitons;
using Banks.Temp;
using Banks.Tools;

namespace Banks.Entities;

public class Bank
{
    private List<BaseAccount> _accountList;
    private List<Client> _clientList;
    public Bank(string name, BankCondition bankCondition)
    {
        _accountList = new List<BaseAccount>();
        _clientList = new List<Client>();

        Name = name;
        BankCondition = bankCondition;
    }

    public string Name { get; }
    public IReadOnlyCollection<BaseAccount> AccountList => _accountList;
    public IReadOnlyCollection<Client> Clients => _clientList;
    public BankCondition BankCondition { get; set; }

    public Client CreateClient(string firstName, string lastName)
    {
        var client = new Client(firstName, lastName);
        _clientList.Add(client);
        return client;
    }

    public CreditAccount AddCreditAccount(Client client)
    {
        var creditAcc = new CreditAccount(client, BankCondition.DoubtClientConditions, BankCondition.CreditConditions);
        client.AddAccount(creditAcc);
        _accountList.Add(creditAcc);
        return creditAcc;
    }

    public DebitAccount AddDebitAccount(Client client)
    {
        var debitAccount = new DebitAccount(client, BankCondition.DoubtClientConditions, BankCondition.DebitConditions);
        client.AddAccount(debitAccount);
        _accountList.Add(debitAccount);
        return debitAccount;
    }

    public DepozitAccount AddDepozitAccount(Client client)
    {
        var depozitAccount = new DepozitAccount(client, BankCondition.DoubtClientConditions, BankCondition.DepositConditions);
        client.AddAccount(depozitAccount);
        _accountList.Add(depozitAccount);
        return depozitAccount;
    }

    public Transaction TransferMoneyInBank(BaseAccount fromAccount, BaseAccount toAccount, decimal money)
    {
        if (!_accountList.Contains(fromAccount) || !_accountList.Contains(toAccount))
        {
            throw new AccountNotRegisteredInBankException();
        }

        Transaction transaction = fromAccount.Withdrawal(fromAccount, toAccount, money, this, this);
        toAccount.Replenishment(fromAccount, toAccount, money, this, this);
        return transaction;
    }

    public void CancelTransaction(Transaction transaction)
    {
        if (transaction.FromAccount is null || transaction.ToAccount is null)
        {
            throw new ImpossibleToCancelTransException();
        }

        transaction.FromAccount.Replenishment(transaction.Amount);
        transaction.ToAccount.Withdrawal(transaction.Amount);
    }

    public Client? GetClientById(int id)
    {
        return _clientList.Find(client => client.Id.Equals(id));
    }

    public void SubscribeToConditionsChanges(Client client)
    {
        BankCondition.SubscribeToChanges(client);
    }
}