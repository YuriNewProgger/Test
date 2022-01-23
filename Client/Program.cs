using System.Net.Http.Json;
using Client;

List<string> menuItems = new List<string>()
{
    "Display products - 1", "Add product - 2", "Clear display - 3", "Exit - 0"
};


try
{
    int menu = -1;
    
    while (menu != 0)
    {
        PrintMenu();
        menu = Int32.Parse(Console.ReadLine()); ;
        
        switch (menu)
        {
            case 1: PrintProduct(); break;
            case 2: AddProduct(); break;
            case 3: Console.Clear();break;
        }
        
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());

    Console.ReadKey();
}

void PrintMenu()
{
    Console.WriteLine("\n");
    Console.WriteLine("==== Menu ====");
    foreach (var item in menuItems)
    {
        Console.WriteLine(item);
    }
    Console.WriteLine("==============");
    Console.WriteLine("\n");
}

async Task<List<Product>> GetProduct()
{
    var client = new HttpClient();
    const string uri = "http://localhost:5282/catalog";
    var products = await client.GetFromJsonAsync<List<Product>>(uri);
    return products;
}

void PrintProduct()
{
    Task<List<Product>> result = GetProduct();

    List<Product> products = result.Result;

    foreach (var item in products)
    {
        Console.WriteLine(item);
    }
}


async void AddProduct()
{

    Product newProduct = CreateProduct();
    var client = new HttpClient();
    const string uri = "http://localhost:5282/catalogAddProductPost";
    await client.PostAsJsonAsync(uri, newProduct);
    
}

Product CreateProduct()
{
    Console.Write("Enter product title: ");
    string title = Console.ReadLine();
    Console.Write("Enter product price: ");
    decimal price = decimal.Parse(Console.ReadLine());
    return new Product(title, price);
}
