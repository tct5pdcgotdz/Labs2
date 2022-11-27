using Banks.Temp;

namespace Banks.Accounts;

public class CreditAccount : BaseAccount
{
    public override bool IsPossibleWithdraw(decimal money)
    {
        throw new NotImplementedException();
    }

    public override bool IsPossibleReplenishment(decimal money)
    {
        throw new NotImplementedException();
    }
}