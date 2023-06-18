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
        public static SqlDataReader myReader;

        //Chuỗi kết nối về server phân mảnh
        public static string conStr;
        public static string conPublisher = "Data Source=ABC" + ";Initial Catalog=TN" + ";Integrated Security=true";

        //Server đang đăng nhập
        public static string serverName = "";

        //Thông tin để login vào SQL
        public static string mLogin = "";
        public static string password = "";
        public static string mLoginSV = "SV";
        public static string passwordSV = "123";

        //Lưu thông tin login vào SQL
        public static string mLoginDN = "";
        public static string passwordDN = "";
        public static int mCoSo = 0;

        public static string database = "TN";
        public static string remoteLogin = "HTKN";
        public static string remoteLoginPassword = "123";

        //Thông tin đăng nhập vào DB
        public static string username = "";
        public static string mGroup = "";
        public static string mHoTen = "";
        public static string maSV = "";



        //Lưu ds phân mảnh khi đăng nhập gồm 2 cột mã và tên CS và 
        public static BindingSource bsDanhSachPhanManh = new BindingSource();
        public static frmMain frmChinh = null;
        public static frmMainSinhVien frmMainSinhVien = null;
        public static frmDangNhap frmDangNhap = null;
        public static frmThi frmThi = null;
        public static frmKQThi frmKQThi = null;


        public static subFrmMonHoc subFrmMonHoc;
        public static subFrmGiangVien subFrmGiangVien;
        public static subFrmLopDaThi subFrmLopDaThi;
        public static subFrmMonHocDaThi subFrmMonHocDaThi;
        public static subFrmGVChuaDki subFrmGVChuaDki;
        public static subFrmSVDaThi subFrmSVDaThi;

        public static String FULLNAME_PATTERN =
    "^[a-zA-Z_ÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶ" +
    "ẸẺẼỀỀỂưăạảấầẩẫậắằẳẵặẹẻẽềềểỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợ" +
    "ụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ\\s]+$";

        //Kết nối về server phân mảnh
        public static int ketNoi()
        {
            if (con != null && con.State == ConnectionState.Open)
            {
                con.Close();
                return 0;
            }
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
                MessageBox.Show("Lỗi Kết nối CSDL\nBạn xem lại username và password", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;

            }
        }

        //Thực thi tải dữ liệu về ko cho hiệu chỉnh
        public static SqlDataReader execSqlDataReader(string sql)
        {
            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand(sql, con);
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
                MessageBox.Show("Chạy lệnh Data Reader lỗi\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        //Thực thi tải dữ liệu về và cho thêm xóa sửa
        public static DataTable execSqlDataTable(string sql)
        {
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed) con.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(dt);
            con.Close();
            return dt;
        }

        //Cập nhật sp nhưng không trả về giá trị
        public static int execSqlNonQuery(string sql)
        {
            SqlCommand Sqlcmd = new SqlCommand(sql, con);
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

                MessageBox.Show("Thực thi lệnh sql non query sai\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
                return 1;

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
