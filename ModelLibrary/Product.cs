namespace ModelLibrary;

public class Product
{
    public string Title { get; set; }
    public decimal Price { get; set; }
    public string Description = "Somthing description ...";

    public Product(string title, decimal price)
    {
        Title = title;
        Price = price;
    }
    
    public Product(){}

    public override string ToString()
    {
        return $"Title:{Title} Price:{Price} {Description}";
    }
}