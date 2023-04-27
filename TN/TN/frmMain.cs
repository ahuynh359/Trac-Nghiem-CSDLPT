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
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnMainDangNhap_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDangNhap frmDangNhap = new frmDangNhap();
            frmDangNhap.Show();
        }

        private void btnThoat_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void btnDangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDangNhap frmDangNhap = new frmDangNhap();
            frmDangNhap.Show();
        }

        private Form checkExists(Type ftype)
        {
            foreach (Form f in MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }

        private void btnMonHoc_ItemClick(object sender, ItemClickEventArgs e)
        {

            Form frm = checkExists(typeof(frmMonHoc));
            if (frm != null) frm.Activate();
            else
            {
                frmMonHoc f = new frmMonHoc();
                f.MdiParent = this;
                f.Show();
            }

        }

        private void btnKhoaLop_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = checkExists(typeof(frmKhoaLop));
            if (frm != null) frm.Activate();
            else
            {
                frmKhoaLop f = new frmKhoaLop();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnNhapDe_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = checkExists(typeof(frmNhapDe));
            if (frm != null) frm.Activate();
            else
            {
                frmNhapDe f = new frmNhapDe();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnSinhVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = checkExists(typeof(frmSinhVien));
            if (frm != null) frm.Activate();
            else
            {
                frmSinhVien f = new frmSinhVien();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnGiaoVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = checkExists(typeof(frmGiaoVien));
            if (frm != null) frm.Activate();
            else
            {
                frmGiaoVien f = new frmGiaoVien();
                f.MdiParent = this;
                f.Show();
            }
        }
    }
}