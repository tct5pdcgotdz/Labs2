using Banks.Conditions;
using Banks.Entities;
using Banks.Models;
using Banks.Temp;
using Banks.Tools;

namespace Banks.Accounts;

public class DebitAccount : BaseAccount
{
    public DebitAccount(Client client, DoubtClientConditions debtClientConditions, DebitConditions debitConditions)
        : base("Debit Account", client, debtClientConditions)
    {
        DebitConditions = debitConditions;
    }

    public decimal SumPercent { get; private set; }
    public DebitConditions DebitConditions { get; }

    public override void CheckPossibleWithdraw(decimal money)
    {
        if (Money < money)
        {
            throw new NotEnoughMoneyException();
        }

        if (Client.ClientType == ClientType.Doubt &&
            History.GetSumTransactions() + money >= DoubtClientConditions.TransfersLimit)
        {
            throw new ReachDoubtClientTransactionsException();
        }
    }

    public override void ChangeBalanceAfterTime()
    {
        int k = 0;
        while (k != (Time.GetTimeNow() - DateCreated).Days && Money < 0)
        {
            if (k % 30 == 0)
            {
                Money -= SumPercent;
                SumPercent = 0;
            }

            SumPercent += (decimal)(DebitConditions.DebitPercent * (double)Money);
            k += 1;
        }
    }
}