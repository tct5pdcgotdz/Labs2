namespace Shops.Tools
{
    public class ExpiredProductException : Exception
    {
        public ExpiredProductException()
            : base("Attempt to buy expired products")
        {
        }
    }
}
