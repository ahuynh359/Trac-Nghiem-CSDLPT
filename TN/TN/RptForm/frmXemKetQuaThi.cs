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

namespace TN
{
    public partial class frmXemKetQuaThi : Form
    {
        public frmXemKetQuaThi()
        {
            InitializeComponent();
        }

        private void btnChon_Click(object sender, EventArgs e)
        {

        }

        private void frmXemKetQuaThi_Load(object sender, EventArgs e)
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

        private void btnPreview_Click(object sender, EventArgs e)
        {

            if (edtMaSV.Text.ToString().Trim().Equals(""))
            {
                MessageBox.Show("Mã SV học không được để trống ", "Thông báo", MessageBoxButtons.OK);
                edtMaSV.Focus();
                return;
            }

            if (edtMaMH.Text.ToString().Trim().Equals(""))
            {
                MessageBox.Show("Mã môn học học không được để trống ", "Thông báo", MessageBoxButtons.OK);
                edtMaMH.Focus();
                return;
            }

            string sql = "EXEC sp_XemKetQua N'" + edtMaSV.Text + "', N'" + edtMaMH.Text.Trim() + "', " + sEditLan.Value;

            try
            {
                Program.myReader = Program.execSqlDataReader(sql);
                if (!Program.myReader.HasRows)
                {
                    MessageBox.Show("Không có bảng điểm cho môn học " + edtMaSV.Text.Trim() + " môn học " + edtMaMH.Text.Trim()
                        + " thi lần " + sEditLan.Value + "!", "", MessageBoxButtons.OK);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sp_XemKetQua" + ex.ToString(), "", MessageBoxButtons.OK);
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
            string ngaythi = "SELECT Ngaythi from BangDiem Where MASV='" + edtMaSV.Text.Trim() + "'AND MAMH='" + edtMaMH.Text.Trim() + "'AND LAN=" + sEditLan.Value;

            try
            {
                Program.myReader = Program.execSqlDataReader(ngaythi);
                if (!Program.myReader.HasRows)
                {
                    MessageBox.Show("Lỗi lấy ngày thi", "", MessageBoxButtons.OK);

                    return;
                }
                Program.myReader.Read();



            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message, "Thông báo", MessageBoxButtons.OK);
            }

            string ngay = Program.myReader.GetDateTime(0).ToString("dd/MM/yyyy");
            Program.myReader.Close();


            rptXemKetQuaThi rpt = new rptXemKetQuaThi(edtMaSV.Text.Trim(), edtMaMH.Text.Trim(), Int32.Parse(sEditLan.Text.ToString()));

            rpt.lbLop.Text = "Lớp : "+edtLop.Text.Trim();
            rpt.lbHoTen.Text ="Họ Tên : "+ edtTenSV.Text.Trim();
         
            DateTime today = DateTime.Today;
            rpt.lbNgayLap.Text = "TP Hồ Chí Minh, ngày " + today.Day + " tháng " + today.Month + " năm " + today.Year;
            rpt.lbNguoiLap.Text = "Người Lập: " + Program.mHoTen;
            rpt.lbMonThi.Text = "Môn Thi : " + edtTenMonHoc.Text.Trim();
            rpt.lbLan.Text = "Lần : " + sEditLan.Text;
            rpt.lbNgayThi.Text ="Ngày Thi :"+ ngay;
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }

        private void btnChonSV_Click(object sender, EventArgs e)
        {

            Program.subFrmSVDaThi = new subFrmSVDaThi();
            Program.subFrmSVDaThi.ShowDialog();
            edtMaSV.Text = Program.subFrmSVDaThi.maSV;
            edtTenSV.Text = Program.subFrmSVDaThi.ten;
        }

        private void btnChonMH_Click(object sender, EventArgs e)
        {
            Program.subFrmMonHocDaThi = new subFrmMonHocDaThi();
            Program.subFrmMonHocDaThi.ShowDialog();
            edtMaMH.Text = Program.subFrmMonHocDaThi.maMH;
            edtTenMonHoc.Text = Program.subFrmMonHocDaThi.tenMH;
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
    }
}
