using IronPdf.Rendering;
using Services.Enums;
using Services.Interfaces;

namespace Services;

public class PdfGeneratorService : IPdfGeneratorService
{
    public byte[] GeneratePdfFromHtml(string html, PageSizesEnum pageSize)
    {
        var renderer = new ChromePdfRenderer
        {
            RenderingOptions =
            {
                PaperSize = PdfPaperSize.Custom,
                MarginTop = 0,
                MarginRight = 0,
                MarginBottom = 0,
                MarginLeft = 0
            }
        };

        switch (pageSize)
        {
            case PageSizesEnum.SixByFour:
                renderer.RenderingOptions.SetCustomPaperSizeinMilimeters(152.4, 101.6);
                break;
            case PageSizesEnum.A4:
                renderer.RenderingOptions.PaperSize = PdfPaperSize.A4;
                break;
            default:
                throw new ArgumentException($"Invalid page size: {pageSize}");
        }

        using var pdfDocument = renderer.RenderHtmlAsPdf(html);
        return pdfDocument.BinaryData;
    }
}