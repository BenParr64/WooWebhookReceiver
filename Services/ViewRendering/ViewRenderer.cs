using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;

namespace Services.ViewRendering;

public class ViewRenderer
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ITempDataProvider _tempDataProvider;
    private readonly ICompositeViewEngine _viewEngine;

    public ViewRenderer(ICompositeViewEngine viewEngine, ITempDataProvider tempDataProvider,
        IServiceProvider serviceProvider)
    {
        _viewEngine = viewEngine;
        _tempDataProvider = tempDataProvider;
        _serviceProvider = serviceProvider;
    }

    public async Task<string> RenderViewToStringAsync<TModel>(string viewName, TModel model)
    {
        var actionContext = new ActionContext
        {
            HttpContext = new DefaultHttpContext { RequestServices = _serviceProvider },
            RouteData = new RouteData(),
            ActionDescriptor = new ActionDescriptor()
        };

        using var sw = new StringWriter();
        var viewResult = _viewEngine.FindView(actionContext, viewName, false);

        if (viewResult.View == null) throw new ArgumentNullException($"{viewName} does not match any available view");

        var viewDictionary =
            new ViewDataDictionary<TModel>(new EmptyModelMetadataProvider(), new ModelStateDictionary())
            {
                Model = model
            };

        var tempData = new TempDataDictionary(actionContext.HttpContext, _tempDataProvider);

        var viewContext = new ViewContext(actionContext, viewResult.View, viewDictionary, tempData, sw,
            new HtmlHelperOptions());

        await viewResult.View.RenderAsync(viewContext);
        return sw.ToString();
    }
}