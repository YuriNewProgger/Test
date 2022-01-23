namespace Client;

public class Product
{
    public string Title { get; set; }
    public decimal Price { get; set; }

    public Product(string title, decimal price)
    {
        Title = title;
        Price = price;
    }

    public override string ToString()
    {
        return $"{Title} {Price}";
    }
}