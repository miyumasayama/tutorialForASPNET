using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace SelfAspNet.Lib;

// ActionResultクラスを自作したい場合
// アクションで取得したデータをカンマ区切りで出力するクラス
public class CsvResult : ActionResult
{
    readonly IEnumerable<object> _list;

    public CsvResult(IEnumerable<object> list)
    {
        _list = list;
    }

    // アクションの処理結果を同期的に実行(最低限ここだけ実装すれば自作のクラスが作成可能)
    public override void ExecuteResult(ActionContext context)
    {
        // 追加の文字エンコーディングを登録。Microsoft Excel等の規定のUTF-8では文字化けの可能性があるため
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        var res = context.HttpContext.Response;
        // ヘッダー情報の宣言
        res.Headers.ContentType = "text/csv; charset=sjis";
        res.Headers.ContentDisposition = "attachment; filename=\"result.csv\"";
        res.WriteAsync(CreateCSV(_list), Encoding.GetEncoding("Shift-JIS"));
    }

    // カンマ区切りテキストを生成s
    private static string CreateCSV(IEnumerable<object> list)
    {
        var sb = new StringBuilder();
        foreach (var obj in list)
        {
            var rows = new List<string?>();
            foreach (var prop in obj.GetType().GetProperties()) // どのようなモデルが渡されるかわからないので、タイプを取得してからプロパティを取得する
            {
                var type = prop.PropertyType;
                if (type.IsPrimitive ||
                  type == typeof(String) || type == typeof(DateTime)) // 特定タイプの場合のみCSVに変換する
                {
                    rows.Add(prop?.GetValue(obj)?.ToString());
                }
            }
            sb.AppendLine(string.Join(",", rows.ToArray()));
        }
        return sb.ToString();
    }
}