namespace QuanLy_SinhVien.DOAN_GUI
{
    partial class Form_In_Report
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
            this.report_DS_Sinhvien = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // report_DS_Sinhvien
            // 
            this.report_DS_Sinhvien.ActiveViewIndex = -1;
            this.report_DS_Sinhvien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.report_DS_Sinhvien.Cursor = System.Windows.Forms.Cursors.Default;
            this.report_DS_Sinhvien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.report_DS_Sinhvien.Location = new System.Drawing.Point(0, 0);
            this.report_DS_Sinhvien.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.report_DS_Sinhvien.Name = "report_DS_Sinhvien";
            this.report_DS_Sinhvien.Size = new System.Drawing.Size(1315, 728);
            this.report_DS_Sinhvien.TabIndex = 0;
            this.report_DS_Sinhvien.ToolPanelWidth = 300;
            // 
            // Form_In_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1315, 728);
            this.Controls.Add(this.report_DS_Sinhvien);
            this.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form_In_Report";
            this.Text = "Form_In_Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer report_DS_Sinhvien;
    }
}