namespace SelfAspNet.Models;

// インセプター
// エンティティを操作するタイミングで実行されるクラスメソッド
public interface IRecordableTimestamp
{
    public DateTime CreatedAt { get; set; }
    public DateTime LastUpdatedAt { get; set; }
}