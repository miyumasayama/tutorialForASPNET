using CoreEntity.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoreEntity.Lib;

// 特定のクラスのためのコンバーター
// ValueConverter<Tmodel, TProvider>の形(Tmodelがプロパティの型、TProviderがデータベースの型)
public class EmailAddressConverter : ValueConverter<EmailAddress, string>
{
  public EmailAddressConverter()
      : base(
          v => v.ToString(), //書き込み時
          v => new EmailAddress(v) //読み込み時
      )
  { }
}