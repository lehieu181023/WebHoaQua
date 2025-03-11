using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Security.Claims;
using WebHoaQua.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebHoaQua.Controllers
{
    public class ThanhToanController : Controller
    {
        private readonly ShopContext db = new ShopContext();

        [Authorize]
        public IActionResult Index()
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

            if (string.IsNullOrEmpty(accountId))
            {
                return Json(new { success = false, message = "Vui lòng đăng nhập!" });
            }

            var lstcar = db.GioHang.Where(m => m.MaKh == int.Parse(accountId)).ToList();
            var userinfor = db.User.Find(int.Parse(accountId));
            ViewData["userinfor"] = userinfor;
            ViewData["lstcart"] = lstcar;
            return View();
        }

        [Authorize]
        public async Task<IActionResult> CheckOut(string name, string phone, string address, string email, string note)
        {
            var accountId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(accountId))
            {
                return Json(new { success = false, message = "Vui lòng đăng nhập!" });
            }

            var user = db.User.Find(int.Parse(accountId));
            if (user == null)
            {
                return Json(new { success = false, message = "Tài khoản không tồn tại" });
            }

            var cartItems = db.GioHang.Where(c => c.MaKh == int.Parse(accountId)).ToList();
            if (cartItems.Count == 0)
            {
                return Json(new { success = false, message = "Giỏ hàng trống!" });
            }

            foreach (var item in cartItems)
            {
                var product = db.SanPham.Find(item.MaSp);
                if (product == null || item.SoLuong > product.SoLuongTon)
                {
                    return Json(new { success = false, message = "Số lượng sản phẩm không đủ!" });
                }
            }

            var total = cartItems.Sum(item => item.SoLuong * db.SanPham.Find(item.MaSp).Gia);

            var order = new DonHang
            {
                MaKh = int.Parse(accountId),
                TongTien = total,
                NgayDat = DateTime.Now,
                TrangThai = "Đang xử lý",
                HoTen = name,
                Sdt = phone,
                DiaChi = address,
                Email = email,
                GhiChu = note
            };
            db.DonHang.Add(order);
            await db.SaveChangesAsync();

            foreach (var item in cartItems)
            {
                var product = db.SanPham.Find(item.MaSp);
                var orderDetail = new ChiTietDonHang
                {
                    MaDh = order.MaDh,
                    MaSp = item.MaSp,
                    SoLuong = item.SoLuong,
                    DonGia = product.Gia,
                    ThanhTien = item.SoLuong * product.Gia
                };
                db.ChiTietDonHang.Add(orderDetail);

                product.SoLuongTon -= item.SoLuong;
                db.SanPham.Update(product);
            }

            db.GioHang.RemoveRange(cartItems);
            await db.SaveChangesAsync();

            return Json(new { success = true, message = "Tạo đơn hàng thành công!" });
        }
    }
}
