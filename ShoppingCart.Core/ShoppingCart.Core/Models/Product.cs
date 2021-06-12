namespace ShoppingCart.Core
{
    public class Product
    {
        public Product(string productName, double productPrice)
        {
            Name = productName;
            Price = productPrice;
        }

        public double Price { get; set; }

        public string Name { get; set; }
    }
}