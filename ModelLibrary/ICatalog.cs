namespace ModelLibrary;

public interface ICatalog
{
    string Name { get; set; }

    List<Product> GetProducts(string device, DateTime dateTime);

    void AddProduct(Product product);
}