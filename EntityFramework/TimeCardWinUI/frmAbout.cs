using System;
using System.Windows.Forms;

internal partial class frmAbout: Form
{
    internal frmAbout()
    {
        InitializeComponent();
    }

    private void btnOK_Click(object sender, System.EventArgs e)
    {
        Close();
    }
}
