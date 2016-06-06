using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TimeCardAppLogic;

internal partial class frmMain: Form
{
    internal static List<clsTimeEntry> TimeEntryList = new List<clsTimeEntry>();
    internal static clsTimeEntryList EntryList = new clsTimeEntryList();

    internal static void Main() 
	{
		frmMain main = new frmMain();
		Application.Run(main);
	}

    internal frmMain()
    {
        InitializeComponent();

        btnAdd.Focus();

        clsTimeEntryList.UserID = Environment.UserName;

        txtBeginDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
        txtEndDate.Text = DateTime.Now.ToString("MM/dd/yyyy");

        try
        {
            TimeEntryList = EntryList.GetAllEntries(DateTime.Now.Date, DateTime.Now.Date);
            refreshView();
        }
        catch (Exception ex)
        {
            messageBoxOK(ex.Message);
        }

    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        frmAddUpdate addUpdate = new frmAddUpdate(1, null);
        if (addUpdate.ShowDialog() == DialogResult.OK)
        {
            refreshView();
        }
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            updateLogEntry();
        }
        catch (Exception ex)
        {
            messageBoxOK(ex.Message);
        }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (lvwMain.SelectedIndices.Count == 0)
        {
            messageBoxOK("An entry must be selected before it can be deleted.");
            return;
        }

        if (messageBoxYesNo("Are you sure you want to delete this entry?") == DialogResult.No)
        {
            return;
        }

        ListViewItem item = lvwMain.SelectedItems[0];
        clsTimeEntry entry = (clsTimeEntry)item.Tag;
        try
        {
            EntryList.DeleteEntry(entry);
        }
        catch (Exception ex)
        {
            messageBoxOK(ex.Message);
        }
        finally
        {
            refreshView();
        }
    }

    private void btnAbout_Click(object sender, EventArgs e)
    {
        frmAbout about = new frmAbout();
        about.ShowDialog(this);
    }

    private void lvwMain_DoubleClick(object sender, System.EventArgs e)
    {
        try
        {
            updateLogEntry();
        }
        catch (Exception ex)
        {
            messageBoxOK(ex.Message);
        }
        finally
        {
            refreshView();
        }
    }

    private void updateLogEntry()
    {
        if (lvwMain.SelectedIndices.Count == 0)
        {
            messageBoxOK("An entry must be selected before it can be updated.");
            return;
        }

        ListViewItem item = lvwMain.SelectedItems[0];
        clsTimeEntry entry = (clsTimeEntry)item.Tag;

        try
        {
            frmAddUpdate addUpdate = new frmAddUpdate(2, entry);
            if (addUpdate.ShowDialog() == DialogResult.OK)
            {
                refreshView();
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            refreshView();
        }
    }

    private void refreshView()
    {
        float totalBillableHours = 0;
        float totalUnbillableHours = 0;

        TimeEntryList.Clear();

        DateTime beginDate;

        if (txtBeginDate.Text.Trim().Length == 0)
        {
            txtBeginDate.Text = DateTime.MinValue.ToString("MM/dd/yyyy");
        }

        bool conversion = DateTime.TryParse(txtBeginDate.Text, out beginDate);

        if (conversion == false)
        {
            messageBoxOK("Enter an End Date that is greater than or equal to the Begin date");
            return;
        }

        DateTime endDate;

        if (txtEndDate.Text.Trim().Length == 0)
        {
            txtEndDate.Text = DateTime.MaxValue.ToString("MM/dd/yyyy");
        }

        conversion = DateTime.TryParse(txtEndDate.Text, out endDate);


        if (conversion == false || DateTime.Compare(endDate.Date, beginDate.Date) < 0)
        {
            messageBoxOK("Enter a valid End Date that is greater than or equal to the Begin date");
            return;
        }

        try
        {
            TimeEntryList = EntryList.GetAllEntries(beginDate, endDate);
        }
        catch (Exception ex)
        {
            messageBoxOK(ex.Message);
            return;
        }

        lvwMain.Items.Clear();

        foreach (clsTimeEntry listEntry in TimeEntryList)
        {
            ListViewItem item = new ListViewItem(listEntry.EmployeeID);
            item.SubItems.Add(listEntry.DateWorked.ToShortDateString());
            item.SubItems.Add(listEntry.NumberOfHoursWorked.ToString("0.00"));

            if (listEntry.BillableIndicator == true)
            {
                item.SubItems.Add("Yes");
                totalBillableHours += (float)listEntry.NumberOfHoursWorked;
            }
            else
            {
                item.SubItems.Add("No");
                totalUnbillableHours += (float)listEntry.NumberOfHoursWorked;
            }

            item.SubItems.Add(listEntry.Description);

            // Add the listview item to the collection.

            lvwMain.Items.Add(item);
            item.Tag = listEntry;
        }

        // Update the status bar with the total hours.

        float totalHours = totalBillableHours + totalUnbillableHours;
        lblTotalHours.Text = "Total: " + totalHours.ToString(".00");
        lblTotalBillableHours.Text = "Billable: " + totalBillableHours.ToString(".00");
        lblTotalUnbillableHours.Text = "Unbillable: " + totalUnbillableHours.ToString(".00");
    }

    private void messageBoxOK(string msg)
    {
        MessageBox.Show(msg, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    
    private DialogResult messageBoxYesNo(string msg)
    {
        return MessageBox.Show(msg, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
        refreshView();
    }
}