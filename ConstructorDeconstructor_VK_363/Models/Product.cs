namespace ConstructorDeconstructor_VK_363.Models;

public class Product
{
    public const int defaultQuantity = 0;
    public string Name { get; }
    public double Price { get; }
    public int Quantity { get; }

    public Product(string name, double price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public void Deconstruct(out string name, out double price, out int quantity)
    {
        name = Name;
        price = Price;
        quantity = Quantity;
    }
}