
namespace TN
{
    partial class frmThi
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
            this.components = new System.ComponentModel.Container();
            this.groupBoxBaiThi = new System.Windows.Forms.GroupBox();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.edtNgayThi = new System.Windows.Forms.TextBox();
            this.lbNgayThi = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.edtThoiGian = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.edtSoCauThi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.edtTenMH = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.edtTrinhDo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnChon = new System.Windows.Forms.Button();
            this.sEdtLanThi = new DevExpress.XtraEditors.SpinEdit();
            this.edtMaMH = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnThi = new System.Windows.Forms.Button();
            this.groupBoxSV = new System.Windows.Forms.GroupBox();
            this.edtTenLop = new System.Windows.Forms.TextBox();
            this.edtHoTen = new System.Windows.Forms.TextBox();
            this.edtMaLop = new System.Windows.Forms.TextBox();
            this.edtMaSV = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bdsDeThi = new System.Windows.Forms.BindingSource(this.components);
            this.labelTime = new System.Windows.Forms.Label();
            this.listViewDaChon = new System.Windows.Forms.ListView();
            this.columnSoCau = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDaChon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.flowDeThi = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNop = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.panelThi = new System.Windows.Forms.Panel();
            this.btnSau = new System.Windows.Forms.Button();
            this.btnTruoc = new System.Windows.Forms.Button();
            this.bdsThi = new System.Windows.Forms.BindingSource(this.components);
            this.DS = new TN.TNDataSet();
            this.thiTableAdapter = new TN.TNDataSetTableAdapters.THI();
            this.tableAdapterManager = new TN.TNDataSetTableAdapters.TableAdapterManager();
            this.gvThi = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMAGV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAMH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTENMH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMALOP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTRINHDO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNGAYTHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOCAUTHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTHOIGIAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControlThi = new DevExpress.XtraGrid.GridControl();
            this.groupBoxBaiThi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sEdtLanThi.Properties)).BeginInit();
            this.groupBoxSV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDeThi)).BeginInit();
            this.panelThi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsThi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvThi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlThi)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxBaiThi
            // 
            this.groupBoxBaiThi.Controls.Add(this.dateEdit1);
            this.groupBoxBaiThi.Controls.Add(this.edtNgayThi);
            this.groupBoxBaiThi.Controls.Add(this.lbNgayThi);
            this.groupBoxBaiThi.Controls.Add(this.label12);
            this.groupBoxBaiThi.Controls.Add(this.edtThoiGian);
            this.groupBoxBaiThi.Controls.Add(this.label11);
            this.groupBoxBaiThi.Controls.Add(this.edtSoCauThi);
            this.groupBoxBaiThi.Controls.Add(this.label5);
            this.groupBoxBaiThi.Controls.Add(this.edtTenMH);
            this.groupBoxBaiThi.Controls.Add(this.label4);
            this.groupBoxBaiThi.Controls.Add(this.edtTrinhDo);
            this.groupBoxBaiThi.Controls.Add(this.label3);
            this.groupBoxBaiThi.Controls.Add(this.btnChon);
            this.groupBoxBaiThi.Controls.Add(this.sEdtLanThi);
            this.groupBoxBaiThi.Controls.Add(this.edtMaMH);
            this.groupBoxBaiThi.Controls.Add(this.label6);
            this.groupBoxBaiThi.Controls.Add(this.label2);
            this.groupBoxBaiThi.Controls.Add(this.label1);
            this.groupBoxBaiThi.Location = new System.Drawing.Point(2, 4);
            this.groupBoxBaiThi.Name = "groupBoxBaiThi";
            this.groupBoxBaiThi.Size = new System.Drawing.Size(1141, 136);
            this.groupBoxBaiThi.TabIndex = 0;
            this.groupBoxBaiThi.TabStop = false;
            this.groupBoxBaiThi.Text = "Thông Tin Bài Thi";
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = new System.DateTime(2023, 6, 18, 7, 57, 5, 0);
            this.dateEdit1.Location = new System.Drawing.Point(97, 95);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Size = new System.Drawing.Size(181, 28);
            this.dateEdit1.TabIndex = 27;
            this.dateEdit1.EditValueChanged += new System.EventHandler(this.dateEdit1_EditValueChanged);
            // 
            // edtNgayThi
            // 
            this.edtNgayThi.Enabled = false;
            this.edtNgayThi.Location = new System.Drawing.Point(906, 89);
            this.edtNgayThi.Name = "edtNgayThi";
            this.edtNgayThi.Size = new System.Drawing.Size(229, 26);
            this.edtNgayThi.TabIndex = 26;
            // 
            // lbNgayThi
            // 
            this.lbNgayThi.AutoSize = true;
            this.lbNgayThi.Location = new System.Drawing.Point(830, 97);
            this.lbNgayThi.Name = "lbNgayThi";
            this.lbNgayThi.Size = new System.Drawing.Size(70, 20);
            this.lbNgayThi.TabIndex = 25;
            this.lbNgayThi.Text = "Ngày Thi";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1000, 38);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 20);
            this.label12.TabIndex = 24;
            this.label12.Text = "phút";
            // 
            // edtThoiGian
            // 
            this.edtThoiGian.Enabled = false;
            this.edtThoiGian.Location = new System.Drawing.Point(906, 35);
            this.edtThoiGian.Name = "edtThoiGian";
            this.edtThoiGian.Size = new System.Drawing.Size(88, 26);
            this.edtThoiGian.TabIndex = 23;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(831, 37);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 20);
            this.label11.TabIndex = 22;
            this.label11.Text = "Thời Gian";
            // 
            // edtSoCauThi
            // 
            this.edtSoCauThi.Enabled = false;
            this.edtSoCauThi.Location = new System.Drawing.Point(761, 93);
            this.edtSoCauThi.Name = "edtSoCauThi";
            this.edtSoCauThi.Size = new System.Drawing.Size(42, 26);
            this.edtSoCauThi.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(668, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 20);
            this.label5.TabIndex = 20;
            this.label5.Text = "Số Câu Thi";
            // 
            // edtTenMH
            // 
            this.edtTenMH.Enabled = false;
            this.edtTenMH.Location = new System.Drawing.Point(391, 93);
            this.edtTenMH.Name = "edtTenMH";
            this.edtTenMH.Size = new System.Drawing.Size(228, 26);
            this.edtTenMH.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(314, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "Tên Môn";
            // 
            // edtTrinhDo
            // 
            this.edtTrinhDo.Enabled = false;
            this.edtTrinhDo.Location = new System.Drawing.Point(761, 32);
            this.edtTrinhDo.Name = "edtTrinhDo";
            this.edtTrinhDo.Size = new System.Drawing.Size(42, 26);
            this.edtTrinhDo.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(668, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "Trình Độ";
            // 
            // btnChon
            // 
            this.btnChon.Location = new System.Drawing.Point(203, 34);
            this.btnChon.Name = "btnChon";
            this.btnChon.Size = new System.Drawing.Size(75, 34);
            this.btnChon.TabIndex = 11;
            this.btnChon.Text = "Chọn";
            this.btnChon.UseVisualStyleBackColor = true;
            this.btnChon.Click += new System.EventHandler(this.btnChon_Click);
            // 
            // sEdtLanThi
            // 
            this.sEdtLanThi.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sEdtLanThi.Location = new System.Drawing.Point(391, 39);
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
            this.sEdtLanThi.Size = new System.Drawing.Size(58, 28);
            this.sEdtLanThi.TabIndex = 9;
            this.sEdtLanThi.EditValueChanged += new System.EventHandler(this.sEdtLanThi_EditValueChanged);
            // 
            // edtMaMH
            // 
            this.edtMaMH.Enabled = false;
            this.edtMaMH.Location = new System.Drawing.Point(97, 38);
            this.edtMaMH.Name = "edtMaMH";
            this.edtMaMH.Size = new System.Drawing.Size(100, 26);
            this.edtMaMH.TabIndex = 6;
            this.edtMaMH.TextChanged += new System.EventHandler(this.edtMaMH_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(313, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Lần Thi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã MH";
            // 
            // btnThi
            // 
            this.btnThi.BackColor = System.Drawing.Color.Honeydew;
            this.btnThi.Location = new System.Drawing.Point(926, 146);
            this.btnThi.Name = "btnThi";
            this.btnThi.Size = new System.Drawing.Size(117, 42);
            this.btnThi.TabIndex = 14;
            this.btnThi.Text = "Bắt Đầu Thi";
            this.btnThi.UseVisualStyleBackColor = false;
            this.btnThi.Visible = false;
            this.btnThi.Click += new System.EventHandler(this.btnThi_Click);
            // 
            // groupBoxSV
            // 
            this.groupBoxSV.Controls.Add(this.edtTenLop);
            this.groupBoxSV.Controls.Add(this.edtHoTen);
            this.groupBoxSV.Controls.Add(this.edtMaLop);
            this.groupBoxSV.Controls.Add(this.edtMaSV);
            this.groupBoxSV.Controls.Add(this.label10);
            this.groupBoxSV.Controls.Add(this.label9);
            this.groupBoxSV.Controls.Add(this.label8);
            this.groupBoxSV.Controls.Add(this.label7);
            this.groupBoxSV.Location = new System.Drawing.Point(1149, 4);
            this.groupBoxSV.Name = "groupBoxSV";
            this.groupBoxSV.Size = new System.Drawing.Size(775, 136);
            this.groupBoxSV.TabIndex = 1;
            this.groupBoxSV.TabStop = false;
            this.groupBoxSV.Text = "Thông Tin Sinh Viên";
            // 
            // edtTenLop
            // 
            this.edtTenLop.Enabled = false;
            this.edtTenLop.Location = new System.Drawing.Point(486, 89);
            this.edtTenLop.Name = "edtTenLop";
            this.edtTenLop.Size = new System.Drawing.Size(261, 26);
            this.edtTenLop.TabIndex = 7;
            // 
            // edtHoTen
            // 
            this.edtHoTen.Enabled = false;
            this.edtHoTen.Location = new System.Drawing.Point(480, 34);
            this.edtHoTen.Name = "edtHoTen";
            this.edtHoTen.Size = new System.Drawing.Size(267, 26);
            this.edtHoTen.TabIndex = 6;
            // 
            // edtMaLop
            // 
            this.edtMaLop.Enabled = false;
            this.edtMaLop.Location = new System.Drawing.Point(112, 92);
            this.edtMaLop.Name = "edtMaLop";
            this.edtMaLop.Size = new System.Drawing.Size(247, 26);
            this.edtMaLop.TabIndex = 5;
            // 
            // edtMaSV
            // 
            this.edtMaSV.Enabled = false;
            this.edtMaSV.Location = new System.Drawing.Point(107, 41);
            this.edtMaSV.Name = "edtMaSV";
            this.edtMaSV.Size = new System.Drawing.Size(252, 26);
            this.edtMaSV.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(402, 92);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 20);
            this.label10.TabIndex = 3;
            this.label10.Text = "Tên Lớp";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(402, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 20);
            this.label9.TabIndex = 2;
            this.label9.Text = "Họ Tên";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "Mã Lớp";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Mã SV";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(1106, 19);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(118, 20);
            this.labelTime.TabIndex = 25;
            this.labelTime.Text = "Thời Gian Còn :";
            // 
            // listViewDaChon
            // 
            this.listViewDaChon.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnSoCau,
            this.columnDaChon});
            this.listViewDaChon.FullRowSelect = true;
            this.listViewDaChon.HideSelection = false;
            this.listViewDaChon.Location = new System.Drawing.Point(2, 0);
            this.listViewDaChon.Name = "listViewDaChon";
            this.listViewDaChon.Size = new System.Drawing.Size(244, 617);
            this.listViewDaChon.TabIndex = 28;
            this.listViewDaChon.UseCompatibleStateImageBehavior = false;
            this.listViewDaChon.View = System.Windows.Forms.View.Details;
            this.listViewDaChon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewDaChon_MouseClick);
            // 
            // columnSoCau
            // 
            this.columnSoCau.Text = "Số Câu";
            this.columnSoCau.Width = 100;
            // 
            // columnDaChon
            // 
            this.columnDaChon.Text = "Chọn";
            this.columnDaChon.Width = 100;
            // 
            // flowDeThi
            // 
            this.flowDeThi.AutoScroll = true;
            this.flowDeThi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowDeThi.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowDeThi.Location = new System.Drawing.Point(252, 52);
            this.flowDeThi.MinimumSize = new System.Drawing.Size(1700, 2);
            this.flowDeThi.Name = "flowDeThi";
            this.flowDeThi.Size = new System.Drawing.Size(1700, 548);
            this.flowDeThi.TabIndex = 29;
            // 
            // btnNop
            // 
            this.btnNop.Location = new System.Drawing.Point(915, 12);
            this.btnNop.Name = "btnNop";
            this.btnNop.Size = new System.Drawing.Size(75, 34);
            this.btnNop.TabIndex = 25;
            this.btnNop.Text = "Nộp";
            this.btnNop.UseVisualStyleBackColor = true;
            this.btnNop.Click += new System.EventHandler(this.btnNop_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(1365, 12);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 34);
            this.btnThoat.TabIndex = 30;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            // 
            // panelThi
            // 
            this.panelThi.Controls.Add(this.btnSau);
            this.panelThi.Controls.Add(this.btnTruoc);
            this.panelThi.Controls.Add(this.btnNop);
            this.panelThi.Controls.Add(this.btnThoat);
            this.panelThi.Controls.Add(this.labelTime);
            this.panelThi.Controls.Add(this.listViewDaChon);
            this.panelThi.Controls.Add(this.flowDeThi);
            this.panelThi.Location = new System.Drawing.Point(2, 146);
            this.panelThi.Name = "panelThi";
            this.panelThi.Size = new System.Drawing.Size(1824, 668);
            this.panelThi.TabIndex = 31;
            this.panelThi.Visible = false;
            // 
            // btnSau
            // 
            this.btnSau.Location = new System.Drawing.Point(1065, 622);
            this.btnSau.Name = "btnSau";
            this.btnSau.Size = new System.Drawing.Size(75, 34);
            this.btnSau.TabIndex = 31;
            this.btnSau.Text = ">";
            this.btnSau.UseVisualStyleBackColor = true;
            this.btnSau.Click += new System.EventHandler(this.btnSau_Click);
            // 
            // btnTruoc
            // 
            this.btnTruoc.Location = new System.Drawing.Point(940, 622);
            this.btnTruoc.Name = "btnTruoc";
            this.btnTruoc.Size = new System.Drawing.Size(75, 34);
            this.btnTruoc.TabIndex = 31;
            this.btnTruoc.Text = "<";
            this.btnTruoc.UseVisualStyleBackColor = true;
            this.btnTruoc.Click += new System.EventHandler(this.btnTruoc_Click);
            // 
            // bdsThi
            // 
            this.bdsThi.DataMember = "THI";
            this.bdsThi.DataSource = this.DS;
            // 
            // DS
            // 
            this.DS.DataSetName = "DS";
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // thiTableAdapter
            // 
            this.thiTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.BANGDIEMTableAdapter = null;
            this.tableAdapterManager.BODETableAdapter = null;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.COSOTableAdapter = null;
            this.tableAdapterManager.CT_BAITHITableAdapter = null;
            this.tableAdapterManager.GIAOVIEN_DANGKYTableAdapter = null;
            this.tableAdapterManager.GIAOVIENTableAdapter = null;
            this.tableAdapterManager.KHOATableAdapter = null;
            this.tableAdapterManager.LOPTableAdapter = null;
            this.tableAdapterManager.MONHOCTableAdapter = null;
            this.tableAdapterManager.SINHVIENTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = TN.TNDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // gvThi
            // 
            this.gvThi.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMAGV,
            this.colMAMH,
            this.colTENMH,
            this.colMALOP,
            this.colTRINHDO,
            this.colNGAYTHI,
            this.colSOCAUTHI,
            this.colLAN,
            this.colTHOIGIAN});
            this.gvThi.GridControl = this.gridControlThi;
            this.gvThi.Name = "gvThi";
            this.gvThi.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvThi_FocusedRowChanged);
            // 
            // colMAGV
            // 
            this.colMAGV.FieldName = "MAGV";
            this.colMAGV.MinWidth = 30;
            this.colMAGV.Name = "colMAGV";
            this.colMAGV.Visible = true;
            this.colMAGV.VisibleIndex = 0;
            this.colMAGV.Width = 112;
            // 
            // colMAMH
            // 
            this.colMAMH.FieldName = "MAMH";
            this.colMAMH.MinWidth = 30;
            this.colMAMH.Name = "colMAMH";
            this.colMAMH.Visible = true;
            this.colMAMH.VisibleIndex = 1;
            this.colMAMH.Width = 112;
            // 
            // colTENMH
            // 
            this.colTENMH.FieldName = "TENMH";
            this.colTENMH.MinWidth = 30;
            this.colTENMH.Name = "colTENMH";
            this.colTENMH.Visible = true;
            this.colTENMH.VisibleIndex = 2;
            this.colTENMH.Width = 112;
            // 
            // colMALOP
            // 
            this.colMALOP.FieldName = "MALOP";
            this.colMALOP.MinWidth = 30;
            this.colMALOP.Name = "colMALOP";
            this.colMALOP.Visible = true;
            this.colMALOP.VisibleIndex = 3;
            this.colMALOP.Width = 112;
            // 
            // colTRINHDO
            // 
            this.colTRINHDO.FieldName = "TRINHDO";
            this.colTRINHDO.MinWidth = 30;
            this.colTRINHDO.Name = "colTRINHDO";
            this.colTRINHDO.Visible = true;
            this.colTRINHDO.VisibleIndex = 4;
            this.colTRINHDO.Width = 112;
            // 
            // colNGAYTHI
            // 
            this.colNGAYTHI.DisplayFormat.FormatString = "dd/MM/yyyy hh:MM:ss";
            this.colNGAYTHI.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNGAYTHI.FieldName = "NGAYTHI";
            this.colNGAYTHI.MinWidth = 30;
            this.colNGAYTHI.Name = "colNGAYTHI";
            this.colNGAYTHI.Visible = true;
            this.colNGAYTHI.VisibleIndex = 5;
            this.colNGAYTHI.Width = 112;
            // 
            // colSOCAUTHI
            // 
            this.colSOCAUTHI.FieldName = "SOCAUTHI";
            this.colSOCAUTHI.MinWidth = 30;
            this.colSOCAUTHI.Name = "colSOCAUTHI";
            this.colSOCAUTHI.Visible = true;
            this.colSOCAUTHI.VisibleIndex = 6;
            this.colSOCAUTHI.Width = 112;
            // 
            // colLAN
            // 
            this.colLAN.FieldName = "LAN";
            this.colLAN.MinWidth = 30;
            this.colLAN.Name = "colLAN";
            this.colLAN.Visible = true;
            this.colLAN.VisibleIndex = 7;
            this.colLAN.Width = 112;
            // 
            // colTHOIGIAN
            // 
            this.colTHOIGIAN.FieldName = "THOIGIAN";
            this.colTHOIGIAN.MinWidth = 30;
            this.colTHOIGIAN.Name = "colTHOIGIAN";
            this.colTHOIGIAN.Visible = true;
            this.colTHOIGIAN.VisibleIndex = 8;
            this.colTHOIGIAN.Width = 112;
            // 
            // gridControlThi
            // 
            this.gridControlThi.DataSource = this.bdsThi;
            this.gridControlThi.Location = new System.Drawing.Point(2, 143);
            this.gridControlThi.MainView = this.gvThi;
            this.gridControlThi.Name = "gridControlThi";
            this.gridControlThi.Size = new System.Drawing.Size(1910, 324);
            this.gridControlThi.TabIndex = 31;
            this.gridControlThi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvThi});
            // 
            // frmThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1924, 841);
            this.Controls.Add(this.btnThi);
            this.Controls.Add(this.gridControlThi);
            this.Controls.Add(this.panelThi);
            this.Controls.Add(this.groupBoxSV);
            this.Controls.Add(this.groupBoxBaiThi);
            this.Name = "frmThi";
            this.Text = "Thi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmThi_Load);
            this.groupBoxBaiThi.ResumeLayout(false);
            this.groupBoxBaiThi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sEdtLanThi.Properties)).EndInit();
            this.groupBoxSV.ResumeLayout(false);
            this.groupBoxSV.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDeThi)).EndInit();
            this.panelThi.ResumeLayout(false);
            this.panelThi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsThi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvThi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlThi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxBaiThi;
        private System.Windows.Forms.Button btnChon;
        private DevExpress.XtraEditors.SpinEdit sEdtLanThi;
        private System.Windows.Forms.TextBox edtMaMH;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxSV;
        private System.Windows.Forms.TextBox edtTenLop;
        private System.Windows.Forms.TextBox edtHoTen;
        private System.Windows.Forms.TextBox edtMaLop;
        private System.Windows.Forms.TextBox edtMaSV;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnThi;
        private System.Windows.Forms.TextBox edtTenMH;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox edtTrinhDo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox edtSoCauThi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox edtThoiGian;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.BindingSource bdsDeThi;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.FlowLayoutPanel flowDeThi;
        private System.Windows.Forms.Button btnNop;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Panel panelThi;
        public System.Windows.Forms.ListView listViewDaChon;
        private System.Windows.Forms.ColumnHeader columnSoCau;
        private System.Windows.Forms.ColumnHeader columnDaChon;
        private System.Windows.Forms.Button btnSau;
        private System.Windows.Forms.Button btnTruoc;
        private System.Windows.Forms.TextBox edtNgayThi;
        private System.Windows.Forms.Label lbNgayThi;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private TNDataSet DS;
        private System.Windows.Forms.BindingSource bdsThi;
        private TNDataSetTableAdapters.THI thiTableAdapter;
        private TNDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.GridControl gridControlThi;
        private DevExpress.XtraGrid.Views.Grid.GridView gvThi;
        private DevExpress.XtraGrid.Columns.GridColumn colMAGV;
        private DevExpress.XtraGrid.Columns.GridColumn colMAMH;
        private DevExpress.XtraGrid.Columns.GridColumn colTENMH;
        private DevExpress.XtraGrid.Columns.GridColumn colMALOP;
        private DevExpress.XtraGrid.Columns.GridColumn colTRINHDO;
        private DevExpress.XtraGrid.Columns.GridColumn colNGAYTHI;
        private DevExpress.XtraGrid.Columns.GridColumn colSOCAUTHI;
        private DevExpress.XtraGrid.Columns.GridColumn colLAN;
        private DevExpress.XtraGrid.Columns.GridColumn colTHOIGIAN;
    }
}