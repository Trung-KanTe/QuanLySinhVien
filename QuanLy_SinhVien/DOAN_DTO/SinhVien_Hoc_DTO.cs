using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLy_SinhVien.DOAN_DTO
{
    internal class SinhVien_Hoc_DTO
    {
        private string maSinhVien;
        private string maLopHoc;
        private string maHocPhan;
        private float diemTX;
        private float diemL1;
        private float diemL2;
        private float diemTB;
        private string diemTB4;
        private float diemTB4So;
     
        public SinhVien_Hoc_DTO()
        {
            this.maSinhVien = "";
            this.maLopHoc = "";
            this.maHocPhan ="" ;
            this.diemTX = 0;
            this.diemL1 = 0;
            this.diemL2 = 0;
            this.diemTB = 0;
            this.diemTB4 = "";
            this.diemTB4So = 0;
        }

        public SinhVien_Hoc_DTO(string maSinhVien, string maLopHoc, string maHocPhan, float diemTX, float diemL1, float diemL2, float diemTB, string diemTB4, float diemTB4So)
        {
            this.maSinhVien = maSinhVien;
            this.maLopHoc = maLopHoc;
            this.maHocPhan = maHocPhan;
            this.diemTX = diemTX;
            this.diemL1 = diemL1;
            this.diemL2 = diemL2;
            this.diemTB = diemTB;
            this.diemTB4 = diemTB4;
            this.diemTB4So = diemTB4So;
        }

        public string MaSinhVien { get => maSinhVien; set => maSinhVien = value; }
        public string MaLopHoc { get => maLopHoc; set => maLopHoc = value; }
        public string MaHocPhan { get => maHocPhan; set => maHocPhan = value; }
        public float DiemTX { get => diemTX; set => diemTX = value; }
        public float DiemL1 { get => diemL1; set => diemL1 = value; }
        public float DiemL2 { get => diemL2; set => diemL2 = value; }
        public float DiemTB { get => diemTB; set => diemTB = value; }
        public string DiemTB4 { get => diemTB4; set => diemTB4 = value; }
        public float DiemTB4So { get => diemTB4So; set => diemTB4So = value; }
    }
}
