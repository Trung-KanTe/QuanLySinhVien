using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLy_SinhVien.DOAN_DTO
{
    internal class LopHoc_DTO
    {
        private string maLopHoc;
        private int nhom;
        private string maHocPhan;
        private string maGiangVien;
        private string namHoc;
        private int khoa;

        public string MaLopHoc { get => maLopHoc; set => maLopHoc = value; }
        public int Nhom { get => nhom; set => nhom = value; }
        public string MaHocPhan { get => maHocPhan; set => maHocPhan = value; }
        public string MaGiangVien { get => maGiangVien; set => maGiangVien = value; }
        public string NamHoc { get => namHoc; set => namHoc = value; }
        public int Khoa { get => khoa; set => khoa = value; }

        public LopHoc_DTO()
        {
            this.maLopHoc = "";
            this.nhom = 0;
            this.maHocPhan = "";
            this.maGiangVien = "";
            this.namHoc = "";
            this.khoa = 0;
        }
        public LopHoc_DTO(string maLopHoc, int nhom, string maHocPhan, string maGiangVien, string namHoc, int khoa)
        {
            this.maLopHoc = maLopHoc;
            this.nhom = nhom;
            this.maHocPhan = maHocPhan;
            this.maGiangVien = maGiangVien;
            this.namHoc = namHoc;
            this.khoa = khoa;
        }
    }
}
