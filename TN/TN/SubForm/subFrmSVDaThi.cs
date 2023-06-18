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
    public partial class subFrmSVDaThi : Form
    {

        public String maSV = "";
        public String ten = "";
       
        public subFrmSVDaThi()
        {
            InitializeComponent();
        }

        private void sINHVIENBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsSV.EndEdit();
            this.tableAdapterManager.UpdateAll(this.tNDataSet);

        }

        private void subFrmSVDaThi_Load(object sender, EventArgs e)
        {
            this.svTableAdapter.Connection.ConnectionString = Program.conStr;
            this.svTableAdapter.FillByDaThi(this.tNDataSet.SINHVIEN);

           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (bdsSV.Count == 0)
            {
                btnChon.Visible = false;
                return;
            }
            DataRowView drv = ((DataRowView)(bdsSV.Current));
            maSV = drv["MASV"].ToString().Trim();
            string ho = drv["HO"].ToString().Trim();
            string ten = drv["TEN"].ToString().Trim();
            ten = ho + ' ' + ten;

            MessageBox.Show("Bạn đã chọn Giáo Viên có mã là : " + maSV, "Thông báo", MessageBoxButtons.OK);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
