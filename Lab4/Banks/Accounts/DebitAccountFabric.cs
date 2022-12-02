using Banks.Condiitons;
using Banks.Entities;
using Banks.Temp;

namespace Banks.Accounts;

public class DebitAccountFactory : AccountFactory
{
    public override BaseAccount CreateAccount(Client client, BankCondition bankCondition)
    {
        return new DebitAccount(client, bankCondition.DoubtClientConditions, bankCondition.DebitConditions);
    }
}