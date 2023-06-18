using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TN
{
    public partial class FrmGiaoVien : Form
    {
        private Boolean isThem = false;
        private Boolean isSua = false;
        private String beforeUpdateString;

        public FrmGiaoVien()
        {
            InitializeComponent();
        }

        private void FrmGiaoVien_Load(object sender, EventArgs e)
        {





            //DS.EnforceConstraints = false; //Tat kiem tra ranh buoc (khoa ngoai)

            this.tbLopADT.Connection.ConnectionString = Program.conStr;
            this.tbLopADT.Fill(this.DS.LOP);

            this.tbBoDeADT.Connection.ConnectionString = Program.conStr;
            this.tbBoDeADT.Fill(this.DS.BODE);
            this.tbGVDKyADT.Connection.ConnectionString = Program.conStr;
            this.tbGVDKyADT.Fill(this.DS.GIAOVIEN_DANGKY);
            this.tbGiaoVienADT.Connection.ConnectionString = Program.conStr;
            this.tbGiaoVienADT.Fill(this.DS.GIAOVIEN);
            this.tbDSKhoaADT.Connection.ConnectionString = Program.conStr;
            this.tbDSKhoaADT.Fill(this.DS.KHOA);
            //Loi nha
            if (Program.mGroup == "COSO")
            {
                btnThem.Visibility = btnHuy.Visibility = btnGhi.Visibility = btnXoa.Visibility = btnSua.Visibility
                       = btnUndo.Visibility = btnRedo.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            //Truong thì login đó có thể đăng nhập vào bất kỳ phân mảnh  nào để xem dữ liệu 
            else if (Program.mGroup == "TRUONG")
            {
                btnThem.Visibility = btnHuy.Visibility = btnGhi.Visibility = btnXoa.Visibility = btnSua.Visibility
                    = btnUndo.Visibility = btnRedo.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }

            //checkStateUndoRedo();

            btnHuy.Enabled = btnGhi.Enabled = false;

        }

       
        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool isValid = ValidateEmpty(); //Kiem tra ma, ho, ten, dia chi giao vien empty
            if (!isValid) return;
            btnHuy.Enabled = btnGhi.Enabled = false;

            if(isThem)
            {
                //Kiem tra ma va ten mon hoc ton tai
                String sql = "EXEC sp_KTGiaoVienTonTai N'" + txtMaGV.Text.Trim() + "'";
                try
                {
                    int kq = Program.execSqlNonQuery(sql);
                    if (kq == 1)
                    {
                        btnHuy.Enabled = btnGhi.Enabled = true;

                        txtMaGV.Focus();
                        return;
                    }
                    else
                    {
                        string maGV = txtMaGV.Text.Trim();


                        WriteToDB();

                        bdsGiaoVien.Position = bdsGiaoVien.Find("MAGV", maGV);

                        isThem = false;

                        XtraMessageBox.Show("Thêm giáo viên thành công!", "", MessageBoxButtons.OK);

                        return;

                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Lỗi thêm giáo viên " + ex.Message, "", MessageBoxButtons.OK);
                }
                finally
                {
                    Program.con.Close();
                }
                

            }
            else if(isSua)
            {
                string maGV = txtMaGV.Text.Trim();

                
                WriteToDB();
                isSua = false;
                bdsGiaoVien.Position = bdsGiaoVien.Find("MAGV", maGV);
                XtraMessageBox.Show("Sửa giáo viên thành công!", "", MessageBoxButtons.OK);
                return;

            }


        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            try
            {

                gcGiaoVien.Enabled = gcKhoa.Enabled = false;
                bdsGiaoVien.AddNew();
                btnGhi.Enabled = btnHuy.Enabled = true;
                isThem = true;
                txtMaGV.Enabled = txtHoGV.Enabled = txtTenGV.Enabled = txtDiaChi.Enabled = true;
                txtMaKhoa.Enabled = false;
                txtMaGV.Focus();
                btnThem.Enabled = btnSua.Enabled = btnTaiLai.Enabled
                    = btnUndo.Enabled = btnRedo.Enabled = btnXoa.Enabled = false;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi thêm môn học " + ex.Message, "", MessageBoxButtons.OK);
            }
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsGiaoVien.Count == 0)
            {
                XtraMessageBox.Show("Không có giáo viên để sửa!", "", MessageBoxButtons.OK);
            }
            else
            {
                btnGhi.Enabled = btnHuy.Enabled = true;
                gcGiaoVien.Enabled = gcKhoa.Enabled = true;
                txtMaGV.Enabled = false;
                txtHoGV.Enabled = txtTenGV.Enabled = txtDiaChi.Enabled = true;
                txtMaKhoa.Enabled = cbbTenKhoa.Enabled = false;
                isSua = true;
                btnThem.Enabled = btnTaiLai.Enabled = btnSua.Enabled
                    = btnUndo.Enabled = btnRedo.Enabled = btnXoa.Enabled = false;
                beforeUpdateString = "N'" + txtMaGV.Text.Trim() + "', N'" + txtHoGV.Text.Trim() + "', N'"
                    + txtTenGV.Text.Trim() + "', N'" + txtDiaChi.Text.Trim() + "', N'" + txtMaKhoa.Text.Trim() + "'";
            }

        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(bdsGiaoVien.Count == 0 )
            {
                XtraMessageBox.Show("Không có giáo viên để xóa!", "", MessageBoxButtons.OK);
            }
            else
            {
                if(bdsBoDe.Count > 0)
                {
                    XtraMessageBox.Show("Giáo viên này đã ra đề thi, không thể xóa", "", MessageBoxButtons.OK);
                    return;
                }

                if(bdsGVDK.Count > 0) {
                    XtraMessageBox.Show("Giáo viên này đã tồn tại trong bảng giảng viên đăng ký, không thể xóa", "", MessageBoxButtons.OK);

                }

                if (MessageBox.Show("Bạn có chắc chắn muốn xóa giáo viên: " + ((DataRowView)this.bdsGiaoVien.Current).Row["TEN"].ToString() + "?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string maGV = "";
                    try
                    {
                        maGV = ((DataRowView)bdsGiaoVien[bdsGiaoVien.Position])["MAGV"].ToString();

                        bdsGiaoVien.RemoveCurrent();
                        this.tbGiaoVienADT.Update(this.DS.GIAOVIEN);

                        this.tbGiaoVienADT.Connection.ConnectionString = Program.conStr;
                        this.tbGiaoVienADT.Fill(this.DS.GIAOVIEN);
                        XtraMessageBox.Show("Xóa giáo viên thành công!", "", MessageBoxButtons.OK);
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Lỗi xóa giáo viên " + ex.Message, "", MessageBoxButtons.OK);
                        this.tbGiaoVienADT.Fill(this.DS.GIAOVIEN);
                        bdsGiaoVien.Position = bdsGiaoVien.Find("MAGV", maGV);
                        return;
                    }
                }
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (isThem == true)
            {
                if (XtraMessageBox.Show("Bạn đang tạo mới giáo viên, bạn có muốn ghi thông tin này?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnGhi_ItemClick(sender, e);
                }

            }
            else if (isSua == true)
            {
                if (XtraMessageBox.Show("Bạn đang sửa giáo viên, bạn có muốn ghi thông tin này?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnGhi_ItemClick(sender, e);
                }

            }

            this.Close();
        }

        private void btnTaiLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                this.tbGiaoVienADT.Connection.ConnectionString = Program.conStr;
                this.tbGiaoVienADT.Fill(this.DS.GIAOVIEN);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi tải lại :" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsKhoa.Count > 0)
            {
                cbbTenKhoa.SelectedValue = ((DataRowView)this.bdsKhoa.Current).Row["MAKH"].ToString();

            }
            bdsGiaoVien.CancelEdit();
            btnHuy.Enabled = btnGhi.Enabled = false;
            isSua = isThem = false;
            txtMaGV.Enabled = txtHoGV.Enabled = txtTenGV.Enabled = txtDiaChi.Enabled = txtMaKhoa.Enabled = cbbTenKhoa.Enabled = false;
            btnThem.Enabled = btnTaiLai.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            this.tbGiaoVienADT.Connection.ConnectionString = Program.conStr;
            this.tbGiaoVienADT.Fill(this.DS.GIAOVIEN);
            gcKhoa.Enabled = gcGiaoVien.Enabled = true;

        }

       
       
        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle == view.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.LawnGreen;
            }
        }

        private void gridView2_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle == view.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.LawnGreen;
            }

        }

        public bool ValidateEmpty()
        {
            if (txtMaGV.Text.Trim().Equals(""))
            {
                XtraMessageBox.Show("Mã giáo viên không được để trống, vui lòng nhập lại", "", MessageBoxButtons.OK);
                txtMaGV.Focus();
                return false;
            }

            if (txtHoGV.Text.Trim().Equals(""))
            {
                XtraMessageBox.Show("Họ giảng viên không được để trống, vui lòng nhập lại", "", MessageBoxButtons.OK);
                txtHoGV.Focus();
                return false;
            }

            if (txtTenGV.Text.Trim().Equals(""))
            {
                XtraMessageBox.Show("Tên giáo viên không được để trống, vui lòng nhập lại", "", MessageBoxButtons.OK);
                txtTenGV.Focus();
                return false;
            }

            if (txtDiaChi.Text.Trim().Equals(""))
            {
                XtraMessageBox.Show("Địa chỉ giáo viên không được để trống, vui lòng nhập lại", "", MessageBoxButtons.OK);
                txtDiaChi.Focus();
                return false;
            }

            if (Regex.IsMatch(txtHoGV.Text, Program.FULLNAME_PATTERN) == false)
            {
                XtraMessageBox.Show("Họ của người chỉ có chữ cái và khoảng trắng", "", MessageBoxButtons.OK);
                txtHoGV.Focus();
                return false;
            }

            if (Regex.IsMatch(txtTenGV.Text, Program.FULLNAME_PATTERN) == false)
            {
                XtraMessageBox.Show("Tên của người chỉ có chữ cái và khoảng trắng", "", MessageBoxButtons.OK);
                txtTenGV.Focus();
                return false;
            }

            if (txtMaGV.Text.Trim().Length > 8)
            {
                XtraMessageBox.Show("Mã giáo viên không được lớn hơn 8 kí tự ", "", MessageBoxButtons.OK);
                txtMaGV.Focus();
                return false;
            }

            if (txtHoGV.Text.Trim().Length > 40)
            {
                XtraMessageBox.Show("Họ giáo viên không được lớn hơn 40 kí tự ", "", MessageBoxButtons.OK);
                txtHoGV.Focus();
                return false;
            }
            if (txtTenGV.Text.Trim().Length > 10)
            {
                XtraMessageBox.Show("Tên giáo viên không được lớn hơn 10 kí tự ", "", MessageBoxButtons.OK);
                txtTenGV.Focus();
                return false;
            }

            if (txtDiaChi.Text.Trim().Length > 100)
            {
                XtraMessageBox.Show("Địa chỉ giáo viên không được lớn hơn 100 kí tự ", "", MessageBoxButtons.OK);
                txtDiaChi.Focus();
                return false;
            }

            return true;
        }

        private void WriteToDB()
        {
            gcGiaoVien.Enabled = gcKhoa.Enabled = true;
            txtMaGV.Enabled = txtHoGV.Enabled = txtTenGV.Enabled = txtDiaChi.Enabled =  false;
            btnThem.Enabled = btnTaiLai.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            try
            {
                bdsGiaoVien.EndEdit();
                bdsGiaoVien.ResetCurrentItem();
                this.tbGiaoVienADT.Update(this.DS.GIAOVIEN);
                this.tbGiaoVienADT.Connection.ConnectionString = Program.conStr;
                this.tbGiaoVienADT.Fill(this.DS.GIAOVIEN);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi ghi giáo viên" + ex.Message, "", MessageBoxButtons.OK);
            }
        }

      
    }
}
