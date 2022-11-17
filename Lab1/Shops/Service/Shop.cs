using Shops.Entities;
using Shops.Models;
using Shops.Registers;

namespace Shops.Service
{
    public class Shop
    {
        private const float STARTSHOPMONEY = 1000000f;

        private string _name;
        private int _id;
        private ProductRegister _productRegister;
        private float _profitRatio;

        public Shop(string name, ProductRegister productRegister, float profit)
        {
            WareHouse = new WareHouse();
            ShopMoney = new Money(STARTSHOPMONEY);

            _name = name;
            _productRegister = productRegister;
            _profitRatio = profit;

            _id = ShopId.GenerateNewId();
        }

        public Money ShopMoney { get; }
        public WareHouse WareHouse { get; }

        public Bill AddProducts(DeliveryList deliveryList)
        {
            _productRegister.IsRegisteredProducts(deliveryList);

            WareHouse.Fill(deliveryList, _profitRatio);

            Bill bill = deliveryList.GetBill();
            ShopMoney.Withdraw(bill);

            return bill;
        }

        public Bill SellProducts(Person person, ShoppingList listProducts)
        {
            Bill bill = GetBill(listProducts);

            WareHouse.Sell(listProducts);
            person.Buy(bill);
            ShopMoney.Addition(bill);

            return bill;
        }

        public void ChangeProductPrice(Product product, int newPrice)
        {
            ProductInfo productInfo = WareHouse.GetProductInfo(product);
            productInfo.ChangePrice(newPrice);
        }

        public Bill GetBill(ShoppingList listProducts)
        {
            var bill = new Bill();
            foreach (Product product in listProducts.GetProducts())
            {
                ProductInfo info = WareHouse.GetProductInfo(product);
                bill.AddSum(info.Price * listProducts.GetCountProduct(product));
            }

            return bill;
        }
    }
}
