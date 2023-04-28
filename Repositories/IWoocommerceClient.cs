using PdfOrders.Repositories.Models;

namespace PdfOrders.Repositories;

public interface IWoocommerceClient
{
    Task<Order> GetOrder();
    Task<Product> GetProduct(int productId);
}
