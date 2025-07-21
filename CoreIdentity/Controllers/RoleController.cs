using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


public class RoleController : Controller
{
  private RoleManager<IdentityRole> _role;
  private UserManager<IdentityUser> _user;

  public RoleController(
    RoleManager<IdentityRole> role, UserManager<IdentityUser> user)
  {
    _role = role;
    _user = user;
  }

  // Adminロールの作成&ログインユーザ-を登録
  [Authorize]
  public async Task<IActionResult> Create()
  {
    var roleName = "Admin";
    var exist = await _role.RoleExistsAsync(roleName);
    // Adminが存在しない時のみ作成
    if (!exist)
    {
      await _role.CreateAsync(new IdentityRole(roleName));
    }

    var current = await _user.GetUserAsync(User);
    if (current != null)
    {
      // ログインユーザをAdminに追加
      await _user.AddToRoleAsync(current, roleName);
    }
    return Content("現在のユーザーにAdminロールを追加しました。");

  }

}
