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
        int index = -1;
        public frmMonHoc()
        {
            InitializeComponent();
        }

        //Fill dữ liệu từ CSDL về phần mềm
        private void fill()
        {
            this.giaoVien_DangKyTableAdapter.Connection.ConnectionString = Program.conStr;
            this.giaoVien_DangKyTableAdapter.Fill(this.DS.GIAOVIEN_DANGKY);

            this.boDeTableAdapter.Connection.ConnectionString = Program.conStr;
            this.boDeTableAdapter.Fill(this.DS.BODE);

            this.bangDiemTableAdapter.Connection.ConnectionString = Program.conStr;
            this.bangDiemTableAdapter.Fill(this.DS.BANGDIEM);

            this.monHocTableAdapter.Connection.ConnectionString = Program.conStr;
            this.monHocTableAdapter.Fill(this.DS.MONHOC);

        }

        private void mONHOCBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsMonHoc.EndEdit();
            this.monHocTableAdapterManager.UpdateAll(this.DS);


        }

        private void frmMonHoc_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;
            fill();
            //Trường Chỉ được xem dữ liệu nên tắt hết các nút
            if (Program.mGroup == "TRUONG")
            {
                setButtonVisibilityOff();

            }
            // Chỉ có cơ sở được chỉnh sửa
            else if (Program.mGroup == "COSO")
            {
                setButtonVisibilityOn();

            }

            toggleButton();

        }

        // Khi nào các button chức năng thực hiện
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
                if (Program.myReader == null) return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực hiện truy vấn bảng MONHOC!\n" + ex.Message, "Thông báo",
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

        private int checkValidData()
        {

            if (edtMaMH.Text.Trim().Equals(""))
            {
                MessageBox.Show("Mã môn học không được để trống\nVui lòng nhập dữ liệu ", "Thông báo", MessageBoxButtons.OK);
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

        private void toggleInput(bool state)
        {
            edtMaMH.Enabled = state;
            edtTenMH.Enabled = state;
        }
        private int wirteDataToDB()
        {
            try
            {
                bdsMonHoc.EndEdit(); //Kết thúc hiệu chỉnh gửi dữ liệu về DS
                bdsMonHoc.ResetCurrentItem(); //Refresh giá trị của nó
                this.monHocTableAdapter.Connection.ConnectionString = Program.conStr;
                this.monHocTableAdapter.Update(this.DS.MONHOC);
                gcMonHoc.Enabled = true;

            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi ghi môn học vào DB\n\n" + e.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return 0;
            }

            return 1;
        }

        private void btnThem_ItemClick(object sender, ItemClickEventArgs e)
        {

            try
            {
                //Nếu đang trỏ vào dữ liệu ko cho sửa thì bật lại
                toggleInput(true);
                edtMaMH.Focus();

                //Phục vụ btn thoát
                isAdd = true;

                //Tắt hết chừa hoàn tác, ghi, thoát
                toggleButton(false, false, true, true, false, true);

                //Không sửa grid view
                gcMonHoc.Enabled = false;

                //Thêm dòng mới
                bdsMonHoc.AddNew();

                //Lấy vị trí con trỏ hiện tại
                index = bdsMonHoc.Position;

            }
            catch (Exception ex)
            {
                isAdd = false;
                MessageBox.Show("Lỗi Khi Thêm Môn Học" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnGhi_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (checkValidData() == 0) return;

            //Nếu đang thêm
            if (isAdd)
            {
                if (checkDuplicateData() == 0) return;
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn ghi môn học có mã " + edtMaMH.Text.Trim() + " vào CSDL ?", "Thông báo",
                           MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.OK)
                {
                    //Lấy dữ liệu để cho vào xử lí hoàn tác
                    string str = "DELETE DBO.MONHOC WHERE MAMH = '" + edtMaMH.Text.Trim() + "'";

                    if (wirteDataToDB() == 0) return;

                    undoList.Push(str);

                    //Bật hết button lên
                    toggleButton();

                    //Không cho sửa mã MH
                    edtMaMH.Enabled = false;

                    //Tắt đang thêm
                    isAdd = false;

                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Trỏ con trỏ đến vị trí mới thêm
                    bdsMonHoc.Position = index;

                }
            }
            //Nếu đang sửa
            else
            {
                string tenMH = ((DataRowView)this.bdsMonHoc.Current).Row["TENMH"].ToString().Trim();
                string maMH = ((DataRowView)this.bdsMonHoc.Current).Row["MAMH"].ToString().Trim();

                //lấy dữ liệu trước khi sửa
                string str = "UPDATE DBO.MONHOC " +
                                "SET " +
                                "TENMH = N'" + tenMH + "' WHERE " +
                                "MAMH = '" + maMH + "'";

                DialogResult dr = MessageBox.Show("Bạn có muốn sửa dữ liệu ?", "Thông báo",
                         MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.OK)
                {

                    if (wirteDataToDB() == 0) return;
                    undoList.Push(str);
                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Đưa con trỏ đến vị trí mới sửa
                    bdsMonHoc.Position = bdsMonHoc.Find("MAMH", maMH);
                }
            }

            if (undoList.Count > 0)
            {
                btnHoanTac.Enabled = true;
            }

            if (bdsMonHoc.Count > 0)
            {
                btnXoa.Enabled = true;
            }

        }

        private void btnXoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            index = bdsMonHoc.Position;

            if (bdsMonHoc.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnXoa.Enabled = false;
                return;
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

            DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa môn học " + ((DataRowView)this.bdsMonHoc.Current).Row["TENMH"].ToString().Trim() + " ?", "Thông báo",
                      MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (dr == DialogResult.OK)
            {
                try
                {
                    string undo = "INSERT INTO DBO.MONHOC( MAMH,TENMH) " +
                    "VALUES( '" + edtMaMH.Text.Trim() + "', N'" +
                        edtTenMH.Text.Trim() + "')";

                    undoList.Push(undo);

                    //Xóa dòng hiện tại
                    bdsMonHoc.RemoveCurrent();
                    this.monHocTableAdapter.Connection.ConnectionString = Program.conStr;
                    this.monHocTableAdapter.Update(this.DS.MONHOC);

                    bdsMonHoc.Position = index;
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                catch (Exception ex)
                {
                    undoList.Pop();
                    MessageBox.Show("Lỗi khi xóa dữ liệu\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (undoList.Count > 0)
            {
                btnHoanTac.Enabled = true;
            }


        }

        private void btnHoanTac_ItemClick(object sender, ItemClickEventArgs e)
        {

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
                    fill();
                    gcMonHoc.Enabled = true;
                    toggleButton();
                    isAdd = false;
                    return;
                }

                DialogResult dr = MessageBox.Show("Bạn có muốn hoàn tác\n" + undoList.Peek() + " ?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    //Bỏ qua dữ liệu row đang hiệu chỉnh cho con trỏ xuống cuối cùng
                    bdsMonHoc.CancelEdit();
                    string str = undoList.Pop().ToString();

                    if (Program.execSqlNonQuery(str) != 0)
                        MessageBox.Show("Hoàn tác thất bại", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Hoàn tác thành công", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    fill();

                    bdsMonHoc.Position = index;
                }
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
                fill();
                MessageBox.Show("Làm mới thành công", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Làm mới" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnThoat_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Nếu đang thêm thì xác nhận hỏi 
            if (isAdd)
            {
                DialogResult dr = MessageBox.Show("Đang thêm dữ liệu bạn có muốn hủy ?", "Thông báo",
                     MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    bdsMonHoc.RemoveCurrent();

                    fill();
                    gcMonHoc.Enabled = true;

                    toggleButton();
                    isAdd = false;
                }
                return;
            }

            Close();
        }


    }
}