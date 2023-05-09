
namespace TN
{
    partial class frmNhapDe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhapDe));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnThem = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnGhi = new DevExpress.XtraBars.BarButtonItem();
            this.btnHoanTac = new DevExpress.XtraBars.BarButtonItem();
            this.btnLamMoi = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.DS = new TN.TNDataSet();
            this.bdsBoDe = new System.Windows.Forms.BindingSource(this.components);
            this.boDeTableAdapter = new TN.TNDataSetTableAdapters.BODETableAdapter();
            this.boDeTableAdapterManager = new TN.TNDataSetTableAdapters.TableAdapterManager();
            this.gcBoDe = new DevExpress.XtraGrid.GridControl();
            this.gvBoDe = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.edtCauHoi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.edtD = new System.Windows.Forms.TextBox();
            this.edtC = new System.Windows.Forms.TextBox();
            this.edtB = new System.Windows.Forms.TextBox();
            this.edtA = new System.Windows.Forms.TextBox();
            this.edtMaGiaoVien = new System.Windows.Forms.TextBox();
            this.edtNoiDung = new System.Windows.Forms.TextBox();
            this.cmbDapAn = new System.Windows.Forms.ComboBox();
            this.cmbTrinhDo = new System.Windows.Forms.ComboBox();
            this.cmbMaMonHoc = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bdsCTBaiThi = new System.Windows.Forms.BindingSource(this.components);
            this.ctBaiThiTableAdapter = new TN.TNDataSetTableAdapters.CT_BAITHITableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsBoDe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBoDe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBoDe)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCTBaiThi)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnThem,
            this.btnXoa,
            this.btnGhi,
            this.btnHoanTac,
            this.btnLamMoi,
            this.btnThoat});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 6;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnThem),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnXoa),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnGhi),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnHoanTac),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnLamMoi),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnThoat)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnThem
            // 
            this.btnThem.Caption = "Thêm";
            this.btnThem.Id = 0;
            this.btnThem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThem.ImageOptions.SvgImage")));
            this.btnThem.Name = "btnThem";
            this.btnThem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnThem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThem_ItemClick);
            // 
            // btnXoa
            // 
            this.btnXoa.Caption = "Xóa";
            this.btnXoa.Id = 1;
            this.btnXoa.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnXoa.ImageOptions.SvgImage")));
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXoa_ItemClick);
            // 
            // btnGhi
            // 
            this.btnGhi.Caption = "Ghi";
            this.btnGhi.Id = 2;
            this.btnGhi.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnGhi.ImageOptions.SvgImage")));
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnGhi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGhi_ItemClick);
            // 
            // btnHoanTac
            // 
            this.btnHoanTac.Caption = "Hoàn Tác";
            this.btnHoanTac.Id = 3;
            this.btnHoanTac.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnHoanTac.ImageOptions.SvgImage")));
            this.btnHoanTac.Name = "btnHoanTac";
            this.btnHoanTac.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnHoanTac.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnHoanTac_ItemClick);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Caption = "Làm Mới";
            this.btnLamMoi.Id = 4;
            this.btnLamMoi.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLamMoi.ImageOptions.SvgImage")));
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnLamMoi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLamMoi_ItemClick);
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Id = 5;
            this.btnThoat.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThoat.ImageOptions.SvgImage")));
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnThoat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThoat_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlTop.Size = new System.Drawing.Size(1498, 34);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 933);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlBottom.Size = new System.Drawing.Size(1498, 20);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 34);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 899);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1498, 34);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 899);
            // 
            // DS
            // 
            this.DS.DataSetName = "DS";
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdsBoDe
            // 
            this.bdsBoDe.DataMember = "BODE";
            this.bdsBoDe.DataSource = this.DS;
            // 
            // boDeTableAdapter
            // 
            this.boDeTableAdapter.ClearBeforeFill = true;
            // 
            // boDeTableAdapterManager
            // 
            this.boDeTableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.boDeTableAdapterManager.BANGDIEMTableAdapter = null;
            this.boDeTableAdapterManager.BODETableAdapter = this.boDeTableAdapter;
            this.boDeTableAdapterManager.COSOTableAdapter = null;
            this.boDeTableAdapterManager.CT_BAITHITableAdapter = null;
            this.boDeTableAdapterManager.GIAOVIEN_DANGKYTableAdapter = null;
            this.boDeTableAdapterManager.GIAOVIENTableAdapter = null;
            this.boDeTableAdapterManager.KHOATableAdapter = null;
            this.boDeTableAdapterManager.LOPTableAdapter = null;
            this.boDeTableAdapterManager.MONHOCTableAdapter = null;
            this.boDeTableAdapterManager.SINHVIENTableAdapter = null;
            this.boDeTableAdapterManager.UpdateOrder = TN.TNDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // gcBoDe
            // 
            this.gcBoDe.DataSource = this.bdsBoDe;
            this.gcBoDe.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcBoDe.Location = new System.Drawing.Point(0, 34);
            this.gcBoDe.MainView = this.gvBoDe;
            this.gcBoDe.MenuManager = this.barManager1;
            this.gcBoDe.Name = "gcBoDe";
            this.gcBoDe.Size = new System.Drawing.Size(1498, 450);
            this.gcBoDe.TabIndex = 5;
            this.gcBoDe.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvBoDe});
            // 
            // gvBoDe
            // 
            this.gvBoDe.GridControl = this.gcBoDe;
            this.gvBoDe.Name = "gvBoDe";
            this.gvBoDe.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvBoDe_FocusedRowChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.edtCauHoi);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.edtD);
            this.panel1.Controls.Add(this.edtC);
            this.panel1.Controls.Add(this.edtB);
            this.panel1.Controls.Add(this.edtA);
            this.panel1.Controls.Add(this.edtMaGiaoVien);
            this.panel1.Controls.Add(this.edtNoiDung);
            this.panel1.Controls.Add(this.cmbDapAn);
            this.panel1.Controls.Add(this.cmbTrinhDo);
            this.panel1.Controls.Add(this.cmbMaMonHoc);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 490);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1498, 463);
            this.panel1.TabIndex = 6;
            // 
            // edtCauHoi
            // 
            this.edtCauHoi.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsBoDe, "CAUHOI", true));
            this.edtCauHoi.Location = new System.Drawing.Point(181, 51);
            this.edtCauHoi.Name = "edtCauHoi";
            this.edtCauHoi.Size = new System.Drawing.Size(273, 27);
            this.edtCauHoi.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 19);
            this.label1.TabIndex = 20;
            this.label1.Text = "Câu Hỏi";
            // 
            // edtD
            // 
            this.edtD.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsBoDe, "D", true));
            this.edtD.Location = new System.Drawing.Point(640, 218);
            this.edtD.Name = "edtD";
            this.edtD.Size = new System.Drawing.Size(273, 27);
            this.edtD.TabIndex = 19;
            // 
            // edtC
            // 
            this.edtC.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsBoDe, "C", true));
            this.edtC.Location = new System.Drawing.Point(640, 159);
            this.edtC.Name = "edtC";
            this.edtC.Size = new System.Drawing.Size(273, 27);
            this.edtC.TabIndex = 18;
            // 
            // edtB
            // 
            this.edtB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsBoDe, "B", true));
            this.edtB.Location = new System.Drawing.Point(640, 100);
            this.edtB.Name = "edtB";
            this.edtB.Size = new System.Drawing.Size(273, 27);
            this.edtB.TabIndex = 17;
            // 
            // edtA
            // 
            this.edtA.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsBoDe, "A", true));
            this.edtA.Location = new System.Drawing.Point(640, 43);
            this.edtA.Name = "edtA";
            this.edtA.Size = new System.Drawing.Size(273, 27);
            this.edtA.TabIndex = 16;
            // 
            // edtMaGiaoVien
            // 
            this.edtMaGiaoVien.Location = new System.Drawing.Point(1164, 152);
            this.edtMaGiaoVien.Name = "edtMaGiaoVien";
            this.edtMaGiaoVien.Size = new System.Drawing.Size(273, 27);
            this.edtMaGiaoVien.TabIndex = 15;
            // 
            // edtNoiDung
            // 
            this.edtNoiDung.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsBoDe, "NOIDUNG", true));
            this.edtNoiDung.Location = new System.Drawing.Point(181, 215);
            this.edtNoiDung.Name = "edtNoiDung";
            this.edtNoiDung.Size = new System.Drawing.Size(273, 27);
            this.edtNoiDung.TabIndex = 14;
            // 
            // cmbDapAn
            // 
            this.cmbDapAn.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsBoDe, "DAP_AN", true));
            this.cmbDapAn.FormattingEnabled = true;
            this.cmbDapAn.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D"});
            this.cmbDapAn.Location = new System.Drawing.Point(1164, 95);
            this.cmbDapAn.Name = "cmbDapAn";
            this.cmbDapAn.Size = new System.Drawing.Size(273, 27);
            this.cmbDapAn.TabIndex = 13;
            // 
            // cmbTrinhDo
            // 
            this.cmbTrinhDo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsBoDe, "TRINHDO", true));
            this.cmbTrinhDo.FormattingEnabled = true;
            this.cmbTrinhDo.Items.AddRange(new object[] {
            "A",
            "B",
            "C"});
            this.cmbTrinhDo.Location = new System.Drawing.Point(181, 162);
            this.cmbTrinhDo.MaxDropDownItems = 3;
            this.cmbTrinhDo.Name = "cmbTrinhDo";
            this.cmbTrinhDo.Size = new System.Drawing.Size(273, 27);
            this.cmbTrinhDo.TabIndex = 12;
            // 
            // cmbMaMonHoc
            // 
            this.cmbMaMonHoc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsBoDe, "MAMH", true));
            this.cmbMaMonHoc.FormattingEnabled = true;
            this.cmbMaMonHoc.Location = new System.Drawing.Point(181, 105);
            this.cmbMaMonHoc.Name = "cmbMaMonHoc";
            this.cmbMaMonHoc.Size = new System.Drawing.Size(273, 27);
            this.cmbMaMonHoc.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1047, 157);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 19);
            this.label10.TabIndex = 9;
            this.label10.Text = "Mã Giáo Viên";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1047, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 19);
            this.label9.TabIndex = 8;
            this.label9.Text = "Đáp Án";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(602, 221);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 19);
            this.label8.TabIndex = 7;
            this.label8.Text = "D";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(602, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 19);
            this.label7.TabIndex = 6;
            this.label7.Text = "C";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(601, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 19);
            this.label6.TabIndex = 5;
            this.label6.Text = "B";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(601, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "A";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(65, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nội Dung";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Trình Độ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã Môn Học";
            // 
            // bdsCTBaiThi
            // 
            this.bdsCTBaiThi.DataMember = "FK_CT_BAITHI_CT_BAITHI";
            this.bdsCTBaiThi.DataSource = this.bdsBoDe;
            // 
            // ctBaiThiTableAdapter
            // 
            this.ctBaiThiTableAdapter.ClearBeforeFill = true;
            // 
            // frmNhapDe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1498, 953);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gcBoDe);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmNhapDe";
            this.Text = "Nhập Đề";
            this.Load += new System.EventHandler(this.frmNhapDe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsBoDe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBoDe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBoDe)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCTBaiThi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnThem;
        private DevExpress.XtraBars.BarButtonItem btnXoa;
        private DevExpress.XtraBars.BarButtonItem btnGhi;
        private DevExpress.XtraBars.BarButtonItem btnHoanTac;
        private DevExpress.XtraBars.BarButtonItem btnLamMoi;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private System.Windows.Forms.BindingSource bdsBoDe;
        private TNDataSet DS;
        private TNDataSetTableAdapters.BODETableAdapter boDeTableAdapter;
        private TNDataSetTableAdapters.TableAdapterManager boDeTableAdapterManager;
        private DevExpress.XtraGrid.GridControl gcBoDe;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBoDe;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox edtD;
        private System.Windows.Forms.TextBox edtC;
        private System.Windows.Forms.TextBox edtB;
        private System.Windows.Forms.TextBox edtA;
        private System.Windows.Forms.TextBox edtMaGiaoVien;
        private System.Windows.Forms.TextBox edtNoiDung;
        private System.Windows.Forms.ComboBox cmbDapAn;
        private System.Windows.Forms.ComboBox cmbTrinhDo;
        private System.Windows.Forms.ComboBox cmbMaMonHoc;
        private System.Windows.Forms.BindingSource bdsCTBaiThi;
        private TNDataSetTableAdapters.CT_BAITHITableAdapter ctBaiThiTableAdapter;
        private System.Windows.Forms.TextBox edtCauHoi;
        private System.Windows.Forms.Label label1;
    }
}