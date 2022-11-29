namespace Banks.Tools;

public class ImpossibleWithdrawDepozitException : Exception
{
    public ImpossibleWithdrawDepozitException()
        : base("It is impossible to withdraw before the end of the deposit period")
    {
    }
}