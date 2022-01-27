namespace ModelLibrary.CatalogsWarehouse;

public static class CatalogsWarehouse
{
    private static ICatalog consoleGame = new GameConsoleCatalog();
    private static ICatalog television = new TelevisionCatalog();

    public static List<ICatalog> Categories { get; } = new List<ICatalog>()
    {
        consoleGame, television
    };

    public static ICatalog GetCategory(string Name) => Categories.Where(i => i.Name == Name).FirstOrDefault();

    public static List<ICatalog> GetAllCategories() => Categories;
}