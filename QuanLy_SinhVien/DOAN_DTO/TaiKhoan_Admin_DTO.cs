using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLy_SinhVien.DOAN_DTO
{
    internal class TaiKhoan_Admin_DTO
    {
        private string tentaikhoan;
        private string matkhau;

       

        public string Tentaikhoan { get => tentaikhoan; set => tentaikhoan = value; }
        public string Matkhau { get => matkhau; set => matkhau = value; }
        public TaiKhoan_Admin_DTO()
        {
            Tentaikhoan = "";
            Matkhau = "";
        }
        public TaiKhoan_Admin_DTO(string tentaikhoan, string matkhau)
        {
            Tentaikhoan = tentaikhoan;
            Matkhau = matkhau;
        }
    }
}
