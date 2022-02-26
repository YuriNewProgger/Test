namespace ModelLibrary.Backet;

public class ShopingBasket
{
    private List<Product> SelectedProducts = new List<Product>();

    public ShopingBasket()
    {
    }

    public void AddProductToBasket(Product product) => SelectedProducts.Add(product);

    public List<Product> GetBasket() => SelectedProducts;

}