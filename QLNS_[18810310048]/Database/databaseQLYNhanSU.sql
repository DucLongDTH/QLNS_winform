CREATE DATABASE QLNHANSU
USE QLNHANSU
GO

CREATE TABLE Nguoidung (
	Taikhoan nvarchar(50) NOT NULL CONSTRAINT pk_acc PRIMARY KEY,
	MatKhau nvarchar(16) NOT NULL

)

CREATE TABLE PhongBan (
	MaPhong nvarchar(50) NOT NULL CONSTRAINT pk_maphong PRIMARY KEY,
	TenPhong nvarchar(50) NOT NULL
)
	
CREATE TABLE ChucVu (
	MaChucVu nvarchar(50) NOT NULL CONSTRAINT pk_machuvu PRIMARY KEY,
	TenChucVu nvarchar(50) NOT NULL
)

CREATE TABLE NhanVien(
	MaNhanVien nvarchar(50) NOT NULL CONSTRAINT pk_manv PRIMARY KEY,
	TenNhanVien nvarchar(50) NOT NULL,
	MaChucVu nvarchar(50) NOT NULL CONSTRAINT fk_machuvu FOREIGN KEY (MaChucVu) REFERENCES ChucVu(MaChucVu),
	MaPhong nvarchar(50) NOT NULL CONSTRAINT fk_maphong FOREIGN KEY (MaPhong) REFERENCES PhongBan(MaPhong)
)

CREATE TABLE Luong
(
	MaBangLuong nvarchar(50) NOT NULL  CONSTRAINT pk_luong PRIMARY KEY,
	MaNhanVien nvarchar(50) NOT NULL CONSTRAINT fk_manv FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
	Thang int NOT NULL ,
	Nam int NOT NULL,
	Luong nvarchar(18) NOT NULL
)

GO
--Drop database QLNHANSU
-- data table 

--INSERT INTO Nguoidung(Taikhoan,MatKhau) VALUES('long','long')
--INSERT INTO Nguoidung(Taikhoan,MatKhau) VALUES('admin','admin')

-- Procedure Phong Ban
CREATE PROCEDURE PB_THEM
	@maphong nvarchar(50),
	@tenphong nvarchar(50)
AS
BEGIN
	INSERT INTO PhongBan(MaPhong,TenPhong) VALUES(@maphong,@tenphong)
END
GO
	--PB_THEM 'MP01','HANH CHINH';
	--PB_THEM 'MP02','KE TOAN';
	--PB_THEM 'MP03','PHAT TRIEN';
	--PB_THEM 'MP04','CHINH SACH';
	--PB_THEM 'MP05','TU PHAP';

CREATE PROCEDURE PB_SUA
	@maphong nvarchar(50),
	@tenphong nvarchar(50)
AS
BEGIN
	 UPDATE PhongBan
	 SET TenPhong = @tenphong
	 WHERE MaPhong = @maphong
END
GO
	--PB_SUA 'MP05','TU PHAP'

CREATE PROCEDURE PB_XOA
	@maphong nvarchar(50)
AS
BEGIN
	 DELETE FROM PhongBan WHERE MaPhong = @maphong
END
GO
-- Procedure Chuc Vu
CREATE PROCEDURE CV_THEM
	@macv nvarchar(50),
	@tencv nvarchar(50)
AS
BEGIN
	INSERT INTO ChucVu(MaChucVu,TenChucVu) VALUES(@macv,@tencv)
END
GO
	--CV_THEM 'CV01','TRUONG PHONG';
	--CV_THEM 'CV02','THU KY';
	--CV_THEM 'CV03','PHO PHONG';
	--CV_THEM 'CV04','QUAN LI';
	--CV_THEM 'CV05','NHANVIEN';

CREATE PROCEDURE CV_SUA
	@macv nvarchar(50),
	@tencv nvarchar(50)
AS
BEGIN
	 UPDATE ChucVu
	 SET TenChucVu = @tencv
	 WHERE MaChucVu = @macv
END
GO
	

CREATE PROCEDURE CV_XOA
	@macv nvarchar(50)
AS
BEGIN
	 DELETE FROM ChucVu WHERE MaChucVu = @macv
END
GO
-- Procedure Nhan Vien 
CREATE PROCEDURE NV_THEM
	@manv nvarchar(50),
	@tennv nvarchar(50),
	@macv nvarchar(50),
	@maphong nvarchar(50)
AS
BEGIN
	INSERT INTO NhanVien(MaNhanVien,TenNhanVien,MaChucVu,MaPhong) Values(@manv,@tennv,@macv,@maphong)
END
GO
	--NV_THEM 'NV01','long','CV01','MP03'


GO
CREATE PROCEDURE NV_SUA
	@manv nvarchar(50),
	@tennv nvarchar(50),
	@macv nvarchar(50),
	@maphong nvarchar(50)
AS
BEGIN
	 UPDATE NhanVien
	 SET TenNhanVien = @tennv , MaPhong =@maphong , MaChucVu =@macv
	 WHERE MaNhanVien = @manv
END
GO
	--NV_SUA 'NV01','Long','CV01','MP03'
	
GO
CREATE PROCEDURE NV_XOa
	@manv nvarchar(50)
AS
BEGIN
	 DELETE FROM NhanVien WHERE MaNhanVien = @manv
END
GO
-- Procedure Luong
CREATE PROCEDURE Luong_them
	@maluong nvarchar(50),
	@manv nvarchar(50),
	@thang int,
	@nam int,
	@luong nvarchar(50)
AS
BEGIN
	INSERT INTO Luong(MaBangLuong,MaNhanVien,Thang,Nam,Luong) Values(@maluong,@manv,@thang,@nam,@luong)
END
GO
	--Luong_them 'ML01','NV01','1','2020','10000000'
	--Luong_them 'ML02','NV01','2','2020','10000000'
	--Luong_them 'ML03','NV01','3','2020','10000000'
	--Luong_them 'ML04','NV01','4','2020','10000000'
	--Luong_them 'ML05','NV01','5','2020','10000000'
	--Luong_them 'ML06','NV01','6','2020','10000000'
GO

CREATE PROCEDURE Luong_SUA
	@maluong nvarchar(50),
	@luong nvarchar(50)
AS
BEGIN
	 UPDATE Luong
	 SET Luong = @luong
	 WHERE MaBangLuong = @maluong
END
GO
	--Luong_SUA 'ML01','16000000'

