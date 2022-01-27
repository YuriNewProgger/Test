using Microsoft.AspNetCore.Mvc;
using ModelLibrary;
using ModelLibrary.CatalogsWarehouse;

namespace RazorShop.Controllers;

public class CatalogController : Controller
{
    private readonly List<ICatalog> _categories = CatalogsWarehouse.GetAllCategories();
    
    // GET
    public IActionResult GetCatalog()
    {
        List<Product> products = new List<Product>();
        
        foreach (var item in _categories)
            foreach (var product in item.GetProducts(Request.Headers["User-Agent"].ToString(), DateTime.Now))
             products.Add(product);
        
        ViewBag.Products = products;
        
        return View();
    }

    public IActionResult GetCategories()
    {
        ViewBag.Categories = _categories;
        
        return View();
    }
}