USE [ShopTheThao]
GO
/****** Object:  Table [dbo].[Administrator]    Script Date: 24/12/2020 5:06:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Administrator](
	[TaiKhoan] [varchar](500) NOT NULL,
	[MatKhau] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[TaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BinhLuan]    Script Date: 24/12/2020 5:06:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BinhLuan](
	[BLMa] [int] IDENTITY(1,1) NOT NULL,
	[SPMa] [varchar](50) NULL,
	[BLTinNhan] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[BLMa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CTDonHang]    Script Date: 24/12/2020 5:06:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CTDonHang](
	[DHMa] [int] NOT NULL,
	[SPMa] [varchar](50) NOT NULL,
	[CTDHSoLuong] [int] NULL,
	[CTDHThanhTien] [varchar](50) NULL,
 CONSTRAINT [PK_CTDonHang] PRIMARY KEY CLUSTERED 
(
	[DHMa] ASC,
	[SPMa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DonHang]    Script Date: 24/12/2020 5:06:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DonHang](
	[DHMa] [int] IDENTITY(1,1) NOT NULL,
	[KHSdt] [varchar](20) NULL,
	[KHTinNhan] [nvarchar](max) NULL,
	[DHTGDatHang] [varchar](50) NULL,
	[DHNoidung] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[DHMa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 24/12/2020 5:06:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KhachHang](
	[KHSdt] [varchar](20) NOT NULL,
	[KHHoTen] [nvarchar](200) NULL,
	[KHEmail] [varchar](100) NULL,
	[KHDiaChi] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[KHSdt] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LoaiSanPham]    Script Date: 24/12/2020 5:06:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiSanPham](
	[LSPMa] [int] IDENTITY(1,1) NOT NULL,
	[TLMa] [int] NULL,
	[LSPTen] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[LSPMa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhaSanXuat]    Script Date: 24/12/2020 5:06:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhaSanXuat](
	[NSXMa] [int] IDENTITY(1,1) NOT NULL,
	[NSXTen] [nvarchar](100) NULL,
	[NSXSdt] [varchar](20) NULL,
	[NSXEmail] [varchar](50) NULL,
	[NSXDiaChi] [nvarchar](max) NULL,
	[NSXThongTin] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[NSXMa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 24/12/2020 5:06:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SanPham](
	[SPMa] [varchar](50) NOT NULL,
	[NSXMa] [int] NULL,
	[LSPMa] [int] NULL,
	[SPTen] [nvarchar](200) NULL,
	[SPSize] [varchar](100) NULL,
	[SPGiaBan] [varchar](10) NULL,
	[SPGIamGia] [int] NULL,
	[SPAnh] [nvarchar](max) NULL,
	[SPNgayUpdate] [varchar](50) NULL,
	[SPNoiDung] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[SPMa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TheLoai]    Script Date: 24/12/2020 5:06:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TheLoai](
	[TLMa] [int] IDENTITY(1,1) NOT NULL,
	[TLTen] [nvarchar](100) NULL,
	[TLAnh] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[TLMa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[Administrator] ([TaiKhoan], [MatKhau]) VALUES (N'Admin', N'123456')
INSERT [dbo].[CTDonHang] ([DHMa], [SPMa], [CTDHSoLuong], [CTDHThanhTien]) VALUES (3, N'G0001f', 1, N'900000')
INSERT [dbo].[CTDonHang] ([DHMa], [SPMa], [CTDHSoLuong], [CTDHThanhTien]) VALUES (4, N'AK001', 1, N'510000')
INSERT [dbo].[CTDonHang] ([DHMa], [SPMa], [CTDHSoLuong], [CTDHThanhTien]) VALUES (4, N'G0001f', 1, N'900000')
SET IDENTITY_INSERT [dbo].[DonHang] ON 

INSERT [dbo].[DonHang] ([DHMa], [KHSdt], [KHTinNhan], [DHTGDatHang], [DHNoidung]) VALUES (3, N'0375861407', N'aa', N'18/12/2020 9:45:10 PM', N'0')
INSERT [dbo].[DonHang] ([DHMa], [KHSdt], [KHTinNhan], [DHTGDatHang], [DHNoidung]) VALUES (4, N'012680000', N'aaaaaaa', N'18/12/2020 10:28:34 PM', NULL)
SET IDENTITY_INSERT [dbo].[DonHang] OFF
INSERT [dbo].[KhachHang] ([KHSdt], [KHHoTen], [KHEmail], [KHDiaChi]) VALUES (N'012680000', N'anh ngoc', N'an@gmail.com', N'Phạm Hữu lầu')
INSERT [dbo].[KhachHang] ([KHSdt], [KHHoTen], [KHEmail], [KHDiaChi]) VALUES (N'0375861407', N'nguyen bang', N'ncb@gmail.com', N'Phạm Hữu lầu')
SET IDENTITY_INSERT [dbo].[LoaiSanPham] ON 

INSERT [dbo].[LoaiSanPham] ([LSPMa], [TLMa], [LSPTen]) VALUES (1, 1, N'Áo thể thao')
INSERT [dbo].[LoaiSanPham] ([LSPMa], [TLMa], [LSPTen]) VALUES (2, 2, N'Quần thể thao')
INSERT [dbo].[LoaiSanPham] ([LSPMa], [TLMa], [LSPTen]) VALUES (3, 3, N'Giày thể thao')
INSERT [dbo].[LoaiSanPham] ([LSPMa], [TLMa], [LSPTen]) VALUES (4, 4, N'Mũ thể thao')
INSERT [dbo].[LoaiSanPham] ([LSPMa], [TLMa], [LSPTen]) VALUES (17, 6, N'Găng tay thể thao')
SET IDENTITY_INSERT [dbo].[LoaiSanPham] OFF
SET IDENTITY_INSERT [dbo].[NhaSanXuat] ON 

INSERT [dbo].[NhaSanXuat] ([NSXMa], [NSXTen], [NSXSdt], [NSXEmail], [NSXDiaChi], [NSXThongTin]) VALUES (1, N'Adidas', N'01212692802', N'adidas@gmail.com', N'TpHCM', N'Thông tin tự gút gồ')
INSERT [dbo].[NhaSanXuat] ([NSXMa], [NSXTen], [NSXSdt], [NSXEmail], [NSXDiaChi], [NSXThongTin]) VALUES (2, N'Nike', N'01212692802', N'nike@gmail.com', N'TpHCM', N'Thông tin tự gút gồ')
INSERT [dbo].[NhaSanXuat] ([NSXMa], [NSXTen], [NSXSdt], [NSXEmail], [NSXDiaChi], [NSXThongTin]) VALUES (6, N'PUMA', N'01212692891', N'puma@gmail.com', N'TpHCM', N'Thông tin tự gút gồ')
INSERT [dbo].[NhaSanXuat] ([NSXMa], [NSXTen], [NSXSdt], [NSXEmail], [NSXDiaChi], [NSXThongTin]) VALUES (7, N'Under Armour', N'021338329', N'UnderArmouri@gmail.com', N'USA', N'Từ mỹ')
SET IDENTITY_INSERT [dbo].[NhaSanXuat] OFF
INSERT [dbo].[SanPham] ([SPMa], [NSXMa], [LSPMa], [SPTen], [SPSize], [SPGiaBan], [SPGIamGia], [SPAnh], [SPNgayUpdate], [SPNoiDung]) VALUES (N'AK001', 1, 1, N'Áo Adiadas nam', N'XL,XXL,L', N'510000', 0, N'/aott.jpg', N'10/08/2020 6:43:36 AM', N'Không có mô tả')
INSERT [dbo].[SanPham] ([SPMa], [NSXMa], [LSPMa], [SPTen], [SPSize], [SPGiaBan], [SPGIamGia], [SPAnh], [SPNgayUpdate], [SPNoiDung]) VALUES (N'AT001', 1, 1, N'Áo Adiadas nữ', N'S,M,L...', N'380000', 0, N'/ao-the-thao-nam.jpg', N'10/09/2020 6:43:36 AM', N'Không có mô tả')
INSERT [dbo].[SanPham] ([SPMa], [NSXMa], [LSPMa], [SPTen], [SPSize], [SPGiaBan], [SPGIamGia], [SPAnh], [SPNgayUpdate], [SPNoiDung]) VALUES (N'AT002', 2, 1, N'Áo Nike nam', N'L,XL,XXL', N'530000', 0, N'/images.jpg', N'10/10/2017 6:43:36 AM', N'Không có mô tả')
INSERT [dbo].[SanPham] ([SPMa], [NSXMa], [LSPMa], [SPTen], [SPSize], [SPGiaBan], [SPGIamGia], [SPAnh], [SPNgayUpdate], [SPNoiDung]) VALUES (N'AT003', 2, 1, N'Áo Nike nữ', N'S,M,L...', N'370000', 5, N'aott2.jpg', N'10/11/2020 6:43:36 AM', N'<p>Hello, World!</p>')
INSERT [dbo].[SanPham] ([SPMa], [NSXMa], [LSPMa], [SPTen], [SPSize], [SPGiaBan], [SPGIamGia], [SPAnh], [SPNgayUpdate], [SPNoiDung]) VALUES (N'G0001f', 1, 3, N'Giày đá bóng A', N'39, 40, 41', N'900000', 4, N'giaydb3.jpg', N'14/12/2020', N'<p>Hello, World!</p>')
INSERT [dbo].[SanPham] ([SPMa], [NSXMa], [LSPMa], [SPTen], [SPSize], [SPGiaBan], [SPGIamGia], [SPAnh], [SPNgayUpdate], [SPNoiDung]) VALUES (N'G003', 2, 3, N'Giày đá bóng nike', N'39,40,41', N'800000', 0, N'images (4).jpg', N'18/12/2020', N'<p><em>Hello, World!</em></p>')
INSERT [dbo].[SanPham] ([SPMa], [NSXMa], [LSPMa], [SPTen], [SPSize], [SPGiaBan], [SPGIamGia], [SPAnh], [SPNgayUpdate], [SPNoiDung]) VALUES (N'G004', 1, 3, N'Giày đá bóng Adidas', N'39,40,41', N'900000', 2, N'giaydb2.jpg', N'18/12/2020', N'<p><em>Hello, World!</em></p>')
INSERT [dbo].[SanPham] ([SPMa], [NSXMa], [LSPMa], [SPTen], [SPSize], [SPGiaBan], [SPGIamGia], [SPAnh], [SPNgayUpdate], [SPNoiDung]) VALUES (N'G01123', 6, 1, N'Áo Puma', N'M, L ,X', N'300000', 5, N'images (1).jpg', N'14/12/2020', N'<p>Hello, World!</p>')
INSERT [dbo].[SanPham] ([SPMa], [NSXMa], [LSPMa], [SPTen], [SPSize], [SPGiaBan], [SPGIamGia], [SPAnh], [SPNgayUpdate], [SPNoiDung]) VALUES (N'M031', 2, 4, N'Mũ thể thao', N'M, L ,X', N'200000', 0, N'muthethao.jpg', N'24/12/2020', N'<p>Hello, World!</p>')
INSERT [dbo].[SanPham] ([SPMa], [NSXMa], [LSPMa], [SPTen], [SPSize], [SPGiaBan], [SPGIamGia], [SPAnh], [SPNgayUpdate], [SPNoiDung]) VALUES (N'N021', 2, 4, N'Mu nike', N'M, L ,X', N'300000', 0, N'mukhong.jpg', N'24/12/2020', N'<p>Hello, World!</p>')
INSERT [dbo].[SanPham] ([SPMa], [NSXMa], [LSPMa], [SPTen], [SPSize], [SPGiaBan], [SPGIamGia], [SPAnh], [SPNgayUpdate], [SPNoiDung]) VALUES (N'PM002', 6, 2, N'Quần Puma', N'M, L ,X', N'200000', 3, N'quan-the-thao.jpg', N'18/12/2020', N'<p style="text-align: left;"><em>Hello, World!</em></p>')
INSERT [dbo].[SanPham] ([SPMa], [NSXMa], [LSPMa], [SPTen], [SPSize], [SPGiaBan], [SPGIamGia], [SPAnh], [SPNgayUpdate], [SPNoiDung]) VALUES (N'U001', 7, 2, N'Quần Under S', N'M, L ,X', N'300000', 0, N'1g2_m2_l2_xl2_2xl2-8353.jpg', N'21/12/2020', N'<p>Hello, World!</p>')
INSERT [dbo].[SanPham] ([SPMa], [NSXMa], [LSPMa], [SPTen], [SPSize], [SPGiaBan], [SPGIamGia], [SPAnh], [SPNgayUpdate], [SPNoiDung]) VALUES (N'U002', 7, 1, N'Áo Under A', N'M, L ,X, XL, XXL', N'400000', 0, N'ao-the-thao-nam-under-armour-.jpg', N'21/12/2020', N'<p>Hello, World!</p>')
SET IDENTITY_INSERT [dbo].[TheLoai] ON 

INSERT [dbo].[TheLoai] ([TLMa], [TLTen], [TLAnh]) VALUES (1, N'Áo', N'MauAoDabong.png')
INSERT [dbo].[TheLoai] ([TLMa], [TLTen], [TLAnh]) VALUES (2, N'Quần', N'/Quantt.jpg')
INSERT [dbo].[TheLoai] ([TLMa], [TLTen], [TLAnh]) VALUES (3, N'Giày', N'/giaydabong.jpg')
INSERT [dbo].[TheLoai] ([TLMa], [TLTen], [TLAnh]) VALUES (4, N'Mũ(nón)', N'/nonthethao.jpg')
INSERT [dbo].[TheLoai] ([TLMa], [TLTen], [TLAnh]) VALUES (6, N'Găng tay', N'gangtay.jpg')
SET IDENTITY_INSERT [dbo].[TheLoai] OFF
ALTER TABLE [dbo].[BinhLuan]  WITH CHECK ADD FOREIGN KEY([SPMa])
REFERENCES [dbo].[SanPham] ([SPMa])
GO
ALTER TABLE [dbo].[CTDonHang]  WITH CHECK ADD FOREIGN KEY([DHMa])
REFERENCES [dbo].[DonHang] ([DHMa])
GO
ALTER TABLE [dbo].[CTDonHang]  WITH CHECK ADD FOREIGN KEY([SPMa])
REFERENCES [dbo].[SanPham] ([SPMa])
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD FOREIGN KEY([KHSdt])
REFERENCES [dbo].[KhachHang] ([KHSdt])
GO
ALTER TABLE [dbo].[LoaiSanPham]  WITH CHECK ADD FOREIGN KEY([TLMa])
REFERENCES [dbo].[TheLoai] ([TLMa])
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD FOREIGN KEY([LSPMa])
REFERENCES [dbo].[LoaiSanPham] ([LSPMa])
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD FOREIGN KEY([NSXMa])
REFERENCES [dbo].[NhaSanXuat] ([NSXMa])
GO
