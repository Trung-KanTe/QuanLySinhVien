using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLy_SinhVien.DOAN_DTO;

namespace QuanLy_SinhVien.DOAN_DAO
{
    internal class Lop_DAO
    {

        public DataTable ThongTin_Lop()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT L.MALOP, L.TENLOP, L.KHOA, GV.HOTENLOTGIANGVIEN + ' ' + GV.TENGIANGVIEN AS TENGIANGVIEN " +
                "FROM LOP L, GIANGVIEN GV WHERE L.MAGIANGVIEN = GV.MAGIANGVIEN";
            dt = KETNOI_SQL.DocDuLieu(sql);
            return dt;
        }
       
        public void Them_Lop(Lop_DTO l)
        {
            string sql = "INSERT INTO LOP (MALOP, TENLOP, KHOA, MAGIANGVIEN) VALUES " +
                "('" + l.MaLop + "', N'" + l.TenLop + "'," +
                l.Khoa + ",'" + l.MaGiangVien + "')";
            KETNOI_SQL.ThucThiTruyVan(sql);
        }
     
        public void CapNhat_Lop(Lop_DTO l)
        {
            string sql = "UPDATE LOP SET TENLOP = N'" + l.TenLop + "', KHOA = '" + l.Khoa + 
                "' WHERE MALOP = '" + l.MaLop + "'";
            KETNOI_SQL.ThucThiTruyVan(sql);
        }
        public DataTable ThongTin_Khoa()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT KHOA FROM LOP GROUP BY KHOA";
            dt = KETNOI_SQL.DocDuLieu(sql);
            return dt;
        }
    }
}
