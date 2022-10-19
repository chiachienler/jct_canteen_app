using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CanteenApp;
using Test;
using System.Data.SqlClient;
using Syncfusion.XlsIO;
using System.IO;

namespace CanteenApp.Layout
{
    public partial class ExportExcel : Form
    {
        //String day, month, year;
        DataTable dt = new DataTable();
        string PreviousMonth, SelectedMonth,y;

        public ExportExcel()
        {
            InitializeComponent();
            ComboMonthRange();
            ComboYear();
        }
        // export excel reference :
        //          https://www.syncfusion.com/blogs/post/6-easy-ways-to-export-data-to-excel-in-c-sharp.aspx
        //via ADO.NET
        private void ExportExcel_Load(object sender, EventArgs e)
        {

        }



        private void BTNreturn_Click(object sender, EventArgs e)
        {
            AdminLayout back = new AdminLayout();
            this.Hide();
            back.ShowDialog();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DirectSearch();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DirectSearch();
        }
        private void ComboMonthRange()
        {
            //SqlCommand cmd = new SqlCommand("SELECT DISTINCT Month FROM Customer_Log", Login_Screen.con);
            SqlCommand cmd = new SqlCommand("ShowMonthRange", Login_Screen.con);
            OpenConnection();
            cmd.CommandType = CommandType.StoredProcedure;


            try
            {
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    String Month = reader["MonthRange"].ToString();
                    comboBox1.Items.Add(Month);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            Login_Screen.con.Close();

        }

        private void ComboYear() 
        {
            SqlCommand cmd = new SqlCommand("GetYear", Login_Screen.con);
            cmd.CommandType = CommandType.StoredProcedure;
            OpenConnection();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) 
                {
                    string getyear = reader["GetYear"].ToString();
                    comboBox2.Items.Add(getyear);
                }
            }
            catch (Exception) { }
        }


        /*
        private void BTNexportThisMonth_Click(object sender, EventArgs e)
        {
            string DateTaim = DateTime.Now.ToString("yyyy-MM-dd");
            string combi = comboBox1.Text + " exported on " + DateTaim; 
            if (comboBox1.Text == "" || comboBox2.Text == "")
            {
                MessageBox.Show("Please select a date!", "NO WAY!");
            }
            else
            {
                
                DataTable tempTable = dt;

                using (ExcelEngine excelengine = new ExcelEngine())
                {
                    IApplication IApp = excelengine.Excel;
                    //create excel workbook with single worksheet.
                    IWorkbook workbook = IApp.Workbooks.Create(1);
                    IWorksheet worksheet = workbook.Worksheets[0];

                    //import from DataGridView
                    worksheet.ImportDataGridView(dataGridView1, 1, 1, isImportHeader: true, isImportStyle: true);
                    worksheet.UsedRange.AutofitColumns();
                    //workbook.SaveAs("Customer '"+comboBox1.Text+"'.xlsx");
                    
                    Stream excelStream = File.Create(Path.GetFullPath(@"C:\Customer Log\Customer " + combi+".xlsx"));
                    workbook.SaveAs(excelStream);
                    excelStream.Dispose();
                    MessageBox.Show("File exported!", "Done!", MessageBoxButtons.OK);

                }
            }
        }*/



        private void BTNexportAll_Click(object sender, EventArgs e)
        {
            DialogResult result =  MessageBox.Show("Export full customer log?","Export All?",MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                OpenConnection();
                SqlDataAdapter adp = new SqlDataAdapter();
                //SqlCommand cmd = new SqlCommand("SELECT Id, Date, Time, Staff_ID, Staff_Name, Employee_ID, Employee_Name, Charge FROM Customer_Log", Login_Screen.con);
                SqlCommand cmd = new SqlCommand("ExportAllCustomer", Login_Screen.con);
                cmd.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand = cmd;
                DataTable table = new DataTable();
                adp.Fill(table);
                dataGridView1.DataSource = table;
                Login_Screen.con.Close();

                DialogResult reconfirmation =  AutoClosingMessageBox.Show("Log will be exported in 5 seconds, are you sure to export all customer log since beginning.", "Reconfirmation", 5000, MessageBoxButtons.YesNo);
                if (reconfirmation == DialogResult.Yes)
                {
                    using (ExcelEngine excelengine = new ExcelEngine())
                    {
                        IApplication IApp = excelengine.Excel;

                        //create excel workbook with single worksheet.
                        IWorkbook workbook = IApp.Workbooks.Create(1);
                        IWorksheet worksheet = workbook.Worksheets[0];

                        //import from DataGridView
                        worksheet.ImportDataGridView(dataGridView1, 1, 1, isImportHeader: true, isImportStyle: true);
                        worksheet.UsedRange.AutofitColumns();
                        //workbook.SaveAs("Customer '"+comboBox1.Text+"'.xlsx");
                        Stream excelStream = File.Create(Path.GetFullPath(@"C:\Customer Log\Full Customer Log.xlsx"));
                        workbook.SaveAs(excelStream);
                        excelStream.Dispose();
                        MessageBox.Show("File exported!", "Done!", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void OpenConnection() 
        {
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

        private void button1_Click(object sender, EventArgs e)
        {
            string DateTaim = DateTime.Now.ToString("yyyy-MM-dd");
            string combi = comboBox1.Text + " exported on " + DateTaim;
            if (comboBox1.Text == "" || comboBox2.Text == "")
            {
                MessageBox.Show("Please select a date!", "NO WAY!");
            }
            else
            {

                DataTable tempTable = dt;

                using (ExcelEngine excelengine = new ExcelEngine())
                {
                    IApplication IApp = excelengine.Excel;
                    //create excel workbook with single worksheet.
                    IWorkbook workbook = IApp.Workbooks.Create(1);
                    IWorksheet worksheet = workbook.Worksheets[0];

                    //import from DataGridView
                    worksheet.ImportDataGridView(dataGridView1, 1, 1, isImportHeader: true, isImportStyle: true);
                    worksheet.UsedRange.AutofitColumns();
                    //workbook.SaveAs("Customer '"+comboBox1.Text+"'.xlsx");

                    Stream excelStream = File.Create(Path.GetFullPath(@"C:\Customer Log\Customer " + combi + ".xlsx"));
                    workbook.SaveAs(excelStream);
                    excelStream.Dispose();
                    MessageBox.Show("File exported!", "Done!", MessageBoxButtons.OK);
                }
            }
        }
        private void DirectSearch() {
            try
            {
                if (comboBox1.Text == "" || comboBox2.Text == "") { }
                else
                {
                    PreviousMonth = comboBox1.Text.Substring(0, 3);
                    SelectedMonth = comboBox1.Text.Substring(8, 3);
                    PreviousMonth = CheckMonth(PreviousMonth);
                    SelectedMonth = CheckMonth(SelectedMonth);
                    OpenConnection();
                    SqlDataAdapter adp = new SqlDataAdapter();
                    SqlCommand cmd = new SqlCommand("dbo.SP_Pivot", Login_Screen.con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SelectedMonth", SqlDbType.Char, 2).Value = SelectedMonth;
                    cmd.Parameters.Add("@CutOffMonth", SqlDbType.Char, 2).Value = PreviousMonth;
                    cmd.Parameters.Add("@SelectedYear", SqlDbType.Char, 4).Value = comboBox2.Text;
                    cmd.Parameters.Add("@NewYear", SqlDbType.Char, 4).Value = comboBox2.Text;
                    adp.SelectCommand = cmd;
                    DataTable table = new DataTable();
                    adp.Fill(table);
                    dataGridView1.DataSource = table;
                    dt = table;
                    Login_Screen.con.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        public String CheckMonth(String x) 
        {
            switch (x)
            {
                case "Jan" :
                    y = "01"; return y;
                case "Feb" :
                    y =  "02"; return y;
                case "Mar" :
                    y =  "03";return y;
                case "Apr" :
                    y =  "04";return y;
                case "May" :
                    y =  "05";return y;
                case "Jun" :
                    y =  "06";return y;
                case "Jul" :
                    y =  "07";return y;
                case "Aug" :
                    y =  "08";return y;
                case "Sep" :
                    y =  "09";return y;
                case "Oct" :
                    y =  "10";return y;
                case "Nov" :
                    y =  "11";return y;
                case "Dec" :
                    y =  "12";return y;
                default:
                    return y;
                   
            }
        }

    }
}
