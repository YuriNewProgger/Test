namespace ModelLibrary;

public class Catalog
{
    private object _key = new object();
    private List<Product> _products { get; } = new List<Product>()
    {
        new Product("Sega Mega Drive", 2000),
        new Product("Sony", 5000),
        new Product("Dandy", 1200)
    };

    public Catalog()
    {
    }

    public List<Product> GetProduct(string device, DateTime date)
    {
        if (device.Contains("Android"))
            return Discount();
        else if (device.Contains("iPhone"))
            return Margin();
        else
            return _products.Select(i => new Product(i.Title, i.Price)).ToList();
    }

    public void AddProduct(Product newProduct)
    {
        lock (_key)
        {
            _products.Add(newProduct);
        }
    }

    private List<Product> Discount() => 
        _products.Select(i => new Product(i.Title, i.Price -= (i.Price / 100) * 10)).ToList();
    
    private List<Product> Margin() =>
        _products.Select(i => new Product(i.Title, i.Price += (i.Price / 100) * 50)).ToList();
    

    private void IncrementPriceByWeekDay(List<Product> listProducts, DateTime date)
    {
        if (date.DayOfWeek == DayOfWeek.Friday)
            foreach (var product in listProducts)
                product.Price += product.Price / 2;
        else
            foreach (var product in listProducts)
                product.Price -= product.Price / 2;
    }
}