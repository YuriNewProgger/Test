using ModelLibrary;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Catalog catalog = new Catalog();

app.MapGet("/", () => "I`m the best developer!!!");
app.MapGet("/catalog", (HttpContext context) => catalog.GetProduct(context.Request.Headers.UserAgent.ToString(), DateTime.Now));
// app.MapGet("/catalogAddProduct", AddProduct);
app.MapGet("/requests", (HttpContext context) => context.Request.Headers);
app.MapPost("/catalogAddProductPost", (Product product) => catalog.AddProduct(product));
// app.MapPost("/catalogAddProductPost", (Product product) => catalog.Add(product));




app.Run();
