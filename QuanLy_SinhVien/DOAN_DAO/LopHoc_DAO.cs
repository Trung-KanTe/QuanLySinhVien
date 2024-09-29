using QuanLy_SinhVien.DOAN_DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Windows.Forms;

namespace QuanLy_SinhVien.DOAN_DAO
{
    internal class LopHoc_DAO
    {
        DataTable dt = new DataTable();
        public DataTable ThongTin_LopHoc() 
        {
            string sql = "SELECT LH.MALOPHOC, LH.NHOM, HP.MAHOCPHAN, HP.TENHOCPHAN, GV.HOTENLOTGIANGVIEN + ' ' + GV.TENGIANGVIEN AS HOTENGIANGVIEN, NAMHOC " +
                " FROM LOPHOC LH, HOCPHAN HP, GIANGVIEN GV " +
                "WHERE LH.MAGIANGVIEN = GV.MAGIANGVIEN AND LH.MAHOCPHAN = HP.MAHOCPHAN AND KHOA = 0";
            dt = KETNOI_SQL.DocDuLieu(sql);
            return dt;
        }
        public DataTable ThongTin_LopHoc_GV(LopHoc_DTO lh)
        {
            string sql = "SELECT LH.MALOPHOC, LH.NHOM, HP.MAHOCPHAN, HP.TENHOCPHAN, GV.HOTENLOTGIANGVIEN + ' ' + GV.TENGIANGVIEN AS HOTENGIANGVIEN, NAMHOC " +
                " FROM LOPHOC LH, HOCPHAN HP, GIANGVIEN GV " +
                "WHERE LH.MAGIANGVIEN = GV.MAGIANGVIEN AND LH.MAHOCPHAN = HP.MAHOCPHAN AND LH.MAGIANGVIEN = '" + lh.MaGiangVien + "'";
            dt = KETNOI_SQL.DocDuLieu(sql);
            return dt;
        }
        public DataTable ThongTin_GiangVien()
        {
            string sql = "SELECT MAGIANGVIEN, HOTENLOTGIANGVIEN + ' ' + TENGIANGVIEN AS TENGIANGVIEN FROM GIANGVIEN";
            dt = KETNOI_SQL.DocDuLieu(sql);
            return dt;
        }
        public DataTable ThongTin_LopHoc_HocPhan(LopHoc_DTO lh)
        {
            string sql = "SELECT LH.MALOPHOC, LH.NHOM, HP.MAHOCPHAN, HP.TENHOCPHAN, GV.HOTENLOTGIANGVIEN + ' ' + GV.TENGIANGVIEN AS HOTENGIANGVIEN, NAMHOC " +
                " FROM LOPHOC LH, HOCPHAN HP, GIANGVIEN GV " +
                "WHERE LH.MAGIANGVIEN = GV.MAGIANGVIEN AND LH.MAHOCPHAN = HP.MAHOCPHAN AND LH.MAHOCPHAN = '" + lh.MaHocPhan + "'";
            dt = KETNOI_SQL.DocDuLieu(sql);
            return dt;
        }
        public DataTable ThongTinLopHoc_ChuaKhoa()
        {
            string sql = "SELECT LH.MALOPHOC, LH.NHOM, HP.MAHOCPHAN, HP.TENHOCPHAN, GV.HOTENLOTGIANGVIEN + ' ' + GV.TENGIANGVIEN AS HOTENGIANGVIEN, NAMHOC, KHOA " +
                 " FROM LOPHOC LH, HOCPHAN HP, GIANGVIEN GV " +
                 "WHERE LH.MAGIANGVIEN = GV.MAGIANGVIEN AND LH.MAHOCPHAN = HP.MAHOCPHAN AND KHOA = 0";
            dt = KETNOI_SQL.DocDuLieu(sql);
            return dt;
        }
        public DataTable ThongTinLopHoc_DaKhoa()
        {
            string sql = "SELECT LH.MALOPHOC, LH.NHOM, HP.MAHOCPHAN, HP.TENHOCPHAN, GV.HOTENLOTGIANGVIEN + ' ' + GV.TENGIANGVIEN AS HOTENGIANGVIEN, NAMHOC, KHOA " +
                 " FROM LOPHOC LH, HOCPHAN HP, GIANGVIEN GV " +
                 "WHERE LH.MAGIANGVIEN = GV.MAGIANGVIEN AND LH.MAHOCPHAN = HP.MAHOCPHAN AND KHOA = 1";
            dt = KETNOI_SQL.DocDuLieu(sql);
            return dt;
        }
        public DataTable ThongTinLopHoc_TheoNam(LopHoc_DTO lh)
        {
            string sql = "SELECT LH.MALOPHOC, LH.NHOM, HP.MAHOCPHAN, HP.TENHOCPHAN, GV.HOTENLOTGIANGVIEN + ' ' + GV.TENGIANGVIEN AS HOTENGIANGVIEN, NAMHOC, KHOA " +
                 " FROM LOPHOC LH, HOCPHAN HP, GIANGVIEN GV " +
                 "WHERE LH.MAGIANGVIEN = GV.MAGIANGVIEN AND LH.MAHOCPHAN = HP.MAHOCPHAN AND NAMHOC = '" + lh.NamHoc + "'";
            dt = KETNOI_SQL.DocDuLieu(sql);
            return dt;
        }
        public void Them_LopHoc(LopHoc_DTO lh)
        {
            string sql = "INSERT INTO LOPHOC (MALOPHOC, NHOM, MAHOCPHAN, MAGIANGVIEN, NAMHOC, KHOA)" +
                " VALUES ('" + lh.MaLopHoc + "'," + lh.Nhom + ", '" + lh.MaHocPhan + "', '" + lh.MaGiangVien +
                "', '"  + lh.NamHoc + "', 0)";
            KETNOI_SQL.ThucThiTruyVan(sql);
        }

        public void CapNhat_HocPhan(HocPhan_DTO hp)
        {
            string sql = "UPDATE HOCPHAN SET TENHOCPHAN = N'" + hp.TenHocPhan +
                "', SOTINCHI = " + hp.SoTinChi +
                ", HOCKY = " + hp.HocKy +
                " WHERE MAHOCPHAN = '" + hp.MaHocPhan + "'";
            KETNOI_SQL.ThucThiTruyVan(sql);
        }
        public void Khoa_LopHoc(LopHoc_DTO lh)
        {
            string sql = "UPDATE LOPHOC SET KHOA = 1 " +
                " WHERE NAMHOC = '" + lh.NamHoc + "'";
            KETNOI_SQL.ThucThiTruyVan(sql);
        }
        public void MoKhoa_LopHoc(LopHoc_DTO lh)
        {
            string sql = "UPDATE LOPHOC SET KHOA = 0 " +
                " WHERE MALOPHOC = '" + lh.MaLopHoc + "'";
            KETNOI_SQL.ThucThiTruyVan(sql);
        }
    }
}
