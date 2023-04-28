using System.Text.Json.Serialization;

namespace Repositories.Models;

public class ShippingLine
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("method_title")] public string MethodTitle { get; set; }
    [JsonPropertyName("method_total")] public string MethodTotal { get; set; }
}