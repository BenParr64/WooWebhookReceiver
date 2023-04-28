using System.Text.Json.Serialization;

namespace PdfOrders.Repositories.Models;

public class LineItem
{
    [JsonPropertyName("product_id")] public int ProductId { get; set; }

    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("quantity")] public int Quantity { get; set; }

    [JsonPropertyName("total")] public string Total { get; set; }
}