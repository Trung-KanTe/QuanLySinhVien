using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLy_SinhVien.DOAN_DTO;

namespace QuanLy_SinhVien.DOAN_DAO
{
    internal class TaiKhoa_Admin_DAO
    {
        public static DataTable ThongTin_TaiKhoan_Admin(TaiKhoan_Admin_DTO tkAdm)
        {
            string sql = "SELECT * FROM TAIKHOANADMIN WHERE TENTAIKHOAN = '" + tkAdm.Tentaikhoan +"' " +
                "AND MATKHAU = '" + tkAdm.Matkhau + "'";
            DataTable dt = new DataTable();
            dt = KETNOI_SQL.DocDuLieu(sql);
            return dt;
        }
    }
}
