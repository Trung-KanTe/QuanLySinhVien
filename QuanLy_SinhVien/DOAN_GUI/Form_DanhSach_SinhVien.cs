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
using Microsoft.Office.Interop;
using QuanLy_SinhVien.REPORT;
using QuanLy_SinhVien.DOAN_GUI;

namespace QuanLy_SinhVien
{
    public partial class Form_DanhSach_SinhVien : Form
    {
        public Form_DanhSach_SinhVien()
        {
            InitializeComponent();
        }
        public string maLop;
        DataTable dt = new DataTable();
        DateTime date = new DateTime(2000, 1, 1);
        SinhVien_DAO sinhVien_DAO = new SinhVien_DAO();
        SinhVien_DTO sinhVien_DTO = new SinhVien_DTO();
        SinhVien_Hoc_DTO sinhVien_Hoc_DTO = new SinhVien_Hoc_DTO();
        SinhVien_Hoc_DAO sinhVien_Hoc_DAO = new SinhVien_Hoc_DAO();
        LOI loi = new LOI();
        public void load_DTG_SinhVien()
        {
            sinhVien_DTO.MaLop = maLop;
            dt = sinhVien_DAO.ThongTin_SinhVien(sinhVien_DTO);
            dtg_SinhVien.DataSource = dt;
            dtg_SinhVien.ColumnHeadersDefaultCellStyle.Font = new Font("Cambria", 12, FontStyle.Bold);
            dtg_SinhVien.Columns["MASINHVIEN"].HeaderText = "MÃ SINH VIÊN";
            dtg_SinhVien.Columns["TENSINHVIEN"].HeaderText = "TÊN SINH VIÊN";
            dtg_SinhVien.Columns["GIOITINH"].HeaderText = "GIỚI TÍNH";
            dtg_SinhVien.Columns["NGAYSINH"].HeaderText = "NGÀY SINH";
            dtg_SinhVien.Columns["SDT"].HeaderText = "SỐ ĐIỆN THOẠI";
            dtg_SinhVien.Columns["DIACHI"].HeaderText = "ĐỊA CHỈ";

        }
        public bool loi_DuLieu()
        {
            if (loi.loi_Trong(txt_MaSinhVien.Text) ||
                loi.loi_Trong(txt_TenSinhVien.Text) ||
                loi.loi_Trong(txt_SDT.Text) ||
                loi.loi_Trong(txt_DiaChi.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!!!", "Thông báo");
                return false;
            }
            else if (loi.loi_ChuaSo(txt_TenSinhVien.Text))
            {
                MessageBox.Show("Tên không được chứa số!!!", "Thông báo");
                return false;
            }
            else if (loi.loi_ChuaKiTu(txt_SDT.Text.Trim()) || loi.loi_SDT(txt_SDT.Text.Trim()))
            {
                MessageBox.Show("Số điện thoại không hợp lệ!!!", "Thông báo");
                return false;
            }
            return true;
        }
        private void Form_DanhSach_SinhVien_Load(object sender, EventArgs e)
        {
            load_DTG_SinhVien();
        }
        private void dtg_SinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow select_Row = dtg_SinhVien.Rows[e.RowIndex];
                txt_MaSinhVien.Enabled = false;
                txt_MaSinhVien.Text = select_Row.Cells["MASINHVIEN"].Value.ToString();
                txt_TenSinhVien.Text = select_Row.Cells["TENSINHVIEN"].Value.ToString();
                txt_SDT.Text = select_Row.Cells["SDT"].Value.ToString();
                txt_DiaChi.Text = select_Row.Cells["DIACHI"].Value.ToString();
                txt_NgaySinh.Value = Convert.ToDateTime(select_Row.Cells["NGAYSINH"].Value);
                if (select_Row.Cells["GIOITINH"].Value.ToString().ToUpper() == "NAM")
                    radNam.Checked = true;
                else radNu.Checked = true;
            }
        }

