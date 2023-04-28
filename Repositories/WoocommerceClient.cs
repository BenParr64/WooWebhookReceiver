using PdfOrders.Repositories.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using Reports.Repositories;

namespace PdfOrders.Repositories;

public class WoocommerceClient : IWoocommerceClient
{
    private readonly HttpClient _httpClient;
    private readonly ConfigurationSettings _configurationService;

    public WoocommerceClient(HttpClient httpClient, IOptions<ConfigurationSettings> configurationService)
    {

        _configurationService = configurationService.Value;
        _httpClient = httpClient;
    }

    public async Task<Order> GetOrder()
    {
        const string endpoint = "/wp-json/wc/v3/orders";
        _httpClient.BaseAddress = new Uri(_configurationService.BaseUrl);
        var byteArray = Encoding.ASCII.GetBytes($"{_configurationService.ConsumerKey}:{_configurationService.ConsumerSecret}");

        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

        // Set the query parameters to retrieve the latest order
        var query = $"?per_page=1&orderby=date&order=desc";
        var url = $"{endpoint}{query}";

        var response = await _httpClient.GetAsync(url);
        var content = await response.Content.ReadAsStringAsync();


        var orders = JsonSerializer.Deserialize<List<Order>>(content);
        return orders.FirstOrDefault();
    }

    public async Task<Product> GetProduct(int productId)
    {
        var endpoint = $"/wp-json/wc/v3/products{productId}";
        _httpClient.BaseAddress = new Uri(_configurationService.BaseUrl);
        var byteArray = Encoding.ASCII.GetBytes($"{_configurationService.ConsumerKey}:{_configurationService.ConsumerSecret}");

        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

        // Set the query parameters to retrieve the latest order
        var query = $"?per_page=1&orderby=date&order=desc";
        var url = $"{endpoint}{query}";

        var response = await _httpClient.GetAsync(url);
        var content = await response.Content.ReadAsStringAsync();


        var products = JsonSerializer.Deserialize<List<Product>>(content);
        return products.FirstOrDefault();
    }
}
