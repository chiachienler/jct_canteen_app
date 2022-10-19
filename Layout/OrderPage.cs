using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data.OleDb;
using Microsoft.VisualBasic;
using System.IO;
using CanteenApp.Layout;

namespace Test
{

    public partial class OrderPage : Form
    {

        //path of excel xlsx file
        public string path = @"C:\CUSTOMER LOG\Customer Log.xlsx";
        public static String EmpID, EmpName, thisDate, thisTime, thisTotal, staffID, staffName, PenaltyStatus, getID;
        bool isBlocked;


        //some user experience shyt
        private void TXTName_TextChanged(object sender, EventArgs e)
        {
            if (TXTName.Text == "") { TXTEmpID.Focus(); }

            this.AcceptButton = SaveBtn;
        }

        private void TXTEmpID_TextChanged(object sender, EventArgs e)
        {
            if (TXTEmpID.Text.Length == 8)
            {
                TXTName.Focus();
            }
        }


        //---------------------------------------------------------------ACTION CODES--------------------------------------------------------------------

        public OrderPage()
        {
            InitializeComponent();
        }

        private void BTNdelete_Click(object sender, EventArgs e)
        {
            DeleteUserForm Del = new DeleteUserForm();
            Del.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                getID = row.Cells["Id"].Value.ToString();
            }
        }

        private void OrderPage_Load(object sender, EventArgs e)
        {
            Timer Timerr = new Timer();
            Timerr.Interval = (60 * 1000);
            Timerr.Tick += new EventHandler(EventTimer);
            Timerr.Start();

            //variables for Date and time.
            String Datetime, date, time;
            int datelength; // vaviable for date character count.

            Datetime = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt");
            String currentTime = DateTime.Now.TimeOfDay.ToString();
            datelength = Datetime.Length;
            //MessageBox.Show(datelength.ToString());
            //parse and trim date time into date and time varieble.
            date = Datetime.Substring(0, 12);
            time = currentTime.Substring(0, 5);

            //write date and time into textbox
            TXTDate.Text = date;
            TXTTime.Text = time;
            //write staff ID, staff Name accroding to connection string from Login_Screen
            TXTStaffID.Text = "-";//Login_Screen.EMPID;
            TXTStaffName.Text = "-";//Login_Screen.EMPNAME;

            DisplaySQL();
        }

        private void BTNlogout_Click(object sender, EventArgs e)
        {
            //confirm and exit 
            DialogResult Result = MessageBox.Show("Confirm to Logout this user?", "Logout?", MessageBoxButtons.YesNo);

            if (Result == DialogResult.Yes)
            {
                Login_Screen ls = new Login_Screen();
                this.Hide();
                ls.ShowDialog();
            }
        }

        //save btn
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            EmpID = TXTEmpID.Text;
            EmpName = TXTName.Text;
            thisDate = TXTDate.Text;
            thisTime = TXTTime.Text;
            staffID = TXTStaffID.Text;
            staffName = TXTStaffName.Text;
            Boolean numeric = EmpName.Any(char.IsDigit);
            
