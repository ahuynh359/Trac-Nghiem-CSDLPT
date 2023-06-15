using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using TN.SubForm;
namespace TN
{
    static class Program
    {

        public static SqlConnection con = new SqlConnection();
        public static string conStr;
        public static string conPublisher = "Data Source=ABC" + ";Initial Catalog=TN" + ";Integrated Security=true";


        public static SqlDataReader myReader;
        public static string serverName = "";
        public static string username = "";
        public static string mLogin = "";
        public static string password = "";
        public static string mLoginSV = "SV";
        public static string passwordSV = "123";
        public static string maSV = "";


        public static string database = "TN";
        public static string remoteLogin = "HTKN";
        public static string remoteLoginPassword = "123";
        public static string mLoginDN = "";
        public static string passwordDN = "";
        public static string mGroup = "";
        public static string mHoTen = "";
        public static int mCoSo = 0;

        //Lưu Db phân mảnh khi đăng nhập
        public static BindingSource bsDanhSachPhanManh = new BindingSource();
        public static frmMain frmChinh = null;
        public static frmMainSinhVien frmMainSinhVien = null;
        public static frmDangNhap frmDangNhap = null;
        public static frmThi frmThi = null;
        public static frmKQThi frmKQThi = null;
        public static subFrmMonHoc subFrmMonHoc;
        public static subFrmGiangVien subFrmGiangVien;

        public static int ketNoi()
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

                conStr = "Data Source=" + serverName + ";Initial Catalog=" + database + ";User ID=" +
                         mLogin + ";password=" + password;
                con.ConnectionString = conStr;
                con.Open();
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Kết nối CSDL\nBạn xem lại username và password.", "Dialog", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;

            }
        }

        //Thu thi sp, view, function, truy van tra ve datareaader
        public static SqlDataReader execSqlDataReader(string str)
        {
            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;

            if (con.State == ConnectionState.Closed) con.Open();
            try
            {
                reader = cmd.ExecuteReader();
                return reader;
            }
            catch (SqlException ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
                return null;


            }
        }

        public static DataTable execSqlDataTable(string cmd)
        {
            DataTable dt = new DataTable();
            if (Program.con.State == ConnectionState.Closed) Program.con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd, con);
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public static int execSqlNonQuery(string strlenh)
        {
            SqlCommand Sqlcmd = new SqlCommand(strlenh, con);
            Sqlcmd.CommandType = CommandType.Text;
            Sqlcmd.CommandTimeout = 600;// 10 phut
            if (con.State == ConnectionState.Closed) con.Open();
            try
            {
                Sqlcmd.ExecuteNonQuery(); con.Close();
                return 0;
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("Error converting data type varchar to int"))
                    MessageBox.Show("Bạn format Cell lại cột \"Ngày Thi\" qua kiểu Number hoặc mở File Excel.");
                else MessageBox.Show(ex.Message);
                con.Close();
                return ex.State; //return 1

            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmDangNhap = new frmDangNhap();
            Application.Run(frmDangNhap);
        }
    }
}
