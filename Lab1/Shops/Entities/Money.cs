using Shops.Tools;

namespace Shops.Entities
{
    public class Money
    {
        public Money(float count)
        {
            MoneyCount = count;
        }

        public float MoneyCount { get; private set; }

        public static implicit operator float(Money money)
        {
            return money.MoneyCount;
        }

        public static float operator +(Money a, Money b)
        {
            return a.MoneyCount + b.MoneyCount;
        }

        public static float operator -(Money a, Money b)
        {
            return a.MoneyCount - b.MoneyCount;
        }

        public void Withdraw(Bill bill)
        {
            if (MoneyCount < bill)
            {
                throw new NotEnoughMoneyException();
            }

            MoneyCount -= bill;
        }

        public void Addition(Bill bill)
        {
            MoneyCount += bill;
        }
    }
}
