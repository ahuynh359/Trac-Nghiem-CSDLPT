
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TN
{
    public partial class frmDangNhap : Form
    {
        private SqlConnection con = new SqlConnection();
        public frmDangNhap()
        {
            InitializeComponent();
        }


        private int connectDB()
        {
            if (con == null)
            {
                Console.WriteLine("con is null");
                return 0;
            }
            if (con.State == ConnectionState.Open)
                con.Close();
            try
            {
                con.ConnectionString = Program.conPublisher;
                con.Open();
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu.\nBạn xem lại tên Server của Publisher và tên CSDL trong chuỗi kết nối.\n" + ex.Message, "", MessageBoxButtons.OK);
                return 0;
            }


        }

        private void getSubcribers(string cmd)
        {
            if (con == null) return;

            DataTable dataTable = new DataTable();
            if (con.State == ConnectionState.Closed) con.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd, con);
            sqlDataAdapter.Fill(dataTable);
            con.Close();

            Program.bsDanhSachPhanManh.DataSource = dataTable;
            cmbCoSo.DataSource = Program.bsDanhSachPhanManh;
            cmbCoSo.DisplayMember = "TENCS";
            cmbCoSo.ValueMember = "TENSERVER";
        }
        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            if (connectDB() == 0) return;
            getSubcribers("SELECT * FROM view_DanhSachPhanManh");
            cmbCoSo.SelectedIndex = 1;
            cmbCoSo.SelectedIndex = 0;


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
            if (txtTenDangNhap.Text.Trim() == "" || txtTenDangNhap.Text.Trim() == "")
            {
                MessageBox.Show("Login name và mật khẩu không được để trống", "Dialog", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            Program.mLogin = txtTenDangNhap.Text;
            Program.password = txtMatKhau.Text;

            if (Program.ketNoi() == 0) return;

            Program.mCoSo = cmbCoSo.SelectedIndex;
            Program.mLoginDN = Program.mLogin;
            Program.passwordDN = Program.password;
            string str = "";
            if (rbtnSinhVien.Checked)
                str = "EXEC sp_DangNhapSinhVien '" + Program.mLogin + "'";
            else if (rbtnGiangVien.Checked)
                str = "EXEC sp_DangNhapGiangVien '" + Program.mLogin + "'";

            Program.myReader = Program.execSqlDataReader(str);
            if (Program.myReader == null) return;
            Program.myReader.Read();

            Program.username = Program.myReader.GetString(0); //Lay username
            if (Convert.IsDBNull(Program.username))
            {
                MessageBox.Show("Login nhập vào không có quyền\nXem lại username và password", "Dialog", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (rbtnSinhVien.Checked && Program.myReader.GetString(2).Trim().Equals("GIANGVIEN"))
            {
                MessageBox.Show("Bạn đăng nhập vào tài khoản quyền GIẢNG VIÊN \nXem lại username và password", "Dialog", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (rbtnSinhVien.Checked && Program.myReader.GetString(2).Trim().Equals("TRUONG"))
            {
                MessageBox.Show("Bạn đăng nhập vào tài khoản quyền TRUONG\nXem lại username và password", "Dialog", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (rbtnSinhVien.Checked && Program.myReader.GetString(2).Trim().Equals("COSO"))
            {
                MessageBox.Show("Bạn đăng nhập vào tài khoản quyền COSO\nXem lại username và password", "Dialog", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (rbtnGiangVien.Checked && Program.myReader.GetString(2).Trim().Equals("SINHVIEN"))
            {
                MessageBox.Show("Bạn đăng nhập vào tài khoản quyền SINH VIÊN\nXem lại username và password", "Dialog", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            

            Program.mHoTen = Program.myReader.GetString(1);
            Program.mGroup = Program.myReader.GetString(2);
            Program.myReader.Close();
            Program.con.Close();
            Program.frmChinh.siMaNv.Caption = "Mã User: " + Program.username;
            Program.frmChinh.siHoTen.Caption = "Họ Tên: " + Program.mHoTen;
            Program.frmChinh.siNhom.Caption = "Nhóm: " + Program.mGroup;
            Close();

            Program.frmChinh.btnMainDangNhap.Enabled = false;
            Program.frmChinh.btnTaoTaiKhoan.Enabled = true;
            Program.frmChinh.btnDangXuat.Enabled = true;
            Program.frmChinh.pageBaoCao.Visible = true;
            Program.frmChinh.pageNhapXuat.Visible = true;





        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbHienMK_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHienMK.Checked)
            {
                txtMatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = true;
            }
        }
        
    }

}