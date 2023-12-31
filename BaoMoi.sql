USE [BaoMoi]
GO
/****** Object:  Table [dbo].[FileUpLoads]    Script Date: 07/30/2023 21:58:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FileUpLoads](
	[MaFile] [int] IDENTITY(1,1) NOT NULL,
	[TenFile] [text] NOT NULL,
	[ChuThichFile] [ntext] NOT NULL,
 CONSTRAINT [PK_FileUpLoads] PRIMARY KEY CLUSTERED 
(
	[MaFile] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VaiTro]    Script Date: 07/30/2023 21:58:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VaiTro](
	[MaVaiTro] [int] IDENTITY(1,1) NOT NULL,
	[TenVaiTro] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_VaiTro] PRIMARY KEY CLUSTERED 
(
	[MaVaiTro] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_delete]    Script Date: 07/30/2023 21:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_delete]
	@tenbang nvarchar(50),
	@dieukien nvarchar(50)
AS
begin
		declare @sql nvarchar(4000) set @sql=''
		set @sql = @sql + 'delete from '+ @tenbang + ' where '+ @dieukien
		exec(@sql)
end
GO
/****** Object:  StoredProcedure [dbo].[sp_select]    Script Date: 07/30/2023 21:58:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_select] @tenbang nvarchar(50)
AS
	begin 
		declare @sql nvarchar(4000) set @sql = ''
		set @sql = @sql + 'select * from ' + @tenbang
		exec(@sql)
	end
RETURN 0
GO
/****** Object:  Table [dbo].[DanhMuc]    Script Date: 07/30/2023 21:58:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMuc](
	[MaDanhMuc] [int] IDENTITY(1,1) NOT NULL,
	[TenDanhMuc] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_DanhMuc] PRIMARY KEY CLUSTERED 
(
	[MaDanhMuc] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FileBaiViet]    Script Date: 07/30/2023 21:58:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FileBaiViet](
	[MaBaiViet] [int] NOT NULL,
	[MaFile] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BaiViet]    Script Date: 07/30/2023 21:58:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaiViet](
	[MaBaiViet] [int] IDENTITY(1,1) NOT NULL,
	[TieuDe] [nvarchar](255) NOT NULL,
	[TomTat] [nvarchar](255) NOT NULL,
	[NoiDung] [ntext] NOT NULL,
	[HinhThuNho] [text] NOT NULL,
	[ChuThichHinh] [nvarchar](100) NULL,
	[LuotXem] [int] NOT NULL,
	[NgayDang] [datetime] NOT NULL,
	[MaNguoiDung] [int] NOT NULL,
	[MaDanhMuc] [int] NOT NULL,
 CONSTRAINT [PK_BaiViet] PRIMARY KEY CLUSTERED 
(
	[MaBaiViet] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BinhLuan]    Script Date: 07/30/2023 21:58:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BinhLuan](
	[MaBinhLuan] [int] IDENTITY(1,1) NOT NULL,
	[NoiDung] [ntext] NOT NULL,
	[NgayDang] [datetime] NOT NULL,
	[MaNguoiDung] [int] NOT NULL,
	[MaBaiViet] [int] NOT NULL,
 CONSTRAINT [PK_BinhLuan] PRIMARY KEY CLUSTERED 
(
	[MaBinhLuan] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguoiDung]    Script Date: 07/30/2023 21:58:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NguoiDung](
	[MaNguoiDung] [int] IDENTITY(1,1) NOT NULL,
	[TenNguoiDung] [nvarchar](50) NOT NULL,
	[Email] [varchar](255) NOT NULL,
	[MatKhau] [varchar](255) NOT NULL,
	[HinhDaiDien] [varchar](255) NULL,
	[NgaySinh] [datetime] NULL,
	[DiaChi] [ntext] NULL,
	[SDT] [int] NULL,
	[GioiTinh] [tinyint] NULL,
	[VaiTro] [int] NOT NULL,
 CONSTRAINT [PK_NguoiDung] PRIMARY KEY CLUSTERED 
(
	[MaNguoiDung] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertFileUpload]    Script Date: 07/30/2023 21:58:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertFileUpload] @tenfile text,@chuthichfile ntext
AS
begin
	insert into FileUpLoads values(@tenfile,@chuthichfile)
	end
GO
/****** Object:  StoredProcedure [dbo].[sp_updateFileUpload]    Script Date: 07/30/2023 21:58:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_updateFileUpload] @mafile int ,@tenfile text,@chuthichfile ntext
AS
begin
	update FileUpLoads set TenFile = @tenfile,ChuThichFile= @chuthichfile where MaFile = @mafile
	end
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertNguoiDung]    Script Date: 07/30/2023 21:58:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertNguoiDung] @tennguoidung nvarchar(50),@email text,@matkhau nvarchar(50),@hinhdaidien text,@ngaysinh datetime,
@diachi ntext,@sdt int,@gioitinh tinyint,@vaitro int
AS
begin
	insert into NguoiDung values(@tennguoidung,@email,@matkhau,@hinhdaidien,@ngaysinh,@diachi,@sdt,@gioitinh,@vaitro)
	end
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertVaiTro]    Script Date: 07/30/2023 21:58:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertVaiTro] @tenvaitro nvarchar(255)
AS
begin
	insert into VaiTro values(@tenvaitro)
	end
GO
/****** Object:  StoredProcedure [dbo].[sp_updatebaiViet]    Script Date: 07/30/2023 21:58:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_updatebaiViet] @mabaiviet int,@tieude nvarchar(255),@tomtat nvarchar(255),@noidung ntext,@hinhthunho text,
@chuthichhinh nvarchar(100),@luotxem int,@ngaydang datetime, @manguoidung int,@madanhmuc int
AS
begin
	UPDATE BaiViet SET TieuDe = @tieude, TomTat= @tomtat,NoiDung = @noidung,HinhThuNho = @hinhthunho,
	ChuThichHinh = @chuthichhinh,LuotXem = @luotxem,NgayDang = @ngaydang,MaNguoiDung = @manguoidung,
	MaDanhMuc = @madanhmuc where MaBaiViet = @mabaiviet
end
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertBaiViet]    Script Date: 07/30/2023 21:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertBaiViet] @tieude nvarchar(255),@tomtat nvarchar(255),@noidung ntext,@hinhthunho text,@chuthichhinh nvarchar(100),
@luotxem int,@ngaydang datetime,@manguoidung int,@madanhmuc int
AS
begin
	insert into BaiViet values(@tieude,@tomtat,@noidung,@hinhthunho,@chuthichhinh,@luotxem,@ngaydang,@manguoidung,@madanhmuc)
	end
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertBinhLuan]    Script Date: 07/30/2023 21:58:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--------------store procedure thêm dữ liệu Bình luận------------------
CREATE PROCEDURE [dbo].[sp_InsertBinhLuan] @Noidung ntext,@ngaydang datetime,
@manguoidung int, @mabaiviet int
AS
begin
	insert into BinhLuan values(@Noidung,@ngaydang,@manguoidung,@mabaiviet)
	end
GO
/****** Object:  StoredProcedure [dbo].[sp_updateBinhLuan]    Script Date: 07/30/2023 21:58:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----store procedure Cập nhật dữ liệu nội dung Bình luận-----------------
CREATE PROCEDURE [dbo].[sp_updateBinhLuan] @mabinhluan int, @Noidung ntext,@ngaydang datetime,
@manguoidung int, @mabaiviet int
AS
begin
	update BinhLuan set NoiDung = @Noidung,NgayDang= @ngaydang,MaNguoiDung= @manguoidung,
	MaBaiViet = @mabaiviet where MaBinhLuan = @mabinhluan
	end
GO
/****** Object:  StoredProcedure [dbo].[sp_updateDanhMuc]    Script Date: 07/30/2023 21:58:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_updateDanhMuc] @madanhmuc int, @tendanhmuc nvarchar(50)
AS
begin
	UPDATE DanhMuc SET TenDanhMuc = @tendanhmuc where MaDanhMuc = @madanhmuc
end
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertDanhMuc]    Script Date: 07/30/2023 21:58:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertDanhMuc] @tendanhmuc nvarchar(50)
AS
begin
	insert into DanhMuc values(@tendanhmuc)
	end
GO
/****** Object:  ForeignKey [FK__BaiViet__MaDanhM__07F6335A]    Script Date: 07/30/2023 21:58:12 ******/
ALTER TABLE [dbo].[BaiViet]  WITH CHECK ADD FOREIGN KEY([MaDanhMuc])
REFERENCES [dbo].[DanhMuc] ([MaDanhMuc])
GO
/****** Object:  ForeignKey [FK__BaiViet__MaNguoi__08EA5793]    Script Date: 07/30/2023 21:58:12 ******/
ALTER TABLE [dbo].[BaiViet]  WITH CHECK ADD FOREIGN KEY([MaNguoiDung])
REFERENCES [dbo].[NguoiDung] ([MaNguoiDung])
GO
/****** Object:  ForeignKey [FK__BinhLuan__MaBaiV__09DE7BCC]    Script Date: 07/30/2023 21:58:13 ******/
ALTER TABLE [dbo].[BinhLuan]  WITH CHECK ADD FOREIGN KEY([MaBaiViet])
REFERENCES [dbo].[BaiViet] ([MaBaiViet])
GO
/****** Object:  ForeignKey [FK__BinhLuan__MaNguo__0AD2A005]    Script Date: 07/30/2023 21:58:13 ******/
ALTER TABLE [dbo].[BinhLuan]  WITH CHECK ADD FOREIGN KEY([MaNguoiDung])
REFERENCES [dbo].[NguoiDung] ([MaNguoiDung])
GO
/****** Object:  ForeignKey [FK__FileBaiVi__MaBai__0BC6C43E]    Script Date: 07/30/2023 21:58:14 ******/
ALTER TABLE [dbo].[FileBaiViet]  WITH CHECK ADD FOREIGN KEY([MaBaiViet])
REFERENCES [dbo].[BaiViet] ([MaBaiViet])
GO
/****** Object:  ForeignKey [FK__FileBaiVi__MaFil__0CBAE877]    Script Date: 07/30/2023 21:58:14 ******/
ALTER TABLE [dbo].[FileBaiViet]  WITH CHECK ADD FOREIGN KEY([MaFile])
REFERENCES [dbo].[FileUpLoads] ([MaFile])
GO
/****** Object:  ForeignKey [FK__NguoiDung__VaiTr__0DAF0CB0]    Script Date: 07/30/2023 21:58:16 ******/
ALTER TABLE [dbo].[NguoiDung]  WITH CHECK ADD FOREIGN KEY([VaiTro])
REFERENCES [dbo].[VaiTro] ([MaVaiTro])
GO
