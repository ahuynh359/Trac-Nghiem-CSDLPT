using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace TN
{
    public partial class RptXemDSDangKy : DevExpress.XtraReports.UI.XtraReport
    {
        public RptXemDSDangKy()
        {
            InitializeComponent();
        }

        public RptXemDSDangKy(DateTime from, DateTime to)
        {
            InitializeComponent();
            this.sqlDataSource2.Connection.ConnectionString = Program.conStr;
            this.sqlDataSource2.Queries[0].Parameters[0].Value = from;
            this.sqlDataSource2.Queries[0].Parameters[1].Value = to;
            this.sqlDataSource2.Fill();
        }

    }
}
