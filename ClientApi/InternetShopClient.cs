using System.Net.Http.Json;
using ModelLibrary;

namespace ClientApi;

public class InternetShopClient
{
    private string _host { get; set; }
    private HttpClient _client { get; set; }

    public InternetShopClient(string? host)
    {
        _host = host ?? "http://localhost:5282";
        _client = new HttpClient();
    }

    public Task<List<Product>> GetProducts() =>
        _client.GetFromJsonAsync<List<Product>>($"{_host}/catalog");

    public Task AddProduct(Product product) =>
        _client.PostAsJsonAsync($"{_host}/catalogAddProductPost", product);

}