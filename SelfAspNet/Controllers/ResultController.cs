using System.Net;
using System.Text;
using SelfAspNet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Microsoft.AspNetCore.Http.Features;
using SelfAspNet.Lib;
using System.Security.Cryptography;
using Microsoft.Net.Http.Headers;

using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Font;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using Microsoft.EntityFrameworkCore;

namespace SelfAspNet.Controllers;

public class ResultController : Controller
{
    private readonly MyContext _db;
    private readonly IWebHostEnvironment _host;
    public ResultController(MyContext db, IWebHostEnvironment host)
    {
        _db = db;
        _host = host;
    }

    public IActionResult Template()
    {
        return View("About");
        // return View("Manage/About");
        // return View("../Manage/About");
        // return View("Template/New.cshtml");
        // return View("/Template/New.cshtml");
    }

    public IActionResult AjaxForm()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AjaxSearch(string keyword, bool? released)
    {
        var bs = _db.Books.Select(b => b);
        if (!string.IsNullOrEmpty(keyword))
        {
            bs = bs.Where(b => b.Title.Contains(keyword));
        }
        if (released.HasValue && released.Value)
        {
            bs = bs.Where(b => b.Published <= DateTime.Now);
        }
        return PartialView("_AjaxResult", bs); // Partialviewクラスは部分ビューを呼び出す
    }

    public IActionResult Move()
    {
        return Redirect("https://wings.msn.to/"); //RedirectResultクラスのメソッドRedirect(アプリ配下の遷移先でなくてもいい)
    }

    public IActionResult Local()
    {
        return LocalRedirect("https://wings.msn.to/");
    }

    public async Task<IActionResult> Status(int? id)
    {
        var bs = await _db.Books.FindAsync(id);
        if (bs == null)
        {
            return StatusCode(404); // HttpStatusCodeResultクラスのメソッドStatusCode(HTTPステータスコードを指定して応答を返す)
            // return StatusCode(StatusCodes.Status404NotFound); 
        }
        return View("../Books/Details", bs);
    }

    public IActionResult Nothing() // アクションの結果としてコンテンツを返さない(コンテンツを返さないことを明確にする場合はNoContentResultクラスを使う)
    {
        return Empty;
    }

    public IActionResult Plain() // コンテンツをそのまま返す
    {
        return Content("こんにちは、世界！", "text/plain", Encoding.UTF8);

        // return Content("こんにちは、世界！ ",
        //     System.Net.Mime.MediaTypeNames.Text.Plain, Encoding.UTF8);

        // return Content("こんにちは、世界！");
    }

    // public string Plain()
    // {
    //     return "こんにちは、世界！";
    // }

    public async Task<IActionResult> Csv()
    {
        var bs = await _db.Books.ToListAsync();
        var data = new StringBuilder();
        bs.ForEach(b =>
            data.Append(string.Format(
                $"{b.Id},{b.Isbn},{b.Title},{b.Price},{b.Publisher},{b.Published}\r\n")
            )
        );
        Response.Headers.Append(
            "Content-Disposition", "attachment;filename=data.csv");
        return Content(data.ToString(), "text/comma-separated-values",
            Encoding.GetEncoding("Shift_JIS"));
    }

    // ユーザ-に引数でpathを指定させる構成は脆弱性を生むため回避すべき(ex: アプリケーション側からProgram.csを開いてしまったり?)(パストラバーサル脆弱性)
    // ファイルパスはDB管理の方がいいかも
    public IActionResult Image(int id) //指定ファイルを出力
    {
        // 仮想パスで指定する場合
        var path = $"/images/img_{id}.png";
        // return File(path, "image/png", "sample.png");
        // return File(path, "image/png");

        // 物理パスで指定する場合
        // var path = $"C:/data/images/img_{id}.png";
        // return PhysicalFile(path, "image/png", "sample.png");

        var fullpath = _host.WebRootPath + path; // 物理パスの生成
        return File(path, "image/png",
            new DateTimeOffset(System.IO.File.GetLastWriteTime(fullpath)),// Last-Modeified=前回の更新日時を指定するタグ。
            new EntityTagHeaderValue(ComputeSha256(fullpath)) // ETag=同一リソースには同一のタグが指定。キャッシュを利用する場合は、ETagを指定しておくと、ブラウザ側でキャッシュが有効な場合は304 Not Modifiedを返すようになる
        );
    }

    public IActionResult Risk(string path)
    {
        return PhysicalFile(path, "application/octet-stream");
    }

    // ファイルの本体のハッシュ値を計算する。ファイルの中身が変更されていたら、ハッシュ値も変わるため、ETagとして利用できる。
    private static string ComputeSha256(string path)
    {
        using var sha = SHA512.Create();
        using var stream = new FileStream(path, FileMode.Open);
        var bs = sha.ComputeHash(stream);
        var result = new StringBuilder();
        foreach (var b in bs)
        {
            result.Append(b.ToString("x2"));
        }
        return $"\"{result.ToString()}\"";
    }

    // 動的に取得したバイナリデータを返す
    public async Task<IActionResult> Photo(int id = 1)
    {
        var p = await _db.Photos.FindAsync(id);
        if (p == null)
        {
            return NotFound();
        }
        return File(p.Content, p.ContentType, p.Name);
    }

    public IActionResult Pdf()
    {
        var stream = new MemoryStream(); //データを一時的に保持するためのメモリストリームを生成
        var doc = new iText.Layout.Document( // ドキュメントを生成
          new PdfDocument(
            new PdfWriter(stream)
          )
        );

        // テンプレートを使う場合
        // var pdf = new PdfDocument(
        // new PdfReader("C:/data/template.pdf"),
        // new PdfWriter(stream)
        // );
        // var doc = new iText.Layout.Document(pdf);

        var font = PdfFontFactory.CreateFont("HeiseiKakuGo-W5", "UniJIS-UCS2-H"); //フォントを準備
        doc.SetFont(font);
        doc.Add( // 文字列の生成
          new Paragraph("こんにちは、")
            .Add(new Text("世界！")
              .SetFontSize(20)
              .SetFontColor(new DeviceRgb(255, 0, 0))
            ));
        doc.Close();// ドキュメントを閉じることで、PDFの内容が確定する
        return File(stream.ToArray(), MediaTypeNames.Application.Pdf);
        // return File(stream.ToArray(), MediaTypeNames.Application.Pdf, "sample.pdf");
    }

    // バイナリデータを直接応答に送出する場合
    // public IActionResult Pdf()
    // {
    //     Response.ContentType = MediaTypeNames.Application.Pdf;
    //     var doc = new iText.Layout.Document(
    //         new PdfDocument(
    //         new PdfWriter(Response.Body)
    //         )
    //     );
    //     var font = PdfFontFactory.CreateFont("HeiseiKakuGo-W5", "UniJIS-UCS2-H");
    //     doc.SetFont(font);
    //     doc.Add(
    //       new Paragraph("こんにちは、")
    //         .Add(new Text("世界！")
    //           .SetFontSize(20)
    //           .SetFontColor(new DeviceRgb(255, 0, 0))
    //         ));
    //     doc.Close();
    //     return Empty;
    // }

    public async Task<IActionResult> Output()
    {
        // 自作のActionResultクラスの呼び出し
        return new CsvResult(await _db.Books.ToListAsync());
    }
}
