using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLy_SinhVien.BATLOI;
using QuanLy_SinhVien.DOAN_DAO;
using QuanLy_SinhVien.DOAN_DTO;

namespace QuanLy_SinhVien
{
    public partial class Form_Khoa_SinhVien : Form
    {
        public Form_Khoa_SinhVien()
        {
            InitializeComponent();
        }
        public string label_TrangThai;

        public Form Form_Con_Duoc_Chon;
        DataTable dt = new DataTable();
        LOI loi = new LOI();
        GiangVien_DAO giangVien_DAO = new GiangVien_DAO();
        GiangVien_DTO giangVien_DTO = new GiangVien_DTO();
        Lop_DAO lop_DAO = new Lop_DAO();
        Lop_DTO lop_DTO = new Lop_DTO();
        DateTime date = DateTime.Now;
        string luu_CoVan;

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

        public void load_DTG_Lop()
        {
            dt = lop_DAO.ThongTin_Lop();
            dtg_Lop.ColumnHeadersDefaultCellStyle.Font = new Font("Cambria", 12, FontStyle.Bold);
            dtg_Lop.DataSource = dt;
            dtg_Lop.Columns["MALOP"].HeaderText = "MÃ LỚP";
            dtg_Lop.Columns["TENLOP"].HeaderText = "TÊN LỚP";
            dtg_Lop.Columns["KHOA"].HeaderText = "KHÓA";
            dtg_Lop.Columns["TENGIANGVIEN"].HeaderText = "TÊN GIẢNG VIÊN";

        }
        public void load_CBB_GiangVien()
        {
            dt = giangVien_DAO.ThongTin_GiangVienCoVan();
            cmb_GiangVien.DataSource = dt;
            cmb_GiangVien.ValueMember = "MAGIANGVIEN";
            cmb_GiangVien.DisplayMember = "TENGIANGVIEN";
            cmb_GiangVien.Text = "  --Chọn giảng viên--";
        }
        public void load_CMB_Khoa()
        {
            for (int i = 20; i <= date.Year - 1999; i++)
            {
                cmb_Khoa.Items.Add(i);
            }
        }
        public bool loi_DuLieu()
        {
            if (loi.loi_Trong(txt_MaLop.Text) || loi.loi_Trong(txt_TenLop.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!!!", "Thông báo");
                return false;
            }
            return true;
        }
        private void Form_Khoa_SinhVien_Load(object sender, EventArgs e)
        {
            load_CBB_GiangVien();
            load_CMB_Khoa();
            load_DTG_Lop();
            btn_LamMoi_Click(sender, e);

        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (loi_DuLieu())
            {
                if (MessageBox.Show("Bạn có chắc muốn thêm thông tin lớp này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        lop_DTO.MaLop = txt_MaLop.Text.Trim();
                        lop_DTO.TenLop = txt_TenLop.Text.Trim();
                        lop_DTO.Khoa = (int)cmb_Khoa.SelectedItem;
                        lop_DTO.MaGiangVien = cmb_GiangVien.SelectedValue.ToString();
                        giangVien_DTO.MaGiangVien = cmb_GiangVien.SelectedValue.ToString();
                        giangVien_DTO.VaiTro = 1;
                        lop_DAO.Them_Lop(lop_DTO);
                        giangVien_DAO.CapNhap_CoVanTheoMa(giangVien_DTO);
                        btn_LamMoi_Click(sender, e);
                        load_CBB_GiangVien();
                        load_DTG_Lop();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Thêm lớp không thành công!");
                    }
                }
            }
        }


        private void dtg_Lop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow select_Row = dtg_Lop.Rows[e.RowIndex];
                txt_MaLop.Enabled = false;
                cmb_GiangVien.Enabled = false;
                cmb_Khoa.Enabled = false;
                txt_TenLop.Enabled = false;
                btn_Them.Enabled = false;
                txt_MaLop.Text = select_Row.Cells["MALOP"].Value.ToString();
                txt_TenLop.Text = select_Row.Cells["TENLOP"].Value.ToString();
                cmb_Khoa.Text = select_Row.Cells["KHOA"].Value.ToString();
                cmb_GiangVien.Text = select_Row.Cells["TENGIANGVIEN"].Value.ToString();
                luu_CoVan = cmb_GiangVien.Text;
            }
        }

        private void dtg_Lop_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                Form_DanhSach_SinhVien frm_SV = new Form_DanhSach_SinhVien();
                DataGridViewRow select_Row = dtg_Lop.Rows[e.RowIndex];
                frm_SV.maLop = select_Row.Cells["MALOP"].Value.ToString();
                Open_Form(frm_SV);

            }
        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            txt_MaLop.Enabled = true;
            cmb_GiangVien.Enabled = true;
            cmb_Khoa.Enabled = true;
            txt_TenLop.Enabled = true;
            btn_Them.Enabled = true;
            txt_MaLop.Clear();
            txt_TenLop.Clear();
            cmb_Khoa.Text = "  --Chọn khóa--";
            cmb_GiangVien.Text = "  --Chọn giảng viên--";

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

        private void cmb_GiangVien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
