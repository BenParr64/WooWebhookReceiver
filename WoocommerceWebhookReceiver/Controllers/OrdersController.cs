using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PdfOrders.Repositories;
using Services;
using Services.Enums;
using Services.Interfaces;
using System.Text;

namespace WoocommerceWebhookReceiver.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {

        private readonly IHubContext<OrderHub> _hub;
        private readonly IWoocommerceClient _woocommerceClient;
        private readonly IPdfDocumentGenerator _pdfDocumentGenerator;
        public OrdersController(IHubContext<OrderHub> hub, IWoocommerceClient woocommerceClient, IPdfDocumentGenerator pdfDocumentGenerator)
        {
            _hub = hub;
            _woocommerceClient = woocommerceClient;
            _pdfDocumentGenerator = pdfDocumentGenerator;
        }

        [HttpPost]
        public async Task<IActionResult> HandleWebhook()
        {
            var order = await _woocommerceClient.GetOrder();

            var html = await _pdfDocumentGenerator.GenerateTemplate(TemplatesEnum.Invoice, order);
            
            await _hub.Clients.All.SendAsync("ReceiveMessage", html);
            
            return Ok(html);
        }

        [HttpGet]
        public async Task<IActionResult> PreviewTemplate()
        {
            var order = await _woocommerceClient.GetOrder();

            var html = await _pdfDocumentGenerator.GenerateTemplate(TemplatesEnum.Invoice, order);

            return Ok(html);
        }
    }
}