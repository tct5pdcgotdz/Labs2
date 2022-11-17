namespace Shops.Entities
{
    public class ShoppingList
    {
        private Dictionary<Product, int> _products;
        public ShoppingList()
        {
            _products = new Dictionary<Product, int>();
        }

        public void Add(Product product, int count)
        {
            _products.Add(product, count);
        }

        public List<Product> GetProducts()
        {
            return _products.Keys.ToList();
        }

        public int GetCountProduct(Product product)
        {
            return _products[product];
        }
    }
}
