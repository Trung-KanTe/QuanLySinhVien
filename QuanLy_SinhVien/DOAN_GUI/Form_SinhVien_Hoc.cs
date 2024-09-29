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
    public partial class Form_SinhVien_Hoc : Form
    {
        public Form_SinhVien_Hoc()
        {
            InitializeComponent();
        }
        public string maLopHoc;
        public string maHocPhan;
        public string tenHocPhan;
        public string nhom;
        public string tenGiangVien;
        DataTable dt = new DataTable();
        Lop_DAO lop_DAO = new Lop_DAO();
        Lop_DTO lop_DTO = new Lop_DTO();
        SinhVien_Hoc_DTO sinhVien_Hoc_DTO = new SinhVien_Hoc_DTO();
        SinhVien_Hoc_DAO sinhVien_Hoc_DAO = new SinhVien_Hoc_DAO();
        string maSinhVien;
        public void load_CMB_Lop()
        {
            dt = lop_DAO.ThongTin_Lop();
            dt.Columns.Add("TENLOPKHOA", typeof(string), "TENLOP + ' - khóa ' + KHOA");
            cmb_Lop.DataSource = dt;
            cmb_Lop.ValueMember = "MALOP";
            cmb_Lop.DisplayMember = "TENLOPKHOA";
        }
        
        public void load_DTG_SinhVien_Hoc()
        {
            dtg_SinhVien.ColumnHeadersDefaultCellStyle.Font = new Font("Cambria", 12, FontStyle.Bold);
            sinhVien_Hoc_DTO.MaLopHoc = maLopHoc;
            dt = sinhVien_Hoc_DAO.ThongTin_SinhVien_Hoc(sinhVien_Hoc_DTO);
            dtg_SinhVien.DataSource = dt;
            dtg_SinhVien.Columns["MASINHVIEN"].HeaderText = "MÃ SINH VIÊN";
            dtg_SinhVien.Columns["TENSINHVIEN"].HeaderText = "TÊN SINH VIÊN";
            dtg_SinhVien.Columns["TENLOP"].HeaderText = "TÊN LỚP";
            dtg_SinhVien.Columns["KHOA"].HeaderText = "KHÓA";
            dtg_SinhVien.Columns["MALOPHOC"].HeaderText = "MÃ LỚP HỌC";
            dtg_SinhVien.Columns["MAHOCPHAN"].HeaderText = "MÃ HỌC PHẦN";


        }
        private void Form_SinhVien_Hoc_Load(object sender, EventArgs e)
        {
            sinhVien_Hoc_DTO.MaLopHoc = maLopHoc;
            sinhVien_Hoc_DTO.MaHocPhan = maHocPhan;
            txt_MaLopHoc.Text = maLopHoc;
            txt_Nhom.Text = nhom;
            txt_GiangVien.Text = tenGiangVien;
            txt_HocPhan.Text = tenHocPhan;
            load_CMB_Lop();
            load_DTG_SinhVien_Hoc();
            btn_LamMoi_Click(sender, e);
        }

        private void cmb_Lop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Lop.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                lop_DTO.MaLop = cmb_Lop.SelectedValue.ToString();
                sinhVien_Hoc_DTO.MaLopHoc = maLopHoc;
                dt = sinhVien_Hoc_DAO.ThongTin_SinhVien(lop_DTO, sinhVien_Hoc_DTO);
                cmb_SinhVien.DataSource = dt;
                cmb_SinhVien.ValueMember = "MASINHVIEN";
                cmb_SinhVien.DisplayMember = "TENSINHVIEN";
                cmb_SinhVien.Text = "  --Chọn sinh viên--";
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

                dtg_SinhVien.DataSource = dt;
                xc_TapTin.Close();
                xc_App.Quit();

                if (MessageBox.Show("Bạn có chắc muốn thêm dữ liệu từ bảng ecxel này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    for (int i = 0; i < dtg_SinhVien.Rows.Count; i++)
                    {
                        if (dtg_SinhVien.Rows[i].Cells[0].Value != null)
                        {
                            if (dtg_SinhVien.Rows[i].Cells[4].Value.ToString().Trim() == maLopHoc.Trim() && dtg_SinhVien.Rows[i].Cells[5].Value.ToString().Trim() == maHocPhan.Trim())
                            {
                                sinhVien_Hoc_DTO.MaSinhVien = dtg_SinhVien.Rows[i].Cells[0].Value.ToString();
                                sinhVien_Hoc_DAO.Them_SinhVien_Hoc(sinhVien_Hoc_DTO);
                            }
                            else
                            {
                                MessageBox.Show("Thêm sinh viên không thành công! Mã lớp học hoặc mã học phần không trùng khớp!!!", "Thông báo");
                            }

                        }
                        else break;
                    }
                    try
                    {
                       
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Thêm sinh viên không thành công! Kiểm tra lại mã sinh viên!!!", "Thông báo");
                    }
                }
                else dt.Clear();
                load_DTG_SinhVien_Hoc();
            }
        }

        private void btn_Icon_ImportEC_Click(object sender, EventArgs e)
        {
            btn_ImportEC_Click(sender, e);
        }
        private void dtg_SinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow select_Row = dtg_SinhVien.Rows[e.RowIndex];
                cmb_SinhVien.Enabled = false; ;
                cmb_Lop.Enabled = false;
                cmb_SinhVien.Text = select_Row.Cells["TENSINHVIEN"].Value.ToString();
                cmb_Lop.Text = select_Row.Cells["TENLOP"].Value.ToString() + " - khóa " + select_Row.Cells["KHOA"].Value.ToString();
                maSinhVien = select_Row.Cells["MASINHVIEN"].Value.ToString();
            }
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (cmb_SinhVien.SelectedValue != null)
            {
                
                if (MessageBox.Show("Bạn có chắc muốn thêm thông tin sinh viên này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        sinhVien_Hoc_DTO.MaSinhVien = cmb_SinhVien.SelectedValue.ToString().Trim();
                        sinhVien_Hoc_DAO.Them_SinhVien_Hoc(sinhVien_Hoc_DTO);
                        
                        btn_LamMoi_Click(sender, e);
                        load_DTG_SinhVien_Hoc();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Thêm sinh viên không thành công!", "Thông báo");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sinh viên!","Thông báo");
            }
        }

        private void btn_Icon_Them_Click(object sender, EventArgs e)
        {
            btn_Them_Click(sender, e);
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (maSinhVien != "")
            {

                if (MessageBox.Show("Bạn có chắc muốn thêm thông tin sinh viên này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        sinhVien_Hoc_DTO.MaSinhVien = maSinhVien.Trim();
                        sinhVien_Hoc_DAO.Xoa_SinhVien_Hoc(sinhVien_Hoc_DTO);
                        btn_LamMoi_Click(sender, e);
                        load_DTG_SinhVien_Hoc();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Thêm sinh viên không thành công!", "Thông báo");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sinh viên!", "Thông báo");
            }
        }

        private void btn_Icon_Xoa_Click(object sender, EventArgs e)
        {
            btn_Xoa_Click(sender, e);
        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            maSinhVien = "";
            cmb_Lop.Text = "  --Chọn lớp--";
            cmb_SinhVien.DataSource = null;
            cmb_SinhVien.Items.Clear();
            cmb_SinhVien.Text = "  --Chọn sinh viên--";
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
