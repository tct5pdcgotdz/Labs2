using Banks.Condiitons;
using Banks.Conditions;
using Banks.Entities;
using Banks.Temp;

namespace Banks;

public class Program
{
    public static Bank EnterNewBank(CentralBank centralBank)
    {
        Console.WriteLine("-----------------------------------BANK CREATE-----------------------------------");
        Console.WriteLine("Enter bank name:");
        string? bankName = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(bankName))
        {
            throw new ArgumentException("Wrong Bank Name");
        }

        CreditConditions creditConditions = EnterCreditConditions();
        DebitConditions debitConditions = EnterDebitConditions();
        DepositConditions depositConditions = EnterDepositConditions();
        DoubtClientConditions doubtClientConditions = EnterDoubtClientConditions();

        var bankConditions = new BankCondition(depositConditions, debitConditions, creditConditions, doubtClientConditions);

        Console.WriteLine();
        return centralBank.CreateBank(bankName, bankConditions);
    }

    public static CreditConditions EnterCreditConditions()
    {
        Console.WriteLine("-CREDIT CONDITIONS-");
        Console.WriteLine("Enter Credit Limit:");
        decimal creditLimit = Convert.ToDecimal(Console.ReadLine());
        if (creditLimit <= 0)
        {
            throw new ArgumentException("Wrong Credit Limit");
        }

        Console.WriteLine("Enter Credit Percent:");
        float creditPercent = float.Parse(Console.ReadLine() ?? string.Empty);
        if (creditLimit <= 0)
        {
            throw new ArgumentException("Wrong Credit Percent");
        }

        Console.WriteLine();
        return new CreditConditions(creditLimit, creditPercent);
    }

    public static DebitConditions EnterDebitConditions()
    {
        Console.WriteLine("-DEBIT CONDITIONS-");
        Console.WriteLine("Enter Debit Percent:");
        float debitPercent = float.Parse(Console.ReadLine() ?? string.Empty);
        if (debitPercent <= 0)
        {
            throw new ArgumentException("Wrong Credit Limit");
        }

        Console.WriteLine();
        return new DebitConditions(debitPercent);
    }

    public static DepositConditions EnterDepositConditions()
    {
        Console.WriteLine("-DEPOSIT CONDITIONS-");
        Console.WriteLine("Enter MinAmount: ");
        decimal minAmount = Convert.ToDecimal(Console.ReadLine());
        if (minAmount <= 0)
        {
            throw new ArgumentException("Wrong Min Amount");
        }

        Console.WriteLine("Enter Percent:");
        float percent = float.Parse(Console.ReadLine() ?? string.Empty);
        if (percent <= 0)
        {
            throw new ArgumentException("Wrong Percent");
        }

        Console.WriteLine();
        return new DepositConditions(minAmount, percent);
    }

    public static DoubtClientConditions EnterDoubtClientConditions()
    {
        Console.WriteLine("-DOUBT CLIENT CONDITIONS-");
        Console.WriteLine("Enter TransferLimit: ");
        decimal transferLimit = Convert.ToDecimal(Console.ReadLine());
        if (transferLimit <= 0)
        {
            throw new ArgumentException("Wrong Transfer Limit");
        }

        Console.WriteLine();
        return new DoubtClientConditions(transferLimit);
    }

    public static Client EnterClient(Bank bank)
    {
        Console.WriteLine("-----------------------------------CLIENT SETTINGS-----------------------------------");
        Console.WriteLine("Enter First Name:");
        string? firstName = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new ArgumentException("Wrong Client First Name");
        }

        Console.WriteLine("Enter Last Name:");
        string? lastName = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(lastName))
        {
            throw new ArgumentException("Wrong Client Last Name");
        }

        Console.WriteLine();
        return bank.CreateClient(firstName, lastName);
    }

    public static void Menu(CentralBank centralBank)
    {
        Console.WriteLine("-----------------------------------MENU-----------------------------------");
        var currentKeyCodes = new List<int>();
        currentKeyCodes.Add(1);
        currentKeyCodes.Add(2);
        currentKeyCodes.Add(3);
        currentKeyCodes.Add(4);

        Console.WriteLine("Choose Bank {1}");
        Console.WriteLine("Choose Client {2}");
        Console.WriteLine("Choose Account {3}");
        Console.WriteLine("Central Bank Menu {4}");

        Console.WriteLine("Enter menu keycode:");
        int keyCode = int.Parse(Console.ReadLine() ?? string.Empty);
        if (!currentKeyCodes.Contains(keyCode))
        {
            throw new ArgumentException("Wrong Key Code");
        }

        Bank bank;
        Client client;
        switch (keyCode)
        {
            case 1:
                bank = ChooseBank(centralBank);
                Console.WriteLine();
                BankMenu(bank);
                Console.WriteLine();
                break;
            case 2:
                bank = ChooseBank(centralBank);
                Console.WriteLine();
                client = ChooseClient(bank);
                Console.WriteLine();
                ClientMenu(client);
                Console.WriteLine();
                break;
            case 3:
                bank = ChooseBank(centralBank);
                Console.WriteLine();
                client = ChooseClient(bank);
                Console.WriteLine();
                BaseAccount account = ChooseAccount(client);
                AccountMenu(account);
                Console.WriteLine();
                break;
            case 4:
                CentralBankMenu(centralBank);
                break;
        }

        Console.WriteLine();
    }

    public static void CentralBankMenu(CentralBank centralBank)
    {
        Console.WriteLine("-----------------------------------CENTRAL BANK MENU-----------------------------------");

        var currentKeyCodes = new List<int>();
        currentKeyCodes.Add(1);
        currentKeyCodes.Add(2);
        currentKeyCodes.Add(3);

        Console.WriteLine("Add New Bank {1}");
        Console.WriteLine("Set TimeMachine {2}");
        Console.WriteLine("Trnafer Money With Banks {3}");

        Console.WriteLine("Enter menu keycode:");
        int keyCode = int.Parse(Console.ReadLine() ?? string.Empty);
        if (!currentKeyCodes.Contains(keyCode))
        {
            throw new ArgumentException("Wrong Key Code");
        }

        switch (keyCode)
        {
            case 1:
                EnterNewBank(centralBank);
                Console.WriteLine("[!] Successful Adding New Bank");
                break;
            case 2:
                Console.WriteLine("Enter days to skip: ");
                int days = int.Parse(Console.ReadLine() ?? string.Empty);
                centralBank.SetTimeMachine(days);
                Console.WriteLine("[!] Successful Skipping days");
                break;
            case 3:
                Console.WriteLine("Choose From: ");
                Bank fromBank = ChooseBank(centralBank);
                Client fromClient = ChooseClient(fromBank);
                BaseAccount fromBaseAcc = ChooseAccount(fromClient);

                Console.WriteLine("Choose To: ");
                Bank toBank = ChooseBank(centralBank);
                Client toClient = ChooseClient(toBank);
                BaseAccount toBaseAcc = ChooseAccount(toClient);

                Console.WriteLine("Enter sum: ");
                int sum = int.Parse(Console.ReadLine() ?? string.Empty);

                centralBank.SBP(fromBank, fromBaseAcc, toBank, toBaseAcc, sum);
                break;
        }

        Console.WriteLine();
    }

    public static void BankMenu(Bank bank)
    {
        Console.WriteLine("-----------------------------------BANK MENU-----------------------------------");

        var currentKeyCodes = new List<int>();
        currentKeyCodes.Add(1);
        currentKeyCodes.Add(2);
        currentKeyCodes.Add(3);
        currentKeyCodes.Add(4);
        currentKeyCodes.Add(5);
        currentKeyCodes.Add(6);
        currentKeyCodes.Add(7);

        Console.WriteLine("Add Deposit Account {1}");
        Console.WriteLine("Add Credit Account {2}");
        Console.WriteLine("Add Debit Account {3}");
        Console.WriteLine("Transfer Money In bank {4}");
        Console.WriteLine("Create Client {5}");
        Console.WriteLine("Edit Conditions {6}");
        Console.WriteLine("Subscribe To Conditions {7}");

        Console.WriteLine("Enter menu keycode:");
        int keyCode = int.Parse(Console.ReadLine() ?? string.Empty);
        if (!currentKeyCodes.Contains(keyCode))
        {
            throw new ArgumentException("Wrong Key Code");
        }

        Client client;
        switch (keyCode)
        {
            case 1:
                client = ChooseClient(bank);
                bank.AddDepozitAccount(client);
                Console.WriteLine("[!] Successful Adding Deposit Account");
                break;
            case 2:
                client = ChooseClient(bank);
                bank.AddCreditAccount(client);
                Console.WriteLine("[!] Successful Adding Credit Account");
                break;
            case 3:
                client = ChooseClient(bank);
                bank.AddDebitAccount(client);
                Console.WriteLine("[!] Successful Adding Debit Account");
                break;
            case 4:
                client = ChooseClient(bank);
                BaseAccount fromAccount = ChooseAccount(client);
                Client client2 = ChooseClient(bank);
                BaseAccount toAccount = ChooseAccount(client2);
                Console.WriteLine("Enter sum:");
                int sum = int.Parse(Console.ReadLine() ?? string.Empty);
                bank.TransferMoneyInBank(fromAccount, toAccount, sum);
                Console.WriteLine("[!] Successful Transfer Money");
                break;
            case 5:
                EnterClient(bank);
                break;
            case 6:
                CreditConditions creditConditions = EnterCreditConditions();
                DebitConditions debitConditions = EnterDebitConditions();
                DepositConditions depositConditions = EnterDepositConditions();
                DoubtClientConditions doubtClientConditions = EnterDoubtClientConditions();

                var bankConditions = new BankCondition(depositConditions, debitConditions, creditConditions, doubtClientConditions);
                bank.BankCondition = bankConditions;
                Console.WriteLine("[!] Successful Changed Conditions");
                break;
            case 7:
                client = ChooseClient(bank);
                bank.SubscribeToConditionsChanges(client);
                Console.WriteLine("[!] Successful Subscribed");
                break;
        }

        Console.WriteLine();
    }

    public static void ClientMenu(Client client)
    {
        Console.WriteLine("-----------------------------------CLIENT MENU-----------------------------------");

        var currentKeyCodes = new List<int>();
        currentKeyCodes.Add(1);

        Console.WriteLine("View Accounts Status {1}");

        Console.WriteLine("Enter menu keycode:");
        int keyCode = int.Parse(Console.ReadLine() ?? string.Empty);
        if (!currentKeyCodes.Contains(keyCode))
        {
            throw new ArgumentException("Wrong Key Code");
        }

        switch (keyCode)
        {
            case 1:
                Console.WriteLine("-ACCOUNTS LIST-");
                foreach (string str in client.GetAccountsStatus())
                {
                    Console.WriteLine(str);
                }

                break;
        }

        Console.WriteLine();
    }

    public static void AccountMenu(BaseAccount account)
    {
        Console.WriteLine("-----------------------------------ACOUNT MENU-----------------------------------");

        var currentKeyCodes = new List<int>();
        currentKeyCodes.Add(1);
        currentKeyCodes.Add(2);

        Console.WriteLine("Withdrawal {1}");
        Console.WriteLine("Replenishment {2}");

        Console.WriteLine("Enter menu keycode:");
        int keyCode = int.Parse(Console.ReadLine() ?? string.Empty);
        if (!currentKeyCodes.Contains(keyCode))
        {
            throw new ArgumentException("Wrong Key Code");
        }

        int sum;
        switch (keyCode)
        {
            case 1:
                Console.WriteLine("Enter sum:");
                sum = int.Parse(Console.ReadLine() ?? string.Empty);
                account.Withdrawal(sum);
                break;
            case 2:
                Console.WriteLine("Enter sum:");
                sum = int.Parse(Console.ReadLine() ?? string.Empty);
                account.Replenishment(sum);
                break;
        }

        Console.WriteLine();
    }

    public static BaseAccount ChooseAccount(Client client)
    {
        Console.WriteLine("-Account LIST-");
        int k = 1;
        foreach (BaseAccount account in client.AccountsList)
        {
            Console.WriteLine($"id -{account.ID} {account.Name} {account.Money}");
            k++;
        }

        Console.WriteLine("Enter Account Id:");
        int id = int.Parse(Console.ReadLine() ?? string.Empty);

        BaseAccount? res = client.GetAccountById(id);

        if (id <= 0 || res is null)
        {
            throw new ArgumentException("Wrong Id");
        }

        Console.WriteLine();
        return res;
    }

    public static Client ChooseClient(Bank bank)
    {
        Console.WriteLine("-Client LIST-");
        int k = 1;
        foreach (Client client in bank.Clients)
        {
            Console.WriteLine($"id = {client.Id} - {client.FirstName} {client.LastName}");
            k++;
        }

        Console.WriteLine("Enter Client Id:");
        int id = int.Parse(Console.ReadLine() ?? string.Empty);

        Client? res = bank.GetClientById(id);

        if (id <= 0 || res is null)
        {
            throw new ArgumentException("Wrong Id");
        }

        Console.WriteLine();
        return res;
    }

    public static Bank ChooseBank(CentralBank centralBank)
    {
        Console.WriteLine("-BANK LIST-");
        int k = 1;
        foreach (Bank bank in centralBank.Banks)
        {
            Console.WriteLine($"{k}. {bank.Name}");
            k++;
        }

        Console.WriteLine("Enter name:");
        string? name = Console.ReadLine();

        Bank? res = centralBank.GetBankByName(name);

        if (string.IsNullOrWhiteSpace(name) || res is null)
        {
            throw new ArgumentException("Wrong Bank Name");
        }

        Console.WriteLine();
        return res;
    }

    public static void Main()
    {
        var centralBank = new CentralBank();
        Bank bank = EnterNewBank(centralBank);
        EnterClient(bank);
        string? exit = "YES";
        while (exit != "NO" && !string.IsNullOrWhiteSpace(exit))
        {
            Menu(centralBank);
            Console.WriteLine("Do you want to continue?{YES}/{NO}:");
            exit = Console.ReadLine();
        }
    }
}