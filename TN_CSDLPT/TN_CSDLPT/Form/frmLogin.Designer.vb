<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.btnGiangVien = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.cbCoSo = New DevExpress.XtraEditors.CheckedComboBoxEdit()
        Me.edtDangNhap = New DevExpress.XtraEditors.TextEdit()
        Me.edtMatKhau = New DevExpress.XtraEditors.TextEdit()
        Me.ceRememberMe = New DevExpress.XtraEditors.CheckEdit()
        Me.btnLogin = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSinhVien = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.cbCoSo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.edtDangNhap.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.edtMatKhau.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ceRememberMe.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.btnSinhVien)
        Me.PanelControl1.Controls.Add(Me.btnLogin)
        Me.PanelControl1.Controls.Add(Me.ceRememberMe)
        Me.PanelControl1.Controls.Add(Me.edtMatKhau)
        Me.PanelControl1.Controls.Add(Me.edtDangNhap)
        Me.PanelControl1.Controls.Add(Me.cbCoSo)
        Me.PanelControl1.Controls.Add(Me.LabelControl4)
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.btnGiangVien)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(498, 453)
        Me.PanelControl1.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Cascadia Code", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.Blue
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Appearance.Options.UseForeColor = True
        Me.LabelControl1.Location = New System.Drawing.Point(181, 35)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(126, 32)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Đăng Nhập"
        '
        'btnGiangVien
        '
        Me.btnGiangVien.Location = New System.Drawing.Point(286, 90)
        Me.btnGiangVien.Name = "btnGiangVien"
        Me.btnGiangVien.Size = New System.Drawing.Size(112, 34)
        Me.btnGiangVien.TabIndex = 1
        Me.btnGiangVien.Text = "Giảng Viên"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(49, 171)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(42, 19)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Cơ Sở"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(49, 236)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(111, 19)
        Me.LabelControl3.TabIndex = 4
        Me.LabelControl3.Text = "Tên Đăng Nhập"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(49, 298)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(65, 19)
        Me.LabelControl4.TabIndex = 5
        Me.LabelControl4.Text = "Mật Khẩu"
        '
        'cbCoSo
        '
        Me.cbCoSo.Location = New System.Drawing.Point(181, 168)
        Me.cbCoSo.Name = "cbCoSo"
        Me.cbCoSo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbCoSo.Size = New System.Drawing.Size(217, 26)
        Me.cbCoSo.TabIndex = 6
        '
        'edtDangNhap
        '
        Me.edtDangNhap.Location = New System.Drawing.Point(181, 233)
        Me.edtDangNhap.Name = "edtDangNhap"
        Me.edtDangNhap.Size = New System.Drawing.Size(217, 26)
        Me.edtDangNhap.TabIndex = 7
        '
        'edtMatKhau
        '
        Me.edtMatKhau.Location = New System.Drawing.Point(181, 295)
        Me.edtMatKhau.Name = "edtMatKhau"
        Me.edtMatKhau.Size = New System.Drawing.Size(217, 26)
        Me.edtMatKhau.TabIndex = 8
        '
        'ceRememberMe
        '
        Me.ceRememberMe.Location = New System.Drawing.Point(286, 347)
        Me.ceRememberMe.Name = "ceRememberMe"
        Me.ceRememberMe.Properties.Caption = "Remember me"
        Me.ceRememberMe.Size = New System.Drawing.Size(165, 27)
        Me.ceRememberMe.TabIndex = 9
        '
        'btnLogin
        '
        Me.btnLogin.Location = New System.Drawing.Point(109, 389)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(289, 34)
        Me.btnLogin.TabIndex = 10
        Me.btnLogin.Text = "Đăng Nhập"
        '
        'btnSinhVien
        '
        Me.btnSinhVien.Location = New System.Drawing.Point(109, 90)
        Me.btnSinhVien.Name = "btnSinhVien"
        Me.btnSinhVien.Size = New System.Drawing.Size(112, 34)
        Me.btnSinhVien.TabIndex = 11
        Me.btnSinhVien.Text = "Sinh Viên"
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(498, 453)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "frmLogin"
        Me.Text = "frmLogin"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.cbCoSo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.edtDangNhap.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.edtMatKhau.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ceRememberMe.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnGiangVien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cbCoSo As DevExpress.XtraEditors.CheckedComboBoxEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents edtMatKhau As DevExpress.XtraEditors.TextEdit
    Friend WithEvents edtDangNhap As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnLogin As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ceRememberMe As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents btnSinhVien As DevExpress.XtraEditors.SimpleButton
End Class