        private void btn_ImportEC_Click(object sender, EventArgs e)
        {
            ((DataTable)dtg_SinhVien.DataSource).Clear();

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

                dtg_SinhVien.DataSource = dt;
                xc_TapTin.Close();
                xc_App.Quit();

                if (MessageBox.Show("Bạn có chắc muốn thêm dữ liệu từ bảng ecxel này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        for (int i = 0; i < dtg_SinhVien.Rows.Count; i++)
                        {
                            if (dtg_SinhVien.Rows[i].Cells[0].Value != null)
                            {
                                sinhVien_DTO.MaSinhVien = dtg_SinhVien.Rows[i].Cells[0].Value.ToString();
                                sinhVien_DTO.TenSinhVien = dtg_SinhVien.Rows[i].Cells[1].Value.ToString();
                                sinhVien_DTO.GioiTinh = dtg_SinhVien.Rows[i].Cells[2].Value.ToString();
                                sinhVien_DTO.NgaySinh = dtg_SinhVien.Rows[i].Cells[3].Value.ToString();
                                sinhVien_DTO.DiaChi = dtg_SinhVien.Rows[i].Cells[4].Value.ToString();
                                string sdt = dtg_SinhVien.Rows[i].Cells[5].Value.ToString();
                                sinhVien_DTO.SoDienThoai = sdt;
                                sinhVien_DAO.Them_SinhVien(sinhVien_DTO);
                            }
                            else break;
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Thêm sinh viên không thành công! Kiểm tra lại mã sinh viên và mã lớp học!!!", "Thông báo");
                    }
                }
                else dt.Clear();
                load_DTG_SinhVien();
            }
        }
        private void btn_Icon_ImportEC_Click(object sender, EventArgs e)
        {
            btn_ImportEC_Click(sender, e);
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (loi_DuLieu())
            {
                if (MessageBox.Show("Bạn có chắc muốn thêm thông tin sinh viên này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        sinhVien_DTO.MaSinhVien = txt_MaSinhVien.Text.Trim();
                        sinhVien_DTO.TenSinhVien = txt_TenSinhVien.Text.Trim();
                        sinhVien_DTO.GioiTinh = (radNam.Checked) ? radNam.Text.ToUpper() : radNu.Text.ToUpper();
                        sinhVien_DTO.NgaySinh = txt_NgaySinh.Text;
                        sinhVien_DTO.DiaChi = txt_DiaChi.Text.Trim();
                        sinhVien_DTO.SoDienThoai = txt_SDT.Text.Trim();
                        sinhVien_DAO.Them_SinhVien(sinhVien_DTO);
                        btn_LamMoi_Click(sender, e);
                        load_DTG_SinhVien();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Thêm sinh viên không thành công!");
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
                if (MessageBox.Show("Bạn có chắc muốn cập nhật thông tin sinh viên này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        sinhVien_DTO.MaSinhVien = txt_MaSinhVien.Text.Trim();
                        sinhVien_DTO.TenSinhVien = txt_TenSinhVien.Text.Trim();
                        sinhVien_DTO.GioiTinh = (radNam.Checked) ? radNam.Text.ToUpper() : radNu.Text.ToUpper();
                        sinhVien_DTO.NgaySinh = txt_NgaySinh.Text;
                        sinhVien_DTO.SoDienThoai = txt_SDT.Text.Trim();

                        sinhVien_DTO.DiaChi = txt_DiaChi.Text.Trim();
                        sinhVien_DAO.CapNhat_SinhVien(sinhVien_DTO);
                        btn_LamMoi_Click(sender, e);
                        load_DTG_SinhVien();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Cập nhật sinh viên không thành công!");
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
            if (MessageBox.Show("Bạn có chắc muốn xóa thông tin sinh viên này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    sinhVien_DTO.MaSinhVien = txt_MaSinhVien.Text.Trim();
                    sinhVien_Hoc_DTO.MaSinhVien = txt_MaSinhVien.Text.Trim();
                    sinhVien_DAO.Xoa_SinhVien(sinhVien_DTO);
                    sinhVien_Hoc_DAO.Xoa_SinhVien_Hoc(sinhVien_Hoc_DTO);
                    btn_LamMoi_Click(sender, e);
                    load_DTG_SinhVien();
                }
                catch (Exception)
                {
                    MessageBox.Show("Xóa sinh viên không thành công!");
                }
            }
        }

        private void btn_Icon_Xoa_Click(object sender, EventArgs e)
        {
            btn_Xoa_Click(sender, e);
        }
        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            txt_MaSinhVien.Clear();
            txt_TenSinhVien.Clear();
            txt_NgaySinh.Value = date;
            txt_SDT.Clear();
            txt_DiaChi.Clear();
            radNam.Checked = true;
            txt_MaSinhVien.Enabled = true;
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

        private void btn_In_Report_Click(object sender, EventArgs e)
        {
            sinhVien_DTO.MaLop = maLop;
            dt = sinhVien_DAO.ThongTin_SinhVien_Report(sinhVien_DTO);
            Report_DS_SinhVien ds_SinhVien = new Report_DS_SinhVien();
            ds_SinhVien.SetDataSource(dt);
            Form_In_Report frm_Report = new Form_In_Report();
            frm_Report.report_DS_Sinhvien.ReportSource = ds_SinhVien;
            frm_Report.ShowDialog();
        }

        private void btn_Icon_Report_Click(object sender, EventArgs e)
        {
            btn_In_Report_Click(sender, e);
        }
    }
}
