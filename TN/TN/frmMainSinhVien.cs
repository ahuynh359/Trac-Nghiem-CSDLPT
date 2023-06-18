using DevExpress.XtraBars;
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
    public partial class frmMainSinhVien : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMainSinhVien()
        {
            InitializeComponent();
        }


        private Form checkExists(Type ftype)
        {
            foreach (Form f in MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }

        private void btnDangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {

            DialogResult dr = MessageBox.Show("Bạn có muốn đăng xuất không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                foreach (Form f in this.MdiChildren)
                    f.Dispose();
                Program.mLogin = "";
                Program.password = "";
                this.Hide();
                Program.frmDangNhap = new frmDangNhap();
                Program.frmDangNhap.Activate();
                Program.frmDangNhap.ShowDialog();

            }


        }

        private void btnThoat_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void btnThi_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            Form frm = checkExists(typeof(frmThi));
            if (frm != null) frm.Activate();
            else
            {
                Program.frmThi = new frmThi();
                Program.frmThi.MdiParent = this;
                Program.frmThi.Show();
            }
        }

        private void btnKetQuaThi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = checkExists(typeof(frmXemKetQuaThi));
            if (frm != null) frm.Activate();
            else
            {
                frmXemKetQuaThi f = new frmXemKetQuaThi();
                f.MdiParent = this;
                f.Show();
            }
        }
    }
}