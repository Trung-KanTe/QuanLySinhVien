using QuanLy_SinhVien.DOAN_DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuanLy_SinhVien.DOAN_DAO
{
    internal class HocPhan_DAO
    {
        public DataTable ThongTin_HocPhan()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM HOCPHAN";
            dt = KETNOI_SQL.DocDuLieu(sql);
            return dt;
        }

        public void Them_HocPhan(HocPhan_DTO hp)
        {
            string sql = "INSERT INTO HOCPHAN (MAHOCPHAN, TENHOCPHAN, SOTINCHI, HOCKY, TILEDIEMTHUONGXUYEN, TILEDIEMTHI)" +
                " VALUES ('" + hp.MaHocPhan + "',N'" + hp.TenHocPhan + "', " +
                hp.SoTinChi + "," + hp.HocKy + ", " + hp.TiLeDiemThuongXuyen + ", " + hp.TiLeDiemThi +")";
            KETNOI_SQL.ThucThiTruyVan(sql);
        }

        public void CapNhat_HocPhan(HocPhan_DTO hp)
        {
            string sql = "UPDATE HOCPHAN SET TENHOCPHAN = N'" + hp.TenHocPhan +
                "', SOTINCHI = " + hp.SoTinChi +
                ", HOCKY = " + hp.HocKy +
                ", TILEDIEMTHUONGXUYEN = " + hp.TiLeDiemThuongXuyen +
                ", TILEDIEMTHI = " + hp.TiLeDiemThi +
                " WHERE MAHOCPHAN = '" + hp.MaHocPhan + "'";
            KETNOI_SQL.ThucThiTruyVan(sql);
        }
        public void Xoa_HocPhan(HocPhan_DTO hp)
        {
            string sql = "DELETE FROM HOCPHAN WHERE MAHOCPHAN = '" + hp.MaHocPhan + "'";
            KETNOI_SQL.ThucThiTruyVan(sql);
        }
    }
}
