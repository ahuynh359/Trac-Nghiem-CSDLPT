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

 
    public partial class frmKQThi : Form
    {
        public static string socau;
        public static string soCauDung;
        public static string diem;
        public static string maMH = "";
        public static string trinhDo = "";
        public static string lan;
        public static string ngayThi = "";
        public static string thoiGian;
        public static string maLop = "";
        public static string tenLop = "";
        public frmKQThi()
        {
            InitializeComponent();
        }

    
        private void frmKQThi_Load(object sender, EventArgs e)
        {
          
            lbTongSoCau.Text ="Tổng Số Câu "+ socau.ToString();
            lbMaMH.Text = "Mã MH " + maMH;
            lbThoiGian.Text = "Thời Gian " + thoiGian;
            lbTrinhDo.Text = "Trình Độ " + trinhDo;
            lbLan.Text = "Lần " + lan;
            lbSoCauDung.Text = "Số Câu Đúng " + soCauDung;
            lbNgayThi.Text = "Ngày Thi " + ngayThi;
            lbTongDiem.Text = "Tổng Điểm " + diem;

           
            if (Program.mGroup.Equals("SINHVIEN"))
            {
                gbSV.Visible = true;
                edtMaSV.Text = Program.maSV;
                edtHoTen.Text = Program.username;
                edtMaLop.Text = maLop;
                edtTenLop.Text = tenLop;
            }
            else
            {
                gbGiangVien.Visible = true;
                edtMaUser.Text =  Program.username; ;
                edtHoTenGV.Text = Program.mHoTen;
                edtNhom.Text =  Program.mGroup;
            }

        }
    }
}
