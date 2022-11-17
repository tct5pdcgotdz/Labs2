namespace Shops.Tools
{
    public class NotExistProductException : Exception
    {
        public NotExistProductException()
            : base("Attempt to access a non-existent product")
        {
        }
    }
}
