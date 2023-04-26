
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
                Program.serverName = cmbCoSo.SelectedIndex.ToString();
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
            string str = "EXEC sp_DangNhapSinhVien '" + Program.mLogin + "'";

            Program.myReader = Program.execSqlDataReader(str);
            if (Program.myReader == null) return;
            Program.myReader.Read();

            Program.username = Program.myReader.GetString(0); //Lay username
            if (Convert.IsDBNull(Program.username))
            {
                MessageBox.Show("Login nhập vào không có quyền\nXem lại username và password", "Dialog", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            Program.mHoTen = Program.myReader.GetString(1);
            Program.mGroup = Program.myReader.GetString(2);
            Program.myReader.Close();
            //Program.frmChinh.showMenu();





            //Program.mCoSo = cmbCoSo.SelectedIndex;

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
            Program.frmChinh.Close();
        }
    }
}