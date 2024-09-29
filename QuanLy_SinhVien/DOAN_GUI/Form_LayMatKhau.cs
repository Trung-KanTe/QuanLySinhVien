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
    public partial class Form_LayMatKhau : Form
    {
        public Form_LayMatKhau()
        {
            InitializeComponent();
        }
        public string maGiangVien;
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
        private void btn_XacNhan_Click(object sender, EventArgs e)
        {
            if (txt_MatKhau.Text == txt_XNMK.Text)
            {
                DataTable dt = new DataTable();
                TaiKhoan_GiangVien_DAO tk_DAO = new TaiKhoan_GiangVien_DAO();
                TaiKhoan_GiangVien_DTO tk_DTO = new TaiKhoan_GiangVien_DTO();
                tk_DTO.MaGiangVien = maGiangVien;
                tk_DTO.MatKhau = txt_MatKhau.Text;
                tk_DAO.CapNhat_MatKhau(tk_DTO);
                MessageBox.Show("Mật khẩu đã được thay đổi", "Thông báo");
                Form_Quen_MatKhau frm = new Form_Quen_MatKhau();
                frm.temp = 1;
                Close();

            }
            else
                MessageBox.Show("Xác nhận mật khẩu không khớp", "Thông báo");
        }

        private void txt_MatKhau_Click(object sender, EventArgs e)
        {
            if (txt_MatKhau.Text == "Mật khẩu")
            {
                txt_MatKhau.Text = "";
            }
            if (check_Rong(txt_XNMK.Text))
            {
                txt_XNMK.Text = "Xác nhận mật khẩu";
            }
            txt_MatKhau.PasswordChar = '*';
        }

        private void btn_Hien_MatKhau_Click(object sender, EventArgs e)
        {
            if (txt_MatKhau.PasswordChar == '*' || txt_MatKhau.Text == "Mật khẩu")
            {
                txt_MatKhau.PasswordChar = '\0';
            }
            else
            {
                txt_MatKhau.PasswordChar = '*';
            }
        }

        private void btn_Hien_XNMK_Click(object sender, EventArgs e)
        {
            if (txt_XNMK.PasswordChar == '*' || txt_XNMK.Text == "Mật khẩu")
            {
                txt_XNMK.PasswordChar = '\0';
            }
            else
            {
                txt_XNMK.PasswordChar = '*';
            }
        }

        private void txt_XNMK_Click(object sender, EventArgs e)
        {
            if (txt_XNMK.Text == "Xác nhận mật khẩu")
            {
                txt_XNMK.Text = "";
            }
            if (check_Rong(txt_MatKhau.Text))
            {
                txt_MatKhau.Text = "Mật khẩu";
            }
            txt_XNMK.PasswordChar = '*';
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Bạn có muốn thoát chương trình không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        private void panel_Chinh_Click(object sender, EventArgs e)
        {
            if (check_Rong(txt_MatKhau.Text))
            {
                txt_MatKhau.Text = "Mật khẩu";
                txt_MatKhau.PasswordChar = '\0';
            }
            if (check_Rong(txt_XNMK.Text))
            {
                txt_XNMK.Text = "Xác nhận mật khẩu";
                txt_XNMK.PasswordChar = '\0';
            }
        }
    }
}
