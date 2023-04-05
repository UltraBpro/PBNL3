USE master;
GO
CREATE DATABASE PBL3;
GO
USE PBL3;
GO

CREATE TABLE LoaiPhong (
    MaLoaiPhong INT PRIMARY KEY,
    TenLoaiPhong NVARCHAR(50) NOT NULL,
    DienTich FLOAT NOT NULL,
    SoGiuong INT NOT NULL,
    GiaTien FLOAT NOT NULL,
    GhiChu NVARCHAR(MAX)
);

CREATE TABLE Phong (
    MaPhong INT PRIMARY KEY,
    MaLoaiPhong INT NOT NULL,
    TinhTrang NVARCHAR(50) NOT NULL,
    ViTri NVARCHAR(50) NOT NULL,
    CONSTRAINT FK_LoaiPhong_Phong FOREIGN KEY (MaLoaiPhong) REFERENCES LoaiPhong(MaLoaiPhong)
);

CREATE TABLE Khach (
    MaKhach INT PRIMARY KEY,
    TenKhach NVARCHAR(50) NOT NULL,
    NgaySinh DATE NOT NULL,
    GioiTinh NVARCHAR(10) NOT NULL,
    SoDienThoai NVARCHAR(20) NOT NULL
);

CREATE TABLE NhanVien (
    MaNhanVien INT PRIMARY KEY,
    TenNhanVien NVARCHAR(50) NOT NULL,
    GioiTinh NVARCHAR(10) NOT NULL,
    Luong FLOAT NOT NULL,
    ChucVu NVARCHAR(50) NOT NULL,
    NgayNhanViec DATE NOT NULL
);

CREATE TABLE LoaiDichVu (
    MaLoaiDichVu INT PRIMARY KEY,
    TenDichVu NVARCHAR(50) NOT NULL,
    DonGia FLOAT NOT NULL
);

CREATE TABLE DonDatPhong (
    MaDonDatPhong INT PRIMARY KEY,
    MaKhach INT NOT NULL,
    TinhTrangThanhToan NVARCHAR(50) NOT NULL,
    NgayDat DATETIME NOT NULL,
    NgayTra DATETIME NOT NULL,
    GiaTien FLOAT NOT NULL,
    MaNhanVienThucHien INT NOT NULL,
    MaNhanVienThanhToan INT NOT NULL,
    CONSTRAINT FK_Khach_DonDatPhong FOREIGN KEY (MaKhach) REFERENCES Khach(MaKhach),
    CONSTRAINT FK_NhanVien_DonDatPhong_ThucHien FOREIGN KEY (MaNhanVienThucHien) REFERENCES NhanVien(MaNhanVien),
    CONSTRAINT FK_NhanVien_DonDatPhong_ThanhToan FOREIGN KEY (MaNhanVienThanhToan) REFERENCES NhanVien(MaNhanVien)
);

CREATE TABLE ChiTietPhongDat (
    MaPhong INT NOT NULL,
    MaDonDatPhong INT NOT NULL,
	GiaPhongDat INT NOT NULL,
    PRIMARY KEY (MaPhong, MaDonDatPhong),
    CONSTRAINT FK_Phong_ChiTietPhongDat FOREIGN KEY (MaPhong) REFERENCES Phong(MaPhong),
    CONSTRAINT FK_DonDatPhong_ChiTietPhongDat FOREIGN KEY (MaDonDatPhong) REFERENCES DonDatPhong(MaDonDatPhong)
);

CREATE TABLE ChiTietDichVuDat (
    MaDichVu INT NOT NULL,
	GiaDichVuDat INT NOT NULL,
    SoLuong INT NOT NULL,
    MaDonDatPhong INT NOT NULL,
    PRIMARY KEY (MaDichVu, MaDonDatPhong),
    CONSTRAINT FK_DichVu_ChiTietDichVuDat FOREIGN KEY (MaDichVu) REFERENCES LoaiDichVu(MaLoaiDichVu),
    CONSTRAINT FK_DonDatPhong_ChiTietDichVuDat FOREIGN KEY (MaDonDatPhong) REFERENCES DonDatPhong(MaDonDatPhong)
);