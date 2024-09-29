using QuanLy_SinhVien.DOAN_DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLy_SinhVien.DOAN_DAO
{
    internal class TaiKhoan_GiangVien_DAO
    {
        public DataTable ThongTin_TaiKhoan()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT MAGIANGVIEN, HOTENLOTGIANGVIEN + ' ' + TENGIANGVIEN AS TENGIANGVIEN  FROM GIANGVIEN WHERE KICHHOAT = 0";
            dt = KETNOI_SQL.DocDuLieu(sql);
            return dt;
        }
        public DataTable Xem_ThongTin_TaiKhoan(GiangVien_DTO gv)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM GIANGVIEN WHERE MAGIANGVIEN = '" + gv.MaGiangVien + "'";
            dt = KETNOI_SQL.DocDuLieu(sql);
            return dt;
        }
        public DataTable Xem_ThongTin_TaiKhoan_QuenMat(TaiKhoan_GiangVien_DTO tk)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM TAIKHOANGIANGVIEN WHERE MAGIANGVIEN = '" + tk.MaGiangVien + "'";
            dt = KETNOI_SQL.DocDuLieu(sql);
            return dt;
        }
        public DataTable ThongTin_TaiKhoan_GiangVien(TaiKhoan_GiangVien_DTO tk)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM TAIKHOANGIANGVIEN TK, GIANGVIEN GV WHERE TK.MAGIANGVIEN = GV.MAGIANGVIEN " +
                "AND TK.MAGIANGVIEN = '" + tk.MaGiangVien + "' AND TK.MATKHAU = '" + tk.MatKhau + "'";
            dt = KETNOI_SQL.DocDuLieu(sql);
            return dt;
        }
        public DataTable ThongTin_TaiKhoan_CoVan(TaiKhoan_GiangVien_DTO tk)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM GIANGVIEN GV, LOP L WHERE L.MAGIANGVIEN = GV.MAGIANGVIEN " +
                "AND GV.MAGIANGVIEN = '" + tk.MaGiangVien + "'";
            dt = KETNOI_SQL.DocDuLieu(sql);
            return dt;
        }
        public void CapNhat_TaiKhoan(GiangVien_DTO gv)
        {
            string sql = "UPDATE GIANGVIEN SET KICHHOAT = 1 WHERE MAGIANGVIEN = '" + gv.MaGiangVien + "'";

            KETNOI_SQL.ThucThiTruyVan(sql);
        }
        public void Them_TaiKhoan_GiangVien(TaiKhoan_GiangVien_DTO tk)
        {
            string sql = "INSERT INTO TAIKHOANGIANGVIEN (MAGIANGVIEN, MATKHAU) VALUES ('" + tk.MaGiangVien + "', '" + tk.MatKhau + "')";
            KETNOI_SQL.ThucThiTruyVan(sql);
        }
        public void CapNhat_MatKhau(TaiKhoan_GiangVien_DTO tk)
        {
            string sql = "UPDATE TAIKHOANGIANGVIEN SET MATKHAU = '" + tk.MatKhau + "' WHERE MAGIANGVIEN = '" + tk.MaGiangVien + "'";

            KETNOI_SQL.ThucThiTruyVan(sql);
        }
        public void CapNhat_TaiKhoan_All()
        {
            string sql = "UPDATE GIANGVIEN SET KICHHOAT = 1 WHERE KICHHOAT = 0";

            KETNOI_SQL.ThucThiTruyVan(sql);
        }
        public void Them_TaiKhoan_GiangVien_All()
        {
            string sql = "INSERT INTO TAIKHOANGIANGVIEN (MAGIANGVIEN, MATKHAU) " +
                "SELECT MAGIANGVIEN, '123456' " +
                "FROM GIANGVIEN " +
                "WHERE KICHHOAT = 0";
            KETNOI_SQL.ThucThiTruyVan(sql);
        }
    }
}
