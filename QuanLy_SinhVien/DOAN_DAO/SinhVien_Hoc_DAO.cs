using QuanLy_SinhVien.DOAN_DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLy_SinhVien.DOAN_DAO
{
    internal class SinhVien_Hoc_DAO
    {
        DataTable dt = new DataTable();
        public DataTable ThongTin_SinhVien(Lop_DTO l, SinhVien_Hoc_DTO svh)
        {
            string sql = "SELECT MASINHVIEN, TENSINHVIEN " +
                "FROM SINHVIEN SV, LOP L " +
                "WHERE SV.MALOP = L.MALOP " +
                "AND SV.MALOP = '" + l.MaLop + "' " +
                "AND NOT EXISTS ( " +
                "SELECT 1 FROM SINHVIENHOC SVH " +
                "WHERE SVH.MASINHVIEN = SV.MASINHVIEN " +
                " AND SVH.MAHOCPHAN = '" + svh.MaHocPhan + "')";
            dt =KETNOI_SQL.DocDuLieu(sql);
            return dt;
        }

        public DataTable ThongTin_SinhVien_Hoc(SinhVien_Hoc_DTO svh)
        {
            string sql = "SELECT SV.MASINHVIEN, SV.TENSINHVIEN, L.TENLOP, L.KHOA, SVH.MALOPHOC, SVH.MAHOCPHAN " +
                "FROM SINHVIEN SV, LOP L, SINHVIENHOC SVH " +
                "WHERE SV.MASINHVIEN = SVH.MASINHVIEN AND SV.MALOP = L.MALOP AND SVH.MALOPHOC = '" + svh.MaLopHoc + "'";
            dt = KETNOI_SQL.DocDuLieu(sql);
            return dt;
        }
        public DataTable ThongTin_Diem_SinhVien(SinhVien_Hoc_DTO svh)
        {
            string sql = "SELECT SV.MASINHVIEN, SV.TENSINHVIEN, L.TENLOP, L.KHOA, TILEDIEMTHUONGXUYEN, TILEDIEMTHI, DIEMTHUONGXUYEN, DIEMTHILAN1, DIEMTHILAN2, DIEMTRUNGBINHMON, DIEMTRUNGBINHMONHE4, TENHOCPHAN, SVH.MAHOCPHAN, LH.KHOA AS KHOAL" +
                " FROM SINHVIEN SV, LOP L, SINHVIENHOC SVH, HOCPHAN HP, LOPHOC LH" +
                " WHERE SVH.MAHOCPHAN = HP.MAHOCPHAN AND SV.MASINHVIEN = SVH.MASINHVIEN AND SV.MALOP = L.MALOP AND LH.MALOPHOC = SVH.MALOPHOC AND SVH.MALOPHOC = '" + svh.MaLopHoc + "'";
            dt = KETNOI_SQL.DocDuLieu(sql);
            return dt;
        }
        public void Them_SinhVien_Hoc(SinhVien_Hoc_DTO svh)
        {
            string sql = "INSERT INTO SINHVIENHOC (MASINHVIEN, MAHOCPHAN, MALOPHOC) " +
                "VALUES ('" + svh.MaSinhVien + "', '" + svh.MaHocPhan + "', '" + svh.MaLopHoc + "')";
            KETNOI_SQL.ThucThiTruyVan(sql);
        }
        public void Them_Diem_SinhVien(SinhVien_Hoc_DTO svh)
        {
            string sql = "UPDATE SINHVIENHOC SET DIEMTHUONGXUYEN = " + svh.DiemTX +
                ", DIEMTHILAN1 = "+ svh.DiemL1 + ", DIEMTHILAN2 = " + svh.DiemL2 + 
                ", DIEMTRUNGBINHMON = " + svh.DiemTB +
                ", DIEMTRUNGBINHMONHE4 = '" + svh.DiemTB4 +
                "', DTBH4SO = " + svh.DiemTB4So +
                "  WHERE MASINHVIEN = '" + svh.MaSinhVien + "' AND MAHOCPHAN = '" + svh.MaHocPhan + "'"; ;
            KETNOI_SQL.ThucThiTruyVan(sql);
        }
        public void Xoa_SinhVien_Hoc(SinhVien_Hoc_DTO svh)
        {
            string sql = "DELETE FROM SINHVIENHOC WHERE MASINHVIEN='" + svh.MaSinhVien + "'";
            KETNOI_SQL.ThucThiTruyVan(sql);
        }
    }
}
