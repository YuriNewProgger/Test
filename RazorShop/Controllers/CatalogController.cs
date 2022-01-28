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
        
        return View(products);
    }

    public IActionResult GetCategories()
    {
        return View(_categories);
    }
    
    [HttpGet]                       
    public IActionResult AddProduct()
    {              
        return View();               
    }     
    
    [HttpPost]
    public IActionResult AddProduct(string Title, decimal Price, string Category)
    {
        if (string.IsNullOrEmpty(Title))
            return LocalRedirect("~/Catalog/ErrorPage");
        
        CatalogsWarehouse.GetCategory(Category).AddProduct(new Product(Title, Price));
        
        return LocalRedirect("~/Home/Index");               
    }  
    
    public IActionResult ErrorPage()
    {              
        return View();               
    }  

}