using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace WebHoaQua.Models
{
    public partial class SanPham
    {
        ShopContext db = new ShopContext();

        public DanhMucSanPham DanhMucSanPham => db.DanhMucSanPham.Find(MaDm) ?? new DanhMucSanPham();

    }

    public partial class GioHang
    {
        ShopContext db = new ShopContext();
        public SanPham SanPham => db.SanPham.Find(MaSp) ?? new SanPham();
    }

    public partial class ChiTietDonHang
    {
        ShopContext db = new ShopContext();
        public SanPham SanPham => db.SanPham.Find(MaSp) ?? new SanPham();
    }

    public class TopSaleViewModel
    {
        public int MaSp { get; set; }
        public string TenSp { get; set; }
        public string HinhAnh { get; set; }
        public decimal DonGia { get; set; }
        public int SoLuongBan { get; set; }
        public decimal Revenue { get; set; }
    }


    public enum TrangThaiDonHang
    {
        [Display(Name = "Đang xử lý")]
        DangXuLy = 1,
        [Display(Name = "Đã hoàn thành")]
        DaHoanThanh = 2,
        [Display(Name = "Đang giao")]
        DaGiao = 3,
        [Display(Name = "Đã hủy")]
        DaHuy = 4
    }

}
