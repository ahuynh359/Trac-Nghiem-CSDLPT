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
using TN.SubForm;
using TN.RptForm;
using DevExpress.XtraReports.UI;
using System.IO;

namespace TN
{
    public partial class frmBangDiem : DevExpress.XtraEditors.XtraForm
    {
        public frmBangDiem()
        {
            InitializeComponent();
        }

        private void frmBangDiem_Load(object sender, EventArgs e)
        {
           
            if (Program.mGroup.Equals("TRUONG"))
            {
                cmbCoSo.Enabled = true;
                cmbCoSo.DataSource = Program.bsDanhSachPhanManh.DataSource;
                cmbCoSo.DisplayMember = "TENCS";
                cmbCoSo.ValueMember = "TENSERVER";
                cmbCoSo.SelectedIndex = Program.mCoSo;
            }

           

        }

      

        private void cmbCoSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Kiem tra cbbCoSo co du lieu chua
            if (cmbCoSo.SelectedValue.ToString() == "System.Data.DataRowView")
                return;

            Program.serverName = cmbCoSo.SelectedValue.ToString();

            //Nếu chọn cơ sở khác
            if (cmbCoSo.SelectedIndex != Program.mCoSo)
            {
                Program.mLogin = Program.remoteLogin;
                Program.password = Program.remoteLoginPassword;
                Program.mCoSo = cmbCoSo.SelectedIndex;
            }
            else
            //Nếu chọn trùng cơ sở với đăng nhập
            {
                Program.mLogin = Program.mLoginDN;
                Program.password = Program.passwordDN;
            }
            
        }

        private void btnXemTruoc_Click(object sender, EventArgs e)
        {
            if (edtMaLop.Text.ToString().Trim().Equals(""))
            {
                MessageBox.Show("Mã lớp học không được để trống ", "Thông báo", MessageBoxButtons.OK);
                edtMaLop.Focus();
                return;
            }

            if (edtMaMH.Text.ToString().Trim().Equals(""))
            {
                MessageBox.Show("Mã môn học học không được để trống ", "Thông báo", MessageBoxButtons.OK);
                edtMaMH.Focus();
                return;
            }

            string sql = "EXEC sp_LayBangDiemMonHoc N'" + edtMaLop.Text.Trim() + "', N'" + edtMaMH.Text.Trim() + "', " + sEdtLanThi.Value;
           
            try
            {
                Program.myReader = Program.execSqlDataReader(sql);
                if (!Program.myReader.HasRows)
                {
                    MessageBox.Show("Không có bảng điểm cho môn học " + edtTenMH.Text.Trim() + " tại lớp " + edtTenLop.Text.Trim()
                        + " thi lần " + sEdtLanThi.Value + "!", "", MessageBoxButtons.OK);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra tồn tại bảng điểm" + ex.ToString(), "", MessageBoxButtons.OK);
                return;
            }
            finally
            {
                Program.myReader.Close();
            }

            previewReport();



        }

        private void previewReport()
        {
            rptXemBangDiem rpt = new rptXemBangDiem(edtMaLop.Text.Trim(), edtMaMH.Text.Trim(), Int32.Parse(sEdtLanThi.Text.ToString()));

            rpt.lbLop.Text = "Lớp : " + edtTenLop.Text.Trim();
            rpt.lbMonHoc.Text = "Môn Học : " + edtTenMH.Text.Trim();
            rpt.lbLan.Text = "Lần : " + sEdtLanThi.Text;
            DateTime today = DateTime.Today;
            rpt.lbNgayLap.Text = "Ngày Lập : TP Hồ Chí Minh, ngày " + today.Day + " tháng " + today.Month + " năm " + today.Year;
            rpt.lbNguoiLap.Text = "Người Lập : " + Program.mHoTen;
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }

        private void btnXuatBan_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChonMaLop_Click(object sender, EventArgs e)
        {
            Program.subFrmLopDaThi = new subFrmLopDaThi();
            Program.subFrmLopDaThi.ShowDialog();
            edtMaLop.Text = Program.subFrmLopDaThi.maLop;
            edtTenLop.Text = Program.subFrmLopDaThi.tenLop;
        }

        private void btnChonMaMH_Click(object sender, EventArgs e)
        {
            Program.subFrmMonHocDaThi = new subFrmMonHocDaThi();
            Program.subFrmMonHocDaThi.ShowDialog();

            edtMaMH.Text = Program.subFrmMonHocDaThi.maMH;
            edtTenMH.Text = Program.subFrmMonHocDaThi.tenMH;
        }
    }
}