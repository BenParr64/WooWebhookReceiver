using Services.Enums;

namespace Services.Interfaces;

public interface ITemplateGeneratorService
{
    Task<string> GenerateTemplateHtml(TemplatesEnum template, object content);
}