Create Database [ShopHoaQuaOnline]
USE [ShopHoaQuaOnline]
GO
/****** Object:  Table [dbo].[ChiTietDonHang]    Script Date: 2/26/2025 4:26:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDonHang](
	[MaCTDH] [int] IDENTITY(1,1) NOT NULL,
	[MaDH] [int] NULL,
	[MaSP] [int] NULL,
	[SoLuong] [int] NOT NULL,
	[DonGia] [decimal](10, 2) NOT NULL,
	[ThanhTien]  AS ([SoLuong]*[DonGia]) PERSISTED,
PRIMARY KEY CLUSTERED 
(
	[MaCTDH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhMucSanPham]    Script Date: 2/26/2025 4:26:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMucSanPham](
	[MaDM] [int] IDENTITY(1,1) NOT NULL,
	[TenDanhMuc] [nvarchar](100) NOT NULL,
	[TrangThai] [bit] NOT NULL,
	[CreateDay] [datetime] NOT NULL,
 CONSTRAINT [PK__DanhMucS__2725866ED337C1FA] PRIMARY KEY CLUSTERED 
(
	[MaDM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonHang]    Script Date: 2/26/2025 4:26:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonHang](
	[MaDH] [int] IDENTITY(1,1) NOT NULL,
	[MaKH] [int] NULL,
	[NgayDat] [datetime] NULL,
	[TongTien] [decimal](10, 2) NULL,
	[TrangThai] [nvarchar](50) NULL,
	[NgayHoanThanh] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GioHang]    Script Date: 2/26/2025 4:26:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GioHang](
	[MaGioHang] [int] IDENTITY(1,1) NOT NULL,
	[MaKH] [int] NULL,
	[MaSP] [int] NULL,
	[SoLuong] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaGioHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 2/26/2025 4:26:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaSP] [int] IDENTITY(1,1) NOT NULL,
	[TenSP] [nvarchar](100) NOT NULL,
	[MoTa] [nvarchar](255) NULL,
	[Gia] [decimal](10, 2) NOT NULL,
	[SoLuongTon] [int] NULL,
	[HinhAnh] [nvarchar](255) NULL,
	[MaDM] [int] NULL,
	[TrangThai] [bit] NOT NULL,
	[CreateDay] [datetime] NOT NULL,
 CONSTRAINT [PK__SanPham__2725081CD196C90F] PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2/26/2025 4:26:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[MaUS] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[SDT] [nvarchar](15) NOT NULL,
	[MatKhau] [nvarchar](255) NOT NULL,
	[DiaChi] [nvarchar](255) NULL,
	[NgayDangKy] [datetime] NULL,
	[Role] [nvarchar](15) NULL,
	[TrangThai] [bit] NOT NULL,
 CONSTRAINT [PK__KhachHan__2725CF1EEE0CCC83] PRIMARY KEY CLUSTERED 
(
	[MaUS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DanhMucSanPham] ON 

INSERT [dbo].[DanhMucSanPham] ([MaDM], [TenDanhMuc], [TrangThai], [CreateDay]) VALUES (9, N'Dâu tây', 1, CAST(N'2025-02-22T07:00:12.150' AS DateTime))
INSERT [dbo].[DanhMucSanPham] ([MaDM], [TenDanhMuc], [TrangThai], [CreateDay]) VALUES (10, N'Xoài', 1, CAST(N'2025-02-22T07:38:46.017' AS DateTime))
SET IDENTITY_INSERT [dbo].[DanhMucSanPham] OFF
GO
SET IDENTITY_INSERT [dbo].[SanPham] ON 

INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MoTa], [Gia], [SoLuongTon], [HinhAnh], [MaDM], [TrangThai], [CreateDay]) VALUES (1, N'Dâu tây mỹ lai', N'Ngonnnnnnnnnnnnnnnnnnnnnnn', CAST(130000.00 AS Decimal(10, 2)), 20, N'/uploads/image.jpg', 10, 1, CAST(N'2025-02-26T11:44:48.650' AS DateTime))
SET IDENTITY_INSERT [dbo].[SanPham] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([MaUS], [HoTen], [Email], [SDT], [MatKhau], [DiaChi], [NgayDangKy], [Role], [TrangThai]) VALUES (1, N'admin', N'admin@gmail.com', N'0316548947', N'admin', N'admin/admin/admin', CAST(N'2025-02-26T15:53:00.377' AS DateTime), N'Admin', 0)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__KhachHan__A9D1053414571D61]    Script Date: 2/26/2025 4:26:45 PM ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [UQ__KhachHan__A9D1053414571D61] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__KhachHan__CA1930A5DE83432C]    Script Date: 2/26/2025 4:26:45 PM ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [UQ__KhachHan__CA1930A5DE83432C] UNIQUE NONCLUSTERED 
(
	[SDT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DanhMucSanPham] ADD  CONSTRAINT [DF_DanhMucSanPham_TrangThai]  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[DanhMucSanPham] ADD  CONSTRAINT [DF_DanhMucSanPham_CreateDay]  DEFAULT (getdate()) FOR [CreateDay]
GO
ALTER TABLE [dbo].[DonHang] ADD  DEFAULT (getdate()) FOR [NgayDat]
GO
ALTER TABLE [dbo].[DonHang] ADD  DEFAULT ((0)) FOR [TongTien]
GO
ALTER TABLE [dbo].[DonHang] ADD  DEFAULT (N'Chờ xử lý') FOR [TrangThai]
GO
ALTER TABLE [dbo].[SanPham] ADD  CONSTRAINT [DF__SanPham__SoLuong__3E52440B]  DEFAULT ((0)) FOR [SoLuongTon]
GO
ALTER TABLE [dbo].[SanPham] ADD  CONSTRAINT [DF_SanPham_TrangThai]  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[SanPham] ADD  CONSTRAINT [DF_SanPham_CreateDay]  DEFAULT (getdate()) FOR [CreateDay]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF__KhachHang__NgayD__398D8EEE]  DEFAULT (getdate()) FOR [NgayDangKy]
GO
ALTER TABLE [dbo].[ChiTietDonHang]  WITH CHECK ADD FOREIGN KEY([MaDH])
REFERENCES [dbo].[DonHang] ([MaDH])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChiTietDonHang]  WITH CHECK ADD  CONSTRAINT [FK__ChiTietDon__MaSP__4CA06362] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[ChiTietDonHang] CHECK CONSTRAINT [FK__ChiTietDon__MaSP__4CA06362]
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [FK__DonHang__MaKH__45F365D3] FOREIGN KEY([MaKH])
REFERENCES [dbo].[User] ([MaUS])
GO
ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [FK__DonHang__MaKH__45F365D3]
GO
ALTER TABLE [dbo].[GioHang]  WITH CHECK ADD  CONSTRAINT [FK__GioHang__MaKH__4222D4EF] FOREIGN KEY([MaKH])
REFERENCES [dbo].[User] ([MaUS])
GO
ALTER TABLE [dbo].[GioHang] CHECK CONSTRAINT [FK__GioHang__MaKH__4222D4EF]
GO
ALTER TABLE [dbo].[GioHang]  WITH CHECK ADD  CONSTRAINT [FK__GioHang__MaSP__4316F928] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[GioHang] CHECK CONSTRAINT [FK__GioHang__MaSP__4316F928]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK__SanPham__MaDM__3F466844] FOREIGN KEY([MaDM])
REFERENCES [dbo].[DanhMucSanPham] ([MaDM])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK__SanPham__MaDM__3F466844]
GO
