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

namespace QuanLy_SinhVien
{
    public partial class Form_TaiKhoan : Form
    {
        public Form_TaiKhoan()
        {
            InitializeComponent();
        }
        TaiKhoan_GiangVien_DAO tk_DAO = new TaiKhoan_GiangVien_DAO();
        TaiKhoan_GiangVien_DTO tk_DTO = new TaiKhoan_GiangVien_DTO();
        GiangVien_DTO gv_DTO = new GiangVien_DTO();
        DataTable dt = new DataTable();
        public void load_CMB_GiangVien()
        {
            dt = tk_DAO.ThongTin_TaiKhoan();
            cmb_GiangVien.DataSource = dt;
            cmb_GiangVien.ValueMember = "MAGIANGVIEN";
            cmb_GiangVien.DisplayMember = "TENGIANGVIEN";
        }
    
        private void Form_TaiKhoan_Load(object sender, EventArgs e)
        {
            load_CMB_GiangVien();
            LamMoi();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            gv_DTO.MaGiangVien = cmb_GiangVien.SelectedValue.ToString();
            dt = tk_DAO.Xem_ThongTin_TaiKhoan(gv_DTO);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                txt_GiangVien.Text = dr["HOTENLOTGIANGVIEN"].ToString() + " " + dr["TENGIANGVIEN"].ToString();
                txt_DiaChi.Text = dr["DIACHI"].ToString();
                txt_TenDN.Text = dr["MAGIANGVIEN"].ToString();
                txt_SDT.Text = dr["SDT"].ToString();
            }
        }

        private void btn_KichHoat_Click(object sender, EventArgs e)
        {
           
            if (txt_MK.Text != "" && txt_XNMK.Text != "" && txt_MK.Text == txt_XNMK.Text)
            {
                if (MessageBox.Show("Bạn có chắc muốn thêm thông tin tài khoản này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        tk_DTO.MaGiangVien = cmb_GiangVien.SelectedValue.ToString();
                        tk_DTO.MatKhau = txt_MK.Text;
                        gv_DTO.MaGiangVien = cmb_GiangVien.SelectedValue.ToString();
                        tk_DAO.CapNhat_TaiKhoan(gv_DTO);
                        tk_DAO.Them_TaiKhoan_GiangVien(tk_DTO);
                        load_CMB_GiangVien();
                        LamMoi();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Thêm tài khoản không thành công!");
                    }
                }
            }
            else
                MessageBox.Show("Kiểm tra lại mật khẩu và xác nhận mật khẩu", "Thông báo");
        }
        public void LamMoi()
        {
            txt_DiaChi.Clear();
            txt_GiangVien.Clear();
            txt_MK.Text = "Mật khẩu";
            txt_SDT.Clear();
            txt_TenDN.Clear();
            txt_XNMK.Text = "Xác nhận mật khẩu";
            cmb_GiangVien.Text = "  --Chọn giảng viên--";
            load_CMB_GiangVien();
        }
        public bool check_Rong(string str)
        {
            return str == "" ? true : false;
        }
        private void txt_MK_Click(object sender, EventArgs e)
        {
            if (txt_MK.Text == "Mật khẩu")
                txt_MK.Text = "";
            if (check_Rong(txt_XNMK.Text))
            {
                txt_XNMK.Text = "Xác nhận mật khẩu";
            }
        }

        private void txt_XNMK_Click(object sender, EventArgs e)
        {
            if (txt_XNMK.Text == "Xác nhận mật khẩu")
            {
                txt_XNMK.Text = "";
            }
            if (check_Rong(txt_MK.Text))
            {
                txt_MK.Text = "Mật khẩu";
            }
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            if (check_Rong(txt_MK.Text))
            {
                txt_MK.Text = "Mật khẩu";
            }
            if (check_Rong(txt_XNMK.Text))
            {
                txt_XNMK.Text = "Xác nhận mật khẩu";
            }
        }

        private void btn_ThemAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc thêm tất cả tài khoản?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    tk_DAO.Them_TaiKhoan_GiangVien_All();
                    tk_DAO.CapNhat_TaiKhoan_All();
                    load_CMB_GiangVien();
                    LamMoi();
                }
                catch (Exception)
                {
                    MessageBox.Show("Thêm tài khoản không thành công!");
                }
            }
        }
    }
}
