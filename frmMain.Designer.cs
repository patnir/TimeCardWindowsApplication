﻿public partial class frmMain
{
    #region Windows Form Designer generated code


    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lvwMain = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.lblTotalUnbillableHours = new System.Windows.Forms.Label();
            this.lblTotalBillableHours = new System.Windows.Forms.Label();
            this.lblTotalHours = new System.Windows.Forms.Label();
            this.lblBeginDate = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.txtBeginDate = new System.Windows.Forms.TextBox();
            this.txtEndDate = new System.Windows.Forms.TextBox();
            this.pnlDate = new System.Windows.Forms.Panel();
            this.pnlToolbar.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.pnlDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.Controls.Add(this.btnRefresh);
            this.pnlToolbar.Controls.Add(this.btnAbout);
            this.pnlToolbar.Controls.Add(this.btnDelete);
            this.pnlToolbar.Controls.Add(this.btnUpdate);
            this.pnlToolbar.Controls.Add(this.btnAdd);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 0);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(534, 30);
            this.pnlToolbar.TabIndex = 4;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(329, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(248, 3);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(75, 23);
            this.btnAbout.TabIndex = 7;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(167, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(86, 3);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(5, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lvwMain
            // 
            this.lvwMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvwMain.FullRowSelect = true;
            this.lvwMain.HideSelection = false;
            this.lvwMain.Location = new System.Drawing.Point(0, 66);
            this.lvwMain.Name = "lvwMain";
            this.lvwMain.Size = new System.Drawing.Size(534, 513);
            this.lvwMain.TabIndex = 5;
            this.lvwMain.UseCompatibleStateImageBehavior = false;
            this.lvwMain.View = System.Windows.Forms.View.Details;
            this.lvwMain.DoubleClick += new System.EventHandler(this.lvwMain_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Employee";
            this.columnHeader1.Width = 166;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Date";
            this.columnHeader2.Width = 90;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Hours";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Billable";
            this.columnHeader4.Width = 50;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Description";
            this.columnHeader5.Width = 500;
            // 
            // pnlStatus
            // 
            this.pnlStatus.Controls.Add(this.lblTotalUnbillableHours);
            this.pnlStatus.Controls.Add(this.lblTotalBillableHours);
            this.pnlStatus.Controls.Add(this.lblTotalHours);
            this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlStatus.Location = new System.Drawing.Point(0, 449);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(534, 27);
            this.pnlStatus.TabIndex = 9;
            // 
            // lblTotalUnbillableHours
            // 
            this.lblTotalUnbillableHours.AutoSize = true;
            this.lblTotalUnbillableHours.Location = new System.Drawing.Point(283, 5);
            this.lblTotalUnbillableHours.Name = "lblTotalUnbillableHours";
            this.lblTotalUnbillableHours.Size = new System.Drawing.Size(115, 13);
            this.lblTotalUnbillableHours.TabIndex = 2;
            this.lblTotalUnbillableHours.Text = "lblTotalUnbillableHours";
            // 
            // lblTotalBillableHours
            // 
            this.lblTotalBillableHours.AutoSize = true;
            this.lblTotalBillableHours.Location = new System.Drawing.Point(130, 5);
            this.lblTotalBillableHours.Name = "lblTotalBillableHours";
            this.lblTotalBillableHours.Size = new System.Drawing.Size(102, 13);
            this.lblTotalBillableHours.TabIndex = 1;
            this.lblTotalBillableHours.Text = "lblTotalBillableHours";
            // 
            // lblTotalHours
            // 
            this.lblTotalHours.AutoSize = true;
            this.lblTotalHours.Location = new System.Drawing.Point(3, 5);
            this.lblTotalHours.Name = "lblTotalHours";
            this.lblTotalHours.Size = new System.Drawing.Size(69, 13);
            this.lblTotalHours.TabIndex = 0;
            this.lblTotalHours.Text = "lblTotalHours";
            // 
            // lblBeginDate
            // 
            this.lblBeginDate.AutoSize = true;
            this.lblBeginDate.Location = new System.Drawing.Point(12, 9);
            this.lblBeginDate.Name = "lblBeginDate";
            this.lblBeginDate.Size = new System.Drawing.Size(63, 13);
            this.lblBeginDate.TabIndex = 10;
            this.lblBeginDate.Text = "Begin Date:";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(254, 9);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(55, 13);
            this.lblEndDate.TabIndex = 11;
            this.lblEndDate.Text = "End Date:";
            // 
            // txtBeginDate
            // 
            this.txtBeginDate.Location = new System.Drawing.Point(86, 6);
            this.txtBeginDate.Name = "txtBeginDate";
            this.txtBeginDate.Size = new System.Drawing.Size(100, 20);
            this.txtBeginDate.TabIndex = 12;
            // 
            // txtEndDate
            // 
            this.txtEndDate.Location = new System.Drawing.Point(329, 6);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(100, 20);
            this.txtEndDate.TabIndex = 13;
            // 
            // pnlDate
            // 
            this.pnlDate.Controls.Add(this.lblBeginDate);
            this.pnlDate.Controls.Add(this.txtEndDate);
            this.pnlDate.Controls.Add(this.txtBeginDate);
            this.pnlDate.Controls.Add(this.lblEndDate);
            this.pnlDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDate.Location = new System.Drawing.Point(0, 30);
            this.pnlDate.Name = "pnlDate";
            this.pnlDate.Size = new System.Drawing.Size(534, 30);
            this.pnlDate.TabIndex = 14;
            // 
            // frmMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(534, 476);
            this.Controls.Add(this.pnlDate);
            this.Controls.Add(this.pnlStatus);
            this.Controls.Add(this.lvwMain);
            this.Controls.Add(this.pnlToolbar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Tag = "";
            this.Text = "TimeCard";
            this.pnlToolbar.ResumeLayout(false);
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.pnlDate.ResumeLayout(false);
            this.pnlDate.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel pnlToolbar;
    private System.Windows.Forms.Button btnAbout;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.Button btnUpdate;
    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.ListView lvwMain;
    private System.Windows.Forms.ColumnHeader columnHeader1;
    private System.Windows.Forms.ColumnHeader columnHeader2;
    private System.Windows.Forms.ColumnHeader columnHeader3;
    private System.Windows.Forms.ColumnHeader columnHeader4;
    private System.Windows.Forms.ColumnHeader columnHeader5;
    private System.Windows.Forms.Panel pnlStatus;
    private System.Windows.Forms.Label lblTotalBillableHours;
    private System.Windows.Forms.Label lblTotalHours;
    private System.Windows.Forms.Label lblTotalUnbillableHours;
    private System.Windows.Forms.Button btnRefresh;
    private System.Windows.Forms.Label lblBeginDate;
    private System.Windows.Forms.Label lblEndDate;
    private System.Windows.Forms.TextBox txtBeginDate;
    private System.Windows.Forms.TextBox txtEndDate;
    private System.Windows.Forms.Panel pnlDate;
}