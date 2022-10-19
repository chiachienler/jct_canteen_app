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
using CanteenApp;

namespace Test
{
    public partial class Login_Screen : Form
    {

        //public variables for other pages to use.
        public static string EMPNAME, EMPID, PERMISSIONLEVEL;
        public static string mdfFilePath = @"C:\Customer Log\Data.mdf";
        public static string dataSource =     @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = "+mdfFilePath+";Integrated Security = True; Connect Timeout = 30";
        public static SqlConnection con = new SqlConnection(dataSource);
        
        public Login_Screen()
        {
            InitializeComponent();
        }
        
        private void GetTheName(String uname) {
            CheckConnectionState();
            SqlCommand Scmd = new SqlCommand("GetLoginName_ID", con);
            Scmd.CommandType = CommandType.StoredProcedure;

            Scmd.Parameters.Add("@EmployeeID", SqlDbType.VarChar, 50).Value = Username.Text;
            try
            {
                SqlDataReader rdr = Scmd.ExecuteReader();
                if (rdr.Read())
                {
                    //put value into public String EMPID and EMPNAME for other pages to use.
                    EMPID = rdr["a"].ToString();
                    EMPNAME = rdr["b"].ToString();
                    PERMISSIONLEVEL = rdr["c"].ToString();
                }
            }
            catch (Exception) {  }
            finally
            {
                con.Close();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            CheckConnectionState();
            SqlDataAdapter Sdap = new SqlDataAdapter();
            // 1. create a command object identifying
            // the stored procedure
            SqlCommand scmd = new SqlCommand("UserLogin", con);
            // 2. set the command object so it knows
            // to execute a stored procedure
            scmd.CommandType = CommandType.StoredProcedure;
            // 3. add parameter to command, which
            // will be passed to the stored procedure
            scmd.Parameters.Add( "@Username",SqlDbType.VarChar,50).Value = Username.Text;
            scmd.Parameters.Add( "@Password",SqlDbType.VarChar,50).Value = Password.Text;
            Sdap.SelectCommand = scmd;
            
            // creating a virtual table  
            DataTable dt = new DataTable();   
            Sdap.Fill(dt);
            try
            {
                if (dt.Rows[0][0].ToString() == Username.Text)
                {
                    if (dt.Rows[0][3].ToString() == "User      ")
                    {
                        this.GetTheName(Username.Text);
                        /*Hide current page and show Form2*/
                        this.Hide();
                        OrderPage f2 = new OrderPage();
                        f2.ShowDialog();
                    }
                    else if (dt.Rows[0][3].ToString() == "Admin     ")
                    {
                        this.GetTheName(Username.Text);
                        this.Hide();
                        AdminLayout adminform = new AdminLayout();
                        adminform.ShowDialog();
                    }
                }
            }
            catch (Exception )
            { //invalid credentials alert message then focus username textbox
                MessageBox.Show("Invalid username or password");
                Username.Text = "";
                Password.Text = "";
                Username.Focus();
            }
            finally { con.Close(); }
        }

        //focus on password textbox once username textbox reach 8characters
        private void Username_TextChanged(object sender, EventArgs e)
        {
            if (Username.TextLength == 8) { Password.Focus(); }
        }

        private void Login_Screen_Load(object sender, EventArgs e)
        {
                //focus textbox Username
                Username.Focus();
        }

        private void Password_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = button1;
        }

        private void CheckConnectionState()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
                con.Open();
            }
            else
            {
                con.Open();
            }
        }
    }
}
