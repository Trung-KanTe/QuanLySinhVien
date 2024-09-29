using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLy_SinhVien.DOAN_DTO
{
    internal class SinhVien_DTO
    {
        private string maSinhVien;
        private string tenSinhVien;
        private string gioiTinh;
        private string ngaySinh;
        private string soDienThoai;
        private string diaChi;
        private float diemTB;
        private float diemTB4;
        private int tinChiDat;
        private string xepLoai;
        private string maLop;

        public string MaSinhVien { get => maSinhVien; set => maSinhVien = value; }
        public string TenSinhVien { get => tenSinhVien; set => tenSinhVien = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public float DiemTB { get => diemTB; set => diemTB = value; }
        public float DiemTB4 { get => diemTB4; set => diemTB4 = value; }
        public int TinChiDat { get => tinChiDat; set => tinChiDat = value; }
        public string XepLoai { get => xepLoai; set => xepLoai = value; }
        public string MaLop { get => maLop; set => maLop = value; }
        public SinhVien_DTO()
        {
            this.maSinhVien = "";
            this.tenSinhVien = "";
            this.gioiTinh = "";
            this.ngaySinh = "";
            this.soDienThoai = "";
            this.diaChi = "";
            this.diemTB = 0;
            this.diemTB4 = 0;
            this.tinChiDat = 0;
            this.xepLoai = "";
            this.maLop = "";
        }

        public SinhVien_DTO(string maSinhVien, string tenSinhVien, string gioiTinh, string ngaySinh, string soDienThoai, string diaChi, float diemTB, float diemTB4, int tinChiDat, string xepLoai, string maLop)
        {
            this.maSinhVien = maSinhVien;
            this.tenSinhVien = tenSinhVien;
            this.gioiTinh = gioiTinh;
            this.ngaySinh = ngaySinh;
            this.soDienThoai = soDienThoai;
            this.diaChi = diaChi;
            this.diemTB = diemTB;
            this.diemTB4 = diemTB4;
            this.tinChiDat = tinChiDat;
            this.xepLoai = xepLoai;
            this.maLop = maLop;
        }

    }
}
