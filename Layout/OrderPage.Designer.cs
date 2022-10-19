using System.Windows.Forms;

namespace Test
{
    partial class OrderPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams {
            get
            {
                CreateParams myCP = base.CreateParams;
                myCP.ClassStyle = myCP.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCP;
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.LblEmpName = new System.Windows.Forms.Label();
            this.TXTName = new System.Windows.Forms.TextBox();
            this.TXTEmpID = new System.Windows.Forms.TextBox();
            this.LblEmpID = new System.Windows.Forms.Label();
            this.LblDate = new System.Windows.Forms.Label();
            this.TXTDate = new System.Windows.Forms.TextBox();
            this.TXTStaffName = new System.Windows.Forms.TextBox();
            this.LblStaffName = new System.Windows.Forms.Label();
            this.LblStaffID = new System.Windows.Forms.Label();
            this.TXTStaffID = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.TXTTime = new System.Windows.Forms.TextBox();
            this.LblTime = new System.Windows.Forms.Label();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.BTNlogout = new System.Windows.Forms.Button();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.BTNdelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaveBtn
            // 
            this.SaveBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SaveBtn.Location = new System.Drawing.Point(1014, 13);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(195, 23);
            this.SaveBtn.TabIndex = 2;
            this.SaveBtn.Text = "Done";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // LblEmpName
            // 
            this.LblEmpName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblEmpName.AutoSize = true;
            this.LblEmpName.Location = new System.Drawing.Point(723, 10);
            this.LblEmpName.Name = "LblEmpName";
            this.LblEmpName.Size = new System.Drawing.Size(84, 13);
            this.LblEmpName.TabIndex = 15;
            this.LblEmpName.Text = "Employee Name";
            // 
            // TXTName
            // 
            this.TXTName.Location = new System.Drawing.Point(813, 3);
            this.TXTName.Name = "TXTName";
            this.TXTName.Size = new System.Drawing.Size(264, 20);
            this.TXTName.TabIndex = 1;
            this.TXTName.TextChanged += new System.EventHandler(this.TXTName_TextChanged);
            // 
            // TXTEmpID
            // 
            this.TXTEmpID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TXTEmpID.Location = new System.Drawing.Point(273, 6);
            this.TXTEmpID.Name = "TXTEmpID";
            this.TXTEmpID.Size = new System.Drawing.Size(264, 20);
            this.TXTEmpID.TabIndex = 0;
            this.TXTEmpID.TextChanged += new System.EventHandler(this.TXTEmpID_TextChanged);
            // 
            // LblEmpID
            // 
            this.LblEmpID.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblEmpID.AutoSize = true;
            this.LblEmpID.Location = new System.Drawing.Point(194, 7);
            this.LblEmpID.Name = "LblEmpID";
            this.LblEmpID.Size = new System.Drawing.Size(67, 13);
            this.LblEmpID.TabIndex = 14;
            this.LblEmpID.Text = "Employee ID";
            // 
            // LblDate
            // 
            this.LblDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblDate.AutoSize = true;
            this.LblDate.Location = new System.Drawing.Point(51, 7);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(30, 13);
            this.LblDate.TabIndex = 9;
            this.LblDate.Text = "Date";
            // 
            // TXTDate
            // 
            this.TXTDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TXTDate.Enabled = false;
            this.TXTDate.Location = new System.Drawing.Point(146, 4);
            this.TXTDate.Name = "TXTDate";
            this.TXTDate.ReadOnly = true;
            this.TXTDate.Size = new System.Drawing.Size(103, 20);
            this.TXTDate.TabIndex = 7;
            // 
            // TXTStaffName
            // 
            this.TXTStaffName.Enabled = false;
            this.TXTStaffName.Location = new System.Drawing.Point(813, 36);
            this.TXTStaffName.Name = "TXTStaffName";
            this.TXTStaffName.ReadOnly = true;
            this.TXTStaffName.Size = new System.Drawing.Size(264, 20);
            this.TXTStaffName.TabIndex = 3;
            // 
            // LblStaffName
            // 
            this.LblStaffName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblStaffName.AutoSize = true;
            this.LblStaffName.Location = new System.Drawing.Point(747, 43);
            this.LblStaffName.Name = "LblStaffName";
            this.LblStaffName.Size = new System.Drawing.Size(60, 13);
            this.LblStaffName.TabIndex = 4;
            this.LblStaffName.Text = "Staff Name";
            // 
            // LblStaffID
            // 
            this.LblStaffID.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblStaffID.AutoSize = true;
            this.LblStaffID.Location = new System.Drawing.Point(218, 7);
            this.LblStaffID.Name = "LblStaffID";
            this.LblStaffID.Size = new System.Drawing.Size(43, 13);
            this.LblStaffID.TabIndex = 5;
            this.LblStaffID.Text = "Staff ID";
            // 
            // TXTStaffID
            // 
            this.TXTStaffID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TXTStaffID.Enabled = false;
            this.TXTStaffID.Location = new System.Drawing.Point(273, 39);
            this.TXTStaffID.Name = "TXTStaffID";
            this.TXTStaffID.ReadOnly = true;
            this.TXTStaffID.Size = new System.Drawing.Size(264, 20);
            this.TXTStaffID.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(941, 520);
            this.dataGridView1.TabIndex = 16;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel8, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel11, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.LblStaffName, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.TXTStaffID, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.TXTStaffName, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.TXTName, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.TXTEmpID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.LblEmpName, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel6, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel7, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1350, 100);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Controls.Add(this.TXTTime, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.LblTime, 0, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(813, 69);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(264, 28);
            this.tableLayoutPanel8.TabIndex = 4;
            // 
            // TXTTime
            // 
            this.TXTTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TXTTime.Enabled = false;
            this.TXTTime.Location = new System.Drawing.Point(146, 4);
            this.TXTTime.Name = "TXTTime";
            this.TXTTime.ReadOnly = true;
            this.TXTTime.Size = new System.Drawing.Size(103, 20);
            this.TXTTime.TabIndex = 6;
            // 
            // LblTime
            // 
            this.LblTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblTime.AutoSize = true;
            this.LblTime.Location = new System.Drawing.Point(51, 7);
            this.LblTime.Name = "LblTime";
            this.LblTime.Size = new System.Drawing.Size(30, 13);
            this.LblTime.TabIndex = 8;
            this.LblTime.Text = "Time";
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 2;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.Controls.Add(this.TXTDate, 1, 0);
            this.tableLayoutPanel11.Controls.Add(this.LblDate, 0, 0);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(543, 69);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 1;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(264, 28);
            this.tableLayoutPanel11.TabIndex = 7;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.LblEmpID, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(264, 27);
            this.tableLayoutPanel6.TabIndex = 16;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.LblStaffID, 1, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 36);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(264, 27);
            this.tableLayoutPanel7.TabIndex = 17;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 100);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 529);
            this.tableLayoutPanel2.TabIndex = 18;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(1150, 100);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(200, 529);
            this.tableLayoutPanel3.TabIndex = 19;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.Controls.Add(this.SaveBtn, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.BTNlogout, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.BTNdelete, 2, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 629);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1350, 100);
            this.tableLayoutPanel4.TabIndex = 20;
            // 
            // BTNlogout
            // 
            this.BTNlogout.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.BTNlogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNlogout.Location = new System.Drawing.Point(143, 13);
            this.BTNlogout.Name = "BTNlogout";
            this.BTNlogout.Size = new System.Drawing.Size(191, 23);
            this.BTNlogout.TabIndex = 11;
            this.BTNlogout.Text = "Logout";
            this.BTNlogout.UseVisualStyleBackColor = true;
            this.BTNlogout.Click += new System.EventHandler(this.BTNlogout_Click);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(200, 100);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(950, 529);
            this.tableLayoutPanel5.TabIndex = 21;
            // 
            // BTNdelete
            // 
            this.BTNdelete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BTNdelete.Location = new System.Drawing.Point(745, 13);
            this.BTNdelete.Name = "BTNdelete";
            this.BTNdelete.Size = new System.Drawing.Size(195, 23);
            this.BTNdelete.TabIndex = 12;
            this.BTNdelete.Text = "Delete";
            this.BTNdelete.UseVisualStyleBackColor = true;
            this.BTNdelete.Click += new System.EventHandler(this.BTNdelete_Click);
            // 
            // OrderPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.tableLayoutPanel5);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimizeBox = false;
            this.Name = "OrderPage";
            this.Text = "Order";
            this.Load += new System.EventHandler(this.OrderPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel11.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Label LblEmpName;
        private System.Windows.Forms.TextBox TXTName;
        private System.Windows.Forms.TextBox TXTEmpID;
        private System.Windows.Forms.Label LblEmpID;
        private System.Windows.Forms.Label LblDate;
        private System.Windows.Forms.TextBox TXTDate;
        private System.Windows.Forms.TextBox TXTStaffName;
        private System.Windows.Forms.Label LblStaffName;
        private System.Windows.Forms.Label LblStaffID;
        private System.Windows.Forms.TextBox TXTStaffID;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.TextBox TXTTime;
        private System.Windows.Forms.Label LblTime;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private Button BTNlogout;
        private Button BTNdelete;
    }
}