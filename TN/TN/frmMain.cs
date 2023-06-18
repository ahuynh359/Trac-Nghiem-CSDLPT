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


        private void btnThoat_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
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
              Form frm = checkExists(typeof(frmKhoa));
            if (frm != null) frm.Activate();
            else
            {
                frmKhoa f = new frmKhoa();
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
             Form frm = checkExists(typeof(FrmSinhVien));
             if (frm != null) frm.Activate();
             else
             {
                FrmSinhVien f = new FrmSinhVien();
                 f.MdiParent = this;
                 f.Show();
             }
        }

        private void btnGiaoVien_ItemClick(object sender, ItemClickEventArgs e)
        {
             Form frm = checkExists(typeof(FrmGiaoVien));
             if (frm != null) frm.Activate();
             else
             {
                FrmGiaoVien f = new FrmGiaoVien();
                 f.MdiParent = this;
                 f.Show();
             }
        }

        private void btnBangDiemMonHoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.checkExists(typeof(frmBangDiem));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmBangDiem f = new frmBangDiem();
                //form.MdiParent = this;
                f.Show();
            }
        }

        private void btnHSThi_ItemClick(object sender, ItemClickEventArgs e)
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



        private void btnTaoTaiKhoan_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            Form frm = this.checkExists(typeof(frmTaoTaiKhoan));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmTaoTaiKhoan f = new frmTaoTaiKhoan();
                //form.MdiParent = this;
                f.Show();
            }
        }

        private void btnXemKetQua_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.checkExists(typeof(frmXemKetQuaThi));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmXemKetQuaThi f = new frmXemKetQuaThi();
                //form.MdiParent = this;
                f.Show();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (Program.mGroup.Equals("GIANGVIEN"))
            {
                btnMonHoc.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnBangDiemMonHoc.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnKhoaLop.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnSinhVien.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnGiaoVien.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnCbThi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnTaoTaiKhoan.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                pageBaoCao.Visible = false;
            }
            if (Program.mGroup.Equals("COSO") || Program.mGroup.Equals("TRUONG"))
            {
                btnHSThi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }

        private void btnCbThi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.checkExists(typeof(FrmGVDK));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                FrmGVDK f = new FrmGVDK();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnDSDkiThi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.checkExists(typeof(FrmXemDSDangKy));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                FrmXemDSDangKy f = new FrmXemDSDangKy();
                f.Show();
            }
        }
    }
}