using Banks.Condiitons;
using Banks.Entities;
using Banks.Temp;

namespace Banks.Accounts;

public class DepositAccountFabric : AccountFactory
{
    public override BaseAccount CreateAccount(Client client, BankCondition bankCondition)
    {
        return new DepozitAccount(client, bankCondition.DoubtClientConditions, bankCondition.DepositConditions);
    }
}