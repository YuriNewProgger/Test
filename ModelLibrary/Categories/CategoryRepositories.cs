namespace ModelLibrary.Categories;

public class CategoryRepositories : IRepositiry
{
    public CategoryRepositories()
    {
        Categories  = new List<ICategory>()
        {
            consoleGame, television
        };
    }
    
    private ICategory consoleGame = new Category(1, "Console Game",
        new List<Product>()
        {
            new Product("Sega Mega Drive", 2000),
            new Product("Sony", 5000),
            new Product("Dandy", 1200)
        });
    
    private ICategory television = new Category(2, "Television",
        new List<Product>()
        {
            new Product("HUAWEI", 25000),
            new Product("Sony", 43000),
            new Product("Samsung", 120000)
        });
    public List<ICategory> Categories { get; }

    public ICategory GetCategory(string Name) => Categories.Where(i => i.Name == Name).FirstOrDefault();
    
    public List<ICategory> GetAllCategories() => Categories;
    
    public void AddCategory(ICategory category) => Categories.Add(category);
}