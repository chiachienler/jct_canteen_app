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
using Microsoft.VisualBasic;
using System.IO;
using Test;

namespace CanteenApp.Layout
{
    public partial class LostNameCard : Form
    {
        
        public LostNameCard()
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------declarations--------------------------------------------------------------------------------
        string LasLosDate, losStatus, initialLostStatus, initialPenalty, penaltyStatus;
        int x;
        Boolean checkedchanged = false;


        //------------------------------------------------------------------------user action event ----------------------------------------------------------------------------
            //page load
        private void LostNameCard_Load(object sender, EventArgs e)
        {
            StatusGroupBox.Enabled = false;
            groupBox1.Enabled = false;
            OpenConnection();
            SqlCommand cmd = new SqlCommand("SelectDistinctCategory",Login_Screen.con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    String Category = reader["EmployeeCategory"].ToString();
                    comboCat.Items.Add(Category);
                }
            }
            catch (Exception) { }

            OpenConnection();
            SqlCommand cmd2 = new SqlCommand("SelectDistinctDepartment", Login_Screen.con);
            cmd2.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlDataReader reader = cmd2.ExecuteReader();
                while (reader.Read())
                {
                    String Department = reader["EmployeeDep"].ToString();
                    comboDep.Items.Add(Department);
                }
            }
            catch (Exception) { }
            Login_Screen.con.Close();

        }


        // cell click show data
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {   //populate datagridview
            if (e.RowIndex >= 0) {
                DataGridViewRow row = this.DataGridView1.Rows[e.RowIndex];
                LBLempID.Text = row.Cells["EmployeeID"].Value.ToString();
                LBLempName.Text = row.Cells["EmployeeName"].Value.ToString();
                try
                {
                    LBLempCategory.Text = row.Cells["EmployeeCategory"].Value.ToString();
                    LBLempDep.Text = row.Cells["EmployeeDep"].Value.ToString();
                    LBLempPos.Text = row.Cells["EmployeePosition"].Value.ToString();
                    LBLlastFoundDate.Text = row.Cells["LastFoundDate"].Value.ToString();
                    LBlasLosDate.Text = row.Cells["LastLostDate"].Value.ToString();
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }

                LBLlostCount.Text = row.Cells["LostCount"].Value.ToString();
                x = int.Parse(row.Cells["LostCount"].Value.ToString());//set value for X
                initialLostStatus = row.Cells["LostStatus"].Value.ToString(); // get initial lost status of user when reading from table
                initialPenalty = row.Cells["Penalty"].Value.ToString(); // get initial penalty status
                //checking radio buttons
                if (row.Cells["LostStatus"].Value.ToString() == "True") 
                {
                    RadMissing.Checked = true;
                    RadNotLost.Checked = false;
                }
                else if (row.Cells["LostStatus"].Value.ToString() == "False")
                {
                    RadNotLost.Checked = true;
                    RadMissing.Checked = false;
                }
                StatusGroupBox.Enabled = true;


                if (row.Cells["Penalty"].Value.ToString() == "True")
                {
                    RADtruePenalty.Checked = true;
                    RADfalsePenalty.Checked = false;
                }
                else if (row.Cells["Penalty"].Value.ToString() == "False")
                {
                    RADtruePenalty.Checked = false;
                    RADfalsePenalty.Checked = true;
                }
                groupBox1.Enabled = true;

                checkedchanged = false;
            }
        }

        //radio button checked changed
        private void RadNotLost_CheckedChanged(object sender, EventArgs e)
        {
            checkedchanged = true; //detect checkedchanges
        }

        private void RADtruePenalty_CheckedChanged(object sender, EventArgs e)
        {
            checkedchanged = true; //detect checkedchanges
        }

        //update status btn
        private void BTNupdateStatus_Click(object sender, EventArgs e)
        {
            if (LBLempID.Text == "") //if user clicked update btn when nothing is selected
            {
                AutoClosingMessageBox.Show("There's nothing to update!", "Please select employee!", 1500);
            } else if (checkedchanged == false) // if employee clicked but no changes made
            {
                AutoClosingMessageBox.Show("No changes made!", "NOT GONNA SAVE!", 1500);
                LBLempID.Text = "";
                LBLempName.Text = "";
                LBLempCategory.Text = "";
                LBLempDep.Text = "";
                LBLempPos.Text = "";
                LBlasLosDate.Text = "";
                LBLlostCount.Text = "";
                LBLlastFoundDate.Text = "";
                RadNotLost.Checked = false;
                RadMissing.Checked = false;
                RADfalsePenalty.Checked = false;
                RADtruePenalty.Checked = false;
                StatusGroupBox.Enabled = false;
                groupBox1.Enabled = false;
            }
            else { //save changes 
                //variables for Date and time.
                String Datetime, date;
                int datelength; // vaviable for date character count.

                Datetime = DateTime.Now.ToString();
                String currentTime = DateTime.Now.TimeOfDay.ToString();
                datelength = Datetime.Length;

                //parse and trim date time into date and time varieble.
                date = Datetime.Substring(0, 10);
                
                LasLosDate = LBlasLosDate.Text;

                if (checkedchanged == true) {  //radio button checkedchanged
                    if (RadNotLost.Checked == true)           //from lost to not lost
                    {
                        losStatus = "False";
                        if (initialLostStatus == "True")     //if found, record let found date 
                        {
                            LBLlastFoundDate.Text = date;
                        }
                    }
                    else if (RadMissing.Checked == true)      //from not lost to lost
                    {
                        losStatus = "True";
                        if (initialLostStatus == "False")     //if originally not lost, lost = lostcount +1 
                        {
                            x = int.Parse(LBLlostCount.Text);
                            x++;                              //increases lost count
                        }
                    }

                    if (RADfalsePenalty.Checked == true)
                    {
                        penaltyStatus = "False";
                    }
                    else if (RADtruePenalty.Checked == true)
                    {
                        penaltyStatus = "True";
                    }  
                }

                //saving into SQL
                //SqlConnection con = new SqlConnection(Login_Screen.dataSource);
                //SqlCommand cmd = new SqlCommand("SELECT * FROM ReportedLost UPDATE ReportedLost SET LostCount = @x, LostStatus = @losStatus, LastLostDate = @date, LastFoundDate = @LastFoundDate, Penalty = @penaltyStatus WHERE EmployeeID = '" + LBLempID.Text + "'", con); con.Open();
                //update lostcount,status,lostdat,founddate.
                OpenConnection();
                SqlCommand cmd = new SqlCommand("UpdateLostStatus", Login_Screen.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@x", SqlDbType.Int).Value= x.ToString();
                cmd.Parameters.Add("@losStatus", SqlDbType.Bit).Value = losStatus;
                cmd.Parameters.Add("@date", SqlDbType.Char).Value = date;
                cmd.Parameters.Add("@LastFoundDate", SqlDbType.Char).Value = LBLlastFoundDate.Text;
                cmd.Parameters.Add("@penaltyStatus",SqlDbType.Bit).Value = penaltyStatus;
                cmd.Parameters.Add("@EmployeeID", SqlDbType.NChar).Value = LBLempID.Text;

                cmd.ExecuteNonQuery();
                Login_Screen.con.Close();
                checkedchanged = false;
                AutoClosingMessageBox.Show("Employee Lost Status updated!", "DONE", 1500);

                //clearing page
                DataGridView1.DataSource = null;

                LBLempID.Text = "";
                LBLempName.Text = "";
                LBLempCategory.Text = "";
                LBLempDep.Text = "";
                LBLempPos.Text = "";
                LBlasLosDate.Text = "";
                LBLlostCount.Text = "";
                LBLlastFoundDate.Text = "";
                RadNotLost.Checked = false;
                RadMissing.Checked = false;
                StatusGroupBox.Enabled = false;
                groupBox1.Enabled = false;
                RADtruePenalty.Checked = false;
                RADfalsePenalty.Checked = false;
            
            }   
        }

//back button key press event
        private void BTNback_Click(object sender, EventArgs e)
        {
            AdminLayout back = new AdminLayout();
            this.Hide();
            back.ShowDialog();
        }

        //search btn key press event
        private void BTNsearch_Click(object sender, EventArgs e)
        {
            DisplaySearch();
        }

 
        

  //---------------------------------------------------------------------------FUNCTIONS PART---------------------------------------------------------------------------------------
        private void DisplaySearch() { //display searched data
            OpenConnection();
            string ID, Cat, Dep;
            ID = TXTempID.Text.PadRight(8);
            Cat = comboCat.Text.PadRight(20);
            Dep = comboDep.Text.PadRight(50);

            //if none of them are filled
            if (TXTempID.Text == "" && TXTempName.Text == "" && comboCat.Text == "" && comboDep.Text == "")
            {
                AutoClosingMessageBox.Show("Please fill in the textboxes to narrow down search.", "Fill 'EM UP!", 1500);
            }
            else if (TXTempID.Text != "") // if employeeID is not empty
            {
                if (TXTempName.Text == "" && comboCat.Text == "" && comboDep.Text == "") //if only employeeID filled
                {
                    try
                    {
                        SqlDataAdapter sda = new SqlDataAdapter();
                    SqlCommand cmd = new SqlCommand("SearchBy_ID", Login_Screen.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@EmployeeID", SqlDbType.NChar).Value = ID;
                    sda.SelectCommand = cmd;
                    DataTable ds = new DataTable();
                    sda.Fill(ds);

                    DataGridView1.DataSource = ds;}
                    catch (Exception) {  }
                }
                else if (TXTempName.Text != "" && comboCat.Text == "" && comboDep.Text == "") // ID and name
                {
                    try
                    {
                        SqlDataAdapter sda = new SqlDataAdapter();
                        SqlCommand cmd = new SqlCommand("SearchBy_ID_Name", Login_Screen.con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@EmpID", SqlDbType.NChar).Value = TXTempID.Text;
                        cmd.Parameters.Add("@EmpName", SqlDbType.NVarChar).Value = TXTempName.Text;
                        sda.SelectCommand = cmd;
                        DataTable ds = new DataTable();
                        sda.Fill(ds);

                        DataGridView1.DataSource = ds;
                    }
                    catch (Exception) {  }
                }
                else if (comboCat.Text != "" && TXTempName.Text == "" && comboDep.Text == "") // ID and catagory
                {
                    try
                    {
                        SqlDataAdapter sda = new SqlDataAdapter();
                        SqlCommand cmd = new SqlCommand("SearchBy_ID_Category", Login_Screen.con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@EmpID", SqlDbType.NChar).Value = TXTempID.Text;
                        cmd.Parameters.Add("@Category", SqlDbType.NChar).Value = comboCat.Text;
                        sda.SelectCommand = cmd;
                        DataTable ds = new DataTable();
                        sda.Fill(ds);

                        DataGridView1.DataSource = ds;
                    }
                    catch (Exception) { }
                }
                else if (comboDep.Text != "" && TXTempName.Text == "" && comboCat.Text == "") // ID and Dep
                {
                    try
                    {
                        SqlDataAdapter sda = new SqlDataAdapter();
                        SqlCommand cmd = new SqlCommand("SearchBy_ID_DEPARTMENT", Login_Screen.con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@EmpID", SqlDbType.NChar).Value = TXTempID.Text;
                        cmd.Parameters.Add("@Dep", SqlDbType.NChar).Value = comboDep.Text;
                        sda.SelectCommand = cmd;
                        DataTable ds = new DataTable();
                        sda.Fill(ds);

                        DataGridView1.DataSource = ds;
                    }
                    catch (Exception) {}
                }
                else if (comboDep.Text != "" && TXTempName.Text != "" && comboCat.Text == "") // ID, Name and Dep
                {
                    try
                    {
                        SqlDataAdapter sda = new SqlDataAdapter();
                        SqlCommand cmd = new SqlCommand("SearchBy_ID_Name_DEPARTMENT", Login_Screen.con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@EmpID", SqlDbType.NChar).Value = TXTempID.Text;
                        cmd.Parameters.Add("@Dep", SqlDbType.NChar).Value = comboDep.Text;
                        cmd.Parameters.Add("@EmpName", SqlDbType.NVarChar).Value = TXTempName.Text;
                        sda.SelectCommand = cmd;
                        DataTable ds = new DataTable();
                        sda.Fill(ds);

                        DataGridView1.DataSource = ds;
                    }
                    catch (Exception) {  }
                }
                else if (comboDep.Text == "" && TXTempName.Text != "" && comboCat.Text != "") // ID, Name and catagory
                {
                    try
                    {
                        SqlDataAdapter sda = new SqlDataAdapter();
                        SqlCommand cmd = new SqlCommand("SearchBy_ID_NAME_CATEGORY", Login_Screen.con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@EmpID", SqlDbType.NChar).Value = TXTempID.Text;
                        cmd.Parameters.Add("@Cat", SqlDbType.NChar).Value = comboCat.Text;
                        cmd.Parameters.Add("@EmpName", SqlDbType.NVarChar).Value = TXTempName.Text;
                        sda.SelectCommand = cmd;
                        DataTable ds = new DataTable();
                        sda.Fill(ds);

                        DataGridView1.DataSource = ds;
                    }
                    catch (Exception) {  }
                }
                else if (comboDep.Text == "" && TXTempName.Text != "" && comboCat.Text != "") // ID, catagory and Dep
                {
                    try
                    {
                        SqlDataAdapter sda = new SqlDataAdapter();
                        SqlCommand cmd = new SqlCommand("SearchBy_ID_DEPARTMENT_CATEGORY", Login_Screen.con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@EmpID", SqlDbType.NChar).Value = TXTempID.Text;
                        cmd.Parameters.Add("@Dep", SqlDbType.NChar).Value = comboDep.Text;
                        cmd.Parameters.Add("@Cat", SqlDbType.NChar).Value = comboCat.Text;
                        sda.SelectCommand = cmd;
                        DataTable ds = new DataTable();
                        sda.Fill(ds);

                        DataGridView1.DataSource = ds;
                    }
                    catch (Exception) { }
                }
                else if (comboDep.Text != "" && TXTempName.Text != "" && comboCat.Text != "") // ALL
                {
                    try
                    {
                        SqlDataAdapter sda = new SqlDataAdapter();
                        SqlCommand cmd = new SqlCommand("SearchBy_ID_NAME_DEPARTMENT_CATEGORY", Login_Screen.con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@EmpID", SqlDbType.NChar).Value = TXTempID.Text;
                        cmd.Parameters.Add("@EmpName", SqlDbType.NVarChar).Value = TXTempName.Text;
                        cmd.Parameters.Add("@Dep", SqlDbType.NChar).Value = comboDep.Text;
                        cmd.Parameters.Add("@Cat", SqlDbType.NChar).Value = comboCat.Text;
                        sda.SelectCommand = cmd;
                        DataTable ds = new DataTable();
                        sda.Fill(ds);

                        DataGridView1.DataSource = ds;
                    }
                    catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                }



            }
            else if (TXTempID.Text == "") // if employeeID is empty
            {
                if (TXTempName.Text != "" && comboCat.Text == "" && comboDep.Text == "") // name
                {
                    try
                    {
                        SqlDataAdapter sda = new SqlDataAdapter();
                        SqlCommand cmd = new SqlCommand("SearchBy_Name", Login_Screen.con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@EmpName", SqlDbType.NVarChar).Value = TXTempName.Text;
                        sda.SelectCommand = cmd;
                        DataTable ds = new DataTable();
                        sda.Fill(ds);

                        DataGridView1.DataSource = ds;
                    }
                    catch (Exception) { }
                }
                else if (comboCat.Text != "" && TXTempName.Text == "" && comboDep.Text == "") // catagory
                {
                    try
                    {
                        SqlDataAdapter sda = new SqlDataAdapter();
                        SqlCommand cmd = new SqlCommand("SearchBy_CATEGORY", Login_Screen.con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Cat", SqlDbType.NChar).Value = comboCat.Text;
                        sda.SelectCommand = cmd;
                        DataTable ds = new DataTable();
                        sda.Fill(ds);

                        DataGridView1.DataSource = ds;
                    }
                    catch (Exception) {  }
                }
                else if (comboDep.Text != "" && TXTempName.Text == "" && comboCat.Text == "") // Dep
                {
                    try
                    {
                        SqlDataAdapter sda = new SqlDataAdapter();
                        SqlCommand cmd = new SqlCommand("SearchBy_DEPARTMENT", Login_Screen.con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Dep", SqlDbType.NChar).Value = comboDep.Text;
                        sda.SelectCommand = cmd;
                        DataTable ds = new DataTable();
                        sda.Fill(ds);

                        DataGridView1.DataSource = ds;
                    }
                    catch (Exception) {  }
                }
                else if (comboDep.Text != "" && TXTempName.Text != "" && comboCat.Text == "") // Name and Dep
                {
                    try
                    {
                        SqlDataAdapter sda = new SqlDataAdapter();
                        SqlCommand cmd = new SqlCommand("SearchBy_NAME_DEPARTMENT", Login_Screen.con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@EmpName", SqlDbType.NVarChar).Value = TXTempName.Text;
                        cmd.Parameters.Add("@Dep", SqlDbType.NChar).Value = comboDep.Text;
                        sda.SelectCommand = cmd;
                        DataTable ds = new DataTable();
                        sda.Fill(ds);

                        DataGridView1.DataSource = ds;
                    }
                    catch (Exception) { }
                }
                else if (comboDep.Text == "" && TXTempName.Text != "" && comboCat.Text != "") // Name and catagory
                {
                    try
                    {
                        SqlDataAdapter sda = new SqlDataAdapter();
                        SqlCommand cmd = new SqlCommand("SearchBy_NAME_CATEGORY", Login_Screen.con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@EmpName", SqlDbType.NVarChar).Value = TXTempName.Text;
                        cmd.Parameters.Add("@Cat", SqlDbType.NChar).Value = comboCat.Text;
                        sda.SelectCommand = cmd;
                        DataTable ds = new DataTable();
                        sda.Fill(ds);

                        DataGridView1.DataSource = ds;
                    }
                    catch (Exception) { }
                }
                else if (comboDep.Text != "" && TXTempName.Text == "" && comboCat.Text != "") // Department and catagory
                {
                    try
                    {
                        SqlDataAdapter sda = new SqlDataAdapter();
                        SqlCommand cmd = new SqlCommand("SearchBy_DEPARTMENT_CATEGORY", Login_Screen.con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Dep", SqlDbType.NChar).Value = comboDep.Text;
                        cmd.Parameters.Add("@Cat", SqlDbType.NChar).Value = comboCat.Text;
                        sda.SelectCommand = cmd;
                        DataTable ds = new DataTable();
                        sda.Fill(ds);

                        DataGridView1.DataSource = ds;
                    }
                    catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                }
                else if (comboDep.Text != "" && TXTempName.Text != "" && comboCat.Text != "") // Name, Dep , catagory
                {
                    try
                    {
                        SqlDataAdapter sda = new SqlDataAdapter();
                        SqlCommand cmd = new SqlCommand("SearchBy_NAME_DEPARTMENT_CATEGORY", Login_Screen.con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@EmpName", SqlDbType.NVarChar).Value = TXTempName.Text;
                        cmd.Parameters.Add("@Dep", SqlDbType.NChar).Value = comboDep.Text;
                        cmd.Parameters.Add("@Cat", SqlDbType.NChar).Value = comboCat.Text;
                        sda.SelectCommand = cmd;
                        DataTable ds = new DataTable();
                        sda.Fill(ds);

                        DataGridView1.DataSource = ds;
                    }
                    catch (Exception) { }
                }
            }
            Login_Screen.con.Close();
        }

        private void OpenConnection() {
            if (Login_Screen.con.State == ConnectionState.Open)
            {
                Login_Screen.con.Close();
                Login_Screen.con.Open();
            }
            else {
                Login_Screen.con.Open();
            }
        }

    }
}
