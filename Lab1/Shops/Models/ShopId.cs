namespace Shops.Models
{
    public class ShopId
    {
        private static int _id = 0;

        public static int GenerateNewId()
        {
            return _id++;
        }
    }
}
