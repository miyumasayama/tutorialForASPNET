using System.ComponentModel.DataAnnotations.Schema;

namespace CoreEntity.Models;

public class Article
{
  public int Id { get; set; }
  public string Url { get; set; } = string.Empty;
  public string Content { get; set; } = string.Empt

}

// 継承関係のエンティティ
public class CollabArticle : Article
{
  public string Company { get; set; } = string.Empty; //提携先
}