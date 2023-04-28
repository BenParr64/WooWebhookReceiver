using System.Text.Json.Serialization;
using Repositories.Models;

namespace PdfOrders.Repositories.Models;

public class Order
{
    [JsonPropertyName("id")] public int Id { get; set; }

    [JsonPropertyName("status")] public string Status { get; set; }

    [JsonPropertyName("date_created")] public DateTime DateCreated { get; set; }

    [JsonPropertyName("date_modified")] public DateTime DateModified { get; set; }

    [JsonPropertyName("total")] public string Total { get; set; }

    [JsonPropertyName("customer_id")] public int CustomerId { get; set; }

    [JsonPropertyName("billing")] public BillingAddress BillingAddress { get; set; }

    [JsonPropertyName("line_items")] public IEnumerable<LineItem> LineItems { get; set; }
    [JsonPropertyName("shipping_lines")] public IEnumerable<ShippingLine> ShippingLines { get; set; }
    [JsonPropertyName("payment_method")] public string PaymentMethod { get; set; }

    [JsonPropertyName("payment_method_title")]
    public string PaymentMethodTitle { get; set; }
}

