using System;
using System.Collections.Generic;
using System.Windows.Forms;

public partial class frmMain: Form
{
	public static void Main() 
	{
		frmMain main = new frmMain();
		Application.Run(main);
	}

    // The list and file where log entries are stored.

    private clsTimeEntryList mTimeEntryListObject = new clsTimeEntryList();

    public frmMain()
    {
        InitializeComponent();

        try
        {
            mTimeEntryListObject.GetAllEntries();
            refreshView();
        }
        catch (Exception ex)
        {
            msgException(ex);
        } 
    }

    private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
    {
        /*try
        {
            mTimeEntryListObject.SaveList();
        }
        catch (Exception ex)
        {
            msgException(ex);
        }*/
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            frmAddUpdate addUpdate = new frmAddUpdate(1, null);
            if (addUpdate.ShowDialog() == DialogResult.OK)
            {
                mTimeEntryListObject.AddEntry(addUpdate.Entry);
                refreshView();
            }
        }
        catch (Exception ex)
        {
            messageBoxOK(ex.Message);
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
            msgException(ex);
        }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            deleteLogEntry();
        }
        catch (Exception ex)
        {
            msgException(ex);
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

        frmAddUpdate addUpdate = new frmAddUpdate(2, entry);
        if (addUpdate.ShowDialog() == DialogResult.OK)
        {
            mTimeEntryListObject.UpdateEntry(addUpdate.Entry);
            refreshView();
        }
    }

    private void deleteLogEntry()
    {
        // Make sure an item is selected in the list.

        if (lvwMain.SelectedIndices.Count == 0)
        {
            messageBoxOK("An entry must be selected before it can be deleted.");
            return;
        }

        // Prompt the user for confirmation.

        if (messageBoxYesNo("Are you sure you want to delete this entry?") == DialogResult.No)
        {
            return;
        }

        ListViewItem item = lvwMain.SelectedItems[0];
        clsTimeEntry entry = (clsTimeEntry)item.Tag;

        mTimeEntryListObject.DeleteEntry(entry);

        refreshView();
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
        refreshView();
    }

    private void refreshView()
    {
        float totalBillableHours = 0;
        float totalUnbillableHours = 0;
        List<clsTimeEntry> entryList = new List<clsTimeEntry>();

        entryList = mTimeEntryListObject.GetAllEntries();
        lvwMain.Items.Clear();

        foreach (clsTimeEntry entry in entryList)
        {
            // Create the new listview item.

            ListViewItem item = new ListViewItem(entry.EmployeeID);
            item.SubItems.Add(entry.DateWorked.ToShortDateString());
            item.SubItems.Add(entry.NumberOfHoursWorked.ToString("0.00"));

            if (entry.BillableIndicator == true)
            {
                item.SubItems.Add("Yes");
                totalBillableHours += entry.NumberOfHoursWorked;
            }
            else
            {
                item.SubItems.Add("No");
                totalUnbillableHours += entry.NumberOfHoursWorked;
            }

            item.SubItems.Add(entry.Description);

            // Add the listview item to the collection.

            lvwMain.Items.Add(item);

            item.Tag = entry;
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

    private static void msgException(Exception ex)
    {
        MessageBox.Show(ex.Message, "Exception Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}

