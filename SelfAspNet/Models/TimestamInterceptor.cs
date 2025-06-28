using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace SelfAspNet.Models;

public class TimestampInterceptor : SaveChangesInterceptor //Inceptorクラスを継承することでインセプターとなる
{
    // SaveChangesメソッドが呼ばれる前に実行される
    public override InterceptionResult<int> SavingChanges(
      DbContextEventData eventData, InterceptionResult<int> result)
    {
        // 現在のコンテクストに基づいてタイムスタンプを更新する
        UpdateTimestamp(eventData.Context!);
        return base.SavingChanges(eventData, result);
    }

    // SaveChangesAsyncメソッドが呼ばれる前に実行される
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
      DbContextEventData eventData, InterceptionResult<int> result,
      CancellationToken cancellationToken = default)
    {
        // 現在のコンテクストに基づいてタイムスタンプを更新する
        UpdateTimestamp(eventData.Context!);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    // 作成、更新日時に現在の時間を指定

    private static void UpdateTimestamp(DbContext db)
    {
        var current = DateTime.Now;
        foreach (var e in db.ChangeTracker.Entries())
        {
            if (e.Entity is IRecordableTimestamp te)
            {
                switch (e.State)
                {
                    case EntityState.Added:
                        te.CreatedAt = current;
                        te.LastUpdatedAt = current;
                        break;
                    case EntityState.Modified:
                        te.LastUpdatedAt = current;
                        break;
                }
            }
        }
    }
}