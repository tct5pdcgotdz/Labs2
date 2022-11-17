using Shops.Entities;
using Shops.Service;
using Shops.Tools;
using Xunit;

namespace Shops.Test
{
    public class ShopManagerTest
    {
        [Fact]
        public void AddRegisteredProductToShop_ShopContainsProduct()
        {
            // Arrange
            var shopManager = new ShopManager();
            var deliveryList = new DeliveryList();

            // Act
            Shop shop = shopManager.Create("Magnit", 1.2f);
            Product product = shopManager.RegisterProduct("Bread");

            deliveryList.Add(product, 90, 5);

            shop.AddProducts(deliveryList);

            // Asserts
            Assert.Equal(product, shop.WareHouse.GetProductInfo(product).Product);
        }

        [Fact]
        public void AddUnregisteredProductToShop_UnregisteredProductException()
        {
            // Arrange
            var shopManager = new ShopManager();
            var deliveryList = new DeliveryList();

            // Act
            Shop shop = shopManager.Create("Magnit", 1.2f);

            deliveryList.Add(new Product("bread"), 90, 5);

            // Assert
            Assert.Throws<UnregisteredProductException>(() =>
            {
                shop.AddProducts(deliveryList);
            });
        }

        [Fact]
        public void CreatePersonBuyProduct_DecreasedProductCountDecreasedPersonMoneyIncreasedShopMoney()
        {
            // Arrange
            var shopManager = new ShopManager();
            var person = new Person("Ivan", 2500.0f);
            var deliveryList = new DeliveryList();
            var shoppingList = new ShoppingList();

            // Act
            Shop shop = shopManager.Create("Magnit", 1.2f);
            Product product = shopManager.RegisterProduct("Bread");

            deliveryList.Add(product, 90, 5);
            shoppingList.Add(product, 2);

            shop.AddProducts(deliveryList);

            float shopMoneyBeforeChanges = shop.ShopMoney;
            float personMoneyBeforeChanges = person.Money;

            shop.SellProducts(person, shoppingList);

            // Assert
            Assert.Equal(person.Money + shop.ShopMoney, personMoneyBeforeChanges + shopMoneyBeforeChanges);
        }

        [Fact]
        public void CreatePersonBuyTooMuchProduct_()
        {
            // Arrange
            var shopManager = new ShopManager();
            var person = new Person("Ivan", 156.0f);
            var deliveryList = new DeliveryList();
            var shoppingList = new ShoppingList();

            // Act
            Shop shop = shopManager.Create("Magnit", 1.2f);
            Product product = shopManager.RegisterProduct("Bread");

            deliveryList.Add(product, 90, 5);
            shoppingList.Add(product, 7);

            shop.AddProducts(deliveryList);

            // Assert
            Assert.Throws<ExpiredProductException>(() =>
            {
                shop.SellProducts(person, shoppingList);
            });
        }

        [Fact]
        public void ChangeProductPrice_ProductHasNewPrice()
        {
            // Arrange
            var shopManager = new ShopManager();
            var deliveryList = new DeliveryList();

            // Act
            Shop shop = shopManager.Create("Magnit", 1.2f);
            Product product = shopManager.RegisterProduct("Bread");
            deliveryList.Add(product, 90, 5);
            shop.AddProducts(deliveryList);

            int newPrice = 780;
            shop.ChangeProductPrice(product, newPrice);

            // Assert
            Assert.Equal(newPrice, shop.WareHouse.GetProductInfo(product).Price);
        }

        [Fact]
        public void TwoShopHasProductFindTheChipiest_ShopWithChipiestPrice()
        {
            // Arrange
            var shopManager = new ShopManager();
            var deliveryListInMagnit = new DeliveryList();
            var deliveryListInPyat = new DeliveryList();
            var shopList = new ShoppingList();

            // Act
            Product product = shopManager.RegisterProduct("Bread");

            Shop magnit = shopManager.Create("Magnit", 1.2f);
            Shop pyat = shopManager.Create("Pyaterochka", 1.2f);

            deliveryListInMagnit.Add(product, 90, 8);
            deliveryListInPyat.Add(product, 4, 5);

            magnit.AddProducts(deliveryListInMagnit);
            pyat.AddProducts(deliveryListInPyat);

            shopList.Add(product, 4);

            Shop? shop = shopManager.FindCheapestShop(shopList);

            // Assert
            Assert.Equal(shop, pyat);
        }
    }
}
