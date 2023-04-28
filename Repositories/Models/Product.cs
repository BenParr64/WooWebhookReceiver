using System.Text.Json.Serialization;

namespace PdfOrders.Repositories.Models;

// Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
public class Attribute
{
    public int id { get; set; }
    public string name { get; set; }
    public int position { get; set; }
    public bool visible { get; set; }
    public bool variation { get; set; }
    public List<string> options { get; set; }
}

public class Category
{
    public int id { get; set; }
    public string name { get; set; }
    public string slug { get; set; }
}

public class Collection
{
    public string href { get; set; }
}

public class DefaultAttribute
{
    public int id { get; set; }
    public string name { get; set; }
    public string option { get; set; }
}

public class Dimensions
{
    public string length { get; set; }
    public string width { get; set; }
    public string height { get; set; }
}

public class Image
{
    public int id { get; set; }
    public DateTime date_created { get; set; }
    public DateTime date_created_gmt { get; set; }
    public DateTime date_modified { get; set; }
    public DateTime date_modified_gmt { get; set; }
    public string src { get; set; }
    public string name { get; set; }
    public string alt { get; set; }
}

public class Links
{
    public List<Self> self { get; set; }
    public List<Collection> collection { get; set; }
}

public class Product
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("slug")]
    public string Slug { get; set; }

    [JsonPropertyName("permalink")]
    public string Permalink { get; set; }

    [JsonPropertyName("date_created")]
    public DateTime DateCreated { get; set; }

    [JsonPropertyName("date_created_gmt")]
    public DateTime DateCreatedGmt { get; set; }

    [JsonPropertyName("date_modified")]
    public DateTime DateModified { get; set; }

    [JsonPropertyName("date_modified_gmt")]
    public DateTime DateModifiedGmt { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("featured")]
    public bool Featured { get; set; }

    [JsonPropertyName("catalog_visibility")]
    public string CatalogVisibility { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("short_description")]
    public string ShortDescription { get; set; }

    [JsonPropertyName("sku")]
    public string Sku { get; set; }

    [JsonPropertyName("price")]
    public string Price { get; set; }

    [JsonPropertyName("regular_price")]
    public string RegularPrice { get; set; }

    [JsonPropertyName("sale_price")]
    public string SalePrice { get; set; }

    [JsonPropertyName("date_on_sale_from")]
    public object DateOnSaleFrom { get; set; }

    [JsonPropertyName("date_on_sale_from_gmt")]
    public object DateOnSaleFromGmt { get; set; }

    [JsonPropertyName("date_on_sale_to")]
    public object DateOnSaleTo { get; set; }

    [JsonPropertyName("date_on_sale_to_gmt")]
    public object DateOnSaleToGmt { get; set; }

    [JsonPropertyName("price_html")]
    public string PriceHtml { get; set; }

    [JsonPropertyName("on_sale")]
    public bool OnSale { get; set; }

    [JsonPropertyName("purchasable")]
    public bool Purchasable { get; set; }

    [JsonPropertyName("total_sales")]
    public int TotalSales { get; set; }

    [JsonPropertyName("virtual")]
    public bool Virtual { get; set; }

    [JsonPropertyName("downloadable")]
    public bool Downloadable { get; set; }

    [JsonPropertyName("downloads")]
    public List<object> Downloads { get; set; }

    [JsonPropertyName("download_limit")]
    public int DownloadLimit { get; set; }

    [JsonPropertyName("download_expiry")]
    public int DownloadExpiry { get; set; }

    [JsonPropertyName("external_url")]
    public string ExternalUrl { get; set; }

    [JsonPropertyName("button_text")]
    public string ButtonText { get; set; }

    [JsonPropertyName("tax_status")]
    public string TaxStatus { get; set; }

    [JsonPropertyName("tax_class")]
    public string TaxClass { get; set; }
    [JsonPropertyName("manage_stock")]
    public bool ManageStock { get; set; }
    [JsonPropertyName("stock_quantity")]
    public object StockQuantity { get; set; }

    [JsonPropertyName("stock_status")]
    public string StockStatus { get; set; }

    [JsonPropertyName("backorders")]
    public string Backorders { get; set; }

    [JsonPropertyName("backorders_allowed")]
    public bool BackordersAllowed { get; set; }

    [JsonPropertyName("backordered")]
    public bool Backordered { get; set; }

    [JsonPropertyName("sold_individually")]
    public bool SoldIndividually { get; set; }

    [JsonPropertyName("weight")]
    public string Weight { get; set; }

    [JsonPropertyName("dimensions")]
    public Dimensions Dimensions { get; set; }

    [JsonPropertyName("shipping_required")]
    public bool ShippingRequired { get; set; }

    [JsonPropertyName("shipping_taxable")]
    public bool ShippingTaxable { get; set; }

    [JsonPropertyName("shipping_class")]
    public string ShippingClass { get; set; }

    [JsonPropertyName("shipping_class_id")]
    public int ShippingClassId { get; set; }

    [JsonPropertyName("reviews_allowed")]
    public bool ReviewsAllowed { get; set; }

    [JsonPropertyName("average_rating")]
    public string AverageRating { get; set; }

    [JsonPropertyName("rating_count")]
    public int RatingCount { get; set; }

    [JsonPropertyName("related_ids")]
    public List<int> RelatedIds { get; set; }

    [JsonPropertyName("upsell_ids")]
    public List<object> UpsellIds { get; set; }

    [JsonPropertyName("cross_sell_ids")]
    public List<object> CrossSellIds { get; set; }

    [JsonPropertyName("parent_id")]
    public int ParentId { get; set; }

    [JsonPropertyName("purchase_note")]
    public string PurchaseNote { get; set; }

    [JsonPropertyName("categories")]
    public List<Category> Categories { get; set; }

    [JsonPropertyName("tags")]
    public List<object> Tags { get; set; }

    [JsonPropertyName("images")]
    public List<Image> Images { get; set; }

    [JsonPropertyName("attributes")]
    public List<Attribute> Attributes { get; set; }

    [JsonPropertyName("default_attributes")]
    public List<DefaultAttribute> DefaultAttributes { get; set; }

    [JsonPropertyName("variations")]
    public List<object> Variations { get; set; }

    [JsonPropertyName("grouped_products")]
    public List<object> GroupedProducts { get; set; }

    [JsonPropertyName("menu_order")]
    public int MenuOrder { get; set; }

    [JsonPropertyName("meta_data")]
    public List<object> MetaData { get; set; }

    [JsonPropertyName("_links")]
    public Links Links { get; set; }
}

public class Self
{
    public string href { get; set; }
}

