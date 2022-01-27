using ModelLibrary;
using ModelLibrary.CatalogsWarehouse;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

GameConsoleCatalog gameConsoleCatalog = new GameConsoleCatalog();

app.MapGet("/", () => "I`m the best developer!!!");
app.MapGet("/catalog", (HttpContext context) => gameConsoleCatalog.GetProducts(context.Request.Headers.UserAgent.ToString(), DateTime.Now));
// app.MapGet("/catalogAddProduct", AddProduct);
app.MapGet("/requests", (HttpContext context) => context.Request.Headers);
app.MapPost("/catalogAddProductPost", (Product product) => gameConsoleCatalog.AddProduct(product));
// app.MapPost("/catalogAddProductPost", (Product product) => catalog.Add(product));




app.Run();
