namespace ModelLibrary.CatalogsWarehouse;

public class TelevisionCatalog : ICatalog
{
    private object _key = new object();
    private List<Product> _products { get; } = new List<Product>()
    {
        new Product("HUAWEI", 25000),
        new Product("Sony", 43000),
        new Product("Samsung", 120000)
    };
    
    public string Name { get; set; } = "Television";
    
    public List<Product> GetProducts(string device, DateTime dateTime)
    {
        if (device.Contains("Android"))
            return Discount();
        else if (device.Contains("iPhone"))
            return Margin();
        else
            return _products.Select(i => new Product(i.Title, i.Price)).ToList();
    }

    public void AddProduct(Product product)
    {
        lock (_key)
        {
            _products.Add(product);
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