using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using WebHoaQua.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebHoaQua.Controllers
{
    public class GioHangController : Controller
    {
        private readonly ShopContext db = new ShopContext();

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult listdata() {
            var accountId = "";
            List<WebHoaQua.Models.GioHang> lstcart = null;
            if (User.Identity.IsAuthenticated)
            {
                accountId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            }
            int id = int.Parse(accountId);
            lstcart = db.GioHang.Where(m => m.MaKh == id).ToList();
            return PartialView(lstcart);
        }

        [HttpPost]
        [Authorize]
        public async Task<JsonResult> AddToCart(int? id, int quantity)
        {
            var accountId = "";
            if (User.Identity.IsAuthenticated)
            {
                accountId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            }
            else
            {
                return Json(new { success = false, message = "Vui lòng đăng nhập!" });
            }

            if (accountId.IsNullOrEmpty())
            {
                return Json(new { success = false, message = "Vui lòng đăng nhập!" });
            }

            var product = db.SanPham.Find(id);
            if (product == null)
            {
                return Json(new { success = false, message = "Sản phẩm không tồn tại!" });
            }

            if (product.SoLuongTon < quantity)
            {
                return Json(new { success = false, message = "Số lượng sản phẩm không đủ!" });
            }

            var cartItem = new GioHang
            {
                MaKh = int.Parse(accountId),
                MaSp = id,
                SoLuong = quantity
            };

            db.GioHang.Add(cartItem);
            db.SaveChanges();

            return Json(new { success = true, message = "Thêm giỏ hàng thành công!" });
        }
        [HttpPost]
        [Authorize]
        public async Task<JsonResult> EditCart(int? id, int quantity)
        {
            var accountId = "";
            if (User.Identity.IsAuthenticated)
            {
                accountId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            }
            else
            {
                return Json(new { success = false, message = "Vui lòng đăng nhập!" });
            }

            if (accountId.IsNullOrEmpty())
            {
                return Json(new { success = false, message = "Vui lòng đăng nhập!" });
            }

            var cartItem = db.GioHang.FirstOrDefault(m => m.MaKh == int.Parse(accountId) && m.MaSp == id);
            if (cartItem == null)
            {
                return Json(new { success = false, message = "Sản phẩm không tồn tại trong giỏ hàng!" });
            }

            var product = db.SanPham.Find(id);
            if (product == null)
            {
                return Json(new { success = false, message = "Sản phẩm không tồn tại!" });
            }

            if (product.SoLuongTon < quantity)
            {
                return Json(new { success = false, message = "Số lượng sản phẩm không đủ!" });
            }

            cartItem.SoLuong = quantity;
            db.SaveChanges();

            return Json(new { success = true, message = "Cập nhật giỏ hàng thành công!" });
        }

        [HttpPost]
        [Authorize]
        public async Task<JsonResult> DeleteFromCart(int? id)
        {
            var accountId = "";
            if (User.Identity.IsAuthenticated)
            {
                accountId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            }
            else
            {
                return Json(new { success = false, message = "Vui lòng đăng nhập!" });
            }

            if (accountId.IsNullOrEmpty())
            {
                return Json(new { success = false, message = "Vui lòng đăng nhập!" });
            }

            var cartItem = db.GioHang.FirstOrDefault(m => m.MaKh == int.Parse(accountId) && m.MaSp == id);
            if (cartItem == null)
            {
                return Json(new { success = false, message = "Sản phẩm không tồn tại trong giỏ hàng!" });
            }

            db.GioHang.Remove(cartItem);
            db.SaveChanges();

            return Json(new { success = true, message = "Xóa sản phẩm khỏi giỏ hàng thành công!" });
        }



    }
}
