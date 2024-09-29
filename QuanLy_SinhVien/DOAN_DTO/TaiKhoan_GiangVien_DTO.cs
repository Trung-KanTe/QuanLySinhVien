using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLy_SinhVien.DOAN_DTO
{
    internal class TaiKhoan_GiangVien_DTO
    {
        private string maGiangVien;
        private string matKhau;
        private int quyen;

        public string MaGiangVien { get => maGiangVien; set => maGiangVien = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public int Quyen { get => quyen; set => quyen = value; }
        public TaiKhoan_GiangVien_DTO()
        {
            this.maGiangVien = "";
            this.matKhau = "";
            this.quyen = 0;
        }
        public TaiKhoan_GiangVien_DTO(string maGiangVien, string matKhau, int quyen)
        {
            this.maGiangVien = maGiangVien;
            this.matKhau = matKhau;
            this.quyen = quyen;
        }
    }
}
