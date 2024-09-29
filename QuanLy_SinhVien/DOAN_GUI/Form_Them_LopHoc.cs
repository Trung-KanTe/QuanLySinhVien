using QuanLy_SinhVien.BATLOI;
using QuanLy_SinhVien.DOAN_DAO;
using QuanLy_SinhVien.DOAN_DTO;
using QuanLy_SinhVien.DOAN_GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLy_SinhVien
{
    public partial class Form_Them_LopHoc : Form
    {
        public Form_Them_LopHoc()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        LOI loi = new LOI();
        HocPhan_DAO hocPhan_DAO = new HocPhan_DAO();
        LopHoc_DAO lopHoc_DAO = new LopHoc_DAO();
        LopHoc_DTO lopHoc_DTO = new LopHoc_DTO();
        GiangVien_DTO giangVien_DTO = new GiangVien_DTO();
        DateTime date = DateTime.Now;
        public Form Form_Con_Duoc_Chon;
        string maLopHoc;
        public void load_CMB_HocPhan()
        {
            dt = hocPhan_DAO.ThongTin_HocPhan();
            cmb_HocPhan.DataSource = dt;
            cmb_HocPhan.ValueMember = "MAHOCPHAN";
            cmb_HocPhan.DisplayMember = "TENHOCPHAN";
        }
        public void load_CMB_HocPhan_Nhom()
        {
            dt = hocPhan_DAO.ThongTin_HocPhan();
            cmb_Nhom_HocPhan.DataSource = dt;
            cmb_Nhom_HocPhan.ValueMember = "MAHOCPHAN";
            cmb_Nhom_HocPhan.DisplayMember = "TENHOCPHAN";
        }
        public void load_CMB_GiangVien()
        {
            dt = lopHoc_DAO.ThongTin_GiangVien();
            cmb_GiangVien.DataSource = dt;
            cmb_GiangVien.ValueMember = "MAGIANGVIEN";
            cmb_GiangVien.DisplayMember = "TENGIANGVIEN";
        }
        
        public void load_DTG_LopHoc()
        {
            dt = lopHoc_DAO.ThongTin_LopHoc();
            dtg_LopHoc.DataSource = dt;
            dtg_LopHoc.ColumnHeadersDefaultCellStyle.Font = new Font("Cambria", 12, FontStyle.Bold);
            dtg_LopHoc.Columns["MALOPHOC"].HeaderText = "MÃ LỚP HỌC";
            dtg_LopHoc.Columns["NHOM"].HeaderText = "NHÓM";
            dtg_LopHoc.Columns["MAHOCPHAN"].Visible = false;
            dtg_LopHoc.Columns["TENHOCPHAN"].HeaderText = "TÊN HỌC PHẦN";
            dtg_LopHoc.Columns["HOTENGIANGVIEN"].HeaderText = "HỌ TÊN GIẢNG VIÊN";
            dtg_LopHoc.Columns["NAMHOC"].HeaderText = "NĂM HỌC";

        }
        public void load_CMB_NamHoc()
        {
            for (int i = 2019; i <= date.Year; i++)
            {
                cmb_NamHoc.Items.Add(i);
            }
        }
        public bool loi_DuLieu_Nhom()
        {
            if (loi.loi_Trong(txt_Nhom.Text)) return false;
            if (loi.loi_ChuaKiTu(txt_Nhom.Text)) return false;
            return true;
        }
        public bool loi_DuLieu()
        {
            if (loi.loi_Trong(txt_Nhom.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!!!", "Thông báo");
                return false;
            }
            if (loi.loi_ChuaKiTu(txt_Nhom.Text))
            {
                MessageBox.Show("Nhóm chứa kí tự!!!", "Thông báo");
                return false;
            }
            return true;
        }
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

        private void Form_Them_LopHoc_Load(object sender, EventArgs e)
        {
            load_CMB_HocPhan();
            load_CMB_HocPhan_Nhom();
            load_CMB_GiangVien();
            load_DTG_LopHoc();
            load_CMB_NamHoc();
            btn_LamMoi_Click(sender, e);
        }

        private void dtg_LopHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow select_Row = dtg_LopHoc.Rows[e.RowIndex];
                txt_MaLopHoc.Enabled = false;
                txt_Nhom.Enabled = false;
                cmb_GiangVien.Enabled = false; ;
                cmb_HocPhan.Enabled = false;
                btn_Them.Enabled = false;
                txt_MaLopHoc.Text = select_Row.Cells["MALOPHOC"].Value.ToString();
                txt_Nhom.Text = select_Row.Cells["NHOM"].Value.ToString();
                cmb_HocPhan.Text = select_Row.Cells["TENHOCPHAN"].Value.ToString();
                cmb_GiangVien.Text = select_Row.Cells["HOTENGIANGVIEN"].Value.ToString();
            }
        }

        private void dtg_LopHoc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow select_Row = dtg_LopHoc.Rows[e.RowIndex];
                Form_SinhVien_Hoc frm_SVH = new Form_SinhVien_Hoc();
                frm_SVH.maLopHoc = select_Row.Cells["MALOPHOC"].Value.ToString();
                frm_SVH.nhom = select_Row.Cells["NHOM"].Value.ToString();
                frm_SVH.maHocPhan = select_Row.Cells["MAHOCPHAN"].Value.ToString();
                frm_SVH.tenHocPhan = select_Row.Cells["TENHOCPHAN"].Value.ToString();
                frm_SVH.tenGiangVien = select_Row.Cells["HOTENGIANGVIEN"].Value.ToString();
                Open_Form(frm_SVH);
            }
            
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {  
            if (loi_DuLieu())
            {
                if (MessageBox.Show("Bạn có chắc muốn thêm thông tin lớp học này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        lopHoc_DTO.MaLopHoc = txt_MaLopHoc.Text;
                        lopHoc_DTO.Nhom = int.Parse(txt_Nhom.Text.Trim());
                        lopHoc_DTO.MaHocPhan = cmb_HocPhan.SelectedValue.ToString().Trim();
                        lopHoc_DTO.MaGiangVien = cmb_GiangVien.SelectedValue.ToString().Trim();
                        lopHoc_DTO.NamHoc = cmb_NamHoc.SelectedItem.ToString().Trim();
                        lopHoc_DAO.Them_LopHoc(lopHoc_DTO);
                        btn_LamMoi_Click(sender, e);
                        load_DTG_LopHoc();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Thêm lớp học không thành công!");
                    }
                }
            }
        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            load_CMB_GiangVien();
            load_DTG_LopHoc();
            txt_MaLopHoc.Clear();
            txt_Nhom.Clear();
            txt_Nhom.Enabled = true;
            cmb_GiangVien.Enabled = true;
            cmb_HocPhan.Enabled = true;
            btn_Them.Enabled = true;
            cmb_HocPhan.Text = "  --Chọn học phần--";
            cmb_Nhom_HocPhan.Text = "  --Chọn học phần--";
            cmb_GiangVien.Text = "  --Chọn giảng viên--";
            cmb_NamHoc.Text = "  --Chọn năm học--";
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

        private void btn_Khoa_Click(object sender, EventArgs e)
        {
            Open_Form(new Form_Khoa_LopHoc());
        }

        private void cmb_Nhom_HocPhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Nhom_HocPhan.SelectedValue != null && cmb_Nhom_HocPhan.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                lopHoc_DTO.MaHocPhan = cmb_Nhom_HocPhan.SelectedValue.ToString().Trim();
                dt = lopHoc_DAO.ThongTin_LopHoc_HocPhan(lopHoc_DTO);
                dtg_LopHoc.DataSource = dt;
            }
        }

        private void cmb_NamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loi_DuLieu_Nhom())
            {
                if (int.Parse(txt_Nhom.Text) <= 9)
                {
                    txt_Nhom.Text = "0" + txt_Nhom.Text;
                }
                txt_MaLopHoc.Text = cmb_HocPhan.SelectedValue.ToString().Trim() + "-" + txt_Nhom.Text + "-" + cmb_NamHoc.SelectedItem.ToString().Trim();
            }
        }
    }
}
