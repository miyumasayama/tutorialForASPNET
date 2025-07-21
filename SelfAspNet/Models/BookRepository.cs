using Microsoft.EntityFrameworkCore;

// リポジトリパターン
// データベース操作を抽象化することで、アクションからデータベースを意識させない
// それによって、本番では本番、テストではテスト用のデータ、というように、異なるデータベースへのアクセスを可能にする

namespace SelfAspNet.Models;

public class BookRepository : IBookRepository
{
    private readonly MyContext _db;

    public BookRepository(MyContext db)
    {
        _db = db;
    }
    public async Task<int> CreateAsync(Book book)
    {
        _db.Books.Add(book);
        return await _db.SaveChangesAsync();
    }

    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        return await _db.Books.ToListAsync();
    }

}

public static class BookRepositoryExtensions
{
    public static IServiceCollection AddBookRepository(
        this IServiceCollection services)
    {
        return services.AddTransient<IBookRepository, BookRepository>();
    }
}