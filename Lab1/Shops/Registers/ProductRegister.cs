using Shops.Entities;
using Shops.Tools;

namespace Shops.Registers
{
    public class ProductRegister
    {
        public ProductRegister()
        {
            Products = new List<Product>();
        }

        public List<Product> Products { get; }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public bool IsRegisteredProducts(DeliveryList deliveryList)
        {
            foreach (ProductInfo product in deliveryList.Products)
            {
                if (!Products.Contains(product.Product))
                {
                    throw new UnregisteredProductException();
                }
            }

            return true;
        }
    }
}
