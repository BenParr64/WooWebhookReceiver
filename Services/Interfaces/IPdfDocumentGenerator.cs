using Services.Enums;

namespace Services.Interfaces;

public interface IPdfDocumentGenerator
{
    Task<string> GenerateTemplate(TemplatesEnum template, object content);
}