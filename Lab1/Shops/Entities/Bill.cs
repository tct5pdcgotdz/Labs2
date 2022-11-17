namespace Shops.Entities
{
    public class Bill
    {
        public Bill()
        {
        }

        public float Sum { get; private set; }

        public static implicit operator float(Bill bill)
        {
            return bill.Sum;
        }

        public static float operator +(Bill a, Bill b)
        {
            return a.Sum + b.Sum;
        }

        public static float operator -(Bill a, Bill b)
        {
            return a.Sum - b.Sum;
        }

        public void AddSum(float sum)
        {
            Sum += sum;
        }

        public void WithdrawSum(float sum)
        {
            Sum -= sum;
        }
    }
}
