
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebHoaQua.Models;
using Newtonsoft.Json;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;


namespace WebHoaQua.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly ShopContext db = new ShopContext();
        private const string KeyCache = "User";
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<PartialViewResult> ListData()
        {
            List<Models.User> listData = null;
            try
            {
                var list = db.User.AsQueryable();

                listData = await list.OrderByDescending(g => g.NgayDangKy).ToListAsync();

            }
            catch (Exception ex)
            {
                
            }
            return PartialView(listData);
        }
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return Json(new { success = false, message = "Không được để trống Id" });
            }
            Models.User objData = await db.User.FindAsync(id);
            if (objData == null)
            {
                return Json(new { success = false, message = " Bản ghi không tồn tại" });
            }
            return PartialView(objData);
        }
        [Authorize(Roles = "Admin")]
        public PartialViewResult Create()
        {

            return PartialView();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<JsonResult> Create([Bind("MaUs,HoTen,Email,Sdt,MatKhau,DiaChi,NgayDangKy,Role,TrangThai")] Models.User obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    obj.MatKhau = new PasswordHelper().HashPassword(obj.MatKhau);
                    obj.TrangThai = (obj.TrangThai)? true : false;
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

                return Json(new { success = false, message = "Thêm mới thất bại, vui lòng thử lại!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Thêm mới thất bại" });
            }
            return Json(new { success = true, message = "Thêm mới thành công" });
        }

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return Json(new { success = false, message = "Id không được để trống" });
            }

            Models.User obj = await db.User.FindAsync(id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Bản ghi không tồn tại" });
            }
            return PartialView(obj);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]

        public async Task<JsonResult> EditPost([Bind("MaUs,HoTen,Email,Sdt,DiaChi,NgayDangKy,Role,TrangThai")] Models.User obj, int? MaUs)
        {
            if (MaUs == null)
            {
                return Json(new { success = false, message = "Id không được để trống" });
            }

            var objData = await db.User.FindAsync(MaUs);
            if (objData == null)
            {
                return Json(new { success = false, message = "Không thể lưu vì có người dùng khác đang sửa hoặc đã bị xóa" });
            }

            try
            {
                objData.HoTen = obj.HoTen;
                objData.Email = obj.Email;
                objData.Sdt = obj.Sdt;
                objData.DiaChi = obj.DiaChi;
                objData.Role = obj.Role;
                objData.TrangThai = obj.TrangThai;
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var entry = ex.Entries.Single();
                var databaseEntry = entry.GetDatabaseValues();
                if (databaseEntry == null)
                {
                    return Json(new { success = false, message = "Bản ghi này đã bị xóa bởi người dùng khác" });
                }
                else
                {
                    return Json(new { success = false, message = "Bản ghi này đã bị sửa bởi người dùng khác" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Không thể lưu được" });
            }

            return Json(new { success = true, message = "Cập nhật thành công" });
        }

        [Authorize(Roles = "Admin")]
        public JsonResult Delete(int? id)
        {
            User obj = null;

            if (id == null)
            {
                return Json(new { success = false, message = "Id không được để trống" });
            }
            try
            {
                obj = db.User.Find(id);
                if (obj != null)
                {
                    db.User.Remove(obj);
                    db.SaveChanges();
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Json(new { success = false, message = "Không xóa được bản ghi này" });
            }

            return Json(new { success = true, message = "Bản ghi đã được xóa thành công" });
        }

        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> Status(int? id)
        {
            if (id == null)
            {
                return Json(new { success = false, message = "Id không được để trống" });
            }
            var objData = await db.User.FindAsync(id);
            if (objData == null)
            {
                return Json(new { success = false, message = "Bản ghi đã bị xóa" });
            }
            try
            {
                objData.TrangThai = !objData.TrangThai;
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