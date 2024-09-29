using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLy_SinhVien.DOAN_DTO;

namespace QuanLy_SinhVien.DOAN_DAO
{
    internal class SinhVien_DAO
    {
        public DataTable ThongTin_SinhVien(SinhVien_DTO sv)
        {
            DataTable dt =  new DataTable();
            string sql = "SELECT MASINHVIEN, TENSINHVIEN, GIOITINH, NGAYSINH, DIACHI, SDT, L.MALOP " +
                "FROM SINHVIEN SV, LOP L WHERE SV.MALOP = L.MALOP AND SV.MALOP = '" + sv.MaLop +"'";
            dt = KETNOI_SQL.DocDuLieu(sql);
            return dt;
        }
        public DataTable ThongTin_SinhVien_Report(SinhVien_DTO sv)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT GV.MAGIANGVIEN, HOTENLOTGIANGVIEN + ' ' + TENGIANGVIEN AS HOTENGIANGVIEN, " +
                "L.MALOP, TENLOP, KHOA , SV.MASINHVIEN, TENSINHVIEN, SV.GIOITINH, SV.NGAYSINH, SV.DIACHI, SV.SDT " +
                "FROM SINHVIEN SV, LOP L, GIANGVIEN GV  WHERE SV.MALOP = L.MALOP AND L.MAGIANGVIEN = GV.MAGIANGVIEN AND SV.MALOP = '" + sv.MaLop + "'";
            dt = KETNOI_SQL.DocDuLieu(sql);
            return dt;
        }
        public DataTable ThongTin_Diem_SinhVien(SinhVien_DTO sv)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT MASINHVIEN, TENSINHVIEN, GIOITINH, ROUND(DIEMTRUNGBINH, 3) AS DIEMTRUNGBINH, ROUND(DIEMTRUNGBINHHE4, 3) AS DIEMTRUNGBINHHE4 , TINCHIDAT, XEPLOAI " +
                "FROM SINHVIEN SV, LOP L WHERE SV.MALOP = L.MALOP AND SV.MALOP = '" + sv.MaLop + "' ORDER BY DIEMTRUNGBINH DESC";
            dt = KETNOI_SQL.DocDuLieu(sql);
            return dt;
        }
        public void Them_SinhVien(SinhVien_DTO sv)
        {
            string sql = "INSERT INTO SINHVIEN (MASINHVIEN, TENSINHVIEN, GIOITINH, NGAYSINH, DIACHI, SDT, MALOP) " +
                "VALUES ('" + sv.MaSinhVien + "',N'" + sv.TenSinhVien + "', N'" + sv.GioiTinh + "','" + 
                sv.NgaySinh + "', N'" + sv.DiaChi + "','" + sv.SoDienThoai + "','" + sv.MaLop + "')";
            KETNOI_SQL.ThucThiTruyVan(sql);
        }

        public void CapNhat_SinhVien(SinhVien_DTO sv)
        {
            string sql = "UPDATE SINHVIEN SET TENSINHVIEN = N'" + sv.TenSinhVien +
                "', GIOITINH = N'" + sv.GioiTinh +
                "', NGAYSINH = '" + sv.NgaySinh +
                "', DIACHI = N'" + sv.DiaChi +
                "', SDT = '" + sv.SoDienThoai +
                "' WHERE MASINHVIEN = '" + sv.MaSinhVien + "'";
            KETNOI_SQL.ThucThiTruyVan(sql);
        }
        public void Xoa_SinhVien(SinhVien_DTO sv)
        {
            string sql = "DELETE FROM SINHVIEN WHERE MASINHVIEN='" + sv.MaSinhVien + "'";
            KETNOI_SQL.ThucThiTruyVan(sql);
        }

        public void CapNhat_DiemTB()
        {
            string sql = "UPDATE SINHVIEN " +
                "SET DiemTrungBinh = SVH.TongDiemTrungBinh / SVH.TongSoTinChi " +
                "FROM SINHVIEN AS SV " +
                "INNER JOIN( " +
                    "SELECT SVH.MASINHVIEN, SUM(SVH.DIEMTRUNGBINHMON* HP.SOTINCHI) AS TongDiemTrungBinh, SUM(HP.SOTINCHI) AS TongSoTinChi " +
                    "FROM SINHVIENHOC SVH " +
                    "INNER JOIN HOCPHAN HP ON SVH.MAHOCPHAN = HP.MAHOCPHAN " +
                    "GROUP BY SVH.MASINHVIEN " +
                ") AS SVH ON SV.MASINHVIEN = SVH.MASINHVIEN";
            KETNOI_SQL.ThucThiTruyVan(sql);
        }
        public void CapNhat_DiemTB4()
        {
            string sql = "UPDATE SINHVIEN " +
                "SET DIEMTRUNGBINHHE4 = SVH.TONGDIEMTRUNGBINHHE4 / SVH.TONGSOTINCHI " +
                "FROM SINHVIEN AS SV " +
                "INNER JOIN( " +
                    "SELECT SVH.MASINHVIEN, SUM(SVH.DTBH4SO * HP.SOTINCHI) AS TONGDIEMTRUNGBINHHE4, SUM(HP.SOTINCHI) AS TONGSOTINCHI " +
                    "FROM SINHVIENHOC SVH " +
                    "INNER JOIN HOCPHAN HP ON SVH.MAHOCPHAN = HP.MAHOCPHAN " +
                    "GROUP BY SVH.MASINHVIEN " +
                ") AS SVH ON SV.MASINHVIEN = SVH.MASINHVIEN";
            KETNOI_SQL.ThucThiTruyVan(sql);
        }
        public void CapNhat_TinChi()
        {
            string sql = "UPDATE SINHVIEN " +
                "SET TINCHIDAT = ( " +
                "SELECT SUM (HP.SOTINCHI) " +
                "FROM SINHVIENHOC SVH, HOCPHAN HP " +
                "WHERE SVH.MASINHVIEN = SINHVIEN.MASINHVIEN AND SVH.MAHOCPHAN = HP.MAHOCPHAN)";
            KETNOI_SQL.ThucThiTruyVan(sql);
        }
        public void CapNhat_XepLoai()
        {
            string sql = "UPDATE SINHVIEN SET XEPLOAI = " +
                "CASE  WHEN DIEMTRUNGBINH >= 9 THEN N'XUẤT SẮC'" +
                " WHEN DIEMTRUNGBINH >= 8 THEN N'GIỎI'" +
                " WHEN DIEMTRUNGBINH >= 6.5 THEN N'KHÁ'" +
                " WHEN DIEMTRUNGBINH >= 5 THEN N'TRUNG BÌNH' " +
                " ELSE N'YẾU' " +
                "END";
            KETNOI_SQL.ThucThiTruyVan(sql);
        }
        public DataTable SoLuong_SinhVien(SinhVien_DTO sv)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT COUNT(*) AS SOLUONGSV FROM SINHVIEN WHERE MALOP = '" + sv.MaLop + "'";
            dt = KETNOI_SQL.DocDuLieu(sql);
            return dt;
        }
        public DataTable So_SinhVien_Gioi(SinhVien_DTO sv)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT COUNT(*) AS SOLUONGSV FROM SINHVIEN WHERE MALOP = '" + sv.MaLop + "' AND DIEMTRUNGBINH >= 8.0";
            dt = KETNOI_SQL.DocDuLieu(sql);
            return dt;
        }
        public DataTable DiemTrungBinh_Lop(SinhVien_DTO sv)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT ROUND(AVG(DIEMTRUNGBINH),3) AS DTB FROM SINHVIEN WHERE MALOP = '" + sv.MaLop + "'";
            dt = KETNOI_SQL.DocDuLieu(sql);
            return dt;
        }
        public DataTable DS_Top_20_SV(SinhVien_DTO sv)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT TOP 20 PERCENT MASINHVIEN, TENSINHVIEN, GIOITINH, DIEMTRUNGBINH, TINCHIDAT, XEPLOAI " +
                "FROM SINHVIEN SV, LOP L WHERE SV.MALOP = L.MALOP AND SV.MALOP = '" + sv.MaLop + "' ORDER BY DIEMTRUNGBINH DESC";
            dt = KETNOI_SQL.DocDuLieu(sql);
            return dt;
        }
        public DataTable DiemTrungBinh_Top_20(SinhVien_DTO sv)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT AVG(DIEMTRUNGBINH) AS TrungBinhDiem " +
                "FROM (SELECT TOP 20 PERCENT DIEMTRUNGBINH FROM SINHVIEN WHERE MALOP = '" + sv.MaLop + "' ORDER BY DIEMTRUNGBINH DESC) AS Top20Percent";
            dt = KETNOI_SQL.DocDuLieu(sql);
            return dt;
        }
        public DataTable SapXep_SinhVien(SinhVien_DTO sv)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT COUNT(MASINHVIEN) AS SOLUONG, XEPLOAI FROM SINHVIEN " +
                "WHERE MALOP = '" + sv.MaLop + "' GROUP BY XEPLOAI " +
                "ORDER BY CASE WHEN XEPLOAI = N'XUẤT SẮC' THEN 1 WHEN XEPLOAI = N'GIỎI' THEN 2 " +
                "WHEN XEPLOAI = N'KHÁ' THEN 3 WHEN XEPLOAI = N'TRUNG BÌNH' THEN 4 WHEN XEPLOAI = N'YẾU' THEN 5 END";
            dt = KETNOI_SQL.DocDuLieu(sql);
            return dt;
        }
        public DataTable ThongTin_SinhVien_Gioi(SinhVien_DTO sv)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT MASINHVIEN, TENSINHVIEN, GIOITINH, DIEMTRUNGBINH, DIEMTRUNGBINHHE4, TINCHIDAT, XEPLOAI " +
                "FROM SINHVIEN SV, LOP L WHERE SV.MALOP = L.MALOP AND SV.DIEMTRUNGBINH >= 8 " +
                "AND SV.MALOP = '" + sv.MaLop + "' ORDER BY DIEMTRUNGBINH DESC";
            dt = KETNOI_SQL.DocDuLieu(sql);
            return dt;
        }


        public DataTable ThongTin_SinhVien_TheoKhoa(Lop_DTO l)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT MASINHVIEN, TENSINHVIEN, GIOITINH, DIEMTRUNGBINH, TINCHIDAT, XEPLOAI, KHOA " +
                "FROM SINHVIEN SV, LOP L WHERE SV.MALOP = L.MALOP AND L.KHOA = '" + l.Khoa + "' ORDER BY DIEMTRUNGBINH DESC";
            dt = KETNOI_SQL.DocDuLieu(sql);
            return dt;
        }
        public DataTable Loc_XepLoai_SinhVien_TheoKhoa(Lop_DTO l, SinhVien_DTO sv)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT MASINHVIEN, TENSINHVIEN, GIOITINH, DIEMTRUNGBINH, TINCHIDAT, XEPLOAI, KHOA  " +
                "FROM SINHVIEN SV, LOP L WHERE SV.MALOP = L.MALOP AND SV.XEPLOAI = N'" + sv.XepLoai +"' AND " +
                "L.KHOA = '" + l.Khoa + "' ORDER BY DIEMTRUNGBINH DESC";
            dt = KETNOI_SQL.DocDuLieu(sql);
            return dt;
        }

        public DataTable ThongTin_SinhVien_TheoLop(Lop_DTO l)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT MASINHVIEN, TENSINHVIEN, GIOITINH, DIEMTRUNGBINH, TINCHIDAT, XEPLOAI, L.MALOP, TENLOP  " +
                "FROM SINHVIEN SV, LOP L WHERE SV.MALOP = L.MALOP AND L.MALOP = '" + l.MaLop + "' ORDER BY DIEMTRUNGBINH DESC";
            dt = KETNOI_SQL.DocDuLieu(sql);
            return dt;
        }
        public DataTable Loc_XepLoai_SinhVien_TheoLop(Lop_DTO l, SinhVien_DTO sv)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT MASINHVIEN, TENSINHVIEN, GIOITINH, DIEMTRUNGBINH, TINCHIDAT, XEPLOAI, L.MALOP, TENLOP  " +
                "FROM SINHVIEN SV, LOP L WHERE SV.MALOP = L.MALOP AND SV.XEPLOAI = N'" + sv.XepLoai + "' AND L.MALOP = '" + l.MaLop + "' ORDER BY DIEMTRUNGBINH DESC";
            dt = KETNOI_SQL.DocDuLieu(sql);
            return dt;
        }
        public DataTable ThongTin_Diem_SinhVien_TheoMa(SinhVien_DTO sv)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT HP.MAHOCPHAN, TENHOCPHAN, TILEDIEMTHUONGXUYEN, TILEDIEMTHI, DIEMTHUONGXUYEN, DIEMTHILAN1, DIEMTHILAN2, DIEMTRUNGBINHMON, DIEMTRUNGBINHMONHE4 " +
                " FROM SINHVIEN SV, LOP L, SINHVIENHOC SVH, HOCPHAN HP" +
                " WHERE SVH.MAHOCPHAN = HP.MAHOCPHAN AND SV.MASINHVIEN = SVH.MASINHVIEN AND L.MALOP = SV.MALOP AND SV.MASINHVIEN = '" + sv.MaSinhVien + "'";
            dt = KETNOI_SQL.DocDuLieu(sql);
            return dt;
        }
        public DataTable ThongTin_Diem_SinhVien_TheoMaHK(SinhVien_DTO sv, HocPhan_DTO hp)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT HP.MAHOCPHAN, TENHOCPHAN, TILEDIEMTHUONGXUYEN, TILEDIEMTHI, DIEMTHUONGXUYEN, DIEMTHILAN1, DIEMTHILAN2, DIEMTRUNGBINHMON, DIEMTRUNGBINHMONHE4 " +
                " FROM SINHVIEN SV, LOP L, SINHVIENHOC SVH, HOCPHAN HP" +
                " WHERE SVH.MAHOCPHAN = HP.MAHOCPHAN AND SV.MASINHVIEN = SVH.MASINHVIEN AND L.MALOP = SV.MALOP AND SV.MASINHVIEN = '" + sv.MaSinhVien + "' AND HOCKY = " + hp.HocKy + "";
            dt = KETNOI_SQL.DocDuLieu(sql);
            return dt;
        }
    }
}
