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
    public partial class subFrmMonHocDaThi : Form
    {

        public String maMH = "";
        public String tenMH = "";
        public subFrmMonHocDaThi()
        {
            InitializeComponent();
        }

        private void mONHOCDATHIBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsMonHocDaThi.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void subFrmMonHocDaThi_Load(object sender, EventArgs e)
        {
            this.monHocDaThiTableAdapter.Connection.ConnectionString = Program.conStr;
     
            this.monHocDaThiTableAdapter.Fill(this.DS.MONHOCDATHI);
          


        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if(bdsMonHocDaThi.Count == 0)
            {
                btnChon.Visible = false;
                return;
            }
            DataRowView drv = ((DataRowView)(bdsMonHocDaThi.Current));
            maMH = drv["MAMH"].ToString().Trim();
            tenMH = drv["TENMH"].ToString().Trim();

            MessageBox.Show("Bạn đã chọn Môn Học có mã môn là : " + maMH, "Thông báo", MessageBoxButtons.OK);


            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
