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
    public partial class subFrmGVChuaDki : Form
    {
        public String maGV = "";
        public String tenGV = "";
        public subFrmGVChuaDki()
        {
            InitializeComponent();
        }

        private void subFrmGVChuaDki_Load(object sender, EventArgs e)
        {
            this.gvChuaDangKyTableAdapter.Connection.ConnectionString = Program.conStr;
            this.gvChuaDangKyTableAdapter.Fill(this.DS.GVCHUADANGKY);

          


        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if (bdsGVChuaDKy.Count == 0)
            {
                btnChon.Visible = false;
                return;
            }
            DataRowView drv = ((DataRowView)(bdsGVChuaDKy.Current));
            maGV = drv["MAGV"].ToString().Trim();
            tenGV = drv["HOTEN"].ToString().Trim();
           

            MessageBox.Show("Bạn đã chọn Giáo Viên có mã là : " + maGV, "Thông báo", MessageBoxButtons.OK);

            this.Close();

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
