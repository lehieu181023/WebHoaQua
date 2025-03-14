
USE [master]
GO
/****** Object:  Database [ShopHoaQuaOnline]    Script Date: 3/11/2025 4:29:34 PM ******/
CREATE DATABASE [ShopHoaQuaOnline]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ShopHoaQuaOnline', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ShopHoaQuaOnline.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ShopHoaQuaOnline_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ShopHoaQuaOnline_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ShopHoaQuaOnline] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ShopHoaQuaOnline].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ShopHoaQuaOnline] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ShopHoaQuaOnline] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ShopHoaQuaOnline] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ShopHoaQuaOnline] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ShopHoaQuaOnline] SET ARITHABORT OFF 
GO
ALTER DATABASE [ShopHoaQuaOnline] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ShopHoaQuaOnline] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ShopHoaQuaOnline] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ShopHoaQuaOnline] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ShopHoaQuaOnline] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ShopHoaQuaOnline] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ShopHoaQuaOnline] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ShopHoaQuaOnline] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ShopHoaQuaOnline] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ShopHoaQuaOnline] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ShopHoaQuaOnline] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ShopHoaQuaOnline] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ShopHoaQuaOnline] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ShopHoaQuaOnline] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ShopHoaQuaOnline] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ShopHoaQuaOnline] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ShopHoaQuaOnline] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ShopHoaQuaOnline] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ShopHoaQuaOnline] SET  MULTI_USER 
GO
ALTER DATABASE [ShopHoaQuaOnline] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ShopHoaQuaOnline] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ShopHoaQuaOnline] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ShopHoaQuaOnline] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ShopHoaQuaOnline] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ShopHoaQuaOnline] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ShopHoaQuaOnline] SET QUERY_STORE = ON
GO
ALTER DATABASE [ShopHoaQuaOnline] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ShopHoaQuaOnline]
GO
/****** Object:  Table [dbo].[ChiTietDonHang]    Script Date: 3/11/2025 4:29:35 PM ******/
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
/****** Object:  Table [dbo].[DanhMucSanPham]    Script Date: 3/11/2025 4:29:35 PM ******/
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
/****** Object:  Table [dbo].[DonHang]    Script Date: 3/11/2025 4:29:35 PM ******/
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
	[Email] [nvarchar](max) NULL,
	[HoTen] [nvarchar](max) NULL,
	[DiaChi] [nvarchar](max) NULL,
	[GhiChu] [nvarchar](max) NULL,
	[Sdt] [nchar](11) NULL,
	[IsRead] [bit] NOT NULL,
 CONSTRAINT [PK__DonHang__272586619B5734B9] PRIMARY KEY CLUSTERED 
(
	[MaDH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GioHang]    Script Date: 3/11/2025 4:29:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GioHang](
	[MaGioHang] [int] IDENTITY(1,1) NOT NULL,
	[MaKh] [int] NULL,
	[MaSP] [int] NULL,
	[SoLuong] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaGioHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LienHe]    Script Date: 3/11/2025 4:29:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LienHe](
	[MaLh] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[SDT] [nchar](11) NULL,
	[ChuDe] [nvarchar](max) NULL,
	[TinNhan] [nvarchar](max) NULL,
	[CreateDay] [datetime] NOT NULL,
	[IsRead] [bit] NOT NULL,
 CONSTRAINT [PK_LienHe] PRIMARY KEY CLUSTERED 
(
	[MaLh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 3/11/2025 4:29:35 PM ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 3/11/2025 4:29:35 PM ******/
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
SET IDENTITY_INSERT [dbo].[DonHang] ON 

INSERT [dbo].[DonHang] ([MaDH], [MaKH], [NgayDat], [TongTien], [TrangThai], [NgayHoanThanh], [Email], [HoTen], [DiaChi], [GhiChu], [Sdt], [IsRead]) VALUES (1, 5, CAST(N'2025-03-11T15:44:18.510' AS DateTime), CAST(1090000.00 AS Decimal(10, 2)), N'Đang xử lý', NULL, N'admin@gmail.com', N'admin', N'admin/admin/admin', NULL, N'0316548947 ', 1)
SET IDENTITY_INSERT [dbo].[DonHang] OFF
GO
SET IDENTITY_INSERT [dbo].[LienHe] ON 

INSERT [dbo].[LienHe] ([MaLh], [HoTen], [Email], [SDT], [ChuDe], [TinNhan], [CreateDay], [IsRead]) VALUES (1, N'admin', N'admin@gmail.com', N'0316548947 ', N'asdsad', N'èasasds', CAST(N'2025-03-11T15:57:27.060' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[LienHe] OFF
GO
SET IDENTITY_INSERT [dbo].[SanPham] ON 

INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MoTa], [Gia], [SoLuongTon], [HinhAnh], [MaDM], [TrangThai], [CreateDay]) VALUES (1, N'Dâu tây mỹ lai', N'Ngonnnnnnnnnnnnnnnnnnnnnnn', CAST(130000.00 AS Decimal(10, 2)), 997, N'/uploads/OIP.jpg', 9, 1, CAST(N'2025-02-26T11:44:48.650' AS DateTime))
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MoTa], [Gia], [SoLuongTon], [HinhAnh], [MaDM], [TrangThai], [CreateDay]) VALUES (3, N'Dâu tây đà lạt', N'Cùng với Sapa, Đà Lạt là 1 trong 2 khu vực có khí hậu ôn đới ở Việt Nam. Trong đó, thành phố ngàn hoa có khí hậu quanh mát mẻ, nhiệt độ dao động từ 18 - 25 độ C, rất thích hợp để trồng dâu tây. ', CAST(395000.00 AS Decimal(10, 2)), 189, N'/uploads/OIP (1).jpg', 9, 1, CAST(N'2025-02-28T16:37:44.777' AS DateTime))
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MoTa], [Gia], [SoLuongTon], [HinhAnh], [MaDM], [TrangThai], [CreateDay]) VALUES (4, N'Xoài cát Hòa Lộc', NULL, CAST(50000.00 AS Decimal(10, 2)), 19987, N'/uploads/xoai-cat-hoa-loc-thom-ngon-dep-ma-da-cang-bong.jpg', 10, 1, CAST(N'2025-03-10T11:50:00.110' AS DateTime))
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MoTa], [Gia], [SoLuongTon], [HinhAnh], [MaDM], [TrangThai], [CreateDay]) VALUES (5, N'Xoài Thái Lan', NULL, CAST(60000.00 AS Decimal(10, 2)), 292, N'/uploads/cay-xoai-thai-lan-hat-lep.jpg', 10, 1, CAST(N'2025-03-10T11:50:42.407' AS DateTime))
SET IDENTITY_INSERT [dbo].[SanPham] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([MaUS], [HoTen], [Email], [SDT], [MatKhau], [DiaChi], [NgayDangKy], [Role], [TrangThai]) VALUES (5, N'admin', N'admin@gmail.com', N'01111111111', N'AQAAAAIAAYagAAAAEGLRpvyJ5wZgnaUktdUauT8pViXVp2k05VdZxUQXnjdj/c/dRlL8lF9mw2RufR2MVQ==', N'admin/admin/admin', CAST(N'2025-02-26T17:56:08.070' AS DateTime), N'Admin', 1)
INSERT [dbo].[User] ([MaUS], [HoTen], [Email], [SDT], [MatKhau], [DiaChi], [NgayDangKy], [Role], [TrangThai]) VALUES (10, N'Customer', N'Customer@gmail.com', N'02222222222', N'AQAAAAIAAYagAAAAEIlD8kQBwWwzIIuY0YZts9LsivsrBZZOZBXvstfcGa8snULmtWTt16YWKEj6IMDhOQ==', N'Customer/Customer/Customer', CAST(N'2025-03-11T16:27:57.250' AS DateTime), N'Custumer', 1)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__KhachHan__A9D1053414571D61]    Script Date: 3/11/2025 4:29:35 PM ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [UQ__KhachHan__A9D1053414571D61] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__KhachHan__CA1930A5DE83432C]    Script Date: 3/11/2025 4:29:35 PM ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [UQ__KhachHan__CA1930A5DE83432C] UNIQUE NONCLUSTERED 
(
	[SDT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DanhMucSanPham] ADD  CONSTRAINT [DF_DanhMucSanPham_TrangThai]  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[DanhMucSanPham] ADD  CONSTRAINT [DF_DanhMucSanPham_CreateDay]  DEFAULT (getdate()) FOR [CreateDay]
GO
ALTER TABLE [dbo].[DonHang] ADD  CONSTRAINT [DF__DonHang__NgayDat__46E78A0C]  DEFAULT (getdate()) FOR [NgayDat]
GO
ALTER TABLE [dbo].[DonHang] ADD  CONSTRAINT [DF__DonHang__TongTie__47DBAE45]  DEFAULT ((0)) FOR [TongTien]
GO
ALTER TABLE [dbo].[DonHang] ADD  CONSTRAINT [DF__DonHang__TrangTh__48CFD27E]  DEFAULT (N'Chờ xử lý') FOR [TrangThai]
GO
ALTER TABLE [dbo].[DonHang] ADD  CONSTRAINT [DF_DonHang_IsRead]  DEFAULT ((0)) FOR [IsRead]
GO
ALTER TABLE [dbo].[LienHe] ADD  CONSTRAINT [DF_LienHe_CreateDay]  DEFAULT (getdate()) FOR [CreateDay]
GO
ALTER TABLE [dbo].[LienHe] ADD  CONSTRAINT [DF_LienHe_IsRead]  DEFAULT ((0)) FOR [IsRead]
GO
ALTER TABLE [dbo].[SanPham] ADD  CONSTRAINT [DF__SanPham__SoLuong__3E52440B]  DEFAULT ((0)) FOR [SoLuongTon]
GO
ALTER TABLE [dbo].[SanPham] ADD  CONSTRAINT [DF_SanPham_TrangThai]  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[SanPham] ADD  CONSTRAINT [DF_SanPham_CreateDay]  DEFAULT (getdate()) FOR [CreateDay]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF__KhachHang__NgayD__398D8EEE]  DEFAULT (getdate()) FOR [NgayDangKy]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_Role]  DEFAULT (N'Customer') FOR [Role]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_TrangThai]  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[ChiTietDonHang]  WITH CHECK ADD  CONSTRAINT [FK__ChiTietDon__MaDH__4BAC3F29] FOREIGN KEY([MaDH])
REFERENCES [dbo].[DonHang] ([MaDH])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChiTietDonHang] CHECK CONSTRAINT [FK__ChiTietDon__MaDH__4BAC3F29]
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
ALTER TABLE [dbo].[GioHang]  WITH CHECK ADD  CONSTRAINT [FK__GioHang__MaKH__4222D4EF] FOREIGN KEY([MaKh])
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
USE [master]
GO
ALTER DATABASE [ShopHoaQuaOnline] SET  READ_WRITE 
GO
