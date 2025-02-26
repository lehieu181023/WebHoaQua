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

    public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; } = new List<ChiTietDonHang>();

    public virtual User? MaKhNavigation { get; set; }
}
