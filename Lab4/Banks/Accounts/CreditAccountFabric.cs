using Banks.Condiitons;
using Banks.Entities;
using Banks.Temp;

namespace Banks.Accounts;

public class CreditAccountFactory : AccountFactory
{
    public override BaseAccount CreateAccount(Client client, BankCondition bankCondition)
    {
        return new CreditAccount(client, bankCondition.DoubtClientConditions, bankCondition.CreditConditions);
    }
}