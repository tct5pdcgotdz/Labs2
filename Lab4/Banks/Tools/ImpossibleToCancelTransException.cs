namespace Banks.Tools;

public class ImpossibleToCancelTransException : Exception
{
    public ImpossibleToCancelTransException()
        : base("Impossible To Cancel Transaction Exception")
    {
    }
}