using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLy_SinhVien.DOAN_DTO
{
    internal class GiangVien_DTO
    {
        private string maGiangVien;
        private string hoTenLotGiangVien;
        private string tenGiangVien;
        private string ngaySinh;
        private string gioiTinh;
        private string soDienThoai;
        private string diaChi;
        private int vaiTro;
        private int kichHoat;



        public string MaGiangVien { get => maGiangVien; set => maGiangVien = value; }
        public string HoTenLotGiangVien { get => hoTenLotGiangVien; set => hoTenLotGiangVien = value; }
        public string TenGiangVien { get => tenGiangVien; set => tenGiangVien = value; }
        public string NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public int VaiTro { get => vaiTro; set => vaiTro = value; }
        public int KichHoat { get => kichHoat; set => kichHoat = value; }

        public GiangVien_DTO()
        {
            MaGiangVien = "";
            HoTenLotGiangVien = "";
            TenGiangVien = "";
            NgaySinh = "";
            GioiTinh = "";
            SoDienThoai = "";
            DiaChi = "";
            VaiTro = 0;
            KichHoat = 0;
        }

        public GiangVien_DTO(string maGiangVien, string hoTenLotGiangVien, string tenGiangVien, string ngaySinh, string gioiTinh, string soDienThoai, string diaChi, int vaiTro, int kichHoat)
        {
            this.maGiangVien = maGiangVien;
            this.hoTenLotGiangVien = hoTenLotGiangVien;
            this.tenGiangVien = tenGiangVien;
            this.ngaySinh = ngaySinh;
            this.gioiTinh = gioiTinh;
            this.soDienThoai = soDienThoai;
            this.diaChi = diaChi;
            this.vaiTro = vaiTro;
            this.kichHoat = kichHoat;
        }

     
    }
}
