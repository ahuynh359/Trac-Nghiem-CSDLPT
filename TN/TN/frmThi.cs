using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TN.SubForm;

namespace TN
{
    public partial class frmThi : Form
    {

        private List<CauHoi> listCauHoi;
        private int thoiGian;
        private int giay = 1;
        private int soCauThi;
        private double diem;
        private int soCauDung = 0;
        private DateTime ngayThi;
        public frmThi()
        {
            InitializeComponent();
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            Program.subFrmMonHoc = new subFrmMonHoc();
            Program.subFrmMonHoc.ShowDialog();
            edtMaMH.Text = Program.subFrmMonHoc.maMH;
            edtTenMH.Text = Program.subFrmMonHoc.tenMH;

        }

        private void frmThi_Load(object sender, EventArgs e)
        {

            if (Program.mGroup == "SINHVIEN")
            {
                gridControlThi.Visible = false;
                groupBoxSV.Visible = true;
                loadInfoSv();
                colMAGV.Visible = false;
            }
            else if (Program.mGroup == "GIANGVIEN")
            {
                groupBoxBaiThi.Enabled = false;
                this.thiTableAdapter.Connection.ConnectionString = Program.conStr;
                this.thiTableAdapter.FillByMaGV(this.DS.THI, Program.username);
                if (bdsThi.Count > 0)
                {
                    btnThi.Enabled = true;

                }
                else
                {
                    MessageBox.Show("Giảng Viên Chưa Đăng Ký Môn Học Nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    gridControlThi.Enabled = false;
                }
            }
        }


        private void loadInfoSv()
        {
            edtMaSV.Text = Program.maSV;
            edtHoTen.Text = Program.mHoTen;
            string sql = "SELECT LOP.MALOP, TENLOP FROM dbo.LOP JOIN dbo.SINHVIEN " +
                    "ON SINHVIEN.MALOP = LOP.MALOP WHERE MASV = '" + Program.maSV + "'";
            try
            {
                Program.myReader = Program.execSqlDataReader(sql);
                if (Program.myReader == null)
                {
                    Program.myReader.Close();
                    Program.con.Close();
                    return; //khong co kq tra ve
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực hiện truy vấn dữ lieu lop SV!\n\n" + ex.Message, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Program.myReader.Read();
            edtMaLop.Text = Program.myReader.GetValue(0).ToString();
            edtTenLop.Text = Program.myReader.GetValue(1).ToString();
            Program.myReader.Close();
            Program.con.Close();
        }

        private void filter()
        {
            if (Program.mGroup.Equals("SINHVIEN")) { 
            ngayThi = dateEdit1.DateTime;
            string ngay = ngayThi.ToString("yyyy-MM-dd");
            string sql = "EXEC sp_LayThongTinThi N'" + edtMaMH.Text.Trim() + "', " + sEdtLanThi.Value + ", '" + ngay + "', N'"+edtMaLop.Text +"'";
            MessageBox.Show(sql);
            try
            {
                Program.myReader = Program.execSqlDataReader(sql);
                if (Program.myReader == null)
                {
                    return;
                }

                bool s = Program.myReader.Read();
                if (s)
                {

                    btnThi.Visible = true;
                    edtTrinhDo.Text = Program.myReader.GetValue(0).ToString();
                    edtSoCauThi.Text = Program.myReader.GetInt16(1).ToString();
                    soCauThi = int.Parse(edtSoCauThi.Text.ToString());
                    edtThoiGian.Text = Program.myReader.GetValue(2).ToString();
                    thoiGian = int.Parse(edtThoiGian.Text.ToString());
                    edtNgayThi.Text = Program.myReader.GetDateTime(3).ToString();
                } else
                {
                    btnThi.Visible = false;
                    edtTrinhDo.Text = "";
                    edtSoCauThi.Text = "";
                    soCauThi = 0;
                    edtThoiGian.Text ="";
                    thoiGian = 0;
                    edtNgayThi.Text = "";
                }
               
                Program.myReader.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực hiện truy vấn sp_LayThongTinThi!\n\n" + ex.Message, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                Program.con.Close();
            }

            }


        }

        private void edtMaMH_TextChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void datePicker_ValueChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void sEdtLanThi_EditValueChanged(object sender, EventArgs e)
        {
            filter();
        }


        private int checkDaThi()
        {

            int res;
            string sql = "DECLARE @result int " +
           "EXEC @result = sp_KiemTraLanThi '" + Program.maSV + "', N'" + edtMaMH.Text.Trim() + "', " + sEdtLanThi.Value + " SELECT 'Res' = @result";

            try
            {
                Program.myReader = Program.execSqlDataReader(sql);
                if (Program.myReader == null)
                {
                    
                    return 0;
                }

                Program.myReader.Read();
                res = int.Parse(Program.myReader.GetValue(0).ToString());
                Program.myReader.Close();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực hiện truy vấn sp_KiemTraLanThi!\n\n" + ex.Message, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            if (res == 0)
            {
                MessageBox.Show("SV đã thi, không được thi nữa ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }


            return 1;
        }

        private int loadCauHoi()
        {

            string str = "EXEC sp_LayCauHoi N'" + edtMaMH.Text + "', N'" + edtTrinhDo.Text + "', " + soCauThi;

            try
            {
                DataTable dt = Program.execSqlDataTable(str);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không thể lấy được đề thi, thiếu đề", "", MessageBoxButtons.OK);
                    return 0;
                }

                labelTime.Text = edtThoiGian.Text + " : 00";
                timer1.Start();

                bdsDeThi.DataSource = dt;
                btnThi.Visible = false;
                gridControlThi.Visible = false;

                listCauHoi = new List<CauHoi>();
                for (int i = 0; i < soCauThi; i++)
                {

                    var ch = new CauHoi();
                    ch.CauSo = i + 1;
                    ch.Width = flowDeThi.Width;
                    ch.IdCauHoi = (int)((DataRowView)bdsDeThi[i])["CauHoi"];
                    ch.NoiDung = ((DataRowView)bdsDeThi[i])["NoiDung"].ToString();
                    ch.CauA = ((DataRowView)bdsDeThi[i])["A"].ToString();
                    ch.CauB = ((DataRowView)bdsDeThi[i])["B"].ToString();
                    ch.CauC = ((DataRowView)bdsDeThi[i])["C"].ToString();
                    ch.CauD = ((DataRowView)bdsDeThi[i])["D"].ToString();
                    ch.DapAn = ((DataRowView)bdsDeThi[i])["DAP_AN"].ToString();
                    ch.DaChon = "";
                    listCauHoi.Add(ch);

                    string[] arr = new string[2];
                    arr[0] = "Câu " + (i + 1).ToString();
                    arr[1] = ch.DaChon;

                    ListViewItem item = new ListViewItem(arr);
                    item.ForeColor = Color.Red;
                    listViewDaChon.Items.Add(item);

                    flowDeThi.Controls.Add(ch);
                    panelThi.Visible = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy đề" + ex.Message, "Thông báo", MessageBoxButtons.OK);
                return 0;
            }
            finally
            {
                Program.myReader.Close();
                Program.con.Close();
            }
            return 1;


        }


        private int checkNgayThi()
        {

            DateTime today = DateTime.Today;
            string now = today.Date.ToString();
            now = now.Substring(0, now.IndexOf(" "));
            string time = dateEdit1.DateTime.ToString();
            time = time.Substring(0, time.IndexOf(" "));
            MessageBox.Show(now);
            MessageBox.Show(time);
            return now.CompareTo(time);

        }


        private void btnThi_Click(object sender, EventArgs e)
        {

            if (Program.mGroup.Equals("SINHVIEN"))
            {
                //Neu da thi

                int check = checkDaThi();
                if (check == 0)
                    return;
                check = checkNgayThi();
                if (check == 0)
                {
                    DialogResult dr = MessageBox.Show("Bạn muốn bắt đầu thi đề thi môn " + edtTenMH.Text + "\nThời gian: "
                        + edtThoiGian.Text +
                        "phút\nLần thi: " + sEdtLanThi.Text + " ?",
                        "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.OK)
                    {

                        groupBoxBaiThi.Enabled = false;
                        if (loadCauHoi() == 0) return;


                    }
                }
                else if (check < 0)
                {
                    MessageBox.Show("Chưa tới thời gian thi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (check > 0)
                {
                    MessageBox.Show("Đã qua thời gian thi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                DialogResult dr = MessageBox.Show("Bạn muốn bắt đầu thi đề thi môn " + ((DataRowView)this.bdsThi.Current).Row["TENMH"].ToString() + "\nThời gian: "
                        + ((DataRowView)this.bdsThi.Current).Row["THOIGIAN"].ToString() +
                        "phút\nLần thi: " + ((DataRowView)this.bdsThi.Current).Row["LAN"].ToString() + " ?",
                        "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {

                    if (loadCauHoi() == 0) return;


                }
            }



        }

        private void displayTime()
        {
            giay--;
            if (giay == 0)
            {
                if (thoiGian > 0)
                {
                    thoiGian--;
                    giay = 59;
                }
            }
            labelTime.Text = "Thời Gian Còn: " + thoiGian.ToString() + " : " + giay.ToString();
        }





        private void timer1_Tick(object sender, EventArgs e)
        {
            displayTime();

            if (thoiGian == 0 && giay == 0)
            {
                timer1.Stop();

                MessageBox.Show("Đã hết thời gian thi!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnNop.Enabled = false;
                flowDeThi.Controls.Clear();

                tinhDiem();
                MessageBox.Show(diem.ToString());

            }
        }

        private void tinhDiem()
        {
            soCauDung = 0;
            for (int i = 0; i < soCauThi; i++)
            {
                if (listCauHoi[i].DaChon.Trim().CompareTo(listCauHoi[i].DapAn.Trim()) == 0)
                    soCauDung++;
            }
            if (soCauDung == 0) diem = 0;
            else
                diem = (Math.Round((double)(10 * soCauDung) / soCauThi));

        }

        private void btnTruoc_Click(object sender, EventArgs e)
        {

            int change = flowDeThi.HorizontalScroll.Value - flowDeThi.Width - flowDeThi.HorizontalScroll.SmallChange;
            flowDeThi.AutoScrollPosition = new Point(change, 0);


        }

        private void btnSau_Click(object sender, EventArgs e)
        {
            int change = flowDeThi.HorizontalScroll.Value + flowDeThi.Width + flowDeThi.HorizontalScroll.SmallChange;
            flowDeThi.AutoScrollPosition = new Point(change, 0);
        }

        private void listViewDaChon_MouseClick(object sender, MouseEventArgs e)
        {
            string so = listViewDaChon.SelectedItems[0].SubItems[0].Text.ToString();
            int s = int.Parse(so.Substring(so.IndexOf(" ") + 1, so.Length - so.IndexOf(" ") - 1));

            flowDeThi.AutoScrollPosition = new Point(0, 0);
            int change = flowDeThi.HorizontalScroll.Value + (s - 1) * flowDeThi.Width;
            flowDeThi.AutoScrollPosition = new Point(change, 0);

        }

        private void ghiDiemBaiThi()
        {
            DataTable dt = new DataTable();

            //Add columns  
            dt.Columns.Add(new DataColumn("CAUHOI", typeof(int)));
            dt.Columns.Add(new DataColumn("THUTU", typeof(int)));
            dt.Columns.Add(new DataColumn("DACHON", typeof(string)));

            for (int i = 0; i < soCauThi; i++)
            {
                dt.Rows.Add(listCauHoi[i].IdCauHoi, listCauHoi[i].CauSo, listCauHoi[i].DaChon);
            }

            SqlParameter para = new SqlParameter();
            para.SqlDbType = SqlDbType.Structured;
            para.TypeName = "dbo.TYPE_CT_BAITHI";
            para.ParameterName = "@BAITHI";
            para.Value = dt;
            Program.con.Open();
            SqlCommand sqlcom = new SqlCommand("sp_ChenKetQuaThi", Program.con);
            sqlcom.Parameters.Clear();
            sqlcom.CommandType = CommandType.StoredProcedure;

            sqlcom.Parameters.Add(para);
            sqlcom.Parameters.Add("@MASV", SqlDbType.Char, 8);
            sqlcom.Parameters.Add("@MAMH", SqlDbType.Char, 5);
            sqlcom.Parameters.Add("@LAN", SqlDbType.SmallInt);
            sqlcom.Parameters.Add("@NGAYTHI", SqlDbType.DateTime);
            sqlcom.Parameters.Add("@DIEM", SqlDbType.Float);
            sqlcom.Parameters["@MASV"].Value = Program.username;
            sqlcom.Parameters["@MAMH"].Value = edtMaMH.Text.Trim();
            sqlcom.Parameters["@LAN"].Value = sEdtLanThi.Text.Trim();
            sqlcom.Parameters["@NGAYTHI"].Value = dateEdit1.DateTime.ToString();
            sqlcom.Parameters["@DIEM"].Value = diem;

            try
            {
                sqlcom.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi điểm bài thi " + ex.Message, "Thông báo", MessageBoxButtons.OK);

            }
            finally
            {
                MessageBox.Show("Ghi điểm bài thi thành công ", "Thông báo", MessageBoxButtons.OK);
                Program.con.Close();
            }


        }

        private void showDiem()
        {
            frmKQThi.socau = soCauThi.ToString();
            frmKQThi.soCauDung = soCauDung.ToString();
            frmKQThi.diem = diem.ToString();
            frmKQThi.maMH = edtMaMH.Text;
            frmKQThi.trinhDo = edtTrinhDo.Text;
            frmKQThi.lan = sEdtLanThi.Text.ToString();
            frmKQThi.ngayThi = dateEdit1.DateTime.ToString();
            frmKQThi.thoiGian = edtThoiGian.Text.ToString();
            frmKQThi.maLop = edtMaLop.Text;
            frmKQThi.tenLop = edtTenLop.Text;
          



            this.Close();

            Program.frmKQThi = new frmKQThi();
            Program.frmKQThi.Activate();
            Program.frmKQThi.Show();
        }

        private void xuLiNop()
        {
            timer1.Stop();
            tinhDiem();

            if (Program.mGroup == "SINHVIEN")
            {

                ghiDiemBaiThi();
            }
            panelThi.Visible = false;
            showDiem();
        }

        private void btnNop_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn nộp bài", "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                xuLiNop();
            }
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void gvThi_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (bdsThi.Count > 0 && Program.mGroup.Equals("GIANGVIEN"))
            {

                edtSoCauThi.Text = ((DataRowView)this.bdsThi.Current).Row["SOCAUTHI"].ToString();
                soCauThi = int.Parse(edtSoCauThi.Text.ToString());
                edtMaMH.Text = ((DataRowView)this.bdsThi.Current).Row["MAMH"].ToString();
                edtTenMH.Text = ((DataRowView)this.bdsThi.Current).Row["TENMH"].ToString();
                sEdtLanThi.Value = int.Parse(((DataRowView)this.bdsThi.Current).Row["LAN"].ToString());
                edtNgayThi.Text = ((DataRowView)this.bdsThi.Current).Row["NGAYTHI"].ToString();
                edtThoiGian.Text = ((DataRowView)this.bdsThi.Current).Row["THOIGIAN"].ToString();
                thoiGian = int.Parse(edtThoiGian.Text.ToString());
                edtTrinhDo.Text = ((DataRowView)this.bdsThi.Current).Row["TRINHDO"].ToString();
                btnThi.Visible = true;


            }
            else
            {
                btnThi.Visible = false;
            }

        }
    }
}
