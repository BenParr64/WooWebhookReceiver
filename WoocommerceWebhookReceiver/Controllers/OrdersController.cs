using Azure.Messaging.ServiceBus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PdfOrders.Repositories;
using Services;
using Services.Enums;
using Services.Helpers;
using Services.Interfaces;

namespace WoocommerceWebhookReceiver.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IHubContext<OrderHub> _hub;
    private readonly IPdfGeneratorService _pdfGeneratorService;
    private readonly ServiceBusClient _serviceBusClient;
    private readonly ITemplateGeneratorService _templateGeneratorService;
    private readonly IWoocommerceClient _woocommerceClient;

    public OrdersController(IHubContext<OrderHub> hub, IWoocommerceClient woocommerceClient,
        ITemplateGeneratorService templateGeneratorService, ServiceBusClient serviceBusClient,
        IPdfGeneratorService pdfGeneratorService)
    {
        _hub = hub;
        _woocommerceClient = woocommerceClient;
        _templateGeneratorService = templateGeneratorService;
        _serviceBusClient = serviceBusClient;
        _pdfGeneratorService = pdfGeneratorService;
    }

    [HttpPost]
    public async Task<IActionResult> HandleWebhook()
    {
        var order = await _woocommerceClient.GetOrder();
        var sender = _serviceBusClient.CreateSender("pdfqueue");

        foreach (TemplatesEnum template in Enum.GetValues(typeof(TemplatesEnum)))
        {
            var pageSize = PageSizeHelper.GetPageSizeFromTemplate(template);
            var html = await _templateGeneratorService.GenerateTemplateHtml(template, order);
            //var pdf = _pdfGeneratorService.GeneratePdfFromHtml(html, pageSize);

            var message = new ServiceBusMessage(html)
            {
                ApplicationProperties =
                {
                    ["pageSize"] = pageSize.ToString()
                }
            };

            await sender.SendMessageAsync(message);
            break;
        }

        return Ok();
    }

    [HttpGet("Invoice")]
    public async Task<IActionResult> PreviewInvoiceTemplate()
    {
        var order = await _woocommerceClient.GetOrder();

        var html = await _templateGeneratorService.GenerateTemplateHtml(TemplatesEnum.Invoice, order);

        return Ok(html);
    }

    [HttpGet("Malt")]
    public async Task<IActionResult> PreviewMaltTemplate()
    {
        var order = await _woocommerceClient.GetOrder();

        var html = await _templateGeneratorService.GenerateTemplateHtml(TemplatesEnum.Malt, order);

        return Ok(html);
    }
}