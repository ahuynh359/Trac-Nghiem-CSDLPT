using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace TN
{
    static class Program
    {

        public static SqlConnection con = new SqlConnection();
        public static string conStr;
        public static string conPublisher = "Data Source=ABC" + ";Initial Catalog=TN" + ";User ID=sa" + ";password=123";


        public static SqlDataReader myReader;
        public static string serverName = "";
        public static string username = "";
        public static string mLogin = "";
        public static string password = "";

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
        public static frmDangNhap frmChinh;

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
                MessageBox.Show("server name=" + serverName + "\nDB=" + database + "\nuser=" + mLogin + "\npass=" + password);
                conStr = "Data Source=" + serverName + ";Initial Catalog=" + database + ";User ID=" +
                         mLogin + ";password=" + password;
                con.ConnectionString = conStr;
                con.Open();
                return 1;
            }
            catch (Exception e)
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
            catch (SqlException e)
            {
                con.Close();
                MessageBox.Show(e.Message);
                return null;


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
            frmChinh = new frmDangNhap();
            Application.Run(frmChinh);
        }
    }
}
