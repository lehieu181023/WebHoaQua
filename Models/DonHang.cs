using System;
using System.Collections.Generic;

namespace WebHoaQua.Models;

public partial class DonHang
{
    public int MaDh { get; set; }

    public int? MaKh { get; set; }

    public DateTime? NgayDat { get; set; }

    public decimal? TongTien { get; set; }

    public string? TrangThai { get; set; }

    public DateTime? NgayHoanThanh { get; set; }

    public string? Email { get; set; }

    public string? HoTen { get; set; }

    public string? DiaChi { get; set; }
    public string? GhiChu { get; set; }
    public string? Sdt { get; set; }
    public bool IsRead { get; set; }

    public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; } = new List<ChiTietDonHang>();

    public virtual User? MaKhNavigation { get; set; }
}
