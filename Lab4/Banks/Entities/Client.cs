namespace Banks.Entities;

public class Client
{
    public Client(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName { get; }
    public string LastName { get; }
    public string? Address { get; private set; }
    public Passport? Passport { get; private set; }

    public void SetAddress(string address)
    {
        Address = address;
    }

    public void SetPassport(int series, int number)
    {
        Passport = new Passport(series, number);
    }
}