using Shops.Tools;

namespace Shops.Entities
{
    public class ProductInfo
    {
        public ProductInfo(Product product, float price, int count)
        {
            Product = product;
            Count = count;
            Price = price;
        }

        public Product Product { get; private set; }
        public int Count { get; private set; }

        public float Price { get; private set; }

        public void Buy(int count)
        {
            if (Count < count)
            {
                throw new ExpiredProductException();
            }

            Count -= count;
        }

        public void Add(int count)
        {
            Count += count;
        }

        public void ChangePrice(float newPrice)
        {
            Price = newPrice;
        }
    }
}
