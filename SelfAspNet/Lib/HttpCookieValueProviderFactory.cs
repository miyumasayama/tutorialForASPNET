using System.Globalization;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SelfAspNet.Lib;

public class HttpCookieValueProviderFactory : IValueProviderFactory
{
    public Task CreateValueProviderAsync(ValueProviderFactoryContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        var cookies = context.ActionContext.HttpContext.Request.Cookies;
        if (cookies != null && cookies.Count > 0)
        {
            var valueProvider = new HttpCookieValueProvider(
              BindingSource.ModelBinding,
              cookies,
              CultureInfo.InvariantCulture);
            context.ValueProviders.Add(valueProvider);
        }

        return Task.CompletedTask;
    }
}