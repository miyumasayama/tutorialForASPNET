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
        return PartialView("_AjaxResult", bs);
    }

    public IActionResult Move()
    {
        return Redirect("https://wings.msn.to/");
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
            return StatusCode(404);
            // return StatusCode(StatusCodes.Status404NotFound);
        }
        return View("../Books/Details", bs);
    }

    public IActionResult Nothing()
    {
        return Empty;
    }

    public IActionResult Plain()
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

    public IActionResult Image(int id)
    {
        var path = $"/images/img_{id}.png";
        // return File(path, "image/png", "sample.png");
        // return File(path, "image/png");

        // 物理パスで指定する場合
        // var path = $"C:/data/images/img_{id}.png";
        // return PhysicalFile(path, "image/png", "sample.png");

        var fullpath = _host.WebRootPath + path;
        return File(path, "image/png",
            new DateTimeOffset(System.IO.File.GetLastWriteTime(fullpath)),
            new EntityTagHeaderValue(ComputeSha256(fullpath))
        );
    }

    public IActionResult Risk(string path)
    {
        return PhysicalFile(path, "application/octet-stream");
    }

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
        var stream = new MemoryStream();
        var doc = new iText.Layout.Document(
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

        var font = PdfFontFactory.CreateFont("HeiseiKakuGo-W5", "UniJIS-UCS2-H");
        doc.SetFont(font);
        doc.Add(
          new Paragraph("こんにちは、")
            .Add(new Text("世界！")
              .SetFontSize(20)
              .SetFontColor(new DeviceRgb(255, 0, 0))
            ));
        doc.Close();
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
        return new CsvResult(await _db.Books.ToListAsync());
    }
}
