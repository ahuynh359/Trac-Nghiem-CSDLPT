
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TN
{
    public partial class frmDangNhap : Form
    {
        private SqlConnection conPublisher = new SqlConnection();
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            if (ketNoiCSDLGoc() == 0) return;
            layDSPhanManh("SELECT * FROM view_DanhSachPhanManh");
            cmbCoSo.SelectedIndex = 1;
            cmbCoSo.SelectedIndex = 0;

        }

        private int ketNoiCSDLGoc()
        {
            if (conPublisher != null && conPublisher.State == ConnectionState.Open) conPublisher.Close();
            try
            {
                conPublisher.ConnectionString = Program.conPublisher;
                conPublisher.Open();
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu.\nBạn xem lại tên Server của Publisher và tên CSDL trong chuỗi kết nối.\n", "Thông báo", MessageBoxButtons.OK);
                return 0;
            }

        }

        private void layDSPhanManh(string sql)
        {
            DataTable dataTable = new DataTable();
            if (conPublisher.State == ConnectionState.Closed) conPublisher.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, conPublisher);
            sqlDataAdapter.Fill(dataTable);
            conPublisher.Close();

            Program.bsDanhSachPhanManh.DataSource = dataTable;

            cmbCoSo.DataSource = Program.bsDanhSachPhanManh;
            cmbCoSo.DisplayMember = "TENCS";
            cmbCoSo.ValueMember = "TENSERVER";
        }


        private void cmbCoSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Program.serverName = cmbCoSo.SelectedValue.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (edtTenDangNhap.Text.Trim().Equals(""))
            {
                MessageBox.Show("Login name không được để trống", "Dialog", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                edtTenDangNhap.Focus();
                return;
            }

            if (edtMatKhau.Text.Trim().Equals(""))
            {
                MessageBox.Show("Mật khẩu không được để trống", "Dialog", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                edtMatKhau.Focus();
                return;
            }

            if (rbGiangVien.Checked)
            {
                Program.mLogin = edtTenDangNhap.Text;
                Program.password = edtMatKhau.Text;
            }
            else if (rbSinhVien.Checked)
            {
                Program.maSV = edtTenDangNhap.Text;
                Program.mLogin = Program.mLoginSV;
                Program.password = Program.passwordSV;
            }

            if (Program.ketNoi() == 0) return;

            Program.mCoSo = cmbCoSo.SelectedIndex;
            Program.mLoginDN = Program.mLogin;
            Program.passwordDN = Program.password;

            string str = "";
            if (rbSinhVien.Checked)
                str = "EXEC sp_DangNhapSinhVien '" + Program.maSV + "'," + edtMatKhau.Text;
            else if (rbGiangVien.Checked)
                str = "EXEC sp_DangNhapGiangVien '" + Program.mLogin + "'";

            try
            {
                Program.myReader = Program.execSqlDataReader(str);
                if (Program.myReader == null) return;
                Program.myReader.Read();

                Program.username = Program.myReader.GetString(0);

                if (Convert.IsDBNull(Program.username))
                {
                    MessageBox.Show("Login nhập vào không có quyền\nXem lại username và password", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Program.mHoTen = Program.myReader.GetString(1);
                Program.mGroup = Program.myReader.GetString(2);
                Program.myReader.Close();
                Program.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login nhập vào không có quyền\nXem lại username và password\n", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Hide();

            if (Program.mGroup.Equals("SINHVIEN"))
            {
              
                Program.frmMainSinhVien = new frmMainSinhVien();
                Program.frmMainSinhVien.siMaSV.Caption = "Mã SV: " + Program.username;
                Program.frmMainSinhVien.siHoTen.Caption = "Mã SV: " + Program.mHoTen;
                Program.frmMainSinhVien.siNhom.Caption = "Nhóm: SINHVIEN";

                Program.frmMainSinhVien.ShowDialog();
                
            }
            else
            {    
                Program.frmChinh = new frmMain();
                Program.frmChinh.siMaNv.Caption = "Mã GV: " + Program.username;
                Program.frmChinh.siHoTen.Caption = "Họ Tên: " + Program.mHoTen;
                Program.frmChinh.siNhom.Caption = "Nhóm: " + Program.mGroup;

                Program.frmChinh.btnDangNhap.Enabled = false;
                Program.frmChinh.btnTaoTaiKhoan.Enabled = true;
                Program.frmChinh.btnDangXuat.Enabled = true;
                Program.frmChinh.pageBaoCao.Visible = true;
                Program.frmChinh.pageNhapXuat.Visible = true;


                Program.frmChinh.ShowDialog();

            }

            Close();

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbHienMK_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHienMK.Checked)
            {
                edtMatKhau.UseSystemPasswordChar = false;
                cbHienMK.Text = "Ẩn MK";
            }
            else
            {
                edtMatKhau.UseSystemPasswordChar = true;
                cbHienMK.Text = "Hiện MK";
            }
        }

    }

}