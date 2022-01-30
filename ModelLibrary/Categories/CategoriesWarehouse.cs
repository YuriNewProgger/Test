namespace ModelLibrary.Categories;

public static class CategoriesWarehouse
{
    private static ICategory consoleGame = new Category(1, "Console Game",
        new List<Product>()
        {
            new Product("Sega Mega Drive", 2000),
            new Product("Sony", 5000),
            new Product("Dandy", 1200)
        });
    
    private static ICategory television = new Category(2, "Television",
        new List<Product>()
        {
            new Product("HUAWEI", 25000),
            new Product("Sony", 43000),
            new Product("Samsung", 120000)
        });
    public static List<ICategory> Categories { get; } = new List<ICategory>()
    {
        consoleGame, television
    };

    public static ICategory GetCategory(string Name) => Categories.Where(i => i.Name == Name).FirstOrDefault();
    
    public static List<ICategory> GetAllCategories() => Categories;
    
    public static void AddCategory(ICategory category) => Categories.Add(category);
}