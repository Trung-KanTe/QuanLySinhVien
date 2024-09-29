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
    public partial class Form_Quen_MatKhau : Form
    {
        public Form_Quen_MatKhau()
        {
            InitializeComponent();
        }
        public int temp = 0;
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
        public bool check_Rong(string str)
        {
            return str == "" ? true : false;
        }

        private void btn_TiepTuc_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            TaiKhoan_GiangVien_DAO tk_DAO = new TaiKhoan_GiangVien_DAO();
            TaiKhoan_GiangVien_DTO tk_DTO = new TaiKhoan_GiangVien_DTO();
            tk_DTO.MaGiangVien = txt_MaGiangVien.Text;
            dt = tk_DAO.Xem_ThongTin_TaiKhoan_QuenMat(tk_DTO);
            if (dt.Rows.Count > 0)
            {
                Form_LayMatKhau frm = new Form_LayMatKhau();
                frm.maGiangVien = txt_MaGiangVien.Text;
                Open_Form(frm);
            }
            else
                MessageBox.Show("Kiểm tra lại mã giảng viên!", "Thông báo");
        }

        private void txt_MaGiangVien_Click(object sender, EventArgs e)
        {
            if (txt_MaGiangVien.Text == "Mã giảng viên")
            {
                txt_MaGiangVien.Text = "";
            }
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            if (check_Rong(txt_MaGiangVien.Text))
            {
                txt_MaGiangVien.Text = "Mã giảng viên";
            }
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Bạn có muốn thoát chương trình không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void Form_Quen_MatKhau_Load(object sender, EventArgs e)
        {
            if (temp == 1)
                Close();
        }
    }
}
