namespace CoreEntity.Models;

public class EmailAddress
{
  //与えられたメールアドレスを分割して、ローカル部分とドメイン部分をプロパティに反映
  public EmailAddress(string mail)
  {
    var mails = mail.Split("@", 2);
    Local = mails[0];
    Domain = mails[1];
  }

  public string Local { get; init; }
  public string Domain { get; init; }

  // 本来のメールアドレスの形に変換
  public override string ToString()
  {
    return $"{Local}@{Domain}";
  }
}