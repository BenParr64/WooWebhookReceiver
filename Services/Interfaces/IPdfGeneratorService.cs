using Services.Enums;

namespace Services.Interfaces;

public interface IPdfGeneratorService
{
    byte[] GeneratePdfFromHtml(string html, PageSizesEnum pageSize);
}