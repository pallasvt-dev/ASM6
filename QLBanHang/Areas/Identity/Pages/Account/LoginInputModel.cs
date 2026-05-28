using System.ComponentModel.DataAnnotations;

namespace QLBanHang.Areas.Identity.Pages.Account;

public class LoginInputModel
{
    [Required]
    [Display(Name = "Username hoặc Email")]
    public string UserName { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Mật khẩu")]
    public string Password { get; set; } = string.Empty;

    [Display(Name = "Ghi nhớ đăng nhập?")]
    public bool RememberMe { get; set; }
}
