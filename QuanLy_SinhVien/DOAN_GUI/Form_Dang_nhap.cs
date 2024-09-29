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
using QuanLy_SinhVien.DOAN_GUI;

namespace QuanLy_SinhVien
{
    public partial class Form_Dang_Nhap : Form
    {
        public Form_Dang_Nhap()
        {
            InitializeComponent();
        }
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
            return str =="" ? true : false;
        }

        private void txt_Ten_Dang_Nhap_Click(object sender, EventArgs e)
        {
            if (txt_Ten_Dang_Nhap.Text == "Tên đăng nhập")
            {
                txt_Ten_Dang_Nhap.Text = "";
            }
            if (check_Rong(txt_Mat_Khau.Text))
            {
                txt_Mat_Khau.Text = "Mật khẩu";
                txt_Mat_Khau.PasswordChar = '\0';
            }
        }

        private void txt_Mat_Khau_Click(object sender, EventArgs e)
        {
            if (txt_Mat_Khau.Text == "Mật khẩu")
            {
                txt_Mat_Khau.Text = "";
            }
            if (check_Rong(txt_Ten_Dang_Nhap.Text))
            {
                txt_Ten_Dang_Nhap.Text = "Tên đăng nhập";
            }
            txt_Mat_Khau.PasswordChar = '*';
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

   

        private void btn_Hien_Mat_Khau_Click(object sender, EventArgs e)
        {
            if (txt_Mat_Khau.PasswordChar == '*' || txt_Mat_Khau.Text == "Mật khẩu")
            {
                txt_Mat_Khau.PasswordChar = '\0';
            }
            else
            {
                txt_Mat_Khau.PasswordChar = '*';
            }
 
        }

        private void btn_Dang_Nhap_Click(object sender, EventArgs e)
        {
            DataTable dt_tkAdmin = new DataTable();
            string str_TenDangNhap = txt_Ten_Dang_Nhap.Text;
            string str_MatKhau = txt_Mat_Khau.Text;
            TaiKhoan_Admin_DTO tkADM = new TaiKhoan_Admin_DTO();
            tkADM.Tentaikhoan = str_TenDangNhap;
            tkADM.Matkhau = str_MatKhau;
            dt_tkAdmin = TaiKhoa_Admin_DAO.ThongTin_TaiKhoan_Admin(tkADM);
            DataTable dt = new DataTable();
            TaiKhoan_GiangVien_DAO tk_DAO = new TaiKhoan_GiangVien_DAO();
            TaiKhoan_GiangVien_DTO tk_DTO = new TaiKhoan_GiangVien_DTO();
            tk_DTO.MaGiangVien = str_TenDangNhap;
            tk_DTO.MatKhau = str_MatKhau;
            dt = tk_DAO.ThongTin_TaiKhoan_GiangVien(tk_DTO);
            if (str_TenDangNhap == "Tên đăng nhập")
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!!!", "Thông báo");
            }
            else if (str_MatKhau == "Mật khẩu")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!!!", "Thông báo");
            }
            else if (dt_tkAdmin.Rows.Count > 0)
            {
                Form_Home_Admin frm_Admin = new Form_Home_Admin();
                Open_Form(frm_Admin);
            }
            else if (dt.Rows.Count > 0)
            {
                Form_Main_GiangVien frm_Main_GV = new Form_Main_GiangVien();
                DataRow dr = dt.Rows[0];
                frm_Main_GV.quyen = int.Parse(dr["VAITRO"].ToString());
                frm_Main_GV.maGiangVien = dr["MAGIANGVIEN"].ToString();
                frm_Main_GV.hoTenLotGV = dr["HOTENLOTGIANGVIEN"].ToString();
                frm_Main_GV.tenGiangVien = dr["TENGIANGVIEN"].ToString();
                Open_Form(frm_Main_GV);
            }
            else
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin đăng nhập!'!!", "Thông báo");
            }
           
        }

        private void panel_Chinh_Click(object sender, EventArgs e)
        {
            if (check_Rong(txt_Ten_Dang_Nhap.Text))
            {
                txt_Ten_Dang_Nhap.Text = "Tên đăng nhập";
            }
            if (check_Rong(txt_Mat_Khau.Text))
            {
                txt_Mat_Khau.Text = "Mật khẩu";
                txt_Mat_Khau.PasswordChar = '\0';
            }
        }

        private void btn_Quen_Mat_Khau_Click(object sender, EventArgs e)
        {
            Form_Quen_MatKhau frm_QuenMK = new Form_Quen_MatKhau();
            Open_Form(frm_QuenMK);
        }
    }
}
