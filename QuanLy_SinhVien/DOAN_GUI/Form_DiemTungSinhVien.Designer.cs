namespace QuanLy_SinhVien.DOAN_GUI
{
    partial class Form_DiemTungSinhVien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmb_HocKy = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lab_XepLoai = new System.Windows.Forms.Label();
            this.lab_Diem4 = new System.Windows.Forms.Label();
            this.lab_Diem10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_TongSinhVien = new System.Windows.Forms.PictureBox();
            this.btn_SinhVienGioi = new System.Windows.Forms.PictureBox();
            this.ntm_TrungBinhLop = new System.Windows.Forms.PictureBox();
            this.btn_Xem = new System.Windows.Forms.Button();
            this.lab_DiemSV = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtg_DiemSinhVien = new System.Windows.Forms.DataGridView();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lab_TinChi = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_TongSinhVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_SinhVienGioi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntm_TrungBinhLop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_DiemSinhVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.cmb_HocKy);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btn_Xem);
            this.panel1.Controls.Add(this.lab_DiemSV);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.dtg_DiemSinhVien);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1500, 672);
            this.panel1.TabIndex = 96;
            // 
            // cmb_HocKy
            // 
            this.cmb_HocKy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmb_HocKy.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_HocKy.FormattingEnabled = true;
            this.cmb_HocKy.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.cmb_HocKy.Location = new System.Drawing.Point(58, 113);
            this.cmb_HocKy.Name = "cmb_HocKy";
            this.cmb_HocKy.Size = new System.Drawing.Size(254, 35);
            this.cmb_HocKy.TabIndex = 93;
            this.cmb_HocKy.Text = "  --Chọn học kỳ--";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.lab_TinChi);
            this.groupBox1.Controls.Add(this.label30);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.lab_XepLoai);
            this.groupBox1.Controls.Add(this.lab_Diem4);
            this.groupBox1.Controls.Add(this.lab_Diem10);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btn_TongSinhVien);
            this.groupBox1.Controls.Add(this.btn_SinhVienGioi);
            this.groupBox1.Controls.Add(this.ntm_TrungBinhLop);
            this.groupBox1.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(419, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1036, 138);
            this.groupBox1.TabIndex = 87;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tổng quan:";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lab_XepLoai
            // 
            this.lab_XepLoai.AutoSize = true;
            this.lab_XepLoai.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lab_XepLoai.Font = new System.Drawing.Font("Cambria", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_XepLoai.ForeColor = System.Drawing.Color.White;
            this.lab_XepLoai.Location = new System.Drawing.Point(609, 65);
            this.lab_XepLoai.Name = "lab_XepLoai";
            this.lab_XepLoai.Size = new System.Drawing.Size(63, 43);
            this.lab_XepLoai.TabIndex = 92;
            this.lab_XepLoai.Text = "40";
            // 
            // lab_Diem4
            // 
            this.lab_Diem4.AutoSize = true;
            this.lab_Diem4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lab_Diem4.Font = new System.Drawing.Font("Cambria", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_Diem4.ForeColor = System.Drawing.Color.White;
            this.lab_Diem4.Location = new System.Drawing.Point(331, 65);
            this.lab_Diem4.Name = "lab_Diem4";
            this.lab_Diem4.Size = new System.Drawing.Size(63, 43);
            this.lab_Diem4.TabIndex = 91;
            this.lab_Diem4.Text = "40";
            // 
            // lab_Diem10
            // 
            this.lab_Diem10.AutoSize = true;
            this.lab_Diem10.BackColor = System.Drawing.Color.SlateBlue;
            this.lab_Diem10.Font = new System.Drawing.Font("Cambria", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_Diem10.ForeColor = System.Drawing.Color.White;
            this.lab_Diem10.Location = new System.Drawing.Point(75, 65);
            this.lab_Diem10.Name = "lab_Diem10";
            this.lab_Diem10.Size = new System.Drawing.Size(63, 43);
            this.lab_Diem10.TabIndex = 90;
            this.lab_Diem10.Text = "40";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.label7.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(567, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 27);
            this.label7.TabIndex = 88;
            this.label7.Text = "Xếp loại:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label2.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(302, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(241, 27);
            this.label2.TabIndex = 87;
            this.label2.Text = "Điểm trung bình hệ 4:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.SlateBlue;
            this.label5.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(29, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(255, 27);
            this.label5.TabIndex = 86;
            this.label5.Text = "Điểm trung bình hệ 10:";
            // 
            // btn_TongSinhVien
            // 
            this.btn_TongSinhVien.BackColor = System.Drawing.Color.SlateBlue;
            this.btn_TongSinhVien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_TongSinhVien.Location = new System.Drawing.Point(20, 30);
            this.btn_TongSinhVien.Name = "btn_TongSinhVien";
            this.btn_TongSinhVien.Size = new System.Drawing.Size(264, 93);
            this.btn_TongSinhVien.TabIndex = 79;
            this.btn_TongSinhVien.TabStop = false;
            // 
            // btn_SinhVienGioi
            // 
            this.btn_SinhVienGioi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_SinhVienGioi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_SinhVienGioi.Location = new System.Drawing.Point(290, 30);
            this.btn_SinhVienGioi.Name = "btn_SinhVienGioi";
            this.btn_SinhVienGioi.Size = new System.Drawing.Size(253, 93);
            this.btn_SinhVienGioi.TabIndex = 80;
            this.btn_SinhVienGioi.TabStop = false;
            // 
            // ntm_TrungBinhLop
            // 
            this.ntm_TrungBinhLop.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ntm_TrungBinhLop.Location = new System.Drawing.Point(549, 30);
            this.ntm_TrungBinhLop.Name = "ntm_TrungBinhLop";
            this.ntm_TrungBinhLop.Size = new System.Drawing.Size(247, 93);
            this.ntm_TrungBinhLop.TabIndex = 81;
            this.ntm_TrungBinhLop.TabStop = false;
            // 
            // btn_Xem
            // 
            this.btn_Xem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_Xem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Xem.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Xem.ForeColor = System.Drawing.Color.White;
            this.btn_Xem.Location = new System.Drawing.Point(58, 154);
            this.btn_Xem.Name = "btn_Xem";
            this.btn_Xem.Size = new System.Drawing.Size(254, 49);
            this.btn_Xem.TabIndex = 84;
            this.btn_Xem.Text = "Xem";
            this.btn_Xem.UseVisualStyleBackColor = false;
            this.btn_Xem.Click += new System.EventHandler(this.btn_Xem_Click);
            // 
            // lab_DiemSV
            // 
            this.lab_DiemSV.AutoSize = true;
            this.lab_DiemSV.Font = new System.Drawing.Font("Cambria", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_DiemSV.Location = new System.Drawing.Point(412, 16);
            this.lab_DiemSV.Name = "lab_DiemSV";
            this.lab_DiemSV.Size = new System.Drawing.Size(442, 38);
            this.lab_DiemSV.TabIndex = 83;
            this.lab_DiemSV.Text = "THÔNG TIN ĐIỂM SINH VIÊN";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(43, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 27);
            this.label6.TabIndex = 79;
            this.label6.Text = "Chọn học kỳ:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label10.Font = new System.Drawing.Font("Cambria", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(436, 630);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(820, 33);
            this.label10.TabIndex = 68;
            this.label10.Text = "© 2024  Copyrights by Thanh Phong | Liên hệ hỗ trợ: 0867574607 ";
            // 
            // dtg_DiemSinhVien
            // 
            this.dtg_DiemSinhVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtg_DiemSinhVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_DiemSinhVien.Location = new System.Drawing.Point(12, 224);
            this.dtg_DiemSinhVien.Name = "dtg_DiemSinhVien";
            this.dtg_DiemSinhVien.RowHeadersWidth = 51;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtg_DiemSinhVien.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtg_DiemSinhVien.RowTemplate.Height = 24;
            this.dtg_DiemSinhVien.Size = new System.Drawing.Size(1476, 395);
            this.dtg_DiemSinhVien.TabIndex = 78;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Black;
            this.pictureBox3.Location = new System.Drawing.Point(0, 625);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(1500, 2);
            this.pictureBox3.TabIndex = 77;
            this.pictureBox3.TabStop = false;
            // 
            // lab_TinChi
            // 
            this.lab_TinChi.AutoSize = true;
            this.lab_TinChi.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lab_TinChi.Font = new System.Drawing.Font("Cambria", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_TinChi.ForeColor = System.Drawing.Color.White;
            this.lab_TinChi.Location = new System.Drawing.Point(862, 65);
            this.lab_TinChi.Name = "lab_TinChi";
            this.lab_TinChi.Size = new System.Drawing.Size(63, 43);
            this.lab_TinChi.TabIndex = 95;
            this.lab_TinChi.Text = "40";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.label30.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.White;
            this.label30.Location = new System.Drawing.Point(820, 38);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(102, 27);
            this.label30.TabIndex = 94;
            this.label30.Text = "Xếp loại:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.pictureBox1.Location = new System.Drawing.Point(802, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(228, 93);
            this.pictureBox1.TabIndex = 93;
            this.pictureBox1.TabStop = false;
            // 
            // Form_DiemTungSinhVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QuanLy_SinhVien.Properties.Resources.anh_nen_9;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1500, 672);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Cambria", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_DiemTungSinhVien";
            this.Text = "Form_DiemTungSinhVien";
            this.Load += new System.EventHandler(this.Form_DiemTungSinhVien_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_TongSinhVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_SinhVienGioi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntm_TrungBinhLop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_DiemSinhVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmb_HocKy;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lab_XepLoai;
        private System.Windows.Forms.Label lab_Diem4;
        private System.Windows.Forms.Label lab_Diem10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox btn_TongSinhVien;
        private System.Windows.Forms.PictureBox btn_SinhVienGioi;
        private System.Windows.Forms.PictureBox ntm_TrungBinhLop;
        private System.Windows.Forms.Button btn_Xem;
        private System.Windows.Forms.Label lab_DiemSV;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dtg_DiemSinhVien;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lab_TinChi;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}