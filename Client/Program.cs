using System.Net.Http.Json;
using ClientApi;
using ModelLibrary;


List<string> menuItems = new List<string>()
{
    "Display products - 1", "Add product - 2", "Clear display - 3", "Exit - 0"
};

InternetShopClient shopClient = new InternetShopClient(null);

try
{
    int menu = -1;
    
    while (menu != 0)
    {
        PrintMenu();
        menu = Int32.Parse(Console.ReadLine()); ;
        
        switch (menu)
        {
            case 1: 
                var listPropucts = shopClient.GetProducts().Result;
                PrintProduct(listPropucts); break;
            case 2: await shopClient.AddProduct(CreateProduct()); break;
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

void PrintProduct(List<Product> _listProducts)
{
    foreach (var item in _listProducts)
        Console.WriteLine(item);
}

Product CreateProduct()
{
    Console.Write("Enter product title: ");
    string title = Console.ReadLine();
    Console.Write("Enter product price: ");
    decimal price = decimal.Parse(Console.ReadLine());
    return new Product(title, price);
}
