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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLy_SinhVien
{
    public partial class Form_Them_GiangVien : Form
    {
        DataTable dt = new DataTable();
        DateTime date = new DateTime(1999, 1, 1);
        GiangVien_DAO giangVien_DAO = new GiangVien_DAO();
        GiangVien_DTO giangVien_DTO = new GiangVien_DTO();
        LOI loi = new LOI();
        public Form_Them_GiangVien()
        {
            InitializeComponent();
        }
        public void Load_DTG_GiangVien()
        {
            dt = giangVien_DAO.ThongTin_GiangVien();
            dtg_GiangVien.DataSource = dt;
            dtg_GiangVien.ColumnHeadersDefaultCellStyle.Font = new Font("Cambria", 12, FontStyle.Bold);
            dtg_GiangVien.Columns["MAGIANGVIEN"].HeaderText = "MÃ GIẢNG VIÊN";
            dtg_GiangVien.Columns["HOTENLOTGIANGVIEN"].HeaderText = "HỌ TÊN LÓT GV";
            dtg_GiangVien.Columns["TENGIANGVIEN"].HeaderText = "TÊN GIẢNG VIÊN";
            dtg_GiangVien.Columns["GIOITINH"].HeaderText = "GIỚI TÍNH";
            dtg_GiangVien.Columns["NGAYSINH"].HeaderText = "NGÀY SINH";
            dtg_GiangVien.Columns["SDT"].HeaderText = "SỐ ĐIỆN THOẠI";
            dtg_GiangVien.Columns["DIACHI"].HeaderText = "ĐỊA CHỈ";
            dtg_GiangVien.Columns["VAITRO"].Visible = false;
            dtg_GiangVien.Columns["KICHHOAT"].Visible = false;

        }
        public bool loi_DuLieu()
        {
            if (loi.loi_Trong(txt_MaGiangVien.Text) ||
                loi.loi_Trong(txt_HoTenLot.Text) ||
                loi.loi_Trong(txt_TenGiangVien.Text) ||
                loi.loi_Trong(txt_SDT_GiangVien.Text) ||
                loi.loi_Trong(txt_DiaChi_GiangVien.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!!!", "Thông báo");
                return false;
            }
            else if (loi.loi_ChuaSo(txt_HoTenLot.Text) || loi.loi_ChuaSo(txt_TenGiangVien.Text))
            {
                MessageBox.Show("Tên không được chứa số!!!", "Thông báo");
                return false;
            }
            else if (loi.loi_ChuaKiTu(txt_SDT_GiangVien.Text) || loi.loi_SDT(txt_SDT_GiangVien.Text))
            {
                MessageBox.Show("Số điện thoại không hợp lệ!!!", "Thông báo");
                return false;
            }
            return true;
        }
        private void Form_Them_GiangVien_Load(object sender, EventArgs e)
        {
            Load_DTG_GiangVien();
        }
        private void dtg_GiangVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow select_Row = dtg_GiangVien.Rows[e.RowIndex];
                txt_MaGiangVien.Enabled = false;
                txt_MaGiangVien.Text = select_Row.Cells["MAGIANGVIEN"].Value.ToString();
                txt_HoTenLot.Text = select_Row.Cells["HOTENLOTGIANGVIEN"].Value.ToString();
                txt_TenGiangVien.Text = select_Row.Cells["TENGIANGVIEN"].Value.ToString();
                txt_SDT_GiangVien.Text = select_Row.Cells["SDT"].Value.ToString();
                txt_DiaChi_GiangVien.Text = select_Row.Cells["DIACHI"].Value.ToString();
                txt_NgaySinh.Value = Convert.ToDateTime(select_Row.Cells["NGAYSINH"].Value);
                if (select_Row.Cells["GIOITINH"].Value.ToString().ToUpper() == "NAM")
                    radNam.Checked = true;
                else radNu.Checked = true;
            }
        }

        private void btn_ThemGiangVien_Click(object sender, EventArgs e)
        {
            
            if (loi_DuLieu())
            {
                if (MessageBox.Show("Bạn có chắc muốn thêm thông tin giảng viên này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        giangVien_DTO.MaGiangVien = txt_MaGiangVien.Text.Trim();
                        giangVien_DTO.HoTenLotGiangVien = txt_HoTenLot.Text.Trim();
                        giangVien_DTO.TenGiangVien = txt_TenGiangVien.Text.Trim();
                        giangVien_DTO.GioiTinh = (radNam.Checked) ? radNam.Text.ToUpper() : radNu.Text.ToUpper();
                        giangVien_DTO.NgaySinh = txt_NgaySinh.Text;
                        giangVien_DTO.SoDienThoai = txt_SDT_GiangVien.Text.Trim();
                        giangVien_DTO.DiaChi = txt_DiaChi_GiangVien.Text.Trim();
                        giangVien_DTO.VaiTro = 0;
                        giangVien_DTO.KichHoat = 0;

                        giangVien_DAO.Them_GiangVien(giangVien_DTO);
                        btn_LamMoi_Click(sender, e);
                        Load_DTG_GiangVien();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Thêm giảng viên không thành công!");
                    }
                }
            }
        }

        private void btn_Icon_ThemGiangVien_Click(object sender, EventArgs e)
        {
            btn_ThemGiangVien_Click(sender, e);
        }

        private void btn_SuaGiangVien_Click(object sender, EventArgs e)
        {
            if (loi_DuLieu())
            {
                if (MessageBox.Show("Bạn có chắc muốn cập nhật thông tin giảng viên này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        giangVien_DTO.MaGiangVien = txt_MaGiangVien.Text.Trim();
                        giangVien_DTO.HoTenLotGiangVien = txt_HoTenLot.Text.Trim();
                        giangVien_DTO.TenGiangVien = txt_TenGiangVien.Text.Trim();
                        giangVien_DTO.GioiTinh = (radNam.Checked) ? radNam.Text.ToUpper() : radNu.Text.ToUpper();
                        giangVien_DTO.NgaySinh = txt_NgaySinh.Text;
                        giangVien_DTO.SoDienThoai = txt_SDT_GiangVien.Text.Trim();
                        giangVien_DTO.DiaChi = txt_DiaChi_GiangVien.Text.Trim();

                        giangVien_DAO.CapNhat_GiangVien(giangVien_DTO);
                        btn_LamMoi_Click(sender, e);
                        Load_DTG_GiangVien();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Cập nhật giảng viên không thành công!");
                    }
                }
            }
        }

        private void btn_Icon_SuaGiangVien_Click(object sender, EventArgs e)
        {
            btn_SuaGiangVien_Click(sender, e);
        }
        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            txt_MaGiangVien.Clear();
            txt_HoTenLot.Clear();
            txt_TenGiangVien.Clear();
            txt_NgaySinh.Value = date;
            txt_SDT_GiangVien.Clear();
            txt_DiaChi_GiangVien.Clear();
            radNam.Checked = true;

        }

        private void btn_Icon_LamMoi_Click(object sender, EventArgs e)
        {
            btn_LamMoi_Click(sender, e);
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

        private void btn_Icon_Thoat_Click(object sender, EventArgs e)
        {
                btn_Thoat_Click(sender, e);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dtg_GiangVien_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            /*
            if (dtg_GiangVien != null)
            {
                // Vẽ số thứ tự bên cạnh hàng
                using (SolidBrush brush = new SolidBrush(dtg_GiangVien.RowHeadersDefaultCellStyle.ForeColor))
                {
                    e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, brush, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
                }
            }*/
        }
    }
}
