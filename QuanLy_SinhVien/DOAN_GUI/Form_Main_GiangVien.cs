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
    public partial class Form_Main_GiangVien : Form
    {
        public Form_Main_GiangVien()
        {
            InitializeComponent();
        }
        public int quyen;
        public string maGiangVien;
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

        private void Form_Main_GiangVien_Load(object sender, EventArgs e)
        {
            if (quyen == 0)
            {
                btn_CoVanHocTap.Enabled = false;
            }
            lab_Avatar.Text = tenGiangVien.Substring(0, 1);
            lab_Ten.Text = hoTenLotGV + " " + tenGiangVien;
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

        private void btn_GiangVien_Click(object sender, EventArgs e)
        {
            Form_NhapDiem frm_NhapDiem = new Form_NhapDiem();
            frm_NhapDiem.maGiangVien = maGiangVien;
            frm_NhapDiem.tenGiangVien = tenGiangVien;
            frm_NhapDiem.hoTenLotGV = hoTenLotGV;
            Open_Form(frm_NhapDiem);
        }

        private void btn_CoVanHocTap_Click(object sender, EventArgs e)
        {
            Form_ThongKe_CoVan frm_ThongKe = new Form_ThongKe_CoVan();
            TaiKhoan_GiangVien_DAO tk_DAO = new TaiKhoan_GiangVien_DAO();
            TaiKhoan_GiangVien_DTO tk_DTO = new TaiKhoan_GiangVien_DTO();
            DataTable dt = new DataTable();
            tk_DTO.MaGiangVien = maGiangVien;
            dt = tk_DAO.ThongTin_TaiKhoan_CoVan(tk_DTO);
            DataRow dr = dt.Rows[0];
            frm_ThongKe.maLop = dr["MALOP"].ToString();
            frm_ThongKe.tenLop = dr["TENLOP"].ToString();
            frm_ThongKe.Khoa = dr["KHOA"].ToString();
            frm_ThongKe.tenGiangVien = tenGiangVien;
            frm_ThongKe.hoTenLotGV = hoTenLotGV;

            Open_Form(frm_ThongKe);
        }

        private void btn_Thoat1_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Bạn có muốn thoát chương trình không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
