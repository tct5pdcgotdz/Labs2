using Banks.Conditions;
using Banks.Entities;
using Banks.Models;
using Banks.Temp;
using Banks.Tools;

namespace Banks.Accounts;

public class CreditAccount : BaseAccount
{
    private CreditConditions _creditConditions;
    public CreditAccount(Client client, DoubtClientConditions debtClientConditions, CreditConditions creditConditions)
        : base("Credit Account", client, debtClientConditions)
    {
        _creditConditions = creditConditions;
    }

    public decimal SumPercent { get; private set; }

    public override void CheckPossibleWithdraw(decimal money)
    {
        if (Money <= -_creditConditions.CreditLimit)
        {
            throw new ReachCreditLimitException();
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

            SumPercent += (decimal)(_creditConditions.CreditPercent * (double)Money);
            k += 1;
        }
    }
}