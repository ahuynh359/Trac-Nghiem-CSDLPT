
namespace TN
{
    partial class frmXemKetQuaThi
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
            this.btnPreview = new System.Windows.Forms.Button();
            this.edtMaSV = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.edtMaMH = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sEditLan = new DevExpress.XtraEditors.SpinEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.edtTenSV = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.edtTenMonHoc = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnChonSV = new System.Windows.Forms.Button();
            this.btnChonMH = new System.Windows.Forms.Button();
            this.edtLop = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbCoSo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.sEditLan.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(537, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kết Quả Thi";
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(653, 582);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(111, 45);
            this.btnPreview.TabIndex = 14;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // edtMaSV
            // 
            this.edtMaSV.Enabled = false;
            this.edtMaSV.Location = new System.Drawing.Point(319, 234);
            this.edtMaSV.Name = "edtMaSV";
            this.edtMaSV.Size = new System.Drawing.Size(197, 26);
            this.edtMaSV.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(226, 237);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "Mã SV";
            // 
            // edtMaMH
            // 
            this.edtMaMH.Enabled = false;
            this.edtMaMH.Location = new System.Drawing.Point(319, 332);
            this.edtMaMH.Name = "edtMaMH";
            this.edtMaMH.Size = new System.Drawing.Size(197, 26);
            this.edtMaMH.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(214, 335);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "Mã Môn Học";
            // 
            // sEditLan
            // 
            this.sEditLan.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sEditLan.Location = new System.Drawing.Point(319, 428);
            this.sEditLan.Name = "sEditLan";
            this.sEditLan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sEditLan.Properties.MaxValue = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.sEditLan.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sEditLan.Size = new System.Drawing.Size(150, 28);
            this.sEditLan.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(226, 432);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "Lần thi";
            // 
            // edtTenSV
            // 
            this.edtTenSV.Enabled = false;
            this.edtTenSV.Location = new System.Drawing.Point(857, 237);
            this.edtTenSV.Name = "edtTenSV";
            this.edtTenSV.Size = new System.Drawing.Size(197, 26);
            this.edtTenSV.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(728, 237);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 20);
            this.label6.TabIndex = 26;
            this.label6.Text = "Họ Tên SV";
            // 
            // edtTenMonHoc
            // 
            this.edtTenMonHoc.Enabled = false;
            this.edtTenMonHoc.Location = new System.Drawing.Point(857, 426);
            this.edtTenMonHoc.Name = "edtTenMonHoc";
            this.edtTenMonHoc.Size = new System.Drawing.Size(197, 26);
            this.edtTenMonHoc.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(728, 432);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 20);
            this.label7.TabIndex = 28;
            this.label7.Text = "Tên Môn Học";
            // 
            // btnChonSV
            // 
            this.btnChonSV.Location = new System.Drawing.Point(545, 234);
            this.btnChonSV.Name = "btnChonSV";
            this.btnChonSV.Size = new System.Drawing.Size(71, 38);
            this.btnChonSV.TabIndex = 29;
            this.btnChonSV.Text = "Chọn";
            this.btnChonSV.UseVisualStyleBackColor = true;
            this.btnChonSV.Click += new System.EventHandler(this.btnChonSV_Click);
            // 
            // btnChonMH
            // 
            this.btnChonMH.Location = new System.Drawing.Point(545, 332);
            this.btnChonMH.Name = "btnChonMH";
            this.btnChonMH.Size = new System.Drawing.Size(71, 36);
            this.btnChonMH.TabIndex = 30;
            this.btnChonMH.Text = "Chọn";
            this.btnChonMH.UseVisualStyleBackColor = true;
            this.btnChonMH.Click += new System.EventHandler(this.btnChonMH_Click);
            // 
            // edtLop
            // 
            this.edtLop.Enabled = false;
            this.edtLop.Location = new System.Drawing.Point(857, 332);
            this.edtLop.Name = "edtLop";
            this.edtLop.Size = new System.Drawing.Size(197, 26);
            this.edtLop.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(728, 340);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 20);
            this.label2.TabIndex = 32;
            this.label2.Text = "Lớp";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(505, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 20);
            this.label8.TabIndex = 33;
            this.label8.Text = "Cơ Sở";
            // 
            // cmbCoSo
            // 
            this.cmbCoSo.Enabled = false;
            this.cmbCoSo.Location = new System.Drawing.Point(598, 140);
            this.cmbCoSo.Name = "cmbCoSo";
            this.cmbCoSo.Size = new System.Drawing.Size(200, 28);
            this.cmbCoSo.TabIndex = 34;
            this.cmbCoSo.SelectedIndexChanged += new System.EventHandler(this.cmbCoSo_SelectedIndexChanged);
            // 
            // frmXemKetQuaThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 684);
            this.Controls.Add(this.cmbCoSo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.edtLop);
            this.Controls.Add(this.btnChonMH);
            this.Controls.Add(this.btnChonSV);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.edtTenMonHoc);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.edtTenSV);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.sEditLan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.edtMaMH);
            this.Controls.Add(this.edtMaSV);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.label1);
            this.Name = "frmXemKetQuaThi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xem Kết Quả Thi";
            this.Load += new System.EventHandler(this.frmXemKetQuaThi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sEditLan.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.TextBox edtMaSV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox edtMaMH;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SpinEdit sEditLan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox edtTenSV;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox edtTenMonHoc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnChonSV;
        private System.Windows.Forms.Button btnChonMH;
        private System.Windows.Forms.TextBox edtLop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbCoSo;
    }
}