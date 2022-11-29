namespace Banks.Tools;

public class AccountNotRegisteredInBankException : Exception
{
    public AccountNotRegisteredInBankException()
        : base("The Account Is Not Registered With This Bank")
    {
    }
}