namespace Shops.Entities
{
    public class DeliveryList
    {
        public DeliveryList()
        {
            Products = new List<ProductInfo>();
        }

        public List<ProductInfo> Products { get; }
        public void Add(Product product, int price, int count)
        {
            Products.Add(new ProductInfo(product, price, count));
        }

        public Bill GetBill()
        {
            var bill = new Bill();

            foreach (ProductInfo product in Products)
            {
                bill.AddSum(product.Price * product.Count);
            }

            return bill;
        }
    }
}
