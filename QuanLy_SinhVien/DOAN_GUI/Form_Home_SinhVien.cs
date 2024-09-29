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
    public partial class Form_SinhVien_TrangChu : Form
    {
        public Form_SinhVien_TrangChu()
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

        private void btn_CNTT_Click(object sender, EventArgs e)
        {
            Form_Khoa_SinhVien f1 = new Form_Khoa_SinhVien();
            f1.label_TrangThai = label_CNTT.Text;
            Open_Form(f1);
           
        }

        private void panel_Chinh_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
