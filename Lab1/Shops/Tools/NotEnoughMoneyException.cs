namespace Shops.Tools
{
    public class NotEnoughMoneyException : Exception
    {
        public NotEnoughMoneyException()
            : base("Not enough money on the card")
        {
        }
    }
}