            //error message for empty txtbox.
            if (TXTName.Text == "" || TXTEmpID.Text == "")
            {
                MessageBox.Show("PLEASE SCAN QR or BARCODE", "ERROR!");
                DisplaySQL();
            }
            else if( numeric == true)
            {
                MessageBox.Show("PLEASE SCAN AGAIN!", "ERROR!");
                DisplaySQL();
            }
            else
            {
                SQLsave();
                DisplaySQL();
            }
        }

        //------------------------------------------------------FUNCTIONS----------------------------------------------------
        private void DisplaySQL()
        {//display SQL Data to DataGridView
            CheckConnectionState();
            SqlCommand scmd = new SqlCommand("DisplayAllCustomers", Login_Screen.con);
            scmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter Sda = new SqlDataAdapter();
            Sda.SelectCommand = scmd;
            DataSet FillDataGridView = new DataSet();
            Sda.Fill(FillDataGridView);
            dataGridView1.DataSource = FillDataGridView.Tables[0];
            dataGridView1.Sort(dataGridView1.Columns["Id"], ListSortDirection.Descending);

            TXTEmpID.Text = "";
            TXTName.Text = "";
            TXTEmpID.Focus();
            dataGridView1.Update();
            dataGridView1.Refresh();
            Login_Screen.con.Close();
        }

        private void EventTimer(object sender, EventArgs e)
        {
            //variables for Date and time.
            String Datetime, date, time;
            int datelength; // vaviable for date character count.

            Datetime = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt");
            String currentTime = DateTime.Now.TimeOfDay.ToString();
            datelength = Datetime.Length;

            //parse and trim date time into date and time varieble.
            date = Datetime.Substring(0, 12);
            time = currentTime.Substring(0, 5);

            //write date and time into textbox
            TXTDate.Text = date;
            TXTTime.Text = time;
            //write staff ID, staff Name accroding to connection string from Login_Screen
            TXTStaffID.Text = "-";// Login_Screen.EMPID;
            TXTStaffName.Text = "-";// Login_Screen.EMPNAME;

            DisplaySQL();
        }

        //save to SQL database
        private void SQLsave()
        {
            CheckPenalty();
            int? LastID;
            bool x;
            CheckConnectionState();

            try //get last ID
            {
                SqlCommand cmd = new SqlCommand("FindMaxID", Login_Screen.con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader datareader = cmd.ExecuteReader();
                if (datareader.Read())
                {

                    int number;
                    x = int.TryParse(datareader["a"].ToString(), out number);
                    if (x == true)
                    {
                        LastID = int.Parse(datareader["a"].ToString());
                        LastID++;

                        Login_Screen.con.Close();
                        //write into Database
                        SqlCommand insertCmd = new SqlCommand("AddNewCustomerData", Login_Screen.con);
                        insertCmd.CommandType = CommandType.StoredProcedure;
                        insertCmd.Parameters.Add("@Id", SqlDbType.Int).Value = LastID;
                        insertCmd.Parameters.Add("@Date", SqlDbType.Char, 10).Value = TXTDate.Text;
                        insertCmd.Parameters.Add("@Time", SqlDbType.Char, 10).Value = TXTTime.Text;
                        insertCmd.Parameters.Add("@Staff_ID", SqlDbType.NChar, 8 ).Value = TXTStaffID.Text;
                        insertCmd.Parameters.Add("@Staff_Name", SqlDbType.NVarChar, 50).Value = TXTStaffName.Text;
                        insertCmd.Parameters.Add("@Employee_ID", SqlDbType.NChar, 8).Value = TXTEmpID.Text;
                        insertCmd.Parameters.Add("@Employee_Name", SqlDbType.NVarChar, 50 ).Value = TXTName.Text;
                        insertCmd.Parameters.Add("@Month", SqlDbType.Char, 10 ).Value = DateTime.Now.ToString("yyyy-MM");
                        if (PenaltyStatus == "True")
                        {
                            insertCmd.Parameters.Add("@Charge", SqlDbType.Int).Value = "2";
                        }
                        else
                        {
                            insertCmd.Parameters.Add("@Charge", SqlDbType.Int).Value = "1";
                        }
  
                        insertCmd.Parameters.Add("@IsBlocked", SqlDbType.Bit).Value = isBlocked;

                        CheckConnectionState();
                        insertCmd.ExecuteNonQuery();
                    }
                    else if (x == false)
                    {
                        LastID = 1;
                        //write into Database
                        SqlCommand insertCmd = new SqlCommand("AddNewCustomerData", Login_Screen.con); 
                        if (LastID == null)
                        {
                            insertCmd.Parameters.Add("@Id", SqlDbType.Int).Value = 1;
                        }
                        insertCmd.Parameters.AddWithValue("@Id", LastID);
                        insertCmd.Parameters.AddWithValue("@Date", TXTDate.Text);
                        insertCmd.Parameters.AddWithValue("@Time", TXTTime.Text);
                        insertCmd.Parameters.AddWithValue("@Staff_ID", TXTStaffID.Text);
                        insertCmd.Parameters.AddWithValue("@Staff_Name", TXTStaffName.Text);
                        insertCmd.Parameters.AddWithValue("@Employee_ID", TXTEmpID.Text);
                        insertCmd.Parameters.AddWithValue("@Employee_Name", TXTName.Text);
                        insertCmd.Parameters.AddWithValue("@Month", DateTime.Now.ToString("yyyy-MM"));
                        if (PenaltyStatus == "True")
                        {
                            insertCmd.Parameters.Add("@Charge", SqlDbType.Int).Value = "2";
                        }
                        else if (PenaltyStatus == "False")
                        {
                            insertCmd.Parameters.Add("@Charge", SqlDbType.Int).Value = "1";
                        }

                        insertCmd.Parameters.Add("@IsBlocked", SqlDbType.Bit).Value = isBlocked;
                        CheckConnectionState();
                        insertCmd.ExecuteNonQuery();
                    }
  
  
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            finally
            {
                isBlocked = false;
                Login_Screen.con.Close();
            }
        
        }

        private void CheckPenalty() // Check customer blocked or has penalty
        {
            CheckConnectionState();
            SqlCommand cmd = new SqlCommand("CheckIsBlocked_and_PenaltyStatus", Login_Screen.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Emp_ID", SqlDbType.NChar, 8).Value = TXTEmpID.Text;

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            try
            {
                if (dt.Rows[0][0].ToString().Trim() == "true" || dt.Rows[0][0].ToString().Trim() == "True")
                {
                    MessageBox.Show("THIS EMPLOYEE ID HAS BEEN BLOCKED DUE TO CARD LOST REPORTED! PLEASE KINDLY ASK THE EMPLOYEE TO SEEK SUPPORT FROM MANAGEMENT TEAM!", "CARD REPORTED LOST", MessageBoxButtons.OK);
                    isBlocked = true;
                }
                else if (dt.Rows[0][0].ToString().Trim() == "false" || dt.Rows[0][0].ToString().Trim() == "False")
                {
                    isBlocked = false;
                    //do save new row of data
                }

                if (dt.Rows[0][1].ToString().Trim() == "True" || dt.Rows[0][1].ToString().Trim() == "true")
                {
                    PenaltyStatus = "True";
                }
                else
                {
                    PenaltyStatus = "False";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("User not yet registered into the Database, Please kindly note down his/her NAME and EMPLOYEE NUMBER and inform management team","CAUTION!",MessageBoxButtons.OK);
                isBlocked = true;
            }
            finally
            {
                Login_Screen.con.Close();
            }
        }

        private void CheckConnectionState() {
            if (Login_Screen.con.State == ConnectionState.Open)
            {
                Login_Screen.con.Close();
                Login_Screen.con.Open();
            }
            else
            {
                Login_Screen.con.Open();
            }
        }
    }
}
