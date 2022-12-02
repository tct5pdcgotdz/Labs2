using Banks.Models;
using Banks.Temp;
using Shops.Entities;

namespace Banks.Entities;

public class Client : IClient
{
    private static int id = 0;
    private List<string> _news;
    public Client(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
        {
            throw new AggregateException("Invalid name");
        }

        AccountsList = new List<BaseAccount>();
        _news = new List<string>();

        FirstName = firstName;
        LastName = lastName;

        ClientType = ClientType.Doubt;
        id++;
    }

    public int Id => id;
    public ClientType ClientType { get; private set; }
    public string FirstName { get; }
    public string LastName { get; }
    public string? Address { get; set; }
    public Passport? Passport { get; set; }
    public IReadOnlyCollection<string> Messages => _news;

    public List<BaseAccount> AccountsList { get; }

    public void AddAccount(BaseAccount account)
    {
        AccountsList.Add(account);
    }

    public List<string> GetAccountsStatus()
    {
        var list = new List<string>();
        foreach (var account in AccountsList)
        {
            list.Add($"{account} {account.Money}");
        }

        return list;
    }

    public BaseAccount? GetAccountById(int id)
    {
        return AccountsList.Find(account => account.ID.Equals(id));
    }

    public void AddNews(string news)
    {
        _news.Add(news);
    }

    public void SetAddress(string address)
    {
        Address = address;
    }

    public void SetPassport(int series, int number)
    {
        Passport = new Passport(series, number);
    }

    private void CheckValideClient()
    {
        if (string.IsNullOrEmpty(Address) || Passport is null)
        {
            return;
        }

        ClientType = ClientType.Valide;
    }
}