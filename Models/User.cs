using System;
using System.Collections.Generic;

namespace WebHoaQua.Models;

public partial class User
{
    public int MaUs { get; set; }

    public string HoTen { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Sdt { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public string? DiaChi { get; set; }

    public DateTime? NgayDangKy { get; set; }

    public string? Role { get; set; }

    public bool TrangThai { get; set; }

    public virtual ICollection<DonHang> DonHangs { get; set; } = new List<DonHang>();

    public virtual ICollection<GioHang> GioHangs { get; set; } = new List<GioHang>();
}
