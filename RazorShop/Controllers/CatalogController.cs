using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ModelLibrary;
using ModelLibrary.CatalogsWarehouse;
using ModelLibrary.Categories;
using RazorShop.Models;

namespace RazorShop.Controllers;

public class CatalogController : Controller
{
    private IRepositiry categories;

    public CatalogController(IRepositiry _categories)
    {
        categories = _categories;
    }
    
    // GET
    public IActionResult GetProducts()
    {
        List<Product> products = new List<Product>();
        
        foreach (var item in categories.GetAllCategories())
            foreach (var product in item.GetProducts(Request.Headers["User-Agent"].ToString(), DateTime.Now))
                products.Add(product);
        
        return View(products);
    }

    public IActionResult GetCategories()
    {
        List<DTO> dataTransferObjects = new List<DTO>();

        foreach (var item in categories.GetAllCategories())
        {
            dataTransferObjects.Add(new DTO()
            {
                Category = item, 
                Products = item.GetProducts(Request.Headers["User-Agent"].ToString(), DateTime.Now)
            });
        }

        return View(dataTransferObjects);
    }
    
    [HttpGet]                       
    public IActionResult CreateProduct()
    {
        return View(categories.GetAllCategories());               
    }     
    
    [HttpPost]
    public IActionResult CreateProduct(string Title, decimal? Price,  string Category)
    {
        if (string.IsNullOrEmpty(Title) || Price is null || string.IsNullOrEmpty(Category))
            return LocalRedirect("~/Catalog/ErrorPage");
        
        categories.GetAllCategories().Where(i => i.Name == Category).FirstOrDefault().AddProduct(new Product(Title, Price.Value));
        return LocalRedirect("~/Catalog/GetProducts");               
    }  
    
    public IActionResult ErrorPage()
    {              
        return View();               
    }

    [HttpGet]
    public IActionResult CreateCategory()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateCategory(int? Id, string? Title)
    {
        if (Id is null || string.IsNullOrEmpty(Title))
            return BadRequest();
        
        ICategory newCategory = new Category(Id.Value, Title);
        categories.AddCategory(newCategory);
        return LocalRedirect("~/Catalog/GetCategories");
    }

    public IActionResult GetInformationSelectedProduct(string productName)
    {
        Product findedProduct = null;
        
        foreach (var category in categories.GetAllCategories())
        {
            foreach (var product in category.GetProducts(Request.Headers["User-Agent"].ToString(), DateTime.Now))
            {
                if (product.Title == productName)
                {
                    findedProduct = product;
                    break;
                }
                    
            }
        }
        
        return View(findedProduct);
    }

}