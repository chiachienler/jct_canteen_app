using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CanteenApp.Layout;
using Test;

namespace CanteenApp
{
    public partial class AdminLayout : Form
    {
        public AdminLayout()
        {
            InitializeComponent();
        }

        private void BTNexportExcel_Click(object sender, EventArgs e)
        {
            ExportExcel ex = new ExportExcel();
            this.Hide();
            ex.ShowDialog();
        }

        private void BTNcardLost_Click(object sender, EventArgs e)
        {
            LostNameCard lnc = new LostNameCard();
            this.Hide();
            lnc.ShowDialog();

        }

        private void BTNLogout_Click(object sender, EventArgs e)
        {
            Login_Screen loginScreen = new Login_Screen();
            this.Hide();
            loginScreen.ShowDialog();
        }
    }
}
