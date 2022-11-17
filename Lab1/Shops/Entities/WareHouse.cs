using Shops.Tools;

namespace Shops.Entities
{
    public class WareHouse
    {
        private List<ProductInfo> _productInfos;

        public WareHouse()
        {
            _productInfos = new List<ProductInfo>();
        }

        public ProductInfo GetProductInfo(Product product)
        {
            ProductInfo? info = FindProduct(product);
            if (info is null)
            {
                throw new NotExistProductException();
            }

            return info;
        }

        public void Sell(ShoppingList listProducts)
        {
            if (!IsExistsProducts(listProducts))
            {
                throw new NotExistProductException();
            }

            if (!IsEnoughProducts(listProducts))
            {
                throw new ExpiredProductException();
            }

            foreach (Product product in listProducts.GetProducts())
            {
                ProductInfo? productInfo = FindProduct(product);
                productInfo?.Buy(listProducts.GetCountProduct(product));
            }
        }

        public void Fill(DeliveryList listProducts, float profitRation)
        {
            foreach (ProductInfo deliveryProduct in listProducts.Products)
            {
                ProductInfo? productInfo = FindProduct(deliveryProduct.Product);
                if (productInfo is null)
                {
                    var product = new ProductInfo(deliveryProduct.Product, deliveryProduct.Price * profitRation, deliveryProduct.Count);
                    _productInfos.Add(product);
                }
                else
                {
                    productInfo.Add(deliveryProduct.Count);
                }
            }
        }

        public ProductInfo? FindProduct(Product product)
        {
            ProductInfo? productInfo = null;
            foreach (ProductInfo info in _productInfos)
            {
                if (info.Product.Equals(product))
                {
                    productInfo = info;
                    break;
                }
            }

            return productInfo;
        }

        public bool IsExistsProducts(ShoppingList listProducts)
        {
            foreach (Product product in listProducts.GetProducts())
            {
                ProductInfo? info = FindProduct(product);
                if (info is null)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsEnoughProducts(ShoppingList listProducts)
        {
            foreach (Product product in listProducts.GetProducts())
            {
                ProductInfo info = GetProductInfo(product);
                if (info.Count < listProducts.GetCountProduct(product))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
