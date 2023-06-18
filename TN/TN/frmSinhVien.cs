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
    public partial class FrmSinhVien : Form
    {
        private Boolean isThem = false;
        private Boolean isSua = false;
        private Stack<string> undoList = new Stack<string>();

        private String beforeUpdateString;
        private String beforePassword;
        public FrmSinhVien()
        {
            InitializeComponent();
        }

    
        private void FrmSinhVien_Load(object sender, EventArgs e)
        {
            cbbCoSo.DataSource = Program.bsDanhSachPhanManh.DataSource;
            cbbCoSo.DisplayMember = "TENCS";
            cbbCoSo.ValueMember = "TENSERVER";

            cbbCoSo.SelectedIndex = Program.mCoSo;

            //DS.EnforceConstraints = false; //Tat kiem tra ranh buoc (khoa ngoai)

            this.tbBangDiemADT.Connection.ConnectionString = Program.conStr;
            this.tbBangDiemADT.Fill(this.DS.BANGDIEM);

            this.tbGVDKyADT.Connection.ConnectionString = Program.conStr;
            this.tbGVDKyADT.Fill(this.DS.GIAOVIEN_DANGKY);

            this.tbSinhVienADT.Connection.ConnectionString = Program.conStr;
            this.tbSinhVienADT.Fill(this.DS.SINHVIEN);

            this.tbLopADT.Connection.ConnectionString = Program.conStr;
            this.tbLopADT.Fill(this.DS.LOP);

            if (Program.mGroup == "COSO")
            {
                cbbCoSo.Enabled = false;
                btnThem.Visibility = btnHuy.Visibility = btnGhi.Visibility = btnXoa.Visibility = btnSua.Visibility
                       = btnUndo.Visibility = btnRedo.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            //Truong thì login đó có thể đăng nhập vào bất kỳ phân mảnh  nào để xem dữ liệu 
            else if (Program.mGroup == "TRUONG")
            {
                cbbCoSo.Enabled = true;
                btnThem.Visibility = btnHuy.Visibility = btnGhi.Visibility = btnXoa.Visibility = btnSua.Visibility
                    = btnUndo.Visibility = btnRedo.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            
            btnHuy.Enabled = btnGhi.Enabled = false;


            if (undoList.Count == 0)
            {
                btnUndo.Enabled = false;
            }
        }

        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
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
                //stackUndo.Clear();
                //stackRedo.Clear();

                //DS.EnforceConstraints = false; //Tat kiem tra ranh buoc (khoa ngoai)

                this.tbBangDiemADT.Connection.ConnectionString = Program.conStr;
                this.tbBangDiemADT.Fill(this.DS.BANGDIEM);

                this.tbGVDKyADT.Connection.ConnectionString = Program.conStr;
                this.tbGVDKyADT.Fill(this.DS.GIAOVIEN_DANGKY);

                this.tbSinhVienADT.Connection.ConnectionString = Program.conStr;
                this.tbSinhVienADT.Fill(this.DS.SINHVIEN);

                this.tbLopADT.Connection.ConnectionString = Program.conStr;
                this.tbLopADT.Fill(this.DS.LOP);
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                gcSinhVien.Enabled = gcLop.Enabled = false;
                btnGhi.Enabled = btnHuy.Enabled = true;
                bdsSinhVien.AddNew();
                isThem = true;
                txtMaSV.Enabled = txtHoSV.Enabled = txtTenSV.Enabled = txtDiaChi.Enabled = dateNgaySinh.Enabled = txtPassword.Enabled = true;
                txtMaSV.Focus();
                btnThem.Enabled = btnSua.Enabled = btnTaiLai.Enabled
                    = btnUndo.Enabled = btnRedo.Enabled = btnXoa.Enabled = false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi thêm sinh viên " + ex.Message, "", MessageBoxButtons.OK);
            }
        }

        private void btnTaiLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //DS.EnforceConstraints = false; //Tat kiem tra ranh buoc (khoa ngoai)

                this.tbBangDiemADT.Connection.ConnectionString = Program.conStr;
                this.tbBangDiemADT.Fill(this.DS.BANGDIEM);

                this.tbGVDKyADT.Connection.ConnectionString = Program.conStr;
                this.tbGVDKyADT.Fill(this.DS.GIAOVIEN_DANGKY);

                this.tbSinhVienADT.Connection.ConnectionString = Program.conStr;
                this.tbSinhVienADT.Fill(this.DS.SINHVIEN);

                this.tbLopADT.Connection.ConnectionString = Program.conStr;
                this.tbLopADT.Fill(this.DS.LOP);
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
                if (XtraMessageBox.Show("Bạn đang tạo mới sinh viên, bạn có muốn ghi thông tin này?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnGhi_ItemClick(sender, e);
                }

            }
            else if (isSua == true)
            {
                if (XtraMessageBox.Show("Bạn đang sửa sinh viên, bạn có muốn ghi thông tin này?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnGhi_ItemClick(sender, e);
                }

            }

            this.Close();
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool isValid = ValidateEmpty(); 
            if (!isValid) return;
            btnHuy.Enabled = btnGhi.Enabled = false;

            if (isThem)
            {
                //Kiem tra ma va ten mon hoc ton tai
                String sql = "EXEC sp_KTSinhVienTonTai N'" + txtMaSV.Text.Trim() + "'";
                try
                {
                    int kq = Program.execSqlNonQuery(sql);
                    if (kq == 1)
                    {
                        btnHuy.Enabled = btnGhi.Enabled = true;

                        txtMaSV.Focus();
                        return;
                    }
                    else
                    {
                        string maSV = txtMaSV.Text.Trim();
                        //txtPassword.Text = txtPassword.Text.Trim();

                        //Lấy dữ liệu để cho vào xử lí hoàn tác
                        string str = "DELETE DBO.MONHOC WHERE MAMH = '" + txtMaSV.Text.Trim() + "'";
                        undoList.Push(str);

                        WriteToDB();

                        bdsSinhVien.Position = bdsSinhVien.Find("MASV", maSV);

                        isThem = false;

                        XtraMessageBox.Show("Thêm sinh viên thành công!", "", MessageBoxButtons.OK);
                        return;

                    }
                }
                catch (Exception ex)
                {
                    undoList.Pop();
                    XtraMessageBox.Show("Thêm sinh viên thất bại " + ex.Message, "", MessageBoxButtons.OK);
                }
                finally
                {
                    Program.con.Close();   
                }
                

            }
            else if (isSua)
            {
                string maSV = txtMaSV.Text.Trim();
                //lấy dữ liệu trước khi sửa
                string str = "UPDATE DBO.SINHVIEN " +
                                "SET " +
                                "TENSV = '" + txtTenSV.Text.Trim() + "' WHERE " +
                                "MASV = '" + txtMaSV.Text.Trim() + "', ";
                WriteToDB();
                isSua = false;
                bdsSinhVien.Position = bdsSinhVien.Find("MASV", maSV);

               
                XtraMessageBox.Show("Sửa sinh viên thành công!", "", MessageBoxButtons.OK);
                return;
            }

        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsSinhVien.CancelEdit();
            btnHuy.Enabled = btnGhi.Enabled = false;
            isSua = isThem = false;
            txtMaSV.Enabled = txtHoSV.Enabled = txtTenSV.Enabled = txtDiaChi.Enabled = dateNgaySinh.Enabled = txtPassword.Enabled = false;

            btnThem.Enabled = btnTaiLai.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            this.tbSinhVienADT.Connection.ConnectionString = Program.conStr;
            this.tbSinhVienADT.Fill(this.DS.SINHVIEN);
            gcLop.Enabled = true;
            //checkStateUndoRedo();
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsSinhVien.Count == 0)
            {
                XtraMessageBox.Show("Không có sinh viên để sửa!", "", MessageBoxButtons.OK);
            }
            else
            {
                btnGhi.Enabled = btnHuy.Enabled = true;
                gcSinhVien.Enabled = gcLop.Enabled = true;
                txtMaSV.Enabled = false;
                txtHoSV.Enabled = txtTenSV.Enabled = txtDiaChi.Enabled = dateNgaySinh.Enabled = txtPassword.Enabled = true;
                txtMaLop.Enabled = false;
                isSua = true;
                btnThem.Enabled = btnTaiLai.Enabled = btnSua.Enabled  
                    = btnUndo.Enabled = btnRedo.Enabled = btnXoa.Enabled = false;
                beforePassword = txtPassword.Text.Trim();
                beforeUpdateString = "N'" + txtMaSV.Text.Trim() + "', N'" + txtHoSV.Text.Trim() + "', N'"
                    + txtTenSV.Text.Trim() + "', N'" + txtDiaChi.Text.Trim() + "', '" + dateNgaySinh.Text.Trim()  
                    + "', N'" + txtMaLop.Text.Trim() + "', N'" + txtPassword.Text.Trim() + "'";
            }
        }
        public bool ValidateEmpty()
        {
            if (txtMaSV.Text.Trim().Equals(""))
            {
                XtraMessageBox.Show("Mã sinh viên không được để trống, vui lòng nhập lại", "", MessageBoxButtons.OK);
                txtMaSV.Focus();
                return false;
            }

            if (txtHoSV.Text.Trim().Equals(""))
            {
                XtraMessageBox.Show("Họ sinh viên không được để trống, vui lòng nhập lại", "", MessageBoxButtons.OK);
                txtHoSV.Focus();
                return false;
            }

            if (Regex.IsMatch(txtHoSV.Text, Program.FULLNAME_PATTERN) == false)
            {
                XtraMessageBox.Show("Họ của người chỉ có chữ cái và khoảng trắng", "", MessageBoxButtons.OK);
                txtHoSV.Focus();
                return false;
            }

            if (Regex.IsMatch(txtTenSV.Text, Program.FULLNAME_PATTERN) == false)
            {
                XtraMessageBox.Show("Tên của người chỉ có chữ cái và khoảng trắng", "", MessageBoxButtons.OK);
                txtHoSV.Focus();
                return false;
            }

            if (txtTenSV.Text.Trim().Equals(""))
            {
                XtraMessageBox.Show("Tên sinh viên không được để trống, vui lòng nhập lại", "", MessageBoxButtons.OK);
                txtTenSV.Focus();
                return false;
            }

            if (txtDiaChi.Text.Trim().Equals(""))
            {
                XtraMessageBox.Show("Địa chỉ sinh viên không được để trống, vui lòng nhập lại", "", MessageBoxButtons.OK);
                txtDiaChi.Focus();
                return false;
            }

            if (CalculateAge(dateNgaySinh.DateTime) < 18)
            {
                MessageBox.Show("Sinh viên chưa đủ 18 tuổi", "Thông báo", MessageBoxButtons.OK);
                dateNgaySinh.Focus();
                return false;
            }

            if (txtMaSV.Text.Trim().Length > 8)
            {
                XtraMessageBox.Show("Mã sinh viên không được lớn hơn 8 kí tự ", "", MessageBoxButtons.OK);
                txtMaSV.Focus();
                return false;
            }

            if (txtHoSV.Text.Trim().Length > 50)
            {
                XtraMessageBox.Show("Họ sinh viên không được lớn hơn 50 kí tự ", "", MessageBoxButtons.OK);
                txtHoSV.Focus();
                return false;
            }

            if (txtTenSV.Text.Trim().Length > 10)
            {
                XtraMessageBox.Show("Tên sinh viên không được lớn hơn 10 kí tự ", "", MessageBoxButtons.OK);
                txtTenSV.Focus();
                return false;
            }

            if (txtDiaChi.Text.Trim().Length > 100)
            {
                XtraMessageBox.Show("Địa chỉ sinh viên không được lớn hơn 100 kí tự ", "", MessageBoxButtons.OK);
                txtDiaChi.Focus();
                return false;
            }

            return true;
        }

        private void WriteToDB()
        {
            gcSinhVien.Enabled = gcLop.Enabled = true;
            txtMaSV.Enabled = txtHoSV.Enabled = txtTenSV.Enabled = txtDiaChi.Enabled = dateNgaySinh.Enabled = txtPassword.Enabled = false;
            btnThem.Enabled = btnTaiLai.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            try
            {
                bdsSinhVien.EndEdit();
                bdsSinhVien.ResetCurrentItem();
                this.tbSinhVienADT.Update(this.DS.SINHVIEN);
                this.tbSinhVienADT.Connection.ConnectionString = Program.conStr;
                this.tbSinhVienADT.Fill(this.DS.SINHVIEN);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi ghi sinh viên" + ex.Message, "", MessageBoxButtons.OK);
            }
        }
        private static int CalculateAge(DateTime dateOfBirth)
        {
            int age = 0;
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return age;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (undoList.Count > 0)
            {
                btnUndo.Enabled = true;
            }

            if (bdsSinhVien.Count == 0)
            {
                XtraMessageBox.Show("Không có sinh viên để xóa!", "", MessageBoxButtons.OK);
            }
            else
            {
                if (bdsBangDiem.Count > 0)
                {
                    XtraMessageBox.Show("Sinh viên này đã có bảng điểm, không thể xóa", "", MessageBoxButtons.OK);
                    return;
                }

                if (MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên: " + ((DataRowView)this.bdsSinhVien.Current).Row["TEN"].ToString() + "?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string maSV = "";
                    try
                    {
                        string undo = string.Format("INSERT INTO DBO.SINHVIEN( MASV,TENSV)" +
                    "VALUES('{0}','{1}')", txtMaSV.Text.Trim(), txtTenSV.Text.Trim());
                        undoList.Push(undo);

                        maSV = ((DataRowView)bdsSinhVien[bdsSinhVien.Position])["MASV"].ToString();

                        bdsSinhVien.RemoveCurrent();
                        this.tbSinhVienADT.Update(this.DS.SINHVIEN);

                        this.tbSinhVienADT.Connection.ConnectionString = Program.conStr;
                        this.tbSinhVienADT.Fill(this.DS.SINHVIEN);
                        XtraMessageBox.Show("Xóa sinh viên thành công!", "", MessageBoxButtons.OK);
                    }
                    catch (Exception ex)
                    {
                        undoList.Pop();
                        XtraMessageBox.Show("Lỗi xóa sinh viên " + ex.Message, "", MessageBoxButtons.OK);
                        this.tbSinhVienADT.Fill(this.DS.SINHVIEN);
                        bdsSinhVien.Position = bdsSinhVien.Find("MASV", maSV);
                        return;
                    }
                }
            }
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Nếu ko có phục hồi, thêm, xóa, sữa -> disble button hoàn tác
            if (undoList.Count == 0)
            {
                MessageBox.Show("Không còn thao tác hoàn tác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUndo.Enabled = false;
                return;

            }

            try
            {
                //Nếu đang thêm mới thì xóa dữ liệu thoát ra
                if (isThem)
                {
                    bdsSinhVien.RemoveCurrent();
                    this.tbSinhVienADT.Connection.ConnectionString = Program.conStr;
                    this.tbSinhVienADT.Fill(this.DS.SINHVIEN);
                    gcSinhVien.Enabled = true;

                    isThem = false;
                    return;
                }


                //Hoàn tác dữ liệu
                bdsSinhVien.CancelEdit();
                string str = undoList.Pop();
                MessageBox.Show(str);
                int result = Program.execSqlNonQuery(str);
                if (result == 0) MessageBox.Show("Lôi khi hoan tác");
                this.tbSinhVienADT.Fill(this.DS.SINHVIEN);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hoàn tác dữ liệu" + ex.Message, "Thông báo", MessageBoxButtons.OK);
            }
        }

        
    }
}
