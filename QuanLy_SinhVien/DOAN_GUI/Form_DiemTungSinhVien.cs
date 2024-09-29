using QuanLy_SinhVien.DOAN_DAO;
using QuanLy_SinhVien.DOAN_DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLy_SinhVien.DOAN_GUI
{
    public partial class Form_DiemTungSinhVien : Form
    {
        public Form_DiemTungSinhVien()
        {
            InitializeComponent();
        }
        public string MaSinhVien;
        public string TenSinhVien;
        public float DiemTrungBinh10;
        public float DiemTrungBinh4;
        public string XepLoai;
        public string TinChi;
        HocPhan_DTO hocPhan_DTO = new HocPhan_DTO();
        SinhVien_DTO sinhVien_DTO = new SinhVien_DTO();
        SinhVien_DAO sinhVien_DAO = new SinhVien_DAO();
        DataTable dt = new DataTable();
        public void load_DTG_SinhVien()
        {
            sinhVien_DTO.MaSinhVien = MaSinhVien;
            dt = sinhVien_DAO.ThongTin_Diem_SinhVien_TheoMa(sinhVien_DTO);
            dtg_DiemSinhVien.DataSource = dt;
            dtg_DiemSinhVien.ColumnHeadersDefaultCellStyle.Font = new Font("Cambria", 12, FontStyle.Bold);
        }
        public void load_DTG_SinhVien_TheoHK()
        {
            if (cmb_HocKy.Text == "  --Chọn học kỳ--")
                MessageBox.Show("Vui lòng chọn học kỳ!!", "Thông báo");
            else
            {
                hocPhan_DTO.HocKy = int.Parse(cmb_HocKy.SelectedItem.ToString());
                sinhVien_DTO.MaSinhVien = MaSinhVien;
                dt = sinhVien_DAO.ThongTin_Diem_SinhVien_TheoMaHK(sinhVien_DTO, hocPhan_DTO);
                dtg_DiemSinhVien.DataSource = dt;
            }
        }
        private void Form_DiemTungSinhVien_Load(object sender, EventArgs e)
        {
            lab_DiemSV.Text = "THÔNG TIN ĐIỂM CỦA SINH VIÊN " + TenSinhVien + " - " + MaSinhVien;
            lab_Diem10.Text = DiemTrungBinh10.ToString();
            lab_Diem4.Text = DiemTrungBinh4.ToString();
            lab_XepLoai.Text = XepLoai;
            lab_TinChi.Text = TinChi;
            load_DTG_SinhVien();
        }

        private void btn_Xem_Click(object sender, EventArgs e)
        {
            load_DTG_SinhVien_TheoHK();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
