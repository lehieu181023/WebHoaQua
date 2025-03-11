
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebHoaQua.Models;
using Newtonsoft.Json;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;


namespace WebHoaQua.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DonHangController : Controller
    {
        private readonly ShopContext db = new ShopContext();
        private const string KeyCache = "DonHang";
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<PartialViewResult> ListData()
        {
            List<Models.DonHang> listData = null;
            try
            {
                var list = db.DonHang.AsQueryable();

                listData = await list.OrderByDescending(g => g.NgayDat).ToListAsync();

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