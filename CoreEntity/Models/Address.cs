using System.ComponentModel.DataAnnotations.Schema;

namespace CoreEntity.Models;

// 複合型
// CompanyとEmployeeが重複して持つプロパティを複合型として切り出す
// 主キーを持たない
[ComplexType]
public class Address
{
  public string PostNumber { get; set; } = string.Empty;
  public string Prefecture { get; set; } = string.Empty;
  public string City { get; set; } = string.Empty;
  public string Other { get; set; } = string.Empty;
}