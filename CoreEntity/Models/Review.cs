using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CoreEntity.Models;

public class Review
{
  [key] //主キーの設定
  public int Code { get; set; }

  public string Name { get; set; } = String.Empty;

  public string Body { get; set; } = String.Empty;

  public DateTime LastUpdated { get; set; } = DateTime.Now;

  public int ForBook { get; set; }
  [ForeignKey(nameof(ForBook))] //外部キーの設定

  public Book Book { get; set; } = null!;

  // DBに保存しないプロパティ
  // NotMapped属性を付けることで、Entity Framework Coreはこのプロパティをデータベースにマッピングしない
  [NotMapped]
  public string Summary
  {
    get
    {
      if (Body.Length < 30) { return Body; }
      return Body[..30] + "...";
    }
  }
}