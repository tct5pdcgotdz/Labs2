using Banks.Condiitons;
using Banks.Entities;
using Banks.Temp;

namespace Banks.Accounts;

public abstract class AccountFactory
{
    public abstract BaseAccount CreateAccount(Client client, BankCondition bankCondition);
}