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
        private string maLop;
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
            DateTime now = new DateTime();
            dateEdit1.DateTime = now;

            if (Program.mGroup == "SINHVIEN")
            {
                groupBoxSV.Visible = true;
                loadInfoSv();
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
            edtMaLop.Text = maLop = Program.myReader.GetValue(0).ToString();
            edtTenLop.Text = Program.myReader.GetValue(1).ToString();
            maLop = edtMaLop.Text.Trim();
            Program.myReader.Close();
            Program.con.Close();
        }

        private void filter()
        {

            string sql = "EXEC sp_LayThongTinThi N'"
                + edtMaLop.Text.ToString().Trim() + "', N'"
                + edtMaMH.Text.ToString().Trim() + "', "
                + sEdtLanThi.Value;

            try
            {
                Program.myReader = Program.execSqlDataReader(sql);
                if (Program.myReader == null)
                {
                    edtTrinhDo.Text = "";
                    edtSoCauThi.Text = "";
                    edtThoiGian.Text = "";
                    btnThi.Visible = false;
                    return;
                }


                Program.myReader.Read();

                edtTrinhDo.Text = Program.myReader.GetString(0);
                soCauThi = Program.myReader.GetInt16(1);
                edtSoCauThi.Text = soCauThi.ToString();
                int thoiGian = Program.myReader.GetInt16(2);
                edtThoiGian.Text = thoiGian.ToString() + ": 00";
                 ngayThi = Program.myReader.GetDateTime(3);
                edtNgayThi.Text = ngayThi.Date.ToShortTimeString();
                btnThi.Visible = true;

                Program.myReader.Close();
                Program.con.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối lấy thông tin thi " + ex.Message, "Thông báo", MessageBoxButtons.OK);

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



        //Kiem tra thi hay chua
        private int checkDaThi()
        {

            int res;
            string sql = "DECLARE @result int " +
           "EXEC @result = sp_KiemTraLanThi '" + Program.maSV + "', N'" + edtMaMH.Text.Trim() + "', " + sEdtLanThi.Value + " SELECT 'Res' = @result";

            try
            {
                Program.myReader = Program.execSqlDataReader(sql);
                if (Program.myReader == null) return 0; //khong co kq tra ve

                Program.myReader.Read();
                res = int.Parse(Program.myReader.GetValue(0).ToString());
                Program.myReader.Close();
                Program.con.Close();

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

        private void loadCauHoi()
        {
            string str = "EXEC sp_LayCauHoi '" + edtMaMH.Text + "', '" + edtTrinhDo.Text + "', " + edtSoCauThi.Text;

            try
            {
                DataTable dt = Program.execSqlDataTable(str);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không thể lấy được đề thi, thiếu đề", "", MessageBoxButtons.OK);
                    return;
                }

                labelTime.Text = edtThoiGian.ToString() + " : 00";
                timer1.Start();

                bdsDeThi.DataSource = dt;

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





                }
                MessageBox.Show(flowDeThi.Controls.Count.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
            finally
            {
                Program.con.Close();
            }


        }

        //Kiem tra dung ngay thi ko
        private int checkNgayThi()
        {

            DateTime today = DateTime.Today;
            return today.CompareTo(ngayThi.Date);

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
                    DialogResult dr = MessageBox.Show("Bạn muốn bắt đầu thi đề thi môn " + edtTenMH.Text + "\nThời gian: " + thoiGian.ToString() + "phút\nLần thi: " + sEdtLanThi.ToString() + " ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.OK)
                    {
                        timer1.Start();
                        groupBoxBaiThi.Enabled = false;
                        loadCauHoi();
                        panelThi.Visible = true;

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
                DialogResult dr = MessageBox.Show("Bạn muốn bắt đầu thi đề thi môn " + edtTenMH.Text + "\nThời gian: " + thoiGian.ToString() + "phút\nLần thi: " + sEdtLanThi.ToString() + " ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    timer1.Start();
                    groupBoxBaiThi.Enabled = false;
                    loadCauHoi();
                    panelThi.Visible = true;

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
                diem = Math.Round((double)(10 * soCauDung) / soCauThi, 2);

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
                //Program.con.Close();
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
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn nộp bài", "", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                xuLiNop();
            }
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            filter();
        }
    }
}
