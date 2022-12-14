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

    public ClientBuilder CreateClient(string firstName, string lastName)
    {
        var clientBuilder = new ClientBuilder(firstName, lastName);
        _clientList.Add(clientBuilder.GetClient());
        return clientBuilder;
    }

    public BaseAccount AddAccount(Client client, AccountFactory accountFabric)
    {
        var acc = accountFabric.CreateAccount(client, BankCondition);
        _accountList.Add(acc);
        return acc;
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