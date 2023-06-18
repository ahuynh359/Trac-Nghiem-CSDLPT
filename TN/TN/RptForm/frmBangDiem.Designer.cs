
namespace TN
{
    partial class frmBangDiem
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnXemTruoc = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbCoSo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.sEdtLanThi = new DevExpress.XtraEditors.SpinEdit();
            this.edtMaLop = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.edtTenMH = new System.Windows.Forms.TextBox();
            this.edtMaMH = new System.Windows.Forms.TextBox();
            this.btnChonMaLop = new System.Windows.Forms.Button();
            this.btnChonMaMH = new System.Windows.Forms.Button();
            this.edtTenLop = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.sEdtLanThi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cơ Sở";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã Lớp";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mã Môn Học";
            // 
            // btnXemTruoc
            // 
            this.btnXemTruoc.BackColor = System.Drawing.Color.Transparent;
            this.btnXemTruoc.Location = new System.Drawing.Point(649, 553);
            this.btnXemTruoc.Name = "btnXemTruoc";
            this.btnXemTruoc.Size = new System.Drawing.Size(127, 35);
            this.btnXemTruoc.TabIndex = 3;
            this.btnXemTruoc.Text = "Xem Trước";
            this.btnXemTruoc.UseVisualStyleBackColor = false;
            this.btnXemTruoc.Click += new System.EventHandler(this.btnXemTruoc_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(105, 341);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "Lần Thi";
            // 
            // cmbCoSo
            // 
            this.cmbCoSo.Enabled = false;
            this.cmbCoSo.FormattingEnabled = true;
            this.cmbCoSo.Location = new System.Drawing.Point(236, 105);
            this.cmbCoSo.Name = "cmbCoSo";
            this.cmbCoSo.Size = new System.Drawing.Size(260, 27);
            this.cmbCoSo.TabIndex = 6;
            this.cmbCoSo.SelectedIndexChanged += new System.EventHandler(this.cmbCoSo_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(563, -4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(329, 34);
            this.label5.TabIndex = 12;
            this.label5.Text = "BẢNG ĐIỂM MÔN HỌC";
            // 
            // sEdtLanThi
            // 
            this.sEdtLanThi.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sEdtLanThi.Location = new System.Drawing.Point(236, 337);
            this.sEdtLanThi.Name = "sEdtLanThi";
            this.sEdtLanThi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sEdtLanThi.Properties.MaxValue = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.sEdtLanThi.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sEdtLanThi.Size = new System.Drawing.Size(260, 28);
            this.sEdtLanThi.TabIndex = 15;
            // 
            // edtMaLop
            // 
            this.edtMaLop.Enabled = false;
            this.edtMaLop.Location = new System.Drawing.Point(236, 178);
            this.edtMaLop.Name = "edtMaLop";
            this.edtMaLop.Size = new System.Drawing.Size(260, 27);
            this.edtMaLop.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(899, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 19);
            this.label6.TabIndex = 18;
            this.label6.Text = "Tên Lớp";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(899, 260);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 19);
            this.label7.TabIndex = 19;
            this.label7.Text = "Tên Môn Học";
            // 
            // edtTenMH
            // 
            this.edtTenMH.Enabled = false;
            this.edtTenMH.Location = new System.Drawing.Point(1018, 257);
            this.edtTenMH.Name = "edtTenMH";
            this.edtTenMH.Size = new System.Drawing.Size(350, 27);
            this.edtTenMH.TabIndex = 20;
            // 
            // edtMaMH
            // 
            this.edtMaMH.Enabled = false;
            this.edtMaMH.Location = new System.Drawing.Point(236, 257);
            this.edtMaMH.Name = "edtMaMH";
            this.edtMaMH.Size = new System.Drawing.Size(260, 27);
            this.edtMaMH.TabIndex = 21;
            // 
            // btnChonMaLop
            // 
            this.btnChonMaLop.BackColor = System.Drawing.Color.Transparent;
            this.btnChonMaLop.Location = new System.Drawing.Point(525, 173);
            this.btnChonMaLop.Name = "btnChonMaLop";
            this.btnChonMaLop.Size = new System.Drawing.Size(82, 35);
            this.btnChonMaLop.TabIndex = 22;
            this.btnChonMaLop.Text = "Chọn";
            this.btnChonMaLop.UseVisualStyleBackColor = false;
            this.btnChonMaLop.Click += new System.EventHandler(this.btnChonMaLop_Click);
            // 
            // btnChonMaMH
            // 
            this.btnChonMaMH.BackColor = System.Drawing.Color.Transparent;
            this.btnChonMaMH.Location = new System.Drawing.Point(525, 257);
            this.btnChonMaMH.Name = "btnChonMaMH";
            this.btnChonMaMH.Size = new System.Drawing.Size(82, 35);
            this.btnChonMaMH.TabIndex = 23;
            this.btnChonMaMH.Text = "Chọn";
            this.btnChonMaMH.UseVisualStyleBackColor = false;
            this.btnChonMaMH.Click += new System.EventHandler(this.btnChonMaMH_Click);
            // 
            // edtTenLop
            // 
            this.edtTenLop.Enabled = false;
            this.edtTenLop.Location = new System.Drawing.Point(1018, 175);
            this.edtTenLop.Name = "edtTenLop";
            this.edtTenLop.Size = new System.Drawing.Size(350, 27);
            this.edtTenLop.TabIndex = 24;
            // 
            // frmBangDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1401, 654);
            this.Controls.Add(this.edtTenLop);
            this.Controls.Add(this.btnChonMaMH);
            this.Controls.Add(this.btnChonMaLop);
            this.Controls.Add(this.edtMaMH);
            this.Controls.Add(this.edtTenMH);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.sEdtLanThi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.edtMaLop);
            this.Controls.Add(this.cmbCoSo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnXemTruoc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmBangDiem";
            this.Text = "Bảng Điểm Môn Học";
            this.Load += new System.EventHandler(this.frmBangDiem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sEdtLanThi.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnXemTruoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbCoSo;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.SpinEdit sEdtLanThi;
        private System.Windows.Forms.TextBox edtMaLop;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox edtTenMH;
        private System.Windows.Forms.TextBox edtMaMH;
        private System.Windows.Forms.Button btnChonMaLop;
        private System.Windows.Forms.Button btnChonMaMH;
        private System.Windows.Forms.TextBox edtTenLop;
    }
}