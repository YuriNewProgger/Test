namespace ModelLibrary.Categories;

public interface IRepositiry
{
    ICategory GetCategory(string Name);

    List<ICategory> GetAllCategories();

    void AddCategory(ICategory category);
}