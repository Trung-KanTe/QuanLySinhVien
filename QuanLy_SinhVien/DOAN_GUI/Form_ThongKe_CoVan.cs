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
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLy_SinhVien.DOAN_GUI
{
    public partial class Form_ThongKe_CoVan : Form
    {
        public Form_ThongKe_CoVan()
        {
            InitializeComponent();
        }
        SinhVien_DAO sinhVien_DAO = new SinhVien_DAO();
        SinhVien_DTO sinhVien_DTO = new SinhVien_DTO();
        DataTable dt = new DataTable();
        public string maLop;
        public string tenLop;
        public string Khoa;
        public string hoTenLotGV;
        public string tenGiangVien;
        public Form Form_Con_Duoc_Chon;
        public void Open_Form(Form form_Con)
        {
            if (Form_Con_Duoc_Chon != null)
            {
                Form_Con_Duoc_Chon.Close();
            }
            Form_Con_Duoc_Chon = form_Con;
            form_Con.TopLevel = false;
            form_Con.Dock = DockStyle.Fill;
            panel_Chinh.Controls.Add(form_Con);
            panel_Chinh.Tag = form_Con;
            form_Con.BringToFront();
            form_Con.Show();
        }

        public void load_DTG_SinhVien()
        {

            dt = sinhVien_DAO.ThongTin_Diem_SinhVien(sinhVien_DTO);
            dtg_SinhVien.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                dtg_SinhVien.ColumnHeadersDefaultCellStyle.Font = new Font("Cambria", 12, FontStyle.Bold);
                dtg_SinhVien.Columns["MASINHVIEN"].HeaderText = "MÃ SINH VIÊN";
                dtg_SinhVien.Columns["TENSINHVIEN"].HeaderText = "TÊN SINH VIÊN";
                dtg_SinhVien.Columns["GIOITINH"].HeaderText = "GIỚI TÍNH";
                dtg_SinhVien.Columns["DIEMTRUNGBINH"].HeaderText = "ĐIỂM TRUNG BÌNH";
                dtg_SinhVien.Columns["DIEMTRUNGBINHHE4"].HeaderText = "ĐIỂM TRUNG BÌNH HỆ 4";
                dtg_SinhVien.Columns["TINCHIDAT"].HeaderText = "TÍN CHỈ ĐẠT";
                dtg_SinhVien.Columns["XEPLOAI"].HeaderText = "XẾP LOẠI";
            }
           
        }
        public void load_Tong_SinhVien()
        {
            dt = sinhVien_DAO.SoLuong_SinhVien(sinhVien_DTO);
            lab_TongSinhVien.Text = dt.Rows[0]["SOLUONGSV"].ToString();
        }
        public void load_SinhVien_Gioi()
        {
            dt = sinhVien_DAO.So_SinhVien_Gioi(sinhVien_DTO);
            lab_SinhVienGioi.Text = dt.Rows[0]["SOLUONGSV"].ToString();
        }
        public void load_TrungBinhDiemSinhVien()
        {
            dt = sinhVien_DAO.DiemTrungBinh_Lop(sinhVien_DTO);
            lab_TrungBinhDiem.Text = dt.Rows[0]["DTB"].ToString();
        }
        public void load_Top_20()
        {
            dt = sinhVien_DAO.DiemTrungBinh_Top_20(sinhVien_DTO);
            lab_Top20.Text = dt.Rows[0]["TrungBinhDiem"].ToString();
        }
        public int dem_SoLuong(DataTable dt, double min, double max)
        {
            int dem = 0;
            foreach (DataRow dr in dt.Rows)
            {
                float DiemTB = float.Parse(dr["DIEMTRUNGBINH"].ToString());
                if (DiemTB > min && DiemTB < max)
                    dem++;
            }
            return dem;
        }
        private void load_Chart_SinhVien()
        {
            dt = sinhVien_DAO.SapXep_SinhVien(sinhVien_DTO);
            chart1.DataSource = dt;
            chart1.ChartAreas["ChartArea1"].AxisX.Title = "Xếp loại";
            chart1.ChartAreas["ChartArea1"].AxisY.Title = "Số sinh viên";
            chart1.Series["Series1"].XValueMember = "XEPLOAI";
            chart1.Series["Series1"].YValueMembers = "SOLUONG";
            chart1.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Cambria", 8, FontStyle.Bold);
            chart1.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("Cambria", 8, FontStyle.Bold);
            chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Font = new Font("Cambria", 9, FontStyle.Bold);
        }

        private void Form_ThongKe_CoVan_Load(object sender, EventArgs e)
        {
            sinhVien_DTO.MaLop = maLop;
            sinhVien_DAO.CapNhat_DiemTB();
            sinhVien_DAO.CapNhat_DiemTB4();
            sinhVien_DAO.CapNhat_TinChi();
            sinhVien_DAO.CapNhat_XepLoai();
            load_DTG_SinhVien();
            load_Tong_SinhVien();
            load_SinhVien_Gioi();
            load_TrungBinhDiemSinhVien();
            load_Top_20();
            load_Chart_SinhVien();
            label_ThongTin.Text = "THÔNG TIN LỚP " + tenLop.ToUpper() + " - KHÓA " + Khoa + " ( " + maLop + ")";
            lab_Avatar.Text = tenGiangVien.Substring(0, 1);
            lab_Ten.Text = hoTenLotGV + " " + tenGiangVien;

        }

        private void btn_20_Lop_Click(object sender, EventArgs e)
        {
            dt.Clear();
            dt = sinhVien_DAO.DS_Top_20_SV(sinhVien_DTO);
            dtg_SinhVien.DataSource = dt;
        }

        private void btn_TongSinhVien_Click(object sender, EventArgs e)
        {
            load_DTG_SinhVien();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btn_SinhVienGioi_Click(object sender, EventArgs e)
        {
            dt.Clear();
            dt = sinhVien_DAO.ThongTin_SinhVien_Gioi(sinhVien_DTO);
            dtg_SinhVien.DataSource = dt;
        }

        private void ntm_TrungBinhLop_Click(object sender, EventArgs e)
        {
            load_DTG_SinhVien();
        }

        private void dtg_SinhVien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                Form_DiemTungSinhVien frm_SV = new Form_DiemTungSinhVien();
                DataGridViewRow select_Row = dtg_SinhVien.Rows[e.RowIndex];
                frm_SV.MaSinhVien = select_Row.Cells["MASINHVIEN"].Value.ToString();
                frm_SV.TenSinhVien = select_Row.Cells["TENSINHVIEN"].Value.ToString();
                frm_SV.DiemTrungBinh10 = float.Parse(select_Row.Cells["DIEMTRUNGBINH"].Value.ToString());
                frm_SV.DiemTrungBinh4 = float.Parse(select_Row.Cells["DIEMTRUNGBINHHE4"].Value.ToString());
                frm_SV.XepLoai = select_Row.Cells["XEPLOAI"].Value.ToString();
                frm_SV.TinChi = select_Row.Cells["TINCHIDAT"].Value.ToString();
                Open_Form(frm_SV);

            }
        }
    }
}
