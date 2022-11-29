using Banks.Condiitons;
using Banks.Conditions;
using Banks.Entities;
using Banks.Temp;
using Banks.Tools;
using Xunit;

namespace Banks.Test;

public class BanksTests
{
    [Fact]
    public void CreatDebtAccWithdrawTooMuch_NotEnoughMoneyException()
    {
        var centralBank = new CentralBank();

        var creditConditions = new CreditConditions(10000, 3);
        var debitConditions = new DebitConditions(8.3f);
        var depositConditions = new DepositConditions(50000, 3);
        var doubtClientConditions = new DoubtClientConditions(5000);

        var bankCond = new BankCondition(depositConditions, debitConditions, creditConditions, doubtClientConditions);

        Bank bank = centralBank.CreateBank("Tinpoff", bankCond);

        Client client = bank.CreateClient("Arthur", "Dzuba");

        BaseAccount baseAccount = bank.AddDebitAccount(client);
        baseAccount.Replenishment(10000);

        Assert.Throws<NotEnoughMoneyException>(() =>
        {
            baseAccount.Withdrawal(10001);
        });
    }

    [Fact]
    public void CreatDebtAccTransferTooMuch_NotEnoughMoneyException()
    {
        var centralBank = new CentralBank();

        var creditConditions = new CreditConditions(10000, 3);
        var debitConditions = new DebitConditions(8.3f);
        var depositConditions = new DepositConditions(50000, 3);
        var doubtClientConditions = new DoubtClientConditions(5000);

        var bankCond = new BankCondition(depositConditions, debitConditions, creditConditions, doubtClientConditions);

        Bank bank = centralBank.CreateBank("Tinpoff", bankCond);

        Client client = bank.CreateClient("Arthur", "Dzuba");
        Client client2 = bank.CreateClient("Igor", "Yurkov");

        BaseAccount baseAccount = bank.AddDebitAccount(client);
        baseAccount.Replenishment(10000);

        BaseAccount baseAccount2 = bank.AddDebitAccount(client2);

        Assert.Throws<NotEnoughMoneyException>(() =>
        {
            bank.TransferMoneyInBank(baseAccount, baseAccount2, 10001);
        });
    }

    [Fact]
    public void CreatDepAccTransfer_ImpossibleWithdrawDepozitException()
    {
        var centralBank = new CentralBank();

        var creditConditions = new CreditConditions(10000, 3);
        var debitConditions = new DebitConditions(8.3f);
        var depositConditions = new DepositConditions(50000, 3);
        var doubtClientConditions = new DoubtClientConditions(5000);

        var bankCond = new BankCondition(depositConditions, debitConditions, creditConditions, doubtClientConditions);

        Bank bank = centralBank.CreateBank("Tinpoff", bankCond);

        Client client = bank.CreateClient("Arthur", "Dzuba");

        BaseAccount baseAccount = bank.AddDepozitAccount(client);

        Assert.Throws<ImpossibleWithdrawDepozitException>(() =>
        {
            baseAccount.Withdrawal(10000);
        });
    }

    [Fact]
    public void CreateDepozAccTimeMachineMonth_AccMoneyRaise()
    {
        var centralBank = new CentralBank();

        var creditConditions = new CreditConditions(10000, 3);
        var debitConditions = new DebitConditions(8.3f);
        var depositConditions = new DepositConditions(50000, 3);
        var doubtClientConditions = new DoubtClientConditions(5000);

        var bankCond = new BankCondition(depositConditions, debitConditions, creditConditions, doubtClientConditions);

        Bank bank = centralBank.CreateBank("Tinpoff", bankCond);

        Client client = bank.CreateClient("Arthur", "Dzuba");

        BaseAccount baseAccount = bank.AddDepozitAccount(client);
        baseAccount.Replenishment(100);

        centralBank.SetTimeMachine(31);

        Assert.Equal(190m, baseAccount.Money);
    }

    [Fact]
    public void CreateDebitAccCancelTrans_TransactionCanceledMoneyBack()
    {
        var centralBank = new CentralBank();

        var creditConditions = new CreditConditions(10000, 3);
        var debitConditions = new DebitConditions(8.3f);
        var depositConditions = new DepositConditions(50000, 3);
        var doubtClientConditions = new DoubtClientConditions(5000);

        var bankCond = new BankCondition(depositConditions, debitConditions, creditConditions, doubtClientConditions);

        Bank bank = centralBank.CreateBank("Tinpoff", bankCond);

        Client client = bank.CreateClient("Arthur", "Dzuba");

        BaseAccount baseAccount = bank.AddDebitAccount(client);
        baseAccount.Replenishment(100);
        BaseAccount baseAccount2 = bank.AddDebitAccount(client);

        Transaction transaction = bank.TransferMoneyInBank(baseAccount, baseAccount2, 50);

        Assert.Equal(50, baseAccount.Money);
        Assert.Equal(50, baseAccount2.Money);

        bank.CancelTransaction(transaction);

        Assert.Equal(100, baseAccount.Money);
        Assert.Equal(0, baseAccount2.Money);
    }

    [Fact]
    public void SubscribeClinetToChangesChangeSth_ClientHasMessage()
    {
        var centralBank = new CentralBank();

        var creditConditions = new CreditConditions(10000, 3);
        var debitConditions = new DebitConditions(8.3f);
        var depositConditions = new DepositConditions(50000, 3);
        var doubtClientConditions = new DoubtClientConditions(5000);

        var bankCond = new BankCondition(depositConditions, debitConditions, creditConditions, doubtClientConditions);

        Bank bank = centralBank.CreateBank("Tinpoff", bankCond);

        Client client = bank.CreateClient("Arthur", "Dzuba");

        bank.SubscribeToConditionsChanges(client);

        debitConditions.DebitPercent += 1;

        Assert.Equal(1, client.Messages.Count);
    }
}