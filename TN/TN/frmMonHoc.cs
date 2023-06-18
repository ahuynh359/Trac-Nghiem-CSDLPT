using DevExpress.XtraBars;
using System;
using System.Collections;
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
    public partial class frmMonHoc : Form
    {
        private Stack<string> undoList = new Stack<string>();
        private bool isAdd = false;
        public frmMonHoc()
        {
            InitializeComponent();
        }

        private void mONHOCBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsMonHoc.EndEdit();
            this.monHocTableAdapterManager.UpdateAll(this.DS);


        }

        private void frmMonHoc_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tNDataSet.GIAOVIEN_DANGKY' table. You can move, or remove it, as needed.
            this.giaoVien_DangKyTableAdapter.Connection.ConnectionString = Program.conStr;
            this.giaoVien_DangKyTableAdapter.Fill(this.DS.GIAOVIEN_DANGKY);
            // TODO: This line of code loads data into the 'tNDataSet.BODE' table. You can move, or remove it, as needed.
            this.boDeTableAdapter.Connection.ConnectionString = Program.conStr;
            this.boDeTableAdapter.Fill(this.DS.BODE);
            // TODO: This line of code loads data into the 'tNDataSet.BANGDIEM' table. You can move, or remove it, as needed.
            this.bangDiemTableAdapter.Connection.ConnectionString = Program.conStr;
            this.bangDiemTableAdapter.Fill(this.DS.BANGDIEM);
            // TODO: This line of code loads data into the 'tNDataSet.MONHOC' table. You can move, or remove it, as needed.
            this.monHocTableAdapter.Connection.ConnectionString = Program.conStr;
            this.monHocTableAdapter.Fill(this.DS.MONHOC);



            //Chỉ được xem dữ liệu nên tắt hết các nút
            if (Program.mGroup == "TRUONG")
            {
                setButtonVisibilityOff();

            }
            else if (Program.mGroup == "COSO")
            {
                setButtonVisibilityOn();

            }

            toggleButton();

        }


        private void toggleButton(bool btnThemStage = true, bool btnXoaStage = true, bool btnGhiStage = true, bool btnHoanTacStage = true, bool btnLamMoiStage = true, bool btnThoatStage = true)
        {
            btnThem.Enabled = btnThemStage;
            btnXoa.Enabled = btnXoaStage;
            if (bdsMonHoc.Count == 0)
            {
                btnXoa.Enabled = false;
            }
            btnGhi.Enabled = btnGhiStage;
            btnHoanTac.Enabled = btnHoanTacStage;
            if (undoList.Count == 0)
            {
                btnHoanTac.Enabled = false;
            }
            btnLamMoi.Enabled = btnLamMoiStage;
            btnThoat.Enabled = btnThoatStage;
        }



        private int checkDuplicateData()
        {

            string sql = "DECLARE @result int " +
               "EXEC @result = sp_KiemTraMonHocTonTai '" + edtMaMH.Text.Trim() + "', N'" + edtTenMH.Text.Trim() + "' " + "SELECT 'Res' = @result";

            try
            {
                Program.myReader = Program.execSqlDataReader(sql);
                if (Program.myReader == null) return 0; //khong co kq tra ve
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực hiện truy vấn bảng MONHOC!\n\n" + ex.Message, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            Program.myReader.Read();
            int res = int.Parse(Program.myReader.GetValue(0).ToString());
            Program.myReader.Close();

            if (res == 1)
            {
                MessageBox.Show("Mã môn học đã tồn tại\nVui lòng nhập dữ liệu khác ", "Thông báo", MessageBoxButtons.OK);
                edtMaMH.Focus();
                return 0;
            }
            if (res == 2)
            {
                MessageBox.Show("Tên môn học đã tồn tại\nVui lòng nhập dữ liệu khác ", "Thông báo", MessageBoxButtons.OK);
                edtTenMH.Focus();
                return 0;
            }
            return 1;
        }

        private int checkExistData()
        {

            string sql = "DECLARE @result int " +
               "EXEC @result = sp_KiemTraSuaMonHoc '" + edtMaMH.Text.Trim() + "' SELECT 'Res' = @result";

            try
            {
                Program.myReader = Program.execSqlDataReader(sql);
                if (Program.myReader == null) return 0; //khong co kq tra ve
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực hiện truy vấn bảng MONHOC!\n\n" + ex.Message, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            Program.myReader.Read();
            int res = int.Parse(Program.myReader.GetValue(0).ToString());
            Program.myReader.Close();

            if (res == 1)
            {
                MessageBox.Show("Mã môn học đã tồn tại\nVui lòng nhập dữ liệu khác ", "Thông báo", MessageBoxButtons.OK);
                edtMaMH.Focus();
                return 0;
            }
            return 1;
        }
        private int checkValidData()
        {


            if (edtMaMH.Text.Trim().Equals(""))
            {
                MessageBox.Show("Mã môn học không được để trống\nVui lòng nhập dữ liệu ", "Thông báo", MessageBoxButtons.OK);
                edtMaMH.Focus();
                return 0;
            }
            if (!Regex.IsMatch(edtMaMH.Text, @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("Mã môn học chỉ nhận kí tự và chữ số\nVui lòng nhập dữ liệu khác", "Thông báo", MessageBoxButtons.OK);
                edtMaMH.Focus();
                return 0;
            }

            if (edtTenMH.Text.Trim().Equals(""))
            {
                MessageBox.Show("Tên môn học không được để trống\nVui lòng nhập dữ liệu ", "Thông báo", MessageBoxButtons.OK);
                edtTenMH.Focus();
                return 0;
            }


            return 1;
        }
        private void setButtonVisibilityOn()
        {
            btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnGhi.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnHoanTac.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnLamMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnThoat.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }

        private void setButtonVisibilityOff()
        {
            btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnGhi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnHoanTac.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnLamMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnThoat.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        private int wirteDataToDB()
        {
            try
            {
                bdsMonHoc.EndEdit();
                monHocTableAdapter.Update(this.DS.MONHOC);
                gcMonHoc.Enabled = true;
                //Trỏ con trỏ vào dữ liệu mới thêm
                bdsMonHoc.Position = bdsMonHoc.Find("MAMH", edtMaMH.Text.Trim());
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi ghi môn học vào DB\n\n" + e.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            MessageBox.Show("Thêm thành công", "Thông báo",
                      MessageBoxButtons.OKCancel);
            return 1;
        }

        private void btnThem_ItemClick(object sender, ItemClickEventArgs e)
        {

            try
            {
                //Dang them phuc vu cho btn Thoat
                isAdd = true;

                //Tat het chi de hoan tac va ghi va thoat
                toggleButton(false, false, true, true, false, true);

                //Ko cho chinh sua grid view bang
                gcMonHoc.Enabled = false;

                //Nhay xuong cuoi bang them 1 dong moi
                bdsMonHoc.AddNew();


                edtMaMH.Focus();


            }
            catch (Exception ex)
            {
                isAdd = false;
                MessageBox.Show("Lỗi Khi Thêm Môn Học" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnGhi_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (undoList.Count > 0)
            {
                btnHoanTac.Enabled = true;
            }

            int check;

            check = checkValidData();
            if (check == 0) return;

            //Nếu đang thêm
            if (isAdd)
            {
                check = checkDuplicateData();
                if (check == 0) return;

                DialogResult dr = MessageBox.Show("Bạn có chắc muốn ghi dữ liệu vào CSDL ?", "Thông báo",
                           MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.OK)
                {
                    //Ghi môn học vào DB có thể xảy ra lôi trùng dữ liệu
                    check = wirteDataToDB();
                    if (check == 0) return;

                    //Lấy dữ liệu để cho vào xử lí hoàn tác
                    string str = "DELETE DBO.MONHOC WHERE MAMH = '" + edtMaMH.Text.Trim() + "'";
                    undoList.Push(str);

                    //Bật hết button lên
                    toggleButton();
                    isAdd = false;
                }
            }
            //Nếu đang sửa
            else
            {

                //lấy dữ liệu trước khi sửa
                string str = "UPDATE DBO.MONHOC " +
                                "SET " +
                                "TENMH = '" + edtTenMH.Text.Trim() + "' WHERE " +
                                "MAMH = '" + edtMaMH.Text.Trim() + "', ";

                DialogResult dr = MessageBox.Show("Bạn có muốn sửa dữ liệu ?", "Thông báo",
                         MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.OK)
                {
                    undoList.Push(str);
                    check = wirteDataToDB();
                    if (check == 0) return;
                }
                edtMaMH.Enabled = true;

            }





        }

        private void btnXoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (bdsMonHoc.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnXoa.Enabled = false;
                return;

            }

            if (undoList.Count > 0)
            {
                btnHoanTac.Enabled = true;
            }



            if (bdsBoDe.Count > 0)
            {
                MessageBox.Show("Không thể xóa môn học này do đã được làm bộ đề", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (bdsGiaoVienDangKy.Count > 0)
            {
                MessageBox.Show("Không thể xóa môn học này do đã được giáo viên đăng kí", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (bdsBangDiem.Count > 0)
            {
                MessageBox.Show("Không thể xóa môn học này do đã lập bảng điểm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa môn học " + ((DataRowView)this.bdsMonHoc.Current).Row["TENMH"].ToString() + " ?", "Thông báo",
                      MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (dr == DialogResult.OK)
            {
                try
                {
                    string undo = string.Format("INSERT INTO DBO.MONHOC( MAMH,TENMH)" +
                    "VALUES('{0}','{1}')", edtMaMH.Text.Trim(), edtTenMH.Text.Trim());
                    undoList.Push(undo);


                    bdsMonHoc.RemoveCurrent();
                    this.monHocTableAdapterManager.UpdateAll(this.DS);
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }

                catch (Exception ex)
                {
                    undoList.Pop();
                    MessageBox.Show("Lỗi khi xóa dữ liệu\n\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        //Sử lí hoàn tác sau
        private void btnHoanTac_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Nếu ko có phục hồi, thêm, xóa, sữa -> disble button hoàn tác
            if (undoList.Count == 0)
            {
                MessageBox.Show("Không còn thao tác hoàn tác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnHoanTac.Enabled = false;
                return;

            }

            try
            {
                //Nếu đang thêm mới thì xóa dữ liệu thoát ra
                if (isAdd)
                {
                    bdsMonHoc.RemoveCurrent();
                    this.monHocTableAdapter.Connection.ConnectionString = Program.conStr;
                    this.monHocTableAdapter.Fill(this.DS.MONHOC);
                    gcMonHoc.Enabled = true;
                    toggleButton();
                    isAdd = false;
                    return;
                }


                //Hoàn tác dữ liệu
                bdsMonHoc.CancelEdit();
                string str = undoList.Pop();
                MessageBox.Show(str);
                int result = Program.execSqlNonQuery(str);
                if (result == 0) MessageBox.Show("Lôi khi hoan tác");
                this.monHocTableAdapter.Fill(this.DS.MONHOC);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hoàn tác dữ liệu" + ex.Message, "Thông báo", MessageBoxButtons.OK);
            }



        }
        private void btnLamMoi_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {

                this.monHocTableAdapter.Fill(this.DS.MONHOC);
                MessageBox.Show("Làm mới thành công", "Thông báo", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Làm mới" + ex.Message, "Thông báo", MessageBoxButtons.OK);
                return;
            }
        }
        private void btnThoat_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Neu dang them thi hoi xac nhan 
            if (isAdd)
            {
                DialogResult dr = MessageBox.Show("Đang thêm dữ liệu bạn có muốn hủy ?", "Thông báo",
                     MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    bdsMonHoc.RemoveCurrent();
                    this.monHocTableAdapter.Fill(this.DS.MONHOC);
                    gcMonHoc.Enabled = true;
                    toggleButton();
                    isAdd = false;
                }
                return;
            }

            Close();


        }

        private void gvMonHoc_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (bdsBoDe.Count > 0 || bdsBoDe.Count > 0 || bdsBangDiem.Count > 0 || bdsBangDiem.Count > 0)
            {
                edtMaMH.Enabled = false;
                edtTenMH.Enabled = false;
                btnGhi.Enabled = false; //Khong cho sửa
            }
            else
            {
                edtMaMH.Enabled = true;
                edtTenMH.Enabled = true;
                btnGhi.Enabled = true;
            }
        }

        private void gcMonHoc_Click(object sender, EventArgs e)
        {

        }
    }
}