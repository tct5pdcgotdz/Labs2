using Banks.Temp;
using Shops.Entities;

namespace Banks.Entities;

public class Bank
{
    private List<BaseAccount> _accountList;
    private List<Client> _clientList;
    public Bank()
    {
        _accountList = new List<BaseAccount>();
        _clientList = new List<Client>();
    }
}