using DevExpress.XtraBars;
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
using TN.TNDataSetTableAdapters;

namespace TN
{
    public partial class frmKhoaLop : DevExpress.XtraEditors.XtraForm
    {
        private Stack<string> undoList = new Stack<string>();
        private bool isAdd = false;
        public frmKhoaLop()
        {
            InitializeComponent();
        }

        private void kHOABindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsKhoa.EndEdit();
            this.khoaTableAdapterManager.UpdateAll(this.DS);

        }

        private void frmKhoaLop_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DS.GIAOVIEN' table. You can move, or remove it, as needed.
            this.gvTableAdapter.Connection.ConnectionString = Program.conStr;
            this.gvTableAdapter.Fill(this.DS.GIAOVIEN);
            // TODO: This line of code loads data into the 'DS.LOP' table. You can move, or remove it, as needed.
            this.lopTableAdapter.Connection.ConnectionString = Program.conStr;
            this.lopTableAdapter.Fill(this.DS.LOP);
            // TODO: This line of code loads data into the 'tNDataSet.KHOA' table. You can move, or remove it, as needed.
            this.khoaTableAdapter.Connection.ConnectionString = Program.conStr;
            this.khoaTableAdapter.Fill(this.DS.KHOA);


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
            if (bdsKhoa.Count == 0)
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
        private int checkDuplicateData()
        {

            string sql = "DECLARE @result int " +
               "EXEC @result = sp_KiemTraKhoaTonTai '" + edtMaKhoa.Text.Trim() + "', N'" + edtTenKhoa.Text.Trim() + "' " + "SELECT 'Res' = @result";

            try
            {
                Program.myReader = Program.execSqlDataReader(sql);
                if (Program.myReader == null) return 0; //khong co kq tra ve
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực hiện truy vấn bảng KHOA!\n\n" + ex.Message, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            Program.myReader.Read();
            int res = int.Parse(Program.myReader.GetValue(0).ToString());
            Program.myReader.Close();

            if (res == 1)
            {
                MessageBox.Show("Mã môn học đã tồn tại\nVui lòng nhập dữ liệu khác ", "Thông báo", MessageBoxButtons.OK);
                edtMaKhoa.Focus();
                return 0;
            }
            if (res == 2)
            {
                MessageBox.Show("Tên môn học đã tồn tại\nVui lòng nhập dữ liệu khác ", "Thông báo", MessageBoxButtons.OK);
                edtTenKhoa.Focus();
                return 0;
            }
            return 1;
        }
        private int checkExistData()
        {

            string sql = "DECLARE @result int " +
               "EXEC @result = sp_KiemTraSuaKhoa '" + edtMaKhoa.Text.Trim() + "' SELECT 'Res' = @result";

            try
            {
                Program.myReader = Program.execSqlDataReader(sql);
                if (Program.myReader == null) return 0; //khong co kq tra ve
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực hiện truy vấn bảng KHOA!\n\n" + ex.Message, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            Program.myReader.Read();
            int res = int.Parse(Program.myReader.GetValue(0).ToString());
            Program.myReader.Close();

            if (res == 1)
            {
                MessageBox.Show("Mã khoa đã tồn tại\nVui lòng nhập dữ liệu khác ", "Thông báo", MessageBoxButtons.OK);
                edtMaKhoa.Focus();
                return 0;
            }
            return 1;
        }
        private int checkValidData()
        {


            if (edtMaKhoa.Text.Trim().Equals(""))
            {
                MessageBox.Show("Mã khoa không được để trống\nVui lòng nhập dữ liệu ", "Thông báo", MessageBoxButtons.OK);
                edtMaKhoa.Focus();
                return 0;
            }
            if (!Regex.IsMatch(edtMaKhoa.Text, @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("Mã khoa chỉ nhận kí tự và chữ số\nVui lòng nhập dữ liệu khác", "Thông báo", MessageBoxButtons.OK);
                edtMaKhoa.Focus();
                return 0;
            }

            if (edtTenKhoa.Text.Trim().Equals(""))
            {
                MessageBox.Show("Tên môn học không được để trống\nVui lòng nhập dữ liệu ", "Thông báo", MessageBoxButtons.OK);
                edtTenKhoa.Focus();
                return 0;
            }


            return 1;
        }
        private int wirteDataToDB()
        {
            try
            {
                bdsKhoa.EndEdit();
                khoaTableAdapter.Update(this.DS.KHOA);
                gcKhoa.Enabled = true;
                //Trỏ con trỏ vào dữ liệu mới thêm
                bdsKhoa.Position = bdsKhoa.Find("MAMH", edtMaKhoa.Text.Trim());
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi ghi khoa vào DB\n\n" + e.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                gcKhoa.Enabled = false;

                //Nhay xuong cuoi bang them 1 dong moi
                bdsKhoa.AddNew();


                edtMaKhoa.Focus();


            }
            catch (Exception ex)
            {
                isAdd = false;
                MessageBox.Show("Lỗi Khi Thêm Khoa" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    string str = "DELETE DBO.KHOA WHERE MAKH = '" + edtMaKhoa.Text.Trim() + "'";
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
                string str = "UPDATE DBO.KHOA " +
                                "SET " +
                                "TENKH = '" + edtTenKhoa.Text.Trim() + "' WHERE " +
                                "MAKH = '" + edtMaKhoa.Text.Trim() + "', ";

                DialogResult dr = MessageBox.Show("Bạn có muốn sửa dữ liệu ?", "Thông báo",
                         MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.OK)
                {
                    undoList.Push(str);
                    check = wirteDataToDB();
                    if (check == 0) return;
                }
                edtMaKhoa.Enabled = true;

            }
        }

        private void btnXoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (bdsKhoa.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnXoa.Enabled = false;
                return;

            }

            if (undoList.Count > 0)
            {
                btnHoanTac.Enabled = true;
            }



            if (bdsGiaoVien.Count > 0)
            {
                MessageBox.Show("Không thể xóa khoa này do đã có giáo viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (bdsLop.Count > 0)
            {
                MessageBox.Show("Không thể xóa khoa này do đã có lớp được mở", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa khoa " + ((DataRowView)this.bdsKhoa.Current).Row["TENKH"].ToString() + " ?", "Thông báo",
                      MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (dr == DialogResult.OK)
            {
                try
                {
                    string undo = string.Format("INSERT INTO DBO.KHOA( MAKH,TENKH)" +
                    "VALUES('{0}','{1}')", edtMaKhoa.Text.Trim(), edtTenKhoa.Text.Trim());
                    undoList.Push(undo);


                    bdsKhoa.RemoveCurrent();
                    this.khoaTableAdapterManager.UpdateAll(this.DS);
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }

                catch (Exception ex)
                {
                    undoList.Pop();
                    MessageBox.Show("Lỗi khi xóa dữ liệu\n\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

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
                    bdsKhoa.RemoveCurrent();
                    this.khoaTableAdapter.Connection.ConnectionString = Program.conStr;
                    this.khoaTableAdapter.Fill(this.DS.KHOA);
                    gcKhoa.Enabled = true;
                    toggleButton();
                    isAdd = false;
                    return;
                }


                //Hoàn tác dữ liệu
                bdsKhoa.CancelEdit();
                string str = undoList.Pop();
                MessageBox.Show(str);
                int result = Program.execSqlNonQuery(str);
                if (result == 0) MessageBox.Show("Lôi khi hoan tác");
                this.khoaTableAdapter.Connection.ConnectionString = Program.conStr;
                this.khoaTableAdapter.Fill(this.DS.KHOA);

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

                this.khoaTableAdapter.Fill(this.DS.KHOA);
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
                    bdsKhoa.RemoveCurrent();
                    this.khoaTableAdapter.Fill(this.DS.KHOA);
                    gcKhoa.Enabled = true;
                    toggleButton();
                    isAdd = false;
                }
                return;
            }

            Close();
        }

        private void gvKhoa_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (bdsGiaoVien.Count > 0 || bdsLop.Count > 0 )
            {
                edtMaKhoa.Enabled = false;
                edtTenKhoa.Enabled = false;
                btnGhi.Enabled = false; //Khong cho sửa
            }
            else
            {
                edtMaKhoa.Enabled = true;
                edtTenKhoa.Enabled = true;
                btnGhi.Enabled = true;
            }
        }

        private void gcKhoa_Click(object sender, EventArgs e)
        {

        }

        private void cmbCoSo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}