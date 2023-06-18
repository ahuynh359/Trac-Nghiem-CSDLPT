using DevExpress.XtraEditors;
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
    public partial class subFrmMonHoc : DevExpress.XtraEditors.XtraForm
    {

        public String maMH = "";
        public String tenMH = "";
        
        public subFrmMonHoc()
        {
            InitializeComponent();
        }

       

        private void mONHOCBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsMonHoc.EndEdit();
            this.tableAdapterManager.UpdateAll(this.tNDataSet);

        }

        private void subFrmMonHoc_Load(object sender, EventArgs e)
        {
           
            this.monHocTableAdapter.Connection.ConnectionString = Program.conStr;
            this.monHocTableAdapter.Fill(this.tNDataSet.MONHOC);

           


        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if (bdsMonHoc.Count == 0)
            {
                btnChon.Visible = false;
                return;
            }
            DataRowView drv = ((DataRowView)(bdsMonHoc.Current));
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