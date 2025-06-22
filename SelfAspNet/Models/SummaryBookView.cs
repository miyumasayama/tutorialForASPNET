using System.ComponentModel.DataAnnotations;

// ビューとして表示、操作すべきデータを作成= ビューモデル
// 必ずしも表示データとエンティティの形が一致するとは限らないため、そのような時にビューモデルを作成する
namespace SelfAspNet.Models;

public record SummaryBookView(
    [property: Display(Name = "書名")] string ShortTitle,
    [property: Display(Name = "値引価格")] int DiscountPrice,
    [property: Display(Name = "状態")] string Released
);
