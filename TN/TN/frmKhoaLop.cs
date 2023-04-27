using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TN
{
    public partial class frmKhoaLop : DevExpress.XtraEditors.XtraForm
    {
       
        public frmKhoaLop()
        {
            InitializeComponent();
        }

        private void kHOABindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsKhoa.EndEdit();
            this.khoaTableAdapterManager.UpdateAll(this.DS);

        }

        private void frmKhoaLop_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DS.LOP' table. You can move, or remove it, as needed.
            this.lopTableAdapter.Fill(this.DS.LOP);
            // TODO: This line of code loads data into the 'tNDataSet.KHOA' table. You can move, or remove it, as needed.
            this.khoaTableAdapter.Fill(this.DS.KHOA);

    
        }
    
    }
}