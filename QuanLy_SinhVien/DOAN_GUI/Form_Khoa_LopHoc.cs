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
    public partial class Form_Khoa_LopHoc : Form
    {
        DateTime date = DateTime.Now;
        LopHoc_DAO lopHoc_DAO = new LopHoc_DAO();
        LopHoc_DTO lopHoc_DTO = new LopHoc_DTO();
        DataTable dt = new DataTable();
        public Form_Khoa_LopHoc()
        {
            InitializeComponent();
        }
        public void load_CMB_NamHoc()
        {
            for (int i = 2019; i <= date.Year; i++)
            {
                cmb_NamHoc.Items.Add(i);
            }
        }
        public void load_DTG_LopHoc_ChuaKhoa()
        {
            dt = lopHoc_DAO.ThongTinLopHoc_ChuaKhoa();
            dtg_LopHocChuaKhoa.DataSource = dt;
            dtg_LopHocChuaKhoa.ColumnHeadersDefaultCellStyle.Font = new Font("Cambria", 12, FontStyle.Bold);
            dtg_LopHocChuaKhoa.Columns["MALOPHOC"].HeaderText = "MÃ LỚP HỌC";
            dtg_LopHocChuaKhoa.Columns["NHOM"].HeaderText = "NHÓM";
            dtg_LopHocChuaKhoa.Columns["MAHOCPHAN"].Visible = false;
            dtg_LopHocChuaKhoa.Columns["TENHOCPHAN"].HeaderText = "TÊN HỌC PHẦN";
            dtg_LopHocChuaKhoa.Columns["HOTENGIANGVIEN"].HeaderText = "HỌ TÊN GIẢNG VIÊN";
            dtg_LopHocChuaKhoa.Columns["NAMHOC"].HeaderText = "NĂM HỌC";
            dtg_LopHocChuaKhoa.Columns["KHOA"].HeaderText = "KHÓA";

        }
        public void load_DTG_LopHoc_DaKhoa()
        {
            dt = lopHoc_DAO.ThongTinLopHoc_DaKhoa();
            dtg_LopHocDaKhoa.DataSource = dt;
            dtg_LopHocDaKhoa.ColumnHeadersDefaultCellStyle.Font = new Font("Cambria", 12, FontStyle.Bold);
            dtg_LopHocDaKhoa.Columns["MALOPHOC"].HeaderText = "MÃ LỚP HỌC";
            dtg_LopHocDaKhoa.Columns["NHOM"].HeaderText = "NHÓM";
            dtg_LopHocDaKhoa.Columns["MAHOCPHAN"].Visible = false;
            dtg_LopHocDaKhoa.Columns["TENHOCPHAN"].HeaderText = "TÊN HỌC PHẦN";
            dtg_LopHocDaKhoa.Columns["HOTENGIANGVIEN"].HeaderText = "HỌ TÊN GIẢNG VIÊN";
            dtg_LopHocDaKhoa.Columns["NAMHOC"].HeaderText = "NĂM HỌC";
            dtg_LopHocDaKhoa.Columns["KHOA"].HeaderText = "KHÓA";

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

        private void Form_Khoa_LopHoc_Load(object sender, EventArgs e)
        {
            load_DTG_LopHoc_ChuaKhoa();
            load_DTG_LopHoc_DaKhoa();
            load_CMB_NamHoc();
        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            load_DTG_LopHoc_ChuaKhoa();
            load_DTG_LopHoc_DaKhoa();
            load_CMB_NamHoc();
        }

        private void btn_Mo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn mở khóa các lớp học này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    lopHoc_DTO.MaLopHoc = txt_MaLopHoc.Text;
                    lopHoc_DAO.MoKhoa_LopHoc(lopHoc_DTO);
                    load_DTG_LopHoc_ChuaKhoa();
                    load_DTG_LopHoc_DaKhoa();
                }
                catch (Exception)
                {
                    MessageBox.Show("Mở khóa lớp học không thành công!");
                }
            }
        }

        private void btn_Khoa1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn khóa các lớp học này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    lopHoc_DTO.NamHoc = cmb_NamHoc.SelectedItem.ToString().Trim();
                    lopHoc_DAO.Khoa_LopHoc(lopHoc_DTO);
                    btn_LamMoi_Click(sender, e);
                }
                catch (Exception)
                {
                    MessageBox.Show("Khóa lớp học không thành công!");
                }
            }
        }

        private void cmb_NamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_NamHoc.SelectedItem != null && cmb_NamHoc.SelectedItem.ToString() != "System.Data.DataRowView")
            {
                lopHoc_DTO.NamHoc = cmb_NamHoc.SelectedItem.ToString().Trim();
                dt = lopHoc_DAO.ThongTinLopHoc_TheoNam(lopHoc_DTO);
                dtg_LopHocChuaKhoa.DataSource = dt;
            }
        }

        private void dtg_LopHocDaKhoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow select_Row = dtg_LopHocDaKhoa.Rows[e.RowIndex];
                txt_MaLopHoc.Text = select_Row.Cells["MALOPHOC"].Value.ToString();
                txt_NhomLop.Text = select_Row.Cells["NHOM"].Value.ToString();
                txt_TenHocPhan.Text = select_Row.Cells["TENHOCPHAN"].Value.ToString();
                txt_GiangVien.Text = select_Row.Cells["HOTENGIANGVIEN"].Value.ToString();
                txtNamHoc.Text = select_Row.Cells["NAMHOC"].Value.ToString();
            }
        }
    }
}
