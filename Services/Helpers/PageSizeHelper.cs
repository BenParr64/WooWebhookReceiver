using Services.Enums;

namespace Services.Helpers;

public static class PageSizeHelper
{
    public static PageSizesEnum GetPageSizeFromTemplate(TemplatesEnum template)
    {
        return template switch
        {
            TemplatesEnum.Invoice => PageSizesEnum.A4,
            TemplatesEnum.PackingSlip => PageSizesEnum.A4,
            TemplatesEnum.Malt => PageSizesEnum.SixByFour,
            TemplatesEnum.Hop => PageSizesEnum.SixByFour,
            _ => throw new ArgumentOutOfRangeException(nameof(template), template, null)
        };
    }
}