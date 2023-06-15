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
    public partial class subFrmGiangVien : DevExpress.XtraEditors.XtraForm
    {

        public String maGV = "";
        public String ho = "";
        public String ten = "";
        public String diaChi = "";
        public String maKhoa = "";
        public subFrmGiangVien()
        {
            InitializeComponent();
        }

        private void gIAOVIENBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsGiaoVien.EndEdit();
            this.tableAdapterManager.UpdateAll(this.tNDataSet);

        }

        private void subFrmGiangVien_Load(object sender, EventArgs e)
        {
            this.giaoVienTableAdapter.Connection.ConnectionString = Program.conStr;
            this.giaoVienTableAdapter.Fill(this.tNDataSet.GIAOVIEN);

        }

        private void btnChon_Click(object sender, EventArgs e)
        {

            DataRowView drv = ((DataRowView)(bdsGiaoVien.Current));
            maGV = drv["MAGV"].ToString().Trim();
            ho = drv["HO"].ToString().Trim();
            ten = drv["TEN"].ToString().Trim();
            diaChi = drv["DIACHI"].ToString().Trim();
            maKhoa = drv["MAKH"].ToString().Trim();

            MessageBox.Show("Bạn đã chọn Giáo Viên có mã là : " + maGV, "Thông báo", MessageBoxButtons.OK);

            this.Close();

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}