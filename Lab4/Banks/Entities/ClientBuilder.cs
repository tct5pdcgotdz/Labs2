namespace Banks.Entities;

public class ClientBuilder : IClient
{
    private Client _client;

    public ClientBuilder(string firstName, string lastName)
    {
        _client = new Client(firstName, lastName);
    }

    public Client GetClient()
    {
        return _client;
    }

    public void SetAddress(string address)
    {
        _client.Address = address;
    }

    public void SetPassport(int series, int number)
    {
        _client.Passport = new Passport(series, number);
    }
}