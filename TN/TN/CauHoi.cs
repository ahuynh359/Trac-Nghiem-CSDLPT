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

namespace TN
{
    public partial class CauHoi : UserControl
    {
        public CauHoi()
        {
            InitializeComponent();
        }

        private int idCauHoi;
        private int cauSo;
        private string noiDung;
        private string cauA;
        private string cauB;
        private string cauC;
        private string cauD;
        private string daChon = "";
        private string dapAn = "";



        public int IdCauHoi { get => idCauHoi; set => idCauHoi = value; }
        public int CauSo { get => cauSo; set { cauSo = value; labelCauSo.Text = "Câu " + cauSo + ":"; } }
        public string NoiDung { get => noiDung; set { noiDung = value; labelNoiDung.Text = noiDung; } }
        public string CauA { get => cauA; set { cauA = value; rbA.Text = cauA; } }
        public string CauB { get => cauB; set { cauB = value; rbB.Text = cauB; } }
        public string CauC { get => cauC; set { cauC = value; rbC.Text = cauC; } }
        public string CauD { get => cauD; set { cauD = value; rbD.Text = cauD; } }
        public string DaChon { get => daChon; set => daChon = value; }
        public string DapAn { get => dapAn; set => dapAn = value; }

        private void rbA_CheckedChanged(object sender, EventArgs e)
        {
            daChon = "A";
            onRadioButtonChange("A");
        }

        private void rbB_CheckedChanged(object sender, EventArgs e)
        {
            daChon = "B";
         
            onRadioButtonChange("B");

        }

        private void rbC_CheckedChanged(object sender, EventArgs e)
        {
            daChon = "C";
            onRadioButtonChange("C");

        }

        private void rbD_CheckedChanged(object sender, EventArgs e)
        {
            daChon = "D";
            onRadioButtonChange("D");

        }

        private void onRadioButtonChange(string chon)
        {

            string[] arr = new string[2];
            arr[0] = "Câu " + cauSo;
            arr[1] = chon;

            ListViewItem item = new ListViewItem(arr);
            item.ForeColor = Color.Green;
            Program.frmThi.listViewDaChon.Items[cauSo - 1] = item;

        }



    }
}