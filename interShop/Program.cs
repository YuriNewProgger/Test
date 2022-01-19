using System.Data.Common;
using interShop;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Product> catalog = new List<Product>()
{
    new Product("Sega Mega Drive", 2000),
    new Product("Sony", 5000),
    new Product("Dandy", 1200)
};

List<Product> AddProduct(string title, int price)
{
    IncrementPrice();
    catalog.Add(new Product(title, price));
    return catalog; 
}

void IncrementPrice()
{
    if (DateTime.Today.DayOfWeek == DayOfWeek.Thursday)
    {
        foreach (var product in catalog)
            product.Price += product.Price / 2;
    }
}

app.MapGet("/", () => "You the best developer!!!");
app.MapGet("/catalog", () => catalog);
app.MapGet("/catalogAddProduct", AddProduct);
app.MapGet("/requests", (HttpContext context) => context.Request.Headers);



app.Run();