namespace ModelLibrary.CatalogsWarehouse;
[Obsolete]
public static class CatalogsWarehouse
{
    private static readonly ICatalog consoleGame = new GameConsoleCatalog();
    private static readonly ICatalog television = new TelevisionCatalog();

    public static List<ICatalog> Categories { get; } = new List<ICatalog>()
    {
        consoleGame, television
    };

    public static ICatalog GetCategory(string Name) => Categories.Where(i => i.Name == Name).FirstOrDefault();

    public static List<ICatalog> GetAllCategories() => Categories;
}