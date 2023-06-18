using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TN
{
    public partial class FrmGVDK : Form
    {
        private Boolean isThem = false;
        private Boolean isSua = false;
        private String beforeUpdateString;
        public FrmGVDK()
        {
            InitializeComponent();
        }

   
        private void FrmGVDK_Load(object sender, EventArgs e)
        {

            cbbCoSo.DataSource = Program.bsDanhSachPhanManh.DataSource;
            cbbCoSo.DisplayMember = "TENCS";
            cbbCoSo.ValueMember = "TENSERVER";
            cbbCoSo.SelectedIndex = Program.mCoSo;
            cbbCoSo.Enabled = true;

            //DS.EnforceConstraints = false; //Tat kiem tra ranh buoc (khoa ngoai)

            this.tbDSGVienADT.Connection.ConnectionString = Program.conStr;
            this.tbDSGVienADT.Fill(this.DS.GIAOVIEN);
            this.tbLopADT.Connection.ConnectionString = Program.conStr;
            this.tbLopADT.Fill(this.DS.LOP);
            this.tbMonHocADT.Connection.ConnectionString = Program.conStr;
            this.tbMonHocADT.Fill(this.DS.MONHOC);
            this.tbGVDKyADT.Connection.ConnectionString = Program.conStr;
            this.tbGVDKyADT.Fill(this.DS.GIAOVIEN_DANGKY);

            cbbTrinhDo.Items.Add("A");
            cbbTrinhDo.Items.Add("B");
            cbbTrinhDo.Items.Add("C");

            cbbLanThi.Items.Add(1);
            cbbLanThi.Items.Add(2);
            if(bdsGVDK.Count > 0)
            {
                cbbLanThi.Text = ((DataRowView)this.bdsGVDK.Current).Row["LAN"].ToString();
                cbbTrinhDo.Text = ((DataRowView)this.bdsGVDK.Current).Row["TRINHDO"].ToString();
            }
            if (Program.mGroup == "COSO")
            {
                cbbCoSo.Enabled = false;

                btnThem.Visibility = btnGhi.Visibility = btnSua.Visibility = btnXoa.Visibility = btnHuy.Visibility 
                    = btnUndo.Visibility = btnRedo.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            //Truong thì login đó có thể đăng nhập vào bất kỳ phân mảnh  nào để xem dữ liệu 
            else if (Program.mGroup == "TRUONG")
            {
                cbbCoSo.Enabled = true;
                btnThem.Visibility = btnGhi.Visibility = btnSua.Visibility = btnXoa.Visibility = btnHuy.Visibility
                    = btnUndo.Visibility = btnRedo.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }

            btnHuy.Enabled = btnGhi.Enabled = false;
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle == view.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.LawnGreen;

            }





        }
      
        private void cbbCoSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Kiem tra cbbCoSo co du lieu chua
            if (cbbCoSo.SelectedValue.ToString() == "System.Data.DataRowView")
                return;
            Program.serverName = cbbCoSo.SelectedValue.ToString();
            if (cbbCoSo.SelectedIndex != Program.mCoSo)
            {
                Program.mLogin = Program.remoteLogin;
                Program.password = Program.remoteLoginPassword;
                Program.mCoSo = cbbCoSo.SelectedIndex;

            }
            else
            {
                Program.mLogin = Program.mLoginDN;
                Program.password = Program.passwordDN;
            }
            if (Program.ketNoi() == 0)
            {
                MessageBox.Show("Lỗi kết nối về cơ sở mới", "", MessageBoxButtons.OK);
            }
            else
            {

                this.tbLopADT.Connection.ConnectionString = Program.conStr;
                this.tbLopADT.Fill(this.DS.LOP);
                this.tbMonHocADT.Connection.ConnectionString = Program.conStr;
                this.tbMonHocADT.Fill(this.DS.MONHOC);
                this.tbGVDKyADT.Connection.ConnectionString = Program.conStr;
                this.tbGVDKyADT.Fill(this.DS.GIAOVIEN_DANGKY);
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                gcGVDK.Enabled = false;
                btnGhi.Enabled = btnHuy.Enabled = true;
                cbbTenGV.Enabled = cbbTenLop.Enabled = cbbTenMon.Enabled = cbbTrinhDo.Enabled 
                    = cbbLanThi.Enabled = dateNgayThi.Enabled = numSoCau.Enabled = numThoiGian.Enabled = true;
                bdsGVDK.AddNew();
                dateNgayThi.Properties.MinValue = DateTime.Today;
                isThem = true;
                cbbTrinhDo.SelectedIndex = cbbLanThi.SelectedIndex = -1;
                btnThem.Enabled = btnSua.Enabled = btnTaiLai.Enabled = btnXoa.Enabled
                    = btnUndo.Enabled = btnRedo.Enabled = false;
                numThoiGian.Value = 15;
                numSoCau.Value = 10;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi thêm  giáo viên đăng ký thi " + ex.Message, "", MessageBoxButtons.OK);
            }
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsLop.Count == 0)
            {
                XtraMessageBox.Show("Không có giáo viên đăng ký để sửa!", "", MessageBoxButtons.OK);
            }
            else
            {
                btnGhi.Enabled = btnHuy.Enabled = true;
                gcGVDK.Enabled = true;
                cbbTenGV.Enabled = cbbTrinhDo.Enabled = numSoCau.Enabled = numThoiGian.Enabled = dateNgayThi.Enabled = true;
                cbbTenMon.Enabled = cbbTenLop.Enabled = cbbLanThi.Enabled = false;
                cbbTenGV.Focus();
                isSua = true;
                btnThem.Enabled = btnTaiLai.Enabled = btnSua.Enabled 
                    = btnUndo.Enabled = btnRedo.Enabled = btnXoa.Enabled = false;
                beforeUpdateString = "N'" + txtMaGV.Text.Trim() + "', N'" + txtMaLop.Text.Trim()
                                                   + "', N'" + txtMaMon.Text.Trim() + "', N'" + cbbTrinhDo.Text.Trim() + "', " + cbbLanThi.Text.Trim()
                                                   + ", '" + dateNgayThi.DateTime + "', " + numSoCau.Value + ", " + numThoiGian.Value;
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsGVDK.Count == 0)
            {
                MessageBox.Show("Không có giảng viên đăng ký để xóa!", "", MessageBoxButtons.OK);

            }
            else
            {
                String sql = "EXEC sp_KTLopDaThi N'" + txtMaLop.Text.Trim()
                   + "', N'" + txtMaMon.Text.Trim()
                   + "',  " + cbbLanThi.Text.Trim();
                try
                {
                    Program.myReader = Program.execSqlDataReader(sql);
                    if (Program.myReader == null) return;
                    Program.myReader.Read();

                    String kq = Program.myReader.GetString(0);

                    Program.myReader.Close();

                    if (kq.Equals("1"))
                    {
                        XtraMessageBox.Show("Thông tin của giảng viên đăng ký này đã tồn tại trong bảng bảng điểm, Không thể xóa", "", MessageBoxButtons.OK);
                        return;
                    }
                    else
                    {
                        if (MessageBox.Show("Bạn có chắc chắn muốn xóa giảng viên đăng ký của môn "
                            + ((DataRowView)this.bdsGVDK.Current).Row["MAMH"].ToString().Trim() + " lớp "
                             + ((DataRowView)this.bdsGVDK.Current).Row["MALOP"].ToString().Trim() + " lần "
                             + ((DataRowView)this.bdsGVDK.Current).Row["LAN"].ToString().Trim()
                            + "?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            try
                            {
                                
                                bdsGVDK.RemoveCurrent();
                                //đẩy dữ liệu về adapter
                                this.tbGVDKyADT.Update(this.DS.GIAOVIEN_DANGKY);
                                this.tbGVDKyADT.Connection.ConnectionString = Program.conStr;
                                this.tbGVDKyADT.Fill(this.DS.GIAOVIEN_DANGKY);
                           
                                XtraMessageBox.Show("Xóa giảng viên đăng ký thi thành công!", "", MessageBoxButtons.OK);

                            }
                            catch (Exception ex)
                            {
                                this.tbGVDKyADT.Connection.ConnectionString = Program.conStr;
                                this.tbGVDKyADT.Fill(this.DS.GIAOVIEN_DANGKY);

                                MessageBox.Show("Lỗi xóa giảng viên đăng ký " + ex.Message, "", MessageBoxButtons.OK);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                
                

            }
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsGVDK.CancelEdit();
            btnHuy.Enabled = btnGhi.Enabled = false;
            isSua = isThem = false;
            cbbTenGV.Enabled = cbbTenLop.Enabled = cbbTenMon.Enabled = cbbTrinhDo.Enabled
                   = cbbLanThi.Enabled = dateNgayThi.Enabled = numSoCau.Enabled = numThoiGian.Enabled = false;
            btnThem.Enabled = btnTaiLai.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            this.tbGVDKyADT.Connection.ConnectionString = Program.conStr;
            this.tbGVDKyADT.Fill(this.DS.GIAOVIEN_DANGKY);
            gcGVDK.Enabled = true;

        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool isValid = ValidateInput(); 
            if (!isValid) return;
            btnHuy.Enabled = btnGhi.Enabled = false;
            if (isThem)
            {
                String sql = "EXEC sp_KTGVDK N'" + txtMaMon.Text.Trim() + "', N'" + txtMaLop.Text.Trim() + "', " + cbbLanThi.Text.Trim() + "";


                try
                {
                    Program.myReader = Program.execSqlDataReader(sql);
                    if (Program.myReader == null) return;
                    Program.myReader.Read();

                    String kq = Program.myReader.GetString(0);

                    Program.myReader.Close();

                    if (kq.Equals("1"))
                    {
                        XtraMessageBox.Show("Đã tồn tại đăng ký thi cho môn học, lớp học và lần thi này!", "", MessageBoxButtons.OK);
                        btnHuy.Enabled = btnGhi.Enabled = true;
                        return;
                    }
                    else
                    {
                       
                        WriteToDB();
                        isThem = false;
                        XtraMessageBox.Show("Thêm giảng viên đăng ký thành công!", "", MessageBoxButtons.OK);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
               
            }
            else if(isSua)
            {
                
                WriteToDB();

                isSua = false;
               
                XtraMessageBox.Show("Sửa giảng viên đăng ký thành công!", "", MessageBoxButtons.OK);
                return;
            }
            
        }


        private void btnTaiLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.tbGVDKyADT.Connection.ConnectionString = Program.conStr;
                this.tbGVDKyADT.Fill(this.DS.GIAOVIEN_DANGKY);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi tải lại :" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (isThem == true)
            {
                if (XtraMessageBox.Show("Bạn đang tạo mới đăng ký thi, bạn có muốn ghi thông tin này?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnGhi_ItemClick(sender, e);
                }

            }
            else if (isSua == true)
            {
                if (XtraMessageBox.Show("Bạn đang sửa đăng ký thi, bạn có muốn ghi thông tin này?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnGhi_ItemClick(sender, e);
                }

            }

            this.Close();
        }

        private void cbbTenGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(cbbTenGV.SelectedValue != null)
                {
                    txtMaGV.Text = cbbTenGV.SelectedValue.ToString();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void cbbTenLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbbTenLop.SelectedValue != null)
                {
                    txtMaLop.Text = cbbTenLop.SelectedValue.ToString();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void cbbTenMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbbTenMon.SelectedValue != null)
                {
                    txtMaMon.Text = cbbTenMon.SelectedValue.ToString();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public bool ValidateInput()
        {
            
            if (txtMaGV.Text.Trim().Equals(""))
            {
                XtraMessageBox.Show("Mã giáo viên không được để trống ", "", MessageBoxButtons.OK);
                cbbTenGV.Focus();
                return false;
            }

            if (txtMaLop.Text.Trim().Equals(""))
            {
                XtraMessageBox.Show("Mã lớp học không được để trống ", "", MessageBoxButtons.OK);
                cbbTenLop.Focus();
                return false;
            }

            if (txtMaMon.Text.Trim().Equals(""))
            {
                XtraMessageBox.Show("Mã môn học không được để trống ", "", MessageBoxButtons.OK);
                cbbTenMon.Focus();
                return false;
            }

            if (dateNgayThi.Text.Trim().Equals(""))
            {
                XtraMessageBox.Show("Ngày thi không được để trống ", "", MessageBoxButtons.OK);
                dateNgayThi.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(cbbLanThi.Text.Trim()))
            {
                XtraMessageBox.Show("Lần thi không được để trống ", "", MessageBoxButtons.OK);
                cbbLanThi.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(cbbTrinhDo.Text.Trim()))
            {
                XtraMessageBox.Show("Trình độ thi không được để trống ", "", MessageBoxButtons.OK);
                cbbTrinhDo.Focus();
                return false;
            }

            if (numSoCau.Value.ToString().Equals(""))
            {
                XtraMessageBox.Show("Số câu thi không được để trống ", "", MessageBoxButtons.OK);
                numSoCau.Focus();
                return false;
            }

            if (numThoiGian.Value.ToString().Equals(""))
            {
                XtraMessageBox.Show("Thời gian thi không được để trống ", "", MessageBoxButtons.OK);
                numThoiGian.Focus();
                return false;
            }

            if(DateTime.Compare(DateTime.Today, dateNgayThi.DateTime) > 0)
            {
                XtraMessageBox.Show("Ngày thi không được bé hơn ngày hiện tại ", "", MessageBoxButtons.OK);
                dateNgayThi.Focus();
                return false;
            }

            if (numSoCau.Value < 10 || numSoCau.Value > 100)
            {
                MessageBox.Show("Số câu thi phải >=10 và <=100 câu, vui lòng nhập lại", "", MessageBoxButtons.OK);
                numSoCau.Focus();
                return false;
            }

            if(numThoiGian.Value < 15 || numThoiGian.Value > 60)
            {
                MessageBox.Show("Thời gian thi phải >=15 và <=60 phút, vui lòng nhập lại", "", MessageBoxButtons.OK);
                numThoiGian.Focus();
                return false;
            }

            //------ktra thông tin đăng ký------start(đã lập hay chưa, nếu là dky lần 2 thì ktra thêm đã thi lần 1 chưa, ngày lần 2 có lớn hơn ngày lần 1 ko) 
            if (int.Parse(cbbLanThi.Text.Trim()) == 2)
            {
                String sqlKtLan = "EXEC sp_KTGVDK N'" + txtMaMon.Text.Trim() + "', N'" + txtMaLop.Text.Trim() + "', " + 1 + "";

                try
                {
                    Program.myReader = Program.execSqlDataReader(sqlKtLan);
                    if (Program.myReader == null) return false;
                    Program.myReader.Read();

                    String kq = Program.myReader.GetString(0);

                    Program.myReader.Close();

                    if (kq.Equals("0"))
                    {
                        XtraMessageBox.Show("Hiện tại chưa đăng ký tổ chức thi lần 1 nên không thể tổ chức đăng ký thi lần 2", "", MessageBoxButtons.OK);
                        cbbLanThi.Focus();
                        return false;
                    }
                 }
                catch(Exception ex)
                {
                    Program.myReader.Close();
                    MessageBox.Show(ex.Message);
                    return false;
                }

                string ngaythi = "SELECT ngaythi from GIAOVIEN_DANGKY Where MALOP='" + txtMaLop.Text.Trim() + "'AND MAMH='" + txtMaMon.Text.Trim() + "'AND LAN=" + 1 + "";
                try
                {
                    Program.myReader = Program.execSqlDataReader(ngaythi);
                    if (Program.myReader == null) return false;
                    Program.myReader.Read();

                    DateTime kq = Program.myReader.GetDateTime(0);

                    Program.myReader.Close();

                    if (DateTime.Compare(kq, dateNgayThi.DateTime) > 0)
                    {
                        XtraMessageBox.Show("Ngày thi đăng ký thi lần 1 không được lớn hơn ngày thi đăng ký thi lần 2 ", "", MessageBoxButtons.OK);
                        dateNgayThi.Focus();
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Program.myReader.Close();
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }

            //------Không đủ câu hỏi để tổ chức thi.
            String sql = "exec sp_LayCauHoi N'"
               + txtMaMon.Text.Trim() + "',N'"
               + cbbTrinhDo.Text.Trim() + "', " + numSoCau.Value.ToString();
            try
            {
                DataTable dt = Program.execSqlDataTable(sql);
                if (dt.Rows.Count == 0)
                {
                    numSoCau.Focus();
                    XtraMessageBox.Show("Không đủ câu hỏi để tổ chức thi, vui lòng nhập lại!", "", MessageBoxButtons.OK);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            return true;
        }
        private void WriteToDB()
        {
            gcGVDK.Enabled = true;
            cbbTenGV.Enabled = cbbTenLop.Enabled = cbbTenMon.Enabled = cbbTrinhDo.Enabled
                    = cbbLanThi.Enabled = dateNgayThi.Enabled = numSoCau.Enabled = numThoiGian.Enabled = false;

            btnThem.Enabled = btnTaiLai.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            try
            {
                bdsGVDK.EndEdit();
                bdsGVDK.ResetCurrentItem();
                this.tbGVDKyADT.Update(this.DS.GIAOVIEN_DANGKY);

                this.tbGVDKyADT.Connection.ConnectionString = Program.conStr;
                this.tbGVDKyADT.Fill(this.DS.GIAOVIEN_DANGKY);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi ghi đăng ký thi" + ex.Message, "", MessageBoxButtons.OK);
            }
        }
    }
}

