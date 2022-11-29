using Banks.Conditions;
using Banks.Entities;

namespace Banks.Condiitons;

public class BankCondition
{
    public BankCondition(DepositConditions depositConditions, DebitConditions debitConditions, CreditConditions creditConditions, DoubtClientConditions doubtClientConditions)
    {
        DepositConditions = depositConditions;
        DebitConditions = debitConditions;
        CreditConditions = creditConditions;
        DoubtClientConditions = doubtClientConditions;
    }

    public DepositConditions DepositConditions { get; }
    public DebitConditions DebitConditions { get; }
    public CreditConditions CreditConditions { get; }
    public DoubtClientConditions DoubtClientConditions { get; }

    public void SubscribeToChanges(Client client)
    {
        DepositConditions.Notify += client.AddNews;
        DebitConditions.Notify += client.AddNews;
        CreditConditions.Notify += client.AddNews;
        DoubtClientConditions.Notify += client.AddNews;
    }
}