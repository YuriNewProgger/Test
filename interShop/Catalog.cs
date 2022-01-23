namespace interShop;

public class Catalog
{
    private object _key = new object();
    private List<Product> _products { get; } = new List<Product>()
    {
        new Product("Sega Mega Drive", 2000),
        new Product("Sony", 5000),
        new Product("Dandy", 1200)
    };
    private string _device { get; set; }

    public Catalog()
    {
    }

    public List<Product> GetProduct(string device, DateTime date)
    {
        List<Product> tmpProducts = _products.Select(i => new Product(i.Title, i.Price)).ToList();
        _device = device;
        
        if (device.Contains("Android"))
            foreach (var item in _products)
            {
                item.Price -= (item.Price / 100) * 10;
            }
        else if (device.Contains("iPhone"))
            foreach (var item in _products)
            {
                item.Price += (item.Price / 100) * 50;
            }
        
        IncrementPriceByWeekDay(tmpProducts, date);

        return tmpProducts;
    }

    public List<Product> AddProduct(Product newProduct)
    {
        lock (_key)
        {
            _products.Add(newProduct);
        }
        
        return GetProduct(_device, DateTime.Today);
    }

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