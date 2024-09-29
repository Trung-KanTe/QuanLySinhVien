using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLy_SinhVien.DOAN_DTO
{
    internal class Lop_DTO
    {
        private string maLop;
        private string tenLop;
        private int khoa;
        private string maGiangVien;

        public string MaLop { get => maLop; set => maLop = value; }
        public string TenLop { get => tenLop; set => tenLop = value; }
        public int Khoa { get => khoa; set => khoa = value; }
        public string MaGiangVien { get => maGiangVien; set => maGiangVien = value; }

        public Lop_DTO()
        {
            this.MaLop = "";
            this.TenLop = "";
            this.Khoa = 0;
            this.MaGiangVien = "";
        }
        public Lop_DTO(string maLop, string tenLop, int khoa, string maGiangVien)
        {
            this.MaLop = maLop;
            this.TenLop = tenLop;
            this.Khoa = khoa;
            this.MaGiangVien = maGiangVien;
        }
    }
}
