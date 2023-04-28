using System.Text.Json.Serialization;

namespace PdfOrders.Repositories.Models;

public class BillingAddress
{
    [JsonPropertyName("first_name")] public string FirstName { get; set; }

    [JsonPropertyName("last_name")] public string LastName { get; set; }

    [JsonPropertyName("email")] public string Email { get; set; }
}