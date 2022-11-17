using Shops.Entities;
using Shops.Registers;

namespace Shops.Service
{
    public class ShopManager
    {
        private ProductRegister _productRegister;
        private List<Shop> _shopsList;

        public ShopManager()
        {
            _productRegister = new ProductRegister();
            _shopsList = new List<Shop>();
        }

        public Shop Create(string shopName, float profit)
        {
            var shop = new Shop(shopName, _productRegister, profit);
            _shopsList.Add(shop);
            return shop;
        }

        public Product RegisterProduct(string productName)
        {
            var product = new Product(productName);
            _productRegister.AddProduct(product);
            return product;
        }

        public Shop? FindCheapestShop(ShoppingList shoppingList)
        {
            float minSum = 0f;
            Shop? currentShop = null;
            foreach (Shop shop in _shopsList)
            {
                if (shop.WareHouse.IsExistsProducts(shoppingList) && shop.WareHouse.IsEnoughProducts(shoppingList))
                {
                    Bill bill = shop.GetBill(shoppingList);
                    if (bill < minSum || minSum == 0)
                    {
                        minSum = bill;
                        currentShop = shop;
                    }
                }
            }

            return currentShop;
        }
    }
}
