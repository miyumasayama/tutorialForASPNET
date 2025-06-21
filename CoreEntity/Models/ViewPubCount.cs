using Microsoft.EntityFrameworkCore;

namespace CoreEntity.Models;

[keyless] // 主キーを持たないエンティティ
public class ViewPubCount
{
  public string Publisher { get; set; } = string.Empty; // 出版社名
  public int BookCount { get; set; } // 出版物の数

}