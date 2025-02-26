using System;
using System.Collections.Generic;

namespace WebHoaQua.Models;

public partial class SanPham
{
    public int MaSp { get; set; }

    public string TenSp { get; set; } = null!;

    public string? MoTa { get; set; }

    public decimal Gia { get; set; }

    public int? SoLuongTon { get; set; }

    public string? HinhAnh { get; set; }

    public int? MaDm { get; set; }

    public bool TrangThai { get; set; }

    public DateTime CreateDay { get; set; }

    public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; } = new List<ChiTietDonHang>();

    public virtual ICollection<GioHang> GioHangs { get; set; } = new List<GioHang>();

    public virtual DanhMucSanPham? MaDmNavigation { get; set; }
}
