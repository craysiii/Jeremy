using System;
using System.Windows.Forms;

namespace Jeremy
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            nameLabel.Text = String.Format(nameLabel.Text, Application.ProductVersion);
        }

        private void githubLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(Jeremy.Properties.Resources.GithubURL);
        }
    }
}
