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
using TN.SubForm;

namespace TN
{
    public partial class frmNhapDe : DevExpress.XtraEditors.XtraForm
    {
        private bool isAdd = false;
        private Stack<string> undoList = new Stack<string>();
        private int index = -1;
        public frmNhapDe()
        {
            InitializeComponent();
        }

        private void frmNhapDe_Load(object sender, EventArgs e)
        {
           
            DS.EnforceConstraints = false;
            fill();

            //Trường chỉ được xem dữ liệu nên tắt hết các nút
            if (Program.mGroup == "TRUONG")
            {
                setButtonVisibilityOff();
            }
            //Giáo viên và cơ sở có quyền chỉnh sửa
            else
            {
                setButtonVisibilityOn();

                if (Program.mGroup.Equals("GIANGVIEN"))
                {
                    btnChonMaGV.Enabled = false;
                    edtMaGiaoVien.Text = Program.username;
                }

                else if (Program.mGroup.Equals("COSO"))
                    btnChonMaGV.Enabled = true;
            }

            toggleButton();

            cmbDapAn.Properties.Items.Add("A");
            cmbDapAn.Properties.Items.Add("B");
            cmbDapAn.Properties.Items.Add("C");
            cmbDapAn.Properties.Items.Add("D");


            cmbTrinhDo.Properties.Items.Add("A");
            cmbTrinhDo.Properties.Items.Add("B");
            cmbTrinhDo.Properties.Items.Add("C");



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

        private void fill()
        {

            this.CTBaiThiTableAdapter.Connection.ConnectionString = Program.conStr;
            this.CTBaiThiTableAdapter.Fill(this.DS.CT_BAITHI);
            
            if (Program.mGroup == "GIANGVIEN")
            {
                this.boDeTableAdapter.Connection.ConnectionString = Program.conStr;
                this.boDeTableAdapter.FillByMaGV(this.DS.BODE, Program.username);
            }
            else
            {
                this.boDeTableAdapter.Connection.ConnectionString = Program.conStr;
                this.boDeTableAdapter.Fill(this.DS.BODE);
               
            }
        }
        private void toggleInput(bool state)
        {
            cmbTrinhDo.Enabled = state;
            edtNoiDung.Enabled = state;
            edtA.Enabled = state;
            edtB.Enabled = state;
            edtC.Enabled = state;
            edtD.Enabled = state;
            cmbDapAn.Enabled = state;
        }
        private int checkValidData()
        {
            if (edtCauHoi.Text.Trim().Equals(""))
            {
                MessageBox.Show("Mã câu hỏi không được để trống\nVui lòng nhập dữ liệu ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                edtCauHoi.Focus();
                return 0;
            }

            if (edtMaMH.Text.Trim().Equals(""))
            {
                MessageBox.Show("Mã môn học không được để trống\nVui lòng nhập dữ liệu ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                edtMaMH.Focus();
                return 0;
            }

            if (cmbTrinhDo.Text.Trim().Equals(""))
            {
                MessageBox.Show("Trình độ không được để trống\nVui lòng chọn dữ liệu ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTrinhDo.Focus();
                return 0;
            }

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
                edtB.Focus();
                return 0;
            }

            if (edtC.Text.Trim().Equals(""))
            {
                MessageBox.Show("Đáp án C không được để trống\nVui lòng nhập dữ liệu ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                edtC.Focus();
                return 0;
            }
            if (edtD.Text.Trim().Equals(""))
            {
                MessageBox.Show("Đáp án D không được để trống\nVui lòng nhập dữ liệu ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                edtD.Focus();
                return 0;
            }

            if (cmbDapAn.Text.Trim().Equals(""))
            {
                MessageBox.Show("Đáp án không được để trống\nVui lòng chọn dữ liệu ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDapAn.Focus();
                return 0;
            }

            if (!Program.mGroup.Equals("GIANGVIEN") && edtMaGiaoVien.Text.Trim().Equals(""))
            {
                MessageBox.Show("Mã giáo viên không được để trống\nVui lòng chọn dữ liệu ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                edtMaGiaoVien.Focus();
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
                bdsBoDe.EndEdit(); //Kết thúc hiệu chỉnh gửi dữ liệu về DS
                bdsBoDe.ResetCurrentItem(); //Refresh giá trị của nó
                this.boDeTableAdapter.Connection.ConnectionString = Program.conStr;
                this.boDeTableAdapter.Update(this.DS.BODE);
                gcBoDe.Enabled = true;


            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi ghi bộ đề vào DB\n\n" + e.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            return 1;
        }
        private void btnThem_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                //Nếu đang trỏ vào dữ liệu ko cho sửa thì xóa dữ liệu edt
                toggleInput(true);
                edtCauHoi.Enabled = true;
                edtCauHoi.Focus();

                //Phục vụ cho btn thoát, nếu đang nhập thì hủy thêm
                isAdd = true;

                //Tắt hết button, để button ghi hoàn tác và thoát
                toggleButton(false, false, true, true, false, true);

                //Không cho hiệu chỉnh grid control
                gcBoDe.Enabled = false;

                //Tạo 1 dòng mới dữ liệu
                bdsBoDe.AddNew();

                //Lấy vị trí con trỏ hiện tại
                index = bdsBoDe.Position;

                cmbDapAn.SelectedIndex = 0;
                cmbTrinhDo.SelectedIndex = 0;

                if (Program.mGroup.Equals("GIANGVIEN"))
                {
                    edtMaGiaoVien.Text = Program.username;
                }


            }
            catch (Exception ex)
            {
                isAdd = false;
                MessageBox.Show("Lỗi khi thêm dữ liệu\n\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnXoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            index = bdsBoDe.Position;
            if (bdsBoDe.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnXoa.Enabled = false;
                return;
            }

            if (bdsCTBaiThi.Count > 0)
            {
                MessageBox.Show("Bộ đề đã được đưa vào bài thi không thể xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dr = MessageBox.Show("Bạn có muốn xóa câu hỏi " + ((DataRowView)this.bdsBoDe.Current).Row["CAUHOI"].ToString()
               + "?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (dr == DialogResult.OK)
            {
                try
                {
                    index = bdsBoDe.Position;
                    //Lấy dữ liệu trước khi xóa
                    string undo = "INSERT INTO DBO.BODE( CAUHOI,MAMH,TRINHDO,NOIDUNG,A,B,C,D,DAP_AN,MAGV) " +
                    "VALUES( '" + edtCauHoi.Text.Trim() + "', '" + edtMaMH.Text.Trim() + "', '" + cmbTrinhDo.Text.Trim()
                    + "', N'" + edtNoiDung.Text.Trim() + "', N'" + edtA.Text.Trim() + "', N'" + edtB.Text.Trim() + "', N'" + edtC.Text.Trim() + "', N'" + edtD.Text.Trim() + "', '" + cmbDapAn.Text.Trim() + "', '" + edtMaGiaoVien.Text.Trim() + "')";

                    undoList.Push(undo);

                    bdsBoDe.RemoveCurrent();
                    this.boDeTableAdapter.Connection.ConnectionString = Program.conStr;
                    this.boDeTableAdapter.Update(this.DS.BODE);


                    bdsBoDe.Position = index;

                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    undoList.Pop();
                    MessageBox.Show("Lỗi khi xóa dữ liệu\n\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (undoList.Count > 0)
            {
                btnHoanTac.Enabled = true;
            }


        }

        private void btnGhi_ItemClick(object sender, ItemClickEventArgs e)
        {

            if (checkValidData() == 0) return;

            //Nếu đang thêm
            if (isAdd)
            {
                if (checkDuplicateData() == 0) return;

                DialogResult dr = MessageBox.Show("Bạn có chắc muốn ghi dữ liệu vào CSDL ?", "Thông báo",
                           MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {

                    //Lấy dữ liệu để cho vào xử lí hoàn tác
                    string str = "DELETE DBO.BODE WHERE CAUHOI = " + edtCauHoi.Text.Trim();

                    if (wirteDataToDB() == 0) return;

                    undoList.Push(str);

                    edtCauHoi.Enabled = false;

                    toggleButton();
                    isAdd = false;

                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    bdsBoDe.Position = index;


                }
            }
            //Nếu đang sửa
            else
            {
                string cauHoi = ((DataRowView)this.bdsBoDe.Current).Row["CAUHOI"].ToString().Trim();
                string maMH = ((DataRowView)this.bdsBoDe.Current).Row["MAMH"].ToString().Trim();
                string trinhDo = ((DataRowView)this.bdsBoDe.Current).Row["TRINHDO"].ToString().Trim();
                string noiDung = ((DataRowView)this.bdsBoDe.Current).Row["NOIDUNG"].ToString().Trim();
                string a = ((DataRowView)this.bdsBoDe.Current).Row["A"].ToString().Trim();
                string b = ((DataRowView)this.bdsBoDe.Current).Row["B"].ToString().Trim();
                string c = ((DataRowView)this.bdsBoDe.Current).Row["C"].ToString().Trim();
                string d = ((DataRowView)this.bdsBoDe.Current).Row["D"].ToString().Trim();
                string dapAn = ((DataRowView)this.bdsBoDe.Current).Row["DAP_AN"].ToString().Trim();
                string maGV = ((DataRowView)this.bdsBoDe.Current).Row["MAGV"].ToString().Trim();


                //lấy dữ liệu trước khi sửa
                string str = "UPDATE DBO.BODE " +
                                "SET " +
                                "MAMH = '" + maMH +
                                "', TRINHDO = '" + trinhDo +
                                "', NOIDUNG = N'" + noiDung +
                                "', A = N'" + a +
                                "', B = N'" + b +
                                "', C = N'" + c +
                                "', D = N'" + d +
                                "', DAP_AN = '" + dapAn +
                                "', MAGV = '" + maGV +
                                "' WHERE " +
                                "CAUHOI = " + cauHoi;

                DialogResult dr = MessageBox.Show("Bạn có muốn sửa dữ liệu ?", "Thông báo",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {

                    if (wirteDataToDB() == 0) return;

                    undoList.Push(str);

                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bdsBoDe.Position = bdsBoDe.Find("CAUHOI", cauHoi);
                }



            }


            if (undoList.Count > 0)
            {
                btnHoanTac.Enabled = true;
            }

            if (bdsBoDe.Count > 0)
            {
                btnXoa.Enabled = true;
            }



        }



        private void btnLamMoi_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {

                fill();

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

                    fill();

                    gcBoDe.Enabled = true;
                    edtCauHoi.Enabled = false;
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
                    fill();
                    gcBoDe.Enabled = true;
                    toggleButton();
                    isAdd = false;
                    return;
                }




                DialogResult dr = MessageBox.Show("Bạn có muốn hoàn tác " + undoList.Peek() + " ?", "Thông Báo", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    //Hoàn tác dữ liệu
                    bdsBoDe.CancelEdit();
                    string str = undoList.Pop();
                    if (Program.execSqlNonQuery(str) != 0)
                        MessageBox.Show("Hoàn tác thất bại", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Hoàn tác thành công", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    fill();
                    bdsBoDe.Position = index;

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hoàn tác dữ liệu" + ex.Message, "Thông báo", MessageBoxButtons.OK);
            }
        }



        private void btnMaMH_Click(object sender, EventArgs e)
        {

            Program.subFrmMonHoc = new subFrmMonHoc();
            Program.subFrmMonHoc.ShowDialog();
            edtMaMH.Text = Program.subFrmMonHoc.maMH;


        }

        private void bODEBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsBoDe.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }


        private void btnChonMaGV_Click(object sender, EventArgs e)
        {

            Program.subFrmGiangVien = new subFrmGiangVien();
            Program.subFrmGiangVien.ShowDialog();
            edtMaGiaoVien.Text = Program.subFrmGiangVien.maGV;
         
        }

        private void bODEBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsBoDe.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }
    }
}