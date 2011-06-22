using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace EEdit
{
    public partial class EEditForm : Form
    {
        public EEditForm()
        {
            InitializeComponent();
        }

        private void EEdit_Load(object sender, EventArgs e)
        {
            MachineEditor.LoadEnvironment(EnvironmentVariableTarget.Machine);
            UserEditor.LoadEnvironment(EnvironmentVariableTarget.User);
        }

        private void WebsiteLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            WebsiteLink.LinkVisited = true;
            Process.Start(WebsiteLink.Text);
        }
    }
}
