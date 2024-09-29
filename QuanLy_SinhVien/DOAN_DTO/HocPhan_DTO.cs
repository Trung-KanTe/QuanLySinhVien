using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLy_SinhVien.DOAN_DTO
{
    internal class HocPhan_DTO
    {
        private string maHocPhan;
        private string tenHocPhan;
        private int soTinChi;
        private int hocKy;
        private float tiLeDiemThuongXuyen;
        private float tiLeDiemThi;

       

        public string MaHocPhan { get => maHocPhan; set => maHocPhan = value; }
        public string TenHocPhan { get => tenHocPhan; set => tenHocPhan = value; }
        public int SoTinChi { get => soTinChi; set => soTinChi = value; }
        public int HocKy { get => hocKy; set => hocKy = value; }
        public float TiLeDiemThuongXuyen { get => tiLeDiemThuongXuyen; set => tiLeDiemThuongXuyen = value; }
        public float TiLeDiemThi { get => tiLeDiemThi; set => tiLeDiemThi = value; }

        public HocPhan_DTO()
        {
            this.maHocPhan = "";
            this.tenHocPhan = "";
            this.soTinChi = 0;
            this.hocKy = 0;
            this.tiLeDiemThuongXuyen = 0;
            this.tiLeDiemThi = 0;
        }
        public HocPhan_DTO(string maHocPhan, string tenHocPhan, int soTinChi, int hocKy, float tiLeDiemThuongXuyen, float tiLeDiemThi)
        {
            this.maHocPhan = maHocPhan;
            this.tenHocPhan = tenHocPhan;
            this.soTinChi = soTinChi;
            this.hocKy = hocKy;
            this.tiLeDiemThuongXuyen = tiLeDiemThuongXuyen;
            this.tiLeDiemThi = tiLeDiemThi;
        }
    }
}
