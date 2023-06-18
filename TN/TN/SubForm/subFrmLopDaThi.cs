using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TN.SubForm
{
    public partial class subFrmLopDaThi : Form
    {

        public String maLop = "";
        public String tenLop = "";
        
        public subFrmLopDaThi()
        {
            InitializeComponent();
        }

        private void subFrmLopDaThi_Load(object sender, EventArgs e)
        {
            this.lopDaThiTableAdapter.Connection.ConnectionString = Program.conStr;
            this.lopDaThiTableAdapter.Fill(this.DS.LOPDATHI);

           


        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if(bdsLopDaThi.Count == 0 )
            {
                btnChon.Visible = false;
                return;
            }
            DataRowView drv = ((DataRowView)(bdsLopDaThi.Current));
            maLop = drv["MALOP"].ToString().Trim();
            tenLop = drv["TENLOP"].ToString().Trim();

            MessageBox.Show("Bạn đã chọn Lớp có mã lớp là : " + maLop, "Thông báo", MessageBoxButtons.OK);


            this.Close();
        }
    }
}
