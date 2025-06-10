// CoreEntity
// アノテーションによる規約のカスタマイズ
// 実際のdbの規約に沿わない、表現できない情報を定義したい時に使用する
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Mycrosoft.EntityFrameworkCore;

namespace CoreEntity.Models;

[Table("Contents")] // マッピング先のテーブル指定
public class Book
{
  public int Id { get; set; }

  [Column(Order = 0, TypeName = "CHAR(17)")] //マッピング先のカラム指定。順番と型名を指定
  public string Isbn { get; set; } = String.Empty;

  [Column("Amount", Order = 1, TypeName = "NVARCHAR(50)")]
  public int Price { get; set; }

}
