
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebHoaQua.Models;
using Newtonsoft.Json;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;


namespace WebHoaQua.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChiTietDonHangController : Controller
    {
        private readonly ShopContext db = new ShopContext();
        private const string KeyCache = "ChiTietDonHang";

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult> Index(int MaDh = 0)
        {
            var donhang = await db.DonHang.FindAsync(MaDh);
            donhang.IsRead = true;
            await db.SaveChangesAsync();
            return View(donhang);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<PartialViewResult> ListData(int MaDh = 0)
        {
            List<Models.ChiTietDonHang> listData = null;
            try
            {
                var list = db.ChiTietDonHang.Where(g => g.MaDh == MaDh).AsQueryable();

                listData = await list.ToListAsync();

            }
            catch (Exception ex)
            {
                
            }
            return PartialView(listData);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<JsonResult> Status(int? id,string status)
        {
            if (id == null)
            {
                return Json(new { success = false, message = "Id không được để trống" });
            }
            var objData = await db.DonHang.FindAsync(id);
            if (objData == null)
            {
                return Json(new { success = false, message = "Bản ghi đã bị xóa" });
            }
            try
            {
                objData.TrangThai = status;
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {

                return Json(new { success = false, message = "Không thay đổi được trạng thái bản ghi này" });
            }

            return Json(new { success = true, message = "Bản ghi đã được cập nhật trạng thái thành công" });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}