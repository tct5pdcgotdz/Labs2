namespace Banks.Entities;

public class CentralBank
{
    private List<Bank> _bankList;

    public CentralBank()
    {
        _bankList = new List<Bank>();
    }

    public Bank CreateBank()
    {
        return new Bank();
    }
}