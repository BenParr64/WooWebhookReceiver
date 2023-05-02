using Services.Enums;
using Services.Interfaces;
using Services.ViewRendering;

namespace Services;

public class TemplateGeneratorServiceService : ITemplateGeneratorService
{
    private readonly ViewRenderer _viewRenderer;
    public TemplateGeneratorServiceService(ViewRenderer viewRenderer)
    {
        _viewRenderer = viewRenderer;
    }

    public async Task<string> GenerateTemplateHtml(TemplatesEnum template, object content)
    {

        var invoiceHtml = template switch
        {
            TemplatesEnum.Invoice => await _viewRenderer.RenderViewToStringAsync("Invoice", content),
            TemplatesEnum.PackingSlip => await _viewRenderer.RenderViewToStringAsync("Invoice", content),
            TemplatesEnum.Malt => await _viewRenderer.RenderViewToStringAsync("Invoice", content),
            TemplatesEnum.Hop => await _viewRenderer.RenderViewToStringAsync("Invoice", content),
            _ => throw new ArgumentOutOfRangeException(nameof(template), template, null)
        };

        return invoiceHtml;
    }

}