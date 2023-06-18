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
    public partial class frmTaoTaiKhoan : Form
    {
        public frmTaoTaiKhoan()
        {
            InitializeComponent();
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            Program.subFrmGVChuaDki = new subFrmGVChuaDki();
           
            Program.subFrmGVChuaDki.ShowDialog();
            edtMaUser.Text = Program.subFrmGVChuaDki.maGV;
            edtTenDangNhap.Text = Program.subFrmGVChuaDki.maGV;
        }

        private int checkValidData()
        {
            if (edtTenDangNhap.Text.Trim().Equals(""))
            {
                MessageBox.Show("Thiếu tên đăng nhập nhân viên", "Thông báo", MessageBoxButtons.OK);
                return 0;
            }
            if (edtMaUser.Text.Trim().Equals(""))
            {
                MessageBox.Show("Thiếu mã nhân viên", "Thông báo", MessageBoxButtons.OK);
                return 0;
            }

            if (edtMK.Text.Trim().Equals(""))
            {
                MessageBox.Show("Thiếu mật khẩu", "Thông báo", MessageBoxButtons.OK);
                return 0;
            }

            if (edtXacNhan.Text.Trim().Equals(""))
            {
                MessageBox.Show("Thiếu mật khẩu xác nhận", "Thông báo", MessageBoxButtons.OK);
                return 0;
            }

            if (!edtXacNhan.Text.Equals(edtMK.Text))
            {
                MessageBox.Show("Mật khẩu không khớp với mật khẩu xác nhận", "Thông báo", MessageBoxButtons.OK);
                return 0;
            }
            return 1;
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn muốn tạo tài khoản với \nLogin Name = " + edtTenDangNhap.Text + "\nMã User :" + edtMaUser.Text + "\nVai trò:" + cmbVaiTro.SelectedItem.ToString(), "Thông báo", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                int check = checkValidData();
                if (check == 0) return;

                check = taoTK();
                if (check == 0) return;
                else
                    this.Close();
            }
           

        }

        private int taoTK()
        {

            string sql = "DECLARE @result int " + "EXEC @result = sp_TaoLogin N'" + edtTenDangNhap.Text + "', N'" + edtMK.Text.Trim() + "', N'" + edtMaUser.Text + "', N'" + cmbVaiTro.SelectedItem.ToString() + "'";

            try
            {
                Program.myReader = Program.execSqlDataReader(sql);
                if (Program.myReader == null) return 0; //khong co kq tra ve



                MessageBox.Show("Tạo tài khoản thành công\nLogin Name = " + edtTenDangNhap.Text + "\nMã User :" + edtMaUser.Text + "\nVai trò:" + cmbVaiTro.SelectedItem.ToString(), "", MessageBoxButtons.OK);




            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo tài khoản " + ex.Message, "", MessageBoxButtons.OK);
                return 0;
            }


            return 1;


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHienMK.Checked)
            {
                edtMK.UseSystemPasswordChar = false;
                edtXacNhan.UseSystemPasswordChar = false;
                cbHienMK.Text = "Ẩn MK";
            }
            else
            {
                edtMK.UseSystemPasswordChar = true;
                edtXacNhan.UseSystemPasswordChar = true;
                cbHienMK.Text = "Hiện MK";
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmTaoTaiKhoan_Load(object sender, EventArgs e)
        {
            if (Program.mGroup == "COSO")
            {
                cmbVaiTro.Items.Add("COSO");
                cmbVaiTro.Items.Add("GIANGVIEN");
            }
            else if (Program.mGroup == "TRUONG")
            {
                cmbVaiTro.Items.Add("TRUONG");
                cmbCoSo.Enabled = true;
                cmbCoSo.DataSource = Program.bsDanhSachPhanManh.DataSource;
                cmbCoSo.DisplayMember = "TENCS";
                cmbCoSo.ValueMember = "TENSERVER";
                cmbCoSo.SelectedIndex = Program.mCoSo;
            }
            cmbVaiTro.SelectedIndex = 0;
        }
    }
}
