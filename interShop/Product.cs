namespace interShop;

public class Product
{
    public string Title { get; set; }
    public int Price { get; set; }

    public Product(string title, int price)
    {
        Title = title;
        Price = price;
    }

    public override string ToString()
    {
        return $"{Title} {Price}";
    }
}