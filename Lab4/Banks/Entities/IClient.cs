namespace Banks.Entities;

public interface IClient
{
    public void SetAddress(string address);

    public void SetPassport(int series, int number);
}