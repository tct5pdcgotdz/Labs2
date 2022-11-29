using Banks.Conditions;
using Banks.Entities;
using Banks.Models;
using Banks.Temp;
using Banks.Tools;

namespace Banks.Accounts;

public class DepozitAccount : BaseAccount
{
    public const int DEPOZITTIMEMONTHS = 12;

    public DepozitAccount(Client client, DoubtClientConditions debtClientConditions, DepositConditions depositConditions)
        : base("Deposit Account", client, debtClientConditions)
    {
        DateFinished = DateCreated.AddMonths(DEPOZITTIMEMONTHS);
        DepositConditions = depositConditions;
    }

    public DepositConditions DepositConditions { get; }
    public DateTime DateFinished { get; }
    public decimal SumPercent { get; private set; }

    public override void CheckPossibleWithdraw(decimal money)
    {
        if (Time.GetTimeNow() < DateFinished)
        {
            throw new ImpossibleWithdrawDepozitException();
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
        while (k <= (Time.GetTimeNow() - DateCreated).Days)
        {
            if (k % 30 == 0)
            {
                Money += SumPercent;
                SumPercent = 0;
            }

            SumPercent += (decimal)Math.Round(DeterminePercent(Money) * (double)Money, 2);
            k += 1;
        }
    }

    public float DeterminePercent(decimal money)
    {
        float res = 0f;
        foreach (KeyValuePair<decimal, float> pair in DepositConditions.DeposAccountPercnet)
        {
            if (pair.Key >= money && pair.Value > res)
            {
                res = pair.Value;
            }
        }

        return res / 100;
    }
}