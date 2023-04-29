using Services.Enums;
using Services.Interfaces;
using Services.ViewRendering;

namespace Services;

public class PdfDocumentGenerator : IPdfDocumentGenerator
{
    private readonly ViewRenderer _viewRenderer;
    public PdfDocumentGenerator(ViewRenderer viewRenderer)
    {
        _viewRenderer = viewRenderer;
    }

    public async Task<string> GenerateTemplate(TemplatesEnum template, object content)
    {

        var invoiceHtml = template switch
        {
            TemplatesEnum.Invoice => await _viewRenderer.RenderViewToStringAsync("Invoice", content),
            TemplatesEnum.PackingSlip => await _viewRenderer.RenderViewToStringAsync("Orders/PackingSlip", content),
            TemplatesEnum.Malt => await _viewRenderer.RenderViewToStringAsync("Ingredient_Grain", content),
            TemplatesEnum.Hop => await _viewRenderer.RenderViewToStringAsync("Orders/Hop", content),
            _ => throw new ArgumentOutOfRangeException(nameof(template), template, null)
        };

        return invoiceHtml;
    }

}