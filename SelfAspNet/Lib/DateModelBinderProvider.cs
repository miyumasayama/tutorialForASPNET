using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SelfAspNet.Lib;

// モデルバインダーをアプリ全体に適用するためのプロバイダー
public class DateModelBinderProvider : IModelBinderProvider
{
    public IModelBinder? GetBinder(ModelBinderProviderContext context)
    {
        if (context.Metadata.ModelType == typeof(DateTime))
        {
            return new DateModelBinder();
        }
        return null;
    }
}
