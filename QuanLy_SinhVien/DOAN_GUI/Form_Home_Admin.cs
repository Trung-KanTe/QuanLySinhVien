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
    public partial class Form_Home_Admin : Form
    {
        public Form_Home_Admin()
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

        private void btn_TrangChu_Click(object sender, EventArgs e)
        {
            if (Form_Con_Duoc_Chon != null)
            {
                Form_Con_Duoc_Chon.Close();
            }
        }

        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            Form_ThongKe frm_ThongKe = new Form_ThongKe();
            Open_Form(frm_ThongKe);
        }

        private void btn_Icon_TrangChu_Click(object sender, EventArgs e)
        {
            btn_TrangChu_Click(sender, e);
        }

        private void btn_SinhVen_Click(object sender, EventArgs e)
        {
            Form_Khoa_SinhVien frm_Khoa_SinhVien = new Form_Khoa_SinhVien();
            Open_Form(frm_Khoa_SinhVien);
        }

        private void btn_Img_SinhVien_Click(object sender, EventArgs e)
        {
            btn_SinhVen_Click(sender, e);
        }

        private void btn_Icon_SinhVien_Click(object sender, EventArgs e)
        {
            btn_SinhVen_Click(sender, e);
        }

        private void btn_HocPhan_Click(object sender, EventArgs e)
        {
            Form_Them_HocPhan frm_HocPhan = new Form_Them_HocPhan();
            Open_Form(frm_HocPhan);
        }

        private void btn_Img_HocPhan_Click(object sender, EventArgs e)
        {
            btn_HocPhan_Click(sender, e);
        }

        private void btn_Icon_HocPhan_Click(object sender, EventArgs e)
        {
            btn_HocPhan_Click(sender, e);
        }

        private void btn_Icon_ThongKe_Click(object sender, EventArgs e)
        {
            btn_ThongKe_Click(sender, e);
        }

        private void btn_Img_ThongKe_Click(object sender, EventArgs e)
        {
            btn_ThongKe_Click(sender, e);
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

        private void btn_Thoat1_Click(object sender, EventArgs e)
        {
            btn_Thoat_Click(sender, e);
        }

        private void btn_Img_Thoat_Click(object sender, EventArgs e)
        {
            btn_Thoat_Click(sender, e);
        }

        private void btn_Icon_Thoat_Click(object sender, EventArgs e)
        {
            btn_Thoat_Click(sender, e);
        }

        private void btn_LopHoc_Click(object sender, EventArgs e)
        {
            Form_Them_LopHoc frm_LopHoc = new Form_Them_LopHoc();
            Open_Form(frm_LopHoc);
        }

        private void btn_Icon_LopHoc_Click(object sender, EventArgs e)
        {
            btn_LopHoc_Click(sender, e);
        }

        private void btn_Img_LopHoc_Click(object sender, EventArgs e)
        {
            btn_LopHoc_Click(sender, e);
        }

        private void btn_GiangVien_Click(object sender, EventArgs e)
        {
            Form_Them_GiangVien frm_GiangVien = new Form_Them_GiangVien();
            Open_Form(frm_GiangVien);
        }

        private void btn_Icon_GiangVien_Click(object sender, EventArgs e)
        {
            btn_GiangVien_Click(sender, e);
        }

        private void btn_Img_GiangVien_Click(object sender, EventArgs e)
        {
            btn_GiangVien_Click(sender, e);
        }

        private void btn_TaiKhoan_Click(object sender, EventArgs e)
        {
            Form_TaiKhoan frm_TaiKhoan = new Form_TaiKhoan();
            Open_Form(frm_TaiKhoan);
        }

        private void btn_Icon_TaiKhoan_Click(object sender, EventArgs e)
        {
            btn_TaiKhoan_Click(sender, e);
        }

        private void btn_Img_TaiKhoan_Click(object sender, EventArgs e)
        {
            btn_TaiKhoan_Click(sender, e);
        }

        private void panel_Trai_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
