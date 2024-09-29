using QuanLy_SinhVien.BATLOI;
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
    public partial class Form_Them_HocPhan : Form
    {
        DataTable dt = new DataTable();
        HocPhan_DAO hocPhan_DAO = new HocPhan_DAO();
        HocPhan_DTO hocPhan_DTO = new HocPhan_DTO();
        LOI loi = new LOI();
        public Form_Them_HocPhan()
        {
            InitializeComponent();
        }
        public bool loi_DuLieu()
        {
            if (loi.loi_Trong(txt_MaHocPhan.Text) || loi.loi_Trong(txt_TenHocPhan.Text) )
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!!!", "Thông báo");
                return false;
            }
            return true;
        }
        public void Load_DTG_hocPhan()
        {
            dt = hocPhan_DAO.ThongTin_HocPhan();
            dtg_HocPhan.DataSource = dt;
            dtg_HocPhan.ColumnHeadersDefaultCellStyle.Font = new Font("Cambria", 12, FontStyle.Bold);
            dtg_HocPhan.Columns["MAHOCPHAN"].HeaderText = "MÃ HỌC PHẦN";
            dtg_HocPhan.Columns["TENHOCPHAN"].HeaderText = "TÊN HỌC PHẦN";
            dtg_HocPhan.Columns["SOTINCHI"].HeaderText = "SỐ TÍN CHỈ";
            dtg_HocPhan.Columns["HOCKY"].HeaderText = "HỌC KỲ";
            dtg_HocPhan.Columns["TILEDIEMTHUONGXUYEN"].HeaderText = "% THƯỜNG XUYÊN";
            dtg_HocPhan.Columns["TILEDIEMTHI"].HeaderText = "% THI";

        }
        private void Form_Them_HocPhan_Load(object sender, EventArgs e)
        {
            Load_DTG_hocPhan();
        }

        private void dtg_HocPhan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow select_Row = dtg_HocPhan.Rows[e.RowIndex];
                txt_MaHocPhan.Enabled = false;
                txt_MaHocPhan.Text = select_Row.Cells["MAHOCPHAN"].Value.ToString();
                txt_TenHocPhan.Text = select_Row.Cells["TENHOCPHAN"].Value.ToString();
                cmb_TinChi.Text = select_Row.Cells["SOTINCHI"].Value.ToString();
                cmb_HocKy.Text = select_Row.Cells["HOCKY"].Value.ToString();
            }
        }

        private void btn_Import_EC_Click(object sender, EventArgs e)
        {
            ((DataTable)dtg_HocPhan.DataSource).Clear();

            OpenFileDialog open = new OpenFileDialog();
            Microsoft.Office.Interop.Excel.Application xc_App;
            Microsoft.Office.Interop.Excel.Workbook xc_TapTin;
            Microsoft.Office.Interop.Excel.Worksheet xc_Trang;
            Microsoft.Office.Interop.Excel.Range xc_Range;

            string str_Ten_File;

            open.Filter = "Excel Office |*.xls; *xlsx";
            open.ShowDialog();
            str_Ten_File = open.FileName;

            if (str_Ten_File != "")
            {
                xc_App = new Microsoft.Office.Interop.Excel.Application();
                xc_TapTin = xc_App.Workbooks.Open(str_Ten_File);
                xc_Trang = xc_App.Worksheets["Sheet1"];
                xc_Range = xc_Trang.UsedRange;

                // Bắt đầu từ hàng thứ 2 để tránh tiêu đề
                for (int xc_Row = 2; xc_Row <= xc_Range.Rows.Count; xc_Row++)
                {
                    try
                    {
                        if (xc_Range.Cells[xc_Row, 1].Text != "")
                        {
                            DataRow row = dt.NewRow();
                            for (int col = 1; col <= xc_Range.Columns.Count; col++)
                            {
                                row[col - 1] = xc_Range.Cells[xc_Row, col].Text;
                            }
                            dt.Rows.Add(row);
                        }
                        else break;
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi file!!!");
                        return;
                    }
                }

                dtg_HocPhan.DataSource = dt;
                xc_TapTin.Close();
                xc_App.Quit();

                if (MessageBox.Show("Bạn có chắc muốn thêm dữ liệu từ bảng ecxel này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        for (int i = 0; i < dtg_HocPhan.Rows.Count; i++)
                        {
                            if (dtg_HocPhan.Rows[i].Cells[0].Value != null)
                            {
                                hocPhan_DTO.MaHocPhan = dtg_HocPhan.Rows[i].Cells[0].Value.ToString();
                                hocPhan_DTO.TenHocPhan = dtg_HocPhan.Rows[i].Cells[1].Value.ToString();
                                hocPhan_DTO.SoTinChi = int.Parse(dtg_HocPhan.Rows[i].Cells[2].Value.ToString());
                                hocPhan_DTO.HocKy = int.Parse(dtg_HocPhan.Rows[i].Cells[3].Value.ToString());
                                hocPhan_DTO.TiLeDiemThuongXuyen = float.Parse(dtg_HocPhan.Rows[i].Cells[4].Value.ToString());
                                hocPhan_DTO.TiLeDiemThi = float.Parse(dtg_HocPhan.Rows[i].Cells[5].Value.ToString());
                                hocPhan_DAO.Them_HocPhan(hocPhan_DTO);
                            }
                            else break;
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Thêm sinh viên không thành công! Kiểm tra lại mã sinh viên!!!", "Thông báo");
                    }
                }
                else dt.Clear();
                Load_DTG_hocPhan();
            }
        }

        private void btn_Icon_Import_EC_Click(object sender, EventArgs e)
        {
            btn_Import_EC_Click(sender, e);
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (loi_DuLieu())
            {
                if (MessageBox.Show("Bạn có chắc muốn thêm thông tin học phần này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        hocPhan_DTO.MaHocPhan = txt_MaHocPhan.Text.Trim().ToUpper();
                        hocPhan_DTO.TenHocPhan = txt_TenHocPhan.Text.Trim();
                        hocPhan_DTO.SoTinChi = int.Parse(cmb_TinChi.SelectedItem.ToString());
                        hocPhan_DTO.HocKy = int.Parse(cmb_HocKy.SelectedItem.ToString());
                        hocPhan_DTO.TiLeDiemThuongXuyen = (float)num_DL_DiemThuongXuyen.Value;
                        hocPhan_DTO.TiLeDiemThi = (float)num_DL_DiemThi.Value;
                        hocPhan_DAO.Them_HocPhan(hocPhan_DTO);
                        btn_LamMoi_Click(sender, e);
                        Load_DTG_hocPhan();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Thêm học phần không thành công!");
                    }
                }
            }
        }

        private void btn_Icon_Them_Click(object sender, EventArgs e)
        {
            btn_Them_Click(sender, e);
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (loi_DuLieu())
            {
                if (MessageBox.Show("Bạn có chắc muốn cập nhật thông tin học phần này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        hocPhan_DTO.MaHocPhan = txt_MaHocPhan.Text.Trim();
                        hocPhan_DTO.TenHocPhan = txt_TenHocPhan.Text.Trim();
                        hocPhan_DTO.SoTinChi = int.Parse(cmb_TinChi.SelectedItem.ToString());
                        hocPhan_DTO.HocKy = int.Parse(cmb_HocKy.SelectedItem.ToString());
                        hocPhan_DTO.TiLeDiemThuongXuyen = (float)num_DL_DiemThuongXuyen.Value;
                        hocPhan_DTO.TiLeDiemThi = (float)num_DL_DiemThi.Value;
                        hocPhan_DAO.CapNhat_HocPhan(hocPhan_DTO);
                        btn_LamMoi_Click(sender, e);
                        Load_DTG_hocPhan();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Cập nhật học phần không thành công!");
                    }
                }
            }
        }

        private void btn_Icon_Sua_Click(object sender, EventArgs e)
        {
            btn_Sua_Click(sender, e);
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa thông tin học phần này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    hocPhan_DTO.MaHocPhan = txt_MaHocPhan.Text.Trim();

                    hocPhan_DAO.Xoa_HocPhan(hocPhan_DTO);
                    btn_LamMoi_Click(sender, e);
                    Load_DTG_hocPhan();
                }
                catch (Exception)
                {
                    MessageBox.Show("Xóa học phần không thành công!");
                }
            }
        }

        private void btn_Icon_Xoa_Click(object sender, EventArgs e)
        {
            btn_Xoa_Click(sender, e);
        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            txt_MaHocPhan.Clear();
            txt_TenHocPhan.Clear();
            cmb_TinChi.Text = "--Chọn số tín chỉ--";
            cmb_HocKy.Text = "--Chọn học kỳ--";
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
    }
}
