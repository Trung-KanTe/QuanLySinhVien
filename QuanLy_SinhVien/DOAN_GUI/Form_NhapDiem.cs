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
    public partial class Form_NhapDiem : Form
    {
        public Form_NhapDiem()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        Lop_DAO lop_DAO = new Lop_DAO();
        Lop_DTO lop_DTO = new Lop_DTO();
        SinhVien_Hoc_DTO sinhVien_Hoc_DTO = new SinhVien_Hoc_DTO();
        SinhVien_Hoc_DAO sinhVien_Hoc_DAO = new SinhVien_Hoc_DAO();
        LopHoc_DAO lopHoc_DAO = new LopHoc_DAO();
        LopHoc_DTO lopHoc_DTO = new LopHoc_DTO();
        public string maGiangVien;
        public string tenGiangVien;
        public string hoTenLotGV;
        float tiLe_DiemTX;
        float tiLe_DiemThi;
        string maHocPhan;
        string maLopHoc;

        public float tinhDiemTrungBinh(float diemTX, float diemThiL1, float diemThiL2, float tiLeDtiemTX, float tiLeDiemThi)
        {
            if (diemThiL2 == null || diemThiL2 < diemThiL1)
                return diemTX * (tiLeDtiemTX / 100) + diemThiL1 * (tiLeDiemThi / 100);
            return diemTX * (tiLeDtiemTX / 100) + diemThiL2 * (tiLeDiemThi / 100);
        }
        public string tinhDiemTrungBinh4(float dtb)
        {
            if (dtb >= 9)
                return "A+";
            else if (dtb >= 8 && dtb < 9)
                return "A";
            else if (dtb >= 7 && dtb < 8)
                return "B+";
            else if (dtb >= 6.5 && dtb < 7)
                return "B";
            else if (dtb >= 5.5 && dtb < 6.5)
                return "C+";
            else if (dtb >= 5 && dtb < 5.5)
                return "C";
            else if (dtb >= 4 && dtb < 5)
                return "D+";
            else if (dtb >= 3.5 && dtb < 4)
                return "D";
            return "F";
        }
        public float tinhDiemTrungBinh4So(float dtb)
        {
            if (dtb >= 9)
                return  4;
            else if (dtb >= 8 && dtb < 9)
                return 3.5f;
            else if (dtb >= 7 && dtb < 8)
                return 3;
            else if (dtb >= 6.5 && dtb < 7)
                return 2.5f;
            else if (dtb >= 5.5 && dtb < 6.5)
                return 2;
            else if (dtb >= 5 && dtb < 5.5)
                return 1.5f;
            else if (dtb >= 4 && dtb < 5)
                return 1;
            else if (dtb >= 3.5 && dtb < 4)
                return 0.5f;
            return 0;
        }

        public void load_CMB_LopHoc()
        {
            lopHoc_DTO.MaGiangVien =maGiangVien;
            dt = lopHoc_DAO.ThongTin_LopHoc_GV(lopHoc_DTO); ;
            cmb_MaLopHoc.DataSource = dt;
            cmb_MaLopHoc.ValueMember = "MALOPHOC";
            cmb_MaLopHoc.DisplayMember = "MALOPHOC";
        }
 
        private void Form_NhapDiem_Load(object sender, EventArgs e)
        {
            dtg_DiemSinhVien.ColumnHeadersDefaultCellStyle.Font = new Font("Cambria", 12, FontStyle.Bold);
            load_CMB_LopHoc();
            lab_Avatar.Text = tenGiangVien.Substring(0, 1);
            lab_Ten.Text = hoTenLotGV + " " + tenGiangVien;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            float diemTX = 0;
            float diemThiL1 = 0;
            float diemThiL2 = 0;
            bool kiemTra = false;

            if (MessageBox.Show("Bạn có chắc muốn thêm dữ liệu này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    for (int i = 0; i < dtg_DiemSinhVien.Rows.Count; i++)
                    {
                        if (dtg_DiemSinhVien.Rows[i].Cells[0].Value != null)
                        {
                            if (float.TryParse(dtg_DiemSinhVien.Rows[i].Cells[6].Value.ToString(), out diemTX))
                            {
                                if (!(diemTX >= 0 && diemTX <= 10))
                                {
                                    kiemTra = true;
                                }
                                if (dtg_DiemSinhVien.Rows[i].Cells[7].Value != null)
                                {
                                    float.TryParse(dtg_DiemSinhVien.Rows[i].Cells[7].Value.ToString(), out diemThiL1);
                                    if (!(diemThiL1 >= 0 && diemThiL1 <= 10))
                                    {
                                        kiemTra = true;
                                    }
                                }
                                if (dtg_DiemSinhVien.Rows[i].Cells[8].Value != null)
                                {
                                    float.TryParse(dtg_DiemSinhVien.Rows[i].Cells[8].Value.ToString(), out diemThiL2);
                                    if (!(diemThiL2 >= 0 && diemThiL2 <= 10))
                                    {
                                        kiemTra = true;
                                    }
                                }
                                if (kiemTra)
                                {
                                    MessageBox.Show("Vui lòng nhập điểm trong khoảng 0 -> 10!!!");
                                    return;
                                }
                                sinhVien_Hoc_DTO.MaSinhVien = dtg_DiemSinhVien.Rows[i].Cells[0].Value.ToString();
                                sinhVien_Hoc_DTO.MaHocPhan = maHocPhan;
                                if (tiLe_DiemThi == 0)
                                {
                                    diemThiL1 = 0;
                                    diemThiL2 = 0;
                                }
                                sinhVien_Hoc_DTO.DiemTX = diemTX;
                                sinhVien_Hoc_DTO.DiemL1 = diemThiL1;
                                sinhVien_Hoc_DTO.DiemL2 = diemThiL2;
                                sinhVien_Hoc_DTO.DiemTB = tinhDiemTrungBinh(diemTX, diemThiL1, diemThiL2, tiLe_DiemTX, tiLe_DiemThi);
                                sinhVien_Hoc_DTO.DiemTB4 = tinhDiemTrungBinh4(tinhDiemTrungBinh(diemTX, diemThiL1, diemThiL2, tiLe_DiemTX, tiLe_DiemThi));
                                sinhVien_Hoc_DTO.DiemTB4So = tinhDiemTrungBinh4So(tinhDiemTrungBinh(diemTX, diemThiL1, diemThiL2, tiLe_DiemTX, tiLe_DiemThi));

                                sinhVien_Hoc_DAO.Them_Diem_SinhVien(sinhVien_Hoc_DTO);
                            }
                        }
                        else break;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Thêm không thành công!!!", "Thông báo");
                }
            }
            cmb_MaLopHoc_SelectedIndexChanged(sender, e);
        }

        private void cmb_MaLopHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_MaLopHoc.SelectedValue != null && cmb_MaLopHoc.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                
                maLopHoc = cmb_MaLopHoc.SelectedValue.ToString().Trim();
                sinhVien_Hoc_DTO.MaLopHoc = maLopHoc;
                dt = sinhVien_Hoc_DAO.ThongTin_Diem_SinhVien(sinhVien_Hoc_DTO);
                if (dt.Rows.Count > 0)
                {
                    DataRow dr_Khoa = dt.Rows[0];
                    if (int.Parse(dr_Khoa["KHOAL"].ToString()) == 0)
                    {
                        dtg_DiemSinhVien.ReadOnly = false;
                        dtg_DiemSinhVien.DataSource = dt;
                        dtg_DiemSinhVien.Columns["TENHOCPHAN"].Visible = false;
                        dtg_DiemSinhVien.Columns["MAHOCPHAN"].Visible = false;
                        dtg_DiemSinhVien.Columns["MASINHVIEN"].HeaderText = "MÃ SINH VIÊN";
                        dtg_DiemSinhVien.Columns["MASINHVIEN"].ReadOnly = true;
                        dtg_DiemSinhVien.Columns["TENSINHVIEN"].HeaderText = "TÊN SINH VIÊN";
                        dtg_DiemSinhVien.Columns["TENSINHVIEN"].ReadOnly = true;
                        dtg_DiemSinhVien.Columns["TENLOP"].HeaderText = "TÊN LỚP";
                        dtg_DiemSinhVien.Columns["TENLOP"].ReadOnly = true;
                        dtg_DiemSinhVien.Columns["KHOA"].HeaderText = "KHÓA";
                        dtg_DiemSinhVien.Columns["KHOA"].ReadOnly = true;
                        dtg_DiemSinhVien.Columns["TILEDIEMTHUONGXUYEN"].HeaderText = "% THƯỜNG XUYÊN";
                        dtg_DiemSinhVien.Columns["TILEDIEMTHUONGXUYEN"].ReadOnly = true;
                        dtg_DiemSinhVien.Columns["TILEDIEMTHI"].HeaderText = "% THI";
                        dtg_DiemSinhVien.Columns["TILEDIEMTHI"].ReadOnly = true;
                        dtg_DiemSinhVien.Columns["DIEMTHUONGXUYEN"].HeaderText = "ĐIỂM THƯỜNG XUYÊN";
                        dtg_DiemSinhVien.Columns["DIEMTHILAN1"].HeaderText = "ĐIỂM THI L1";
                        dtg_DiemSinhVien.Columns["DIEMTHILAN2"].HeaderText = "ĐIỂM THI LẦN 2";
                        dtg_DiemSinhVien.Columns["DIEMTRUNGBINHMON"].HeaderText = "ĐIỂM TRUNG BÌNH MÔN";
                        dtg_DiemSinhVien.Columns["DIEMTRUNGBINHMON"].ReadOnly = true;
                        dtg_DiemSinhVien.Columns["DIEMTRUNGBINHMONHE4"].HeaderText = "ĐIỂM HỆ 4";
                        dtg_DiemSinhVien.Columns["DIEMTRUNGBINHMONHE4"].ReadOnly = true;
                        dtg_DiemSinhVien.Columns["KHOAL"].Visible = false;
                        if (dt.Rows.Count > 0)
                        {
                            DataRow dr = dt.Rows[0];
                            txt_HocPhan.Text = dr["TENHOCPHAN"].ToString().Trim();
                            tiLe_DiemTX = float.Parse(dr["TILEDIEMTHUONGXUYEN"].ToString());
                            tiLe_DiemThi = float.Parse(dr["TILEDIEMTHI"].ToString());
                            maHocPhan = dr["MAHOCPHAN"].ToString();
                        }
                    }
                    else if (int.Parse(dr_Khoa["KHOAL"].ToString()) == 1)
                    {
                        dtg_DiemSinhVien.ReadOnly = true;
                        dtg_DiemSinhVien.DataSource = dt;
                        dtg_DiemSinhVien.Columns["TENHOCPHAN"].Visible = false;
                        dtg_DiemSinhVien.Columns["MAHOCPHAN"].Visible = false;
                        dtg_DiemSinhVien.Columns["MASINHVIEN"].HeaderText = "MÃ SINH VIÊN";
                        dtg_DiemSinhVien.Columns["MASINHVIEN"].ReadOnly = true;
                        dtg_DiemSinhVien.Columns["TENSINHVIEN"].HeaderText = "TÊN SINH VIÊN";
                        dtg_DiemSinhVien.Columns["TENSINHVIEN"].ReadOnly = true;
                        dtg_DiemSinhVien.Columns["TENLOP"].HeaderText = "TÊN LỚP";
                        dtg_DiemSinhVien.Columns["TENLOP"].ReadOnly = true;
                        dtg_DiemSinhVien.Columns["KHOA"].HeaderText = "KHÓA";
                        dtg_DiemSinhVien.Columns["KHOA"].ReadOnly = true;
                        dtg_DiemSinhVien.Columns["TILEDIEMTHUONGXUYEN"].HeaderText = "% THƯỜNG XUYÊN";
                        dtg_DiemSinhVien.Columns["TILEDIEMTHUONGXUYEN"].ReadOnly = true;
                        dtg_DiemSinhVien.Columns["TILEDIEMTHI"].HeaderText = "% THI";
                        dtg_DiemSinhVien.Columns["TILEDIEMTHI"].ReadOnly = true;
                        dtg_DiemSinhVien.Columns["DIEMTHUONGXUYEN"].HeaderText = "ĐIỂM THƯỜNG XUYÊN";
                        dtg_DiemSinhVien.Columns["DIEMTHILAN1"].HeaderText = "ĐIỂM THI L1";
                        dtg_DiemSinhVien.Columns["DIEMTHILAN2"].HeaderText = "ĐIỂM THI LẦN 2";
                        dtg_DiemSinhVien.Columns["DIEMTRUNGBINHMON"].HeaderText = "ĐIỂM TRUNG BÌNH MÔN";
                        dtg_DiemSinhVien.Columns["DIEMTRUNGBINHMON"].ReadOnly = true;
                        dtg_DiemSinhVien.Columns["DIEMTRUNGBINHMONHE4"].HeaderText = "ĐIỂM HỆ 4";
                        dtg_DiemSinhVien.Columns["DIEMTRUNGBINHMONHE4"].ReadOnly = true;
                        dtg_DiemSinhVien.Columns["KHOAL"].Visible = false;
                        if (dt.Rows.Count > 0)
                        {
                            DataRow dr = dt.Rows[0];
                            txt_HocPhan.Text = dr["TENHOCPHAN"].ToString().Trim();
                            tiLe_DiemTX = float.Parse(dr["TILEDIEMTHUONGXUYEN"].ToString());
                            tiLe_DiemThi = float.Parse(dr["TILEDIEMTHI"].ToString());
                            maHocPhan = dr["MAHOCPHAN"].ToString();
                        }
                    }
                }
            }
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
    }
}
