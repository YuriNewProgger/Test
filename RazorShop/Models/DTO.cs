using ModelLibrary;
using ModelLibrary.Categories;

namespace RazorShop.Models;

public class DTO
{
    public ICategory Category { get; set; }
    public  List<Product> Products { get; set; }
}