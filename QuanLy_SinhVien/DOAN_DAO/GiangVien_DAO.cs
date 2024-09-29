using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLy_SinhVien.DOAN_DTO;

namespace QuanLy_SinhVien.DOAN_DAO
{
    internal class GiangVien_DAO
    {
        public DataTable ThongTin_GiangVien()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT MAGIANGVIEN, HOTENLOTGIANGVIEN, TENGIANGVIEN, GIOITINH, NGAYSINH, SDT, VAITRO, DIACHI, KICHHOAT FROM GIANGVIEN";
            dt = KETNOI_SQL.DocDuLieu(sql);
            return dt;
        }
        public DataTable ThongTin_GiangVienCoVan()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT MAGIANGVIEN, HOTENLOTGIANGVIEN + ' ' + TENGIANGVIEN AS TENGIANGVIEN FROM GIANGVIEN WHERE VAITRO = 0";
            dt = KETNOI_SQL.DocDuLieu(sql);
            return dt;
        }
        public void CapNhap_CoVanTheoMa(GiangVien_DTO gv)
        {
            string sql = "UPDATE GIANGVIEN SET VAITRO = " + gv.VaiTro + " WHERE MAGIANGVIEN = '" + gv.MaGiangVien + "'";
            KETNOI_SQL.ThucThiTruyVan(sql);
        }
      
        public void Them_GiangVien(GiangVien_DTO gv)
        {
            string sql = "INSERT INTO GIANGVIEN (MAGIANGVIEN, HOTENLOTGIANGVIEN, TENGIANGVIEN, GIOITINH, NGAYSINH, SDT, " +
                "VAITRO, DIACHI, KICHHOAT) VALUES ('" + gv.MaGiangVien + "',N'"+ gv.HoTenLotGiangVien + "', N'" + gv.TenGiangVien + "',N'" + 
                gv.GioiTinh + "','" + gv.NgaySinh + "', '" + gv.SoDienThoai + "'," + gv.VaiTro + ",N'" + 
                gv.DiaChi + "'," + gv.KichHoat + ")";
            KETNOI_SQL.ThucThiTruyVan(sql);
        }
        public void CapNhat_GiangVien(GiangVien_DTO gv)
        {
            string sql = "UPDATE GIANGVIEN SET HOTENLOTGIANGVIEN = N'" + gv.HoTenLotGiangVien +
                "',TENGIANGVIEN = N'" + gv.TenGiangVien +
                "', GIOITINH = N'" + gv.GioiTinh +
                "', NGAYSINH = '" + gv.NgaySinh +
                "', SDT = '" + gv.SoDienThoai +
                "', DIACHI = N'" + gv.DiaChi +
                "' WHERE MAGIANGVIEN = '" + gv.MaGiangVien + "'";

            KETNOI_SQL.ThucThiTruyVan(sql);
        }
        public void Xoa_GiangVien(GiangVien_DTO gv)
        {
            string sql = "DELETE FROM GIANGVIEN WHERE MAGIANGVIEN='" + gv.MaGiangVien + "'";
            KETNOI_SQL.ThucThiTruyVan(sql);
        }
    }
}
