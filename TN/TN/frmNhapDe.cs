using DevExpress.XtraBars;
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
    public partial class frmNhapDe : DevExpress.XtraEditors.XtraForm
    {
        private bool isAdd = false;
        private Stack<string> undoList = new Stack<string>();
        public frmNhapDe()
        {
            InitializeComponent();
        }

        private void bODEBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsBoDe.EndEdit();
            this.boDeTableAdapterManager.UpdateAll(this.DS);

        }

        private void frmNhapDe_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DS.CT_BAITHI' table. You can move, or remove it, as needed.
            this.ctBaiThiTableAdapter.Fill(this.DS.CT_BAITHI);
            // TODO: This line of code loads data into the 'tNDataSet.BODE' table. You can move, or remove it, as needed.
            this.boDeTableAdapter.Fill(this.DS.BODE);

        }
        private void toggleButton(bool btnThemState = true, bool btnXoaState = true, bool btnGhiState = true, bool btnHoanTacState = true, bool btnLamMoiState = true, bool btnThoatState = true)
        {
            btnThem.Enabled = btnThemState;
            btnXoa.Enabled = btnXoaState;
            if (bdsBoDe.Count == 0)
            {
                btnXoa.Enabled = false;
            }
            btnGhi.Enabled = btnGhiState;
            btnHoanTac.Enabled = btnHoanTacState;
            if (undoList.Count == 0)
            {
                btnHoanTac.Enabled = false;
            }
            btnLamMoi.Enabled = btnLamMoiState;
            btnThoat.Enabled = btnThoatState;
        }

        private void toggleInput(bool state)
        {
            cmbMaMonHoc.Enabled = state;
            cmbTrinhDo.Enabled = state;
            edtNoiDung.Enabled = state;
            edtA.Enabled = state;
            edtB.Enabled = state;
            edtC.Enabled = state;
            edtD.Enabled = state;
            cmbDapAn.Enabled = state;
            edtMaGiaoVien.Enabled = state;

        }
        private int checkValidData()
        {

            if (edtNoiDung.Text.Trim().Equals(""))
            {
                MessageBox.Show("Nội dung không được để trống\nVui lòng nhập dữ liệu ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                edtNoiDung.Focus();
                return 0;
            }

            if (edtA.Text.Trim().Equals(""))
            {
                MessageBox.Show("Đáp án A không được để trống\nVui lòng nhập dữ liệu ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                edtA.Focus();
                return 0;
            }

            if (edtB.Text.Trim().Equals(""))
            {
                MessageBox.Show("Đáp án B không được để trống\nVui lòng nhập dữ liệu ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                edtA.Focus();
                return 0;
            }

            if (edtC.Text.Trim().Equals(""))
            {
                MessageBox.Show("Đáp án C không được để trống\nVui lòng nhập dữ liệu ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                edtA.Focus();
                return 0;
            }
            if (edtD.Text.Trim().Equals(""))
            {
                MessageBox.Show("Đáp án B không được để trống\nVui lòng nhập dữ liệu ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                edtA.Focus();
                return 0;
            }

            return 1;
        }

        private int checkDuplicateData()
        {
            string sql = "DECLARE @result int EXEC @result = sp_KiemTraBoDeTonTai '" + edtCauHoi.Text.Trim() + "' SELECT 'Res' = @result";
            try
            {
                Program.myReader = Program.execSqlDataReader(sql);
                if (Program.myReader == null) return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực hiện truy vấn bảng BODE!\n\n" + ex.Message, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            Program.myReader.Read();
            int res = int.Parse(Program.myReader.GetValue(0).ToString());
            Program.myReader.Close();

            if (res == 1)
            {
                MessageBox.Show("Câu hỏi bộ đề đã tồn tại\nVui lòng nhập dữ liệu khác ", "Thông báo", MessageBoxButtons.OK);
                edtCauHoi.Focus();
                return 0;
            }

            return 1;
        }

        private int wirteDataToDB()
        {
            try
            {
                bdsBoDe.EndEdit();
                this.boDeTableAdapter.Update(this.DS.BODE);
                gcBoDe.Enabled = true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi ghi bộ đề vào DB\n\n" + e.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                //Phục vụ cho btn thoát, nếu đang nhập thì hủy thêm
                isAdd = true;

                //Tắt hết button, để button ghi hoàn tác và thoát
                toggleButton(false, false, true, true, false, true);

                //Không cho hiệu chỉnh grid control
                gcBoDe.Enabled = false;

                //Tạo 1 dòng mới dữ liệu
                bdsBoDe.AddNew();

                //Trỏ con trỏ
                edtCauHoi.Focus();

            }
            catch (Exception ex)
            {
                isAdd = false;
                MessageBox.Show("Lỗi khi thêm dữ liệu\n\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnXoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (bdsBoDe.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnXoa.Enabled = false;
                return;
            }


            if (undoList.Count > 0)
            {
                btnHoanTac.Enabled = true;
            }

            if (bdsCTBaiThi.Count > 0)
            {
                MessageBox.Show("Bộ đề đã được đưa vào bài thi không thể xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dr = MessageBox.Show("Bạn có muốn xóa dữ liệu ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (dr == DialogResult.OK)
            {
                try
                {
                    bdsBoDe.RemoveCurrent();
                    this.boDeTableAdapter.Update(this.DS.BODE);
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa dữ liệu\n\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void btnGhi_ItemClick(object sender, ItemClickEventArgs e)
        {

            int check = checkValidData();
            if (check == 0) return;


            if (isAdd)
            {
                check = checkDuplicateData();
                if (check == 0) return;
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn ghi dữ liệu vào CSDL ?", "Thông báo",
                           MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    check = wirteDataToDB();
                    if (check == 0) return;
                    //sau khi them thanh cong enable het button
                    toggleButton();
                    isAdd = false;
                }
            }
            else
            {
                DialogResult dr = MessageBox.Show("Bạn có muốn sửa dữ liệu ?", "Thông báo",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {

                    check = wirteDataToDB();
                    if (check == 0) return;
                }
                //Nếu đã có khóa ngoại thì disable -> enable nó lên
                toggleInput(true);
            }
        }

        private void gvBoDe_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (bdsCTBaiThi.Count > 0)
            {
                toggleInput(false);
                btnHoanTac.Enabled = false;
            }
            else
            {
                toggleInput(true);
                btnHoanTac.Enabled = true;
            }
        }

        private void btnLamMoi_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {

                this.boDeTableAdapter.Fill(this.DS.BODE);
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
            if (isAdd)
            {
                DialogResult dr = MessageBox.Show("Đang thêm dữ liệu bạn có muốn hủy ?", "Thông báo",
                     MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    bdsBoDe.RemoveCurrent();
                    this.boDeTableAdapter.Fill(this.DS.BODE);
                    gcBoDe.Enabled = true;
                    toggleButton();
                    isAdd = false;
                }
                return;
            }

            Close();

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
                    bdsBoDe.RemoveCurrent();
                    this.boDeTableAdapter.Fill(this.DS.BODE);
                    gcBoDe.Enabled = true;
                    toggleButton();
                    isAdd = false;
                    return;
                }


                //Hoàn tác dữ liệu
                bdsBoDe.CancelEdit();
                string str = undoList.Pop();
                MessageBox.Show(str);
                int result = Program.execSqlNonQuery(str);
                if (result == 0) MessageBox.Show("Lôi khi hoàn tác");
                this.boDeTableAdapter.Fill(this.DS.BODE);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hoàn tác dữ liệu" + ex.Message, "Thông báo", MessageBoxButtons.OK);
            }
        }
    }
}