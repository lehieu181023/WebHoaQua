using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebHoaQua.Models;


namespace WebHoaQua.Controllers
{
    public class AccountController : Controller
    {
        private readonly ShopContext db = new ShopContext();
        public IActionResult login()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> loginAction(string UserName, string PassWord)
        {
            var user = db.User.FirstOrDefault(u =>
                u.Email == UserName ||
                u.Sdt == UserName);
            if (user == null) {
                return Json(new { success = false, message = "Tài khoản không tồn tại" });
            }
            if (user != null && new PasswordHelper().VerifyPassword(user.MatKhau,PassWord))
            {
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Role, user.Role),
                        new Claim(ClaimTypes.NameIdentifier, user.MaUs.ToString())
                    };

                var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                try
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
                }
                catch (Exception e)
                {
                    return Json(new { success = false, message = e.Message });
                }
            }
            else {
                return Json(new { success = false, message = "Mật khẩu không chính xác" });
            }
            return Json(new { success = true, message = "Đăng nhập thành công" });
        }
        [HttpPost]
        public async Task<JsonResult> registration([Bind("MaUs,HoTen,Email,Sdt,MatKhau,DiaChi")] Models.User obj,string repass = "")
        {
            if (obj.MatKhau != repass) {
                return Json(new { success = false, message = "Mật khẩu nhập lại không đúng" });
            }
            try
            {
                if (ModelState.IsValid)
                {
                    obj.MatKhau = new PasswordHelper().HashPassword(obj.MatKhau);
                    obj.Role = "Customer";
                    obj.TrangThai = true;
                    db.User.Add(obj);
                    await db.SaveChangesAsync();
                }
                else
                {
                    return Json(new { success = false, message = "Lỗi dữ liệu nhập" });
                }
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is SqlException sqlEx)
                {
                    if (sqlEx.Number == 2627 || sqlEx.Number == 2601) // Lỗi UNIQUE constraint
                    {
                        return Json(new { success = false, message = "Email hoặc Số điện thoại đã tồn tại!" });
                    }
                }

                return Json(new { success = false, message = "Đăng ký thất bại, vui lòng thử lại!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Đăng ký thất bại" });
            }
            return Json(new { success = true, message = "Đăng ký thành công" });
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View("login");
        }
    }
}
