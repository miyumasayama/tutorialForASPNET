using Microsoft.AspNetCore.Mvc.Filters;

namespace SelfAspNet.Filters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method
    , AllowMultiple = false)]
public class MyLogAsyncAttribute : Attribute, IAsyncActionFilter
{
    // アクションの実行前に呼び出される
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        Console.WriteLine($"【Before】{context.ActionDescriptor.DisplayName}が実行されます。");
        await next(); //明示的にアクションを呼ぶ
        Console.WriteLine($"【After】{context.ActionDescriptor.DisplayName}が実行されました。");
    }
}