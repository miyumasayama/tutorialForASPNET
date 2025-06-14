using Microsoft.EntityFrameworkCore;

namespace CoreEntity.Models;
public class MyContext : DbContext
{

  public MyContext(DbContextOptions<MyContext> options) : base(options) { }
  public DbSet<Book> Books { get; set; } = default!;
  public DbSet<Review> Reviews { get; set; } = default!;
  public DbSet<Author> Authors { get; set; } = default!;
  public DbSet<User> Users { get; set; } = default!;
  public DbSet<Employee> Employees { get; set; } = default!;
  public DbSet<Company> Companies { get; set; } = default!;
  public DbSet<Article> Articles { get; set; } = default!;
  public DbSet<CollabArticle> CollabArticles { get; set; } = default!;
  public DbSet<ViewPubCount> ViewPubCounts { get; set; } = default!;

  // 属性ではなく
  // Fluent APIを使用して、モデルの構成を行うことができる
  // Fluent APIではOnModelCreatingメソッドをオーバーライドして、モデルの構成を行う
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    // Entityメソッドで目的のエンティティを呼び出し、エンティティ/プロパティをマッピング
    modelBuilder.Entity<Review>(Rev =>
    {
      Rev.ToTable("Comments").HasKey(base => base.Code)
      Rev.Property(e => e.Body).HasColumnName("Messsage").HasMaxLength(150)
    })
  }
}