using QuanLy_SinhVien.DOAN_DAO;
using QuanLy_SinhVien.DOAN_DTO;
using QuanLy_SinhVien.DOAN_GUI;
using QuanLy_SinhVien.REPORT;
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
    public partial class Form_ThongKe : Form
    {
        public Form_ThongKe()
        {
            InitializeComponent();
        }
        Lop_DAO lop_DAO = new Lop_DAO();
        Lop_DTO lop_DTO = new Lop_DTO();
        HocPhan_DAO hocPhan_DAO = new HocPhan_DAO();
        SinhVien_DAO sinhVien_DAO = new SinhVien_DAO();
        SinhVien_DTO sinhVien_DTO = new SinhVien_DTO();
        DataTable dt = new DataTable();
        int temp = 0;

        private void btn_Khoa_Click(object sender, EventArgs e)
        {
            dt = lop_DAO.ThongTin_Khoa();
            cmb_Chon.DataSource = dt;
            cmb_Chon.ValueMember = "KHOA";
            cmb_Chon.Text = "  --Chọn khóa--";
            temp = 1;
        }

        private void btn_Lop_Click(object sender, EventArgs e)
        {
            dt = lop_DAO.ThongTin_Lop();
            dt.Columns.Add("TENLOPKHOA", typeof(string), "TENLOP + ' - khóa ' + KHOA");
            cmb_Chon.DataSource = dt;
            cmb_Chon.ValueMember = "MALOP";
            cmb_Chon.DisplayMember = "TENLOPKHOA";
            cmb_Chon.Text = "  --Chọn lớp--";
            temp = 2;
        }
        private void cmb_Chon_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtg_SinhVien.ColumnHeadersDefaultCellStyle.Font = new Font("Cambria", 12, FontStyle.Bold);
            if (temp == 1)
            {
                if (cmb_Chon.SelectedValue != null && int.TryParse(cmb_Chon.SelectedValue.ToString(), out int khoa))
                {
                    lop_DTO.Khoa = khoa;
                    dt = sinhVien_DAO.ThongTin_SinhVien_TheoKhoa(lop_DTO);
                    dtg_SinhVien.DataSource = dt;
                    dtg_SinhVien.Columns["MASINHVIEN"].HeaderText = "MÃ SINH VIÊN";
                    dtg_SinhVien.Columns["TENSINHVIEN"].HeaderText = "TÊN SINH VIÊN";
                    dtg_SinhVien.Columns["GIOITINH"].HeaderText = "GIỚI TÍNH";
                    dtg_SinhVien.Columns["DIEMTRUNGBINH"].HeaderText = "ĐIỂM TRUNG BÌNH";
                    dtg_SinhVien.Columns["TINCHIDAT"].HeaderText = "TÍN CHỈ ĐẠT";
                    dtg_SinhVien.Columns["XEPLOAI"].HeaderText = "XẾP LOẠI";
                    dtg_SinhVien.Columns["KHOA"].Visible = false;
                }
            }
            if (temp == 2)
            {
                if (cmb_Chon.SelectedValue != null)
                {
                    lop_DTO.MaLop = cmb_Chon.SelectedValue.ToString();
                    dt = sinhVien_DAO.ThongTin_SinhVien_TheoLop(lop_DTO);
                    dtg_SinhVien.DataSource = dt;
                    dtg_SinhVien.Columns["MASINHVIEN"].HeaderText = "MÃ SINH VIÊN";
                    dtg_SinhVien.Columns["TENSINHVIEN"].HeaderText = "TÊN SINH VIÊN";
                    dtg_SinhVien.Columns["GIOITINH"].HeaderText = "GIỚI TÍNH";
                    dtg_SinhVien.Columns["DIEMTRUNGBINH"].HeaderText = "ĐIỂM TRUNG BÌNH";
                    dtg_SinhVien.Columns["TINCHIDAT"].HeaderText = "TÍN CHỈ ĐẠT";
                    dtg_SinhVien.Columns["XEPLOAI"].HeaderText = "XẾP LOẠI";
                    dtg_SinhVien.Columns["MALOP"].Visible = false;
                    dtg_SinhVien.Columns["TENLOP"].Visible = false;
                }
            }
        }

        private void rad_XuatSac_CheckedChanged(object sender, EventArgs e)
        {
            if (temp == 1)
            {
                if (cmb_Chon.SelectedValue != null && int.TryParse(cmb_Chon.SelectedValue.ToString(), out int khoa))
                {
                    lop_DTO.Khoa = khoa;
                    sinhVien_DTO.XepLoai = rad_XuatSac.Text;
                    dt = sinhVien_DAO.Loc_XepLoai_SinhVien_TheoKhoa(lop_DTO, sinhVien_DTO);
                    dtg_SinhVien.DataSource = dt;
                }
            }
            if (temp == 2)
            {
                if (cmb_Chon.SelectedValue != null)
                {
                    lop_DTO.MaLop = cmb_Chon.SelectedValue.ToString();
                    sinhVien_DTO.XepLoai = rad_XuatSac.Text;
                    dt = sinhVien_DAO.Loc_XepLoai_SinhVien_TheoLop(lop_DTO, sinhVien_DTO);
                    dtg_SinhVien.DataSource = dt;
                }
            }

        }

        private void rad_Gioi_CheckedChanged(object sender, EventArgs e)
        {
            if (temp == 1)
            {
                if (cmb_Chon.SelectedValue != null && int.TryParse(cmb_Chon.SelectedValue.ToString(), out int khoa))
                {
                    lop_DTO.Khoa = khoa;
                    sinhVien_DTO.XepLoai = rad_Gioi.Text;
                    dt = sinhVien_DAO.Loc_XepLoai_SinhVien_TheoKhoa(lop_DTO, sinhVien_DTO);
                    dtg_SinhVien.DataSource = dt;
                }
            }
            if (temp == 2)
            {
                if (cmb_Chon.SelectedValue != null)
                {
                    lop_DTO.MaLop = cmb_Chon.SelectedValue.ToString();
                    sinhVien_DTO.XepLoai = rad_Gioi.Text;
                    dt = sinhVien_DAO.Loc_XepLoai_SinhVien_TheoLop(lop_DTO, sinhVien_DTO);
                    dtg_SinhVien.DataSource = dt;
                }
            }
        }

        private void rad_Kha_CheckedChanged(object sender, EventArgs e)
        {
            if (temp == 1)
            {
                if (cmb_Chon.SelectedValue != null && int.TryParse(cmb_Chon.SelectedValue.ToString(), out int khoa))
                {
                    lop_DTO.Khoa = khoa;
                    sinhVien_DTO.XepLoai = rad_Kha.Text;
                    dt = sinhVien_DAO.Loc_XepLoai_SinhVien_TheoKhoa(lop_DTO, sinhVien_DTO);
                    dtg_SinhVien.DataSource = dt;
                }
            }
            if (temp == 2)
            {
                if (cmb_Chon.SelectedValue != null)
                {
                    lop_DTO.MaLop = cmb_Chon.SelectedValue.ToString();
                    sinhVien_DTO.XepLoai = rad_Kha.Text;
                    dt = sinhVien_DAO.Loc_XepLoai_SinhVien_TheoLop(lop_DTO, sinhVien_DTO);
                    dtg_SinhVien.DataSource = dt;
                }
            }
        }

        private void rad_TrungBinh_CheckedChanged(object sender, EventArgs e)
        {
            if (temp == 1)
            {
                if (cmb_Chon.SelectedValue != null && int.TryParse(cmb_Chon.SelectedValue.ToString(), out int khoa))
                {
                    lop_DTO.Khoa = khoa;
                    sinhVien_DTO.XepLoai = rad_TrungBinh.Text;
                    dt = sinhVien_DAO.Loc_XepLoai_SinhVien_TheoKhoa(lop_DTO, sinhVien_DTO);
                    dtg_SinhVien.DataSource = dt;
                }
            }
            if (temp == 2)
            {
                if (cmb_Chon.SelectedValue != null)
                {
                    lop_DTO.MaLop = cmb_Chon.SelectedValue.ToString();
                    sinhVien_DTO.XepLoai = rad_TrungBinh.Text;
                    dt = sinhVien_DAO.Loc_XepLoai_SinhVien_TheoLop(lop_DTO, sinhVien_DTO);
                    dtg_SinhVien.DataSource = dt;
                }
            }
        }

        private void rad_Yeu_CheckedChanged(object sender, EventArgs e)
        {
            if (temp == 1)
            {
                if (cmb_Chon.SelectedValue != null && int.TryParse(cmb_Chon.SelectedValue.ToString(), out int khoa))
                {
                    lop_DTO.Khoa = khoa;
                    sinhVien_DTO.XepLoai = rad_Yeu.Text;
                    dt = sinhVien_DAO.Loc_XepLoai_SinhVien_TheoKhoa(lop_DTO, sinhVien_DTO);
                    dtg_SinhVien.DataSource = dt;
                }
            }
            if (temp == 2)
            {
                if (cmb_Chon.SelectedValue != null)
                {
                    lop_DTO.MaLop = cmb_Chon.SelectedValue.ToString();
                    sinhVien_DTO.XepLoai = rad_Yeu.Text;
                    dt = sinhVien_DAO.Loc_XepLoai_SinhVien_TheoLop(lop_DTO, sinhVien_DTO);
                    dtg_SinhVien.DataSource = dt;
                }
            }
        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            ((DataTable)dtg_SinhVien.DataSource).Clear();
        }

        private void btn_Report_Click(object sender, EventArgs e)
        {

            if (temp == 1)
            {
                int khoa;
                if (rad_XuatSac.Checked == true)
                {
                    if (cmb_Chon.SelectedValue != null && int.TryParse(cmb_Chon.SelectedValue.ToString(), out khoa))
                    {
                        lop_DTO.Khoa = khoa;
                        sinhVien_DTO.XepLoai = rad_XuatSac.Text;
                        dt = sinhVien_DAO.Loc_XepLoai_SinhVien_TheoKhoa(lop_DTO, sinhVien_DTO);
                        Report_DS_TheoKhoa rp_Khoa = new Report_DS_TheoKhoa();
                        rp_Khoa.SetDataSource(dt);
                        Form_In_Report frm_Report = new Form_In_Report();
                        frm_Report.report_DS_Sinhvien.ReportSource = rp_Khoa;
                        frm_Report.ShowDialog();
                    }
                }
                else if (rad_Gioi.Checked == true)
                {
                    if (cmb_Chon.SelectedValue != null && int.TryParse(cmb_Chon.SelectedValue.ToString(), out khoa))
                    {
                        lop_DTO.Khoa = khoa;
                        sinhVien_DTO.XepLoai = rad_Gioi.Text;
                        dt = sinhVien_DAO.Loc_XepLoai_SinhVien_TheoKhoa(lop_DTO, sinhVien_DTO);
                        Report_DS_TheoKhoa rp_Khoa = new Report_DS_TheoKhoa();
                        rp_Khoa.SetDataSource(dt);
                        Form_In_Report frm_Report = new Form_In_Report();
                        frm_Report.report_DS_Sinhvien.ReportSource = rp_Khoa;
                        frm_Report.ShowDialog();
                    }
                }
                else if (rad_Kha.Checked == true)
                {
                    if (cmb_Chon.SelectedValue != null && int.TryParse(cmb_Chon.SelectedValue.ToString(), out khoa))
                    {
                        lop_DTO.Khoa = khoa;
                        sinhVien_DTO.XepLoai = rad_Kha.Text;
                        dt = sinhVien_DAO.Loc_XepLoai_SinhVien_TheoKhoa(lop_DTO, sinhVien_DTO);
                        Report_DS_TheoKhoa rp_Khoa = new Report_DS_TheoKhoa();
                        rp_Khoa.SetDataSource(dt);
                        Form_In_Report frm_Report = new Form_In_Report();
                        frm_Report.report_DS_Sinhvien.ReportSource = rp_Khoa;
                        frm_Report.ShowDialog();
                    }
                }
                else if (rad_TrungBinh.Checked == true)
                {
                    if (cmb_Chon.SelectedValue != null && int.TryParse(cmb_Chon.SelectedValue.ToString(), out khoa))
                    {
                        lop_DTO.Khoa = khoa;
                        sinhVien_DTO.XepLoai = rad_TrungBinh.Text;
                        dt = sinhVien_DAO.Loc_XepLoai_SinhVien_TheoKhoa(lop_DTO, sinhVien_DTO);
                        Report_DS_TheoKhoa rp_Khoa = new Report_DS_TheoKhoa();
                        rp_Khoa.SetDataSource(dt);
                        Form_In_Report frm_Report = new Form_In_Report();
                        frm_Report.report_DS_Sinhvien.ReportSource = rp_Khoa;
                        frm_Report.ShowDialog();
                    }
                }
                else if (rad_Yeu.Checked == true)
                {
                    if (cmb_Chon.SelectedValue != null && int.TryParse(cmb_Chon.SelectedValue.ToString(), out khoa))
                    {
                        lop_DTO.Khoa = khoa;
                        sinhVien_DTO.XepLoai = rad_Yeu.Text;
                        dt = sinhVien_DAO.Loc_XepLoai_SinhVien_TheoKhoa(lop_DTO, sinhVien_DTO);
                        Report_DS_TheoKhoa rp_Khoa = new Report_DS_TheoKhoa();
                        rp_Khoa.SetDataSource(dt);
                        Form_In_Report frm_Report = new Form_In_Report();
                        frm_Report.report_DS_Sinhvien.ReportSource = rp_Khoa;
                        frm_Report.ShowDialog();
                    }
                }
                else if (cmb_Chon.SelectedValue != null && int.TryParse(cmb_Chon.SelectedValue.ToString(), out khoa))
                {
                    lop_DTO.Khoa = khoa;
                    dt = sinhVien_DAO.ThongTin_SinhVien_TheoKhoa(lop_DTO);
                    Report_DS_TheoKhoa rp_Khoa = new Report_DS_TheoKhoa();
                    rp_Khoa.SetDataSource(dt);
                    Form_In_Report frm_Report = new Form_In_Report();
                    frm_Report.report_DS_Sinhvien.ReportSource = rp_Khoa;
                    frm_Report.ShowDialog();
                }
            }
            if (temp == 2)
            {
                if (rad_XuatSac.Checked == true)
                {
                    if (cmb_Chon.SelectedValue != null)
                    {
                        lop_DTO.MaLop = cmb_Chon.SelectedValue.ToString();
                        sinhVien_DTO.XepLoai = rad_XuatSac.Text;
                        dt = sinhVien_DAO.Loc_XepLoai_SinhVien_TheoLop(lop_DTO, sinhVien_DTO);
                        Report_DS_TheoLop rp_Lop = new Report_DS_TheoLop();
                        rp_Lop.SetDataSource(dt);
                        Form_In_Report frm_Report = new Form_In_Report();
                        frm_Report.report_DS_Sinhvien.ReportSource = rp_Lop;
                        frm_Report.ShowDialog();
                    }
                }
                else if (rad_Gioi.Checked == true)
                {
                    if (cmb_Chon.SelectedValue != null)
                    {
                        lop_DTO.MaLop = cmb_Chon.SelectedValue.ToString();
                        sinhVien_DTO.XepLoai = rad_Gioi.Text;
                        dt = sinhVien_DAO.Loc_XepLoai_SinhVien_TheoLop(lop_DTO, sinhVien_DTO);
                        Report_DS_TheoLop rp_Lop = new Report_DS_TheoLop();
                        rp_Lop.SetDataSource(dt);
                        Form_In_Report frm_Report = new Form_In_Report();
                        frm_Report.report_DS_Sinhvien.ReportSource = rp_Lop;
                        frm_Report.ShowDialog();
                    }
                }
                else if (rad_Kha.Checked == true)
                {
                    if (cmb_Chon.SelectedValue != null)
                    {
                        lop_DTO.MaLop = cmb_Chon.SelectedValue.ToString();
                        sinhVien_DTO.XepLoai = rad_Kha.Text;
                        dt = sinhVien_DAO.Loc_XepLoai_SinhVien_TheoLop(lop_DTO, sinhVien_DTO);
                        Report_DS_TheoLop rp_Lop = new Report_DS_TheoLop();
                        rp_Lop.SetDataSource(dt);
                        Form_In_Report frm_Report = new Form_In_Report();
                        frm_Report.report_DS_Sinhvien.ReportSource = rp_Lop;
                        frm_Report.ShowDialog();
                    }
                }
                else if (rad_TrungBinh.Checked == true)
                {
                    if (cmb_Chon.SelectedValue != null)
                    {
                        lop_DTO.MaLop = cmb_Chon.SelectedValue.ToString();
                        sinhVien_DTO.XepLoai = rad_TrungBinh.Text;
                        dt = sinhVien_DAO.Loc_XepLoai_SinhVien_TheoLop(lop_DTO, sinhVien_DTO);
                        Report_DS_TheoLop rp_Lop = new Report_DS_TheoLop();
                        rp_Lop.SetDataSource(dt);
                        Form_In_Report frm_Report = new Form_In_Report();
                        frm_Report.report_DS_Sinhvien.ReportSource = rp_Lop;
                        frm_Report.ShowDialog();
                    }
                }
                else if (rad_Yeu.Checked == true)
                {
                    if (cmb_Chon.SelectedValue != null)
                    {
                        lop_DTO.MaLop = cmb_Chon.SelectedValue.ToString();
                        sinhVien_DTO.XepLoai = rad_Yeu.Text;
                        dt = sinhVien_DAO.Loc_XepLoai_SinhVien_TheoLop(lop_DTO, sinhVien_DTO);
                        Report_DS_TheoLop rp_Lop = new Report_DS_TheoLop();
                        rp_Lop.SetDataSource(dt);
                        Form_In_Report frm_Report = new Form_In_Report();
                        frm_Report.report_DS_Sinhvien.ReportSource = rp_Lop;
                        frm_Report.ShowDialog();
                    }
                }
                else if (cmb_Chon.SelectedValue != null)
                {
                    lop_DTO.MaLop = cmb_Chon.SelectedValue.ToString();
                    dt = sinhVien_DAO.ThongTin_SinhVien_TheoLop(lop_DTO);
                    Report_DS_TheoLop rp_Lop = new Report_DS_TheoLop();
                    rp_Lop.SetDataSource(dt);
                    Form_In_Report frm_Report = new Form_In_Report();
                    frm_Report.report_DS_Sinhvien.ReportSource = rp_Lop;
                    frm_Report.ShowDialog();

                }
            }
        }
    }
}
