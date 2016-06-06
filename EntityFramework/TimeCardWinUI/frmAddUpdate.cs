using System;
using System.Windows.Forms;
using TimeCardAppLogic;

internal partial class frmAddUpdate: Form
{
	private byte mMode;
    internal clsTimeEntryList EntryList;
    internal clsTimeEntry TimeEntryData = new clsTimeEntry();

    internal frmAddUpdate(byte mode, clsTimeEntry entry)
	{
        InitializeComponent();

        EntryList = frmMain.EntryList;
		mMode = mode;

		if (mode == 1)
		{
			Text = "Add";
        }
		else
		{
			Text = "Update";

            TimeEntryData = entry;
			txtEmployeeID.Text = entry.EmployeeID;
			txtDateWorked.Text = entry.DateWorked.ToShortDateString();
			cboHoursWorked.Text = entry.NumberOfHoursWorked.ToString("#.00");
			chkBillable.Checked = entry.BillableIndicator;
			txtDescription.Text = entry.Description;
		}
	}

	private void btnOK_Click(object sender, System.EventArgs e)
	{
		if (validateForm() == false)
		{
			return;
		}

        TimeEntryData.EmployeeID = txtEmployeeID.Text;
        TimeEntryData.DateWorked = DateTime.Parse(txtDateWorked.Text);
        TimeEntryData.NumberOfHoursWorked = double.Parse(cboHoursWorked.Text);
        TimeEntryData.BillableIndicator = chkBillable.Checked;
        TimeEntryData.Description = txtDescription.Text;

        if (mMode == 1)
		{
            EntryList.AddEntry(TimeEntryData);
		}
        else
        {
            EntryList.UpdateEntry(TimeEntryData);
        }
		
		DialogResult = DialogResult.OK;
	}

	private void btnCancel_Click(object sender, System.EventArgs e)
	{
		DialogResult = DialogResult.Cancel;
	}

	private bool validateForm()
	{		
		if (txtEmployeeID.Text == "")
		{
            messageBoxOK("Employee ID is required.");
			txtEmployeeID.Focus();
			return false;
		}

        DateTime dateWorked;

        if (DateTime.TryParse(txtDateWorked.Text, out dateWorked) == false)
        {
            messageBoxOK("Data Worked must be a valid date.");
            txtDateWorked.Focus();
            return false;
        }

        TimeSpan diff = DateTime.Now.Date.Subtract(dateWorked);

        if (dateWorked > DateTime.Now.Date 
			|| diff.TotalDays > 7)
		{
            messageBoxOK("Date Worked cannot be > today's date or more than 7 days in the past.");
            txtDateWorked.Focus();
			return false;
		}

		float hoursWorked;
		const string cInvalidHoursWorked = "Hours worked must be in the range .25 through 4.00 and be in .25 hour increments.";

		if (float.TryParse(cboHoursWorked.Text, out hoursWorked) == false)
		{
            messageBoxOK(cInvalidHoursWorked);
			cboHoursWorked.Focus();
			return false;
		}

		if (hoursWorked < .25 
			|| hoursWorked > 4
			|| (hoursWorked % .25) != 0)
		{
            messageBoxOK(cInvalidHoursWorked);
			cboHoursWorked.Focus();
			return false;
		}
				
		if (txtDescription.Text.Length < 25)
		{
            messageBoxOK("Description is required and must contain at least 25 characters.");
			txtDescription.Focus();
			return false;
		}
		
		return true;
	}

    private void messageBoxOK(string msg)
    {
        MessageBox.Show(msg, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
