using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Test;

namespace CanteenApp.Layout
{
    public partial class DeleteUserForm : Form
    {
        public DeleteUserForm()
        {
            InitializeComponent();
        }

        private void TXTempID_TextChanged(object sender, EventArgs e)
        {
            if (TXTempID.Text.Length == 8)
            {
                TXTempName.Focus();
            }
        }

        private void TXTempName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Login_Screen.con.State == ConnectionState.Open)
                {
                    Login_Screen.con.Close();
                }
                Login_Screen.con.Open();
                SqlCommand cmd = new SqlCommand("DeleteUser", Login_Screen.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Employee_ID", SqlDbType.NChar, 8).Value = TXTempID.Text;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = int.Parse(OrderPage.getID);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    Login_Screen.con.Close();
                }
                finally
                {
                    MessageBox.Show("Entry Deleted!", "Deleted!");
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Please select the Entry you want to delete and input correct Employee ID!", "ERROR!");
            }

        }
    }
}
