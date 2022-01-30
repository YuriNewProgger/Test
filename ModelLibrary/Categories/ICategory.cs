namespace ModelLibrary.Categories;

public interface ICategory
{
    int Id { get; set; }
    string Name { get; set; }

    List<Product> GetProducts(string device, DateTime dateTime);

    void AddProduct(Product product);
}