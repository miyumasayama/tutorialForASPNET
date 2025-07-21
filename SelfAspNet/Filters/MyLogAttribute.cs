using Microsoft.AspNetCore.Mvc.Filters;

namespace SelfAspNet.Filters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)] // フィルターを属性として登録
public class MyLogAttribute : Attribute, IActionFilter //実行したいタイミングによって、IxxxxFilterを実装する
{
    //アクションの実行前
    public void OnActionExecuting(ActionExecutingContext context)
    {
        Console.WriteLine($"【Before】{context.ActionDescriptor.DisplayName}が実行されます。");
    }

    //アクションの実行後

    public void OnActionExecuted(ActionExecutedContext context)
    {
        Console.WriteLine($"【After】{context.ActionDescriptor.DisplayName}が実行されました。");
    }
}
// ActionFilterAttributeクラスで書き換えた場合
// public class MyLogAttribute : ActionFilterAttribute
// {
//     public override void OnActionExecuting(ActionExecutingContext context)
//     {
//         Console.WriteLine($"【Before】{context.ActionDescriptor.DisplayName}が実行されます。");
//     }

//     public override void OnActionExecuted(ActionExecutedContext context)
//     {
//         Console.WriteLine($"【After】{context.ActionDescriptor.DisplayName}が実行されました。");
//     }
// }