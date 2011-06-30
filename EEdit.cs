/*
EEdit - A Windows Environment Editor
Copyright (C) 2011  Mirozell

Website: https://github.com/Mirozell/EEdit

EEdit is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

EEdit is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with EEdit.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace EEdit
{
    public partial class EEditForm : Form
    {
        private EnvEditor activeEditor;

        public EEditForm()
        {
            InitializeComponent();
            KeyPreview = true;
            activeEditor = MachineEditor;
        }

        private void EEdit_Load(object sender, EventArgs e)
        {
            MachineEditor.LoadEnvironment(EnvironmentVariableTarget.Machine);
            UserEditor.LoadEnvironment(EnvironmentVariableTarget.User);
            VersionLabel.Text = Application.ProductVersion;
        }

        private void WebsiteLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            WebsiteLink.LinkVisited = true;
            Process.Start(WebsiteLink.Text);
        }

        private void LicenseLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LicenseLink.LinkVisited = true;
            Process.Start("http://www.gnu.org/licenses/gpl.txt");
        }

        private void EEditForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (activeEditor == null) return;

            activeEditor.Shortcut(e);
        }

        private void EnvSelectionTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            activeEditor =
                (EnvSelectionTabs.SelectedTab == MachineTab) ? MachineEditor :
                (EnvSelectionTabs.SelectedTab == UserTab) ? UserEditor :
                null;
        }
    }
}
