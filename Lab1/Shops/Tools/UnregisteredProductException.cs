namespace Shops.Tools
{
    public class UnregisteredProductException : Exception
    {
        public UnregisteredProductException()
            : base("Unregistered Product Exception")
        {
        }
    }
}
