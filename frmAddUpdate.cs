using System;
using System.Windows.Forms;

public partial class frmAddUpdate: Form
{
    private byte mMode;
    public clsTimeEntry Entry = new clsTimeEntry();

    public frmAddUpdate(byte mode, clsTimeEntry entry)
	{
        InitializeComponent();

        mMode = mode;

		if (mode == 1)
		{
			Text = "Add";
		}
		else
		{
			Text = "Update";

			// Copy the values to the form.

			txtEmployeeID.Text = entry.EmployeeID;
			txtDateWorked.Text = entry.DateWorked.ToShortDateString();
			cboHoursWorked.Text = entry.NumberOfHoursWorked.ToString("#.00");
			chkBillable.Checked = entry.BillableIndicator;
			txtDescription.Text = entry.Description;
		}
	}

	private void btnOK_Click(object sender, System.EventArgs e)
	{
		// Validate the contents of the form and exit if anything is bad.

		if (validateForm() == false)
		{
			return;
		}

        // Get the input from the form and store.
        Entry.EmployeeID = txtEmployeeID.Text;
        Entry.DateWorked = DateTime.Parse(txtDateWorked.Text);
        Entry.NumberOfHoursWorked = float.Parse(cboHoursWorked.Text);
        Entry.BillableIndicator = chkBillable.Checked;
        Entry.Description = txtDescription.Text;

		// Close the form.
		
		DialogResult = DialogResult.OK;
	}

	private void btnCancel_Click(object sender, System.EventArgs e)
	{
		DialogResult = DialogResult.Cancel;
	}

	private bool validateForm()
	{
		// Check Employee ID.
		
		if (txtEmployeeID.Text == "")
		{
            messageBoxOK("Employee ID is required.");
			txtEmployeeID.Focus();
			return false;
		}

		// Check Date Worked.

        DateTime dateWorked;

        if (DateTime.TryParse(txtDateWorked.Text, out dateWorked) == false)
        {
            messageBoxOK("Date Worked must be a valid date.");
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

		// Check Hours Worked.

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
		
		// Check Description.
		
		if (txtDescription.Text.Length < 25)
		{
            messageBoxOK("Description is required and must contain at least 25 characters.");
			txtDescription.Focus();
			return false;
		}

		// If we get this far, then everything is OK.
		
		return true;
	}

    private void messageBoxOK(string msg)
    {
        MessageBox.Show(msg, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
