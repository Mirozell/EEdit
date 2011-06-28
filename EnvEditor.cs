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
using System.Collections.Specialized;
using System.Drawing;
using System.Security;
using System.Windows.Forms;
using EEdit.Environment;
using System.Collections.Generic;

namespace EEdit
{
    public partial class EnvEditor : UserControl
    {
        private const string DefaultVariable = "path";

        private EnvModel environment;

        public EnvEditor()
        {
            InitializeComponent();
        }

        #region Form Events

        private void VariableList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadValues();
        }

        private void List_SizeChanged(object sender, EventArgs e)
        {
            ListView list = (ListView)sender;
            list.Columns[0].Width = list.Width - 22; // 22 = slightly wider than the vertical scroll bar that appears
        }

        private void EntryList_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            // handle the update manually.  The list will refresh when value changes.
            e.CancelEdit = true;
            EntryList.LabelEdit = false;

            if (e.Label == null || string.IsNullOrWhiteSpace(e.Label)) return;

            EnvVariable value = environment.Variables[VarList.SelectedItems[0].Text];

            if (e.Item == value.EntryCount)
                value.AddEntry(e.Label);
            else
                value.UpdateEntry(e.Item, e.Label);
        }

        private void CopyValueButton_Click(object sender, EventArgs e)
        {
            ValueDisplay.Focus();
            ValueDisplay.SelectAll();
            Clipboard.SetText(ValueDisplay.Text);
        }

        private void EntryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtonState();
        }

        private void TopButton_Click(object sender, EventArgs e)
        {
            if (EntryList.SelectedIndices.Count == 0)
                return;

            ListViewItem item = EntryList.SelectedItems[0];
            EnvVariable value = ((EnvVariable)item.Tag);
            value.MoveEntry(item.Index, 0);
        }

        private void UpButton_Click(object sender, EventArgs e)
        {
            if (EntryList.SelectedIndices.Count == 0)
                return;

            ListViewItem item = EntryList.SelectedItems[0];

            if (item.Index > 0)
            {
                EnvVariable value = ((EnvVariable)item.Tag);
                value.MoveEntry(item.Index, item.Index - 1);
            }
        }

        private void DownButton_Click(object sender, EventArgs e)
        {
            if (EntryList.SelectedIndices.Count == 0)
                return;

            ListViewItem item = EntryList.SelectedItems[0];

            if (item.Index < EntryList.Items.Count - 1)
            {
                EnvVariable value = ((EnvVariable)item.Tag);
                value.MoveEntry(item.Index, item.Index + 1);
            }
        }

        private void BottomButton_Click(object sender, EventArgs e)
        {
            if (EntryList.SelectedIndices.Count == 0)
                return;

            ListViewItem item = EntryList.SelectedItems[0];
            EnvVariable value = ((EnvVariable)item.Tag);
            value.MoveEntry(item.Index, EntryList.Items.Count - 2);
        }

        private void EntryList_KeyDown(object sender, KeyEventArgs e)
        {
            if (EntryList.SelectedIndices.Count == 0) return;
            
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    RemoveSelectedEntry();
                    break;

                case Keys.Enter:
                    ListViewItem item = EntryList.SelectedItems[0];
                    item.BeginEdit();
                    break;
            }
        }

        private void VarList_KeyDown(object sender, KeyEventArgs e)
        {
            if (VarList.SelectedIndices.Count == 0) return;

            switch (e.KeyCode)
            {
                case Keys.Delete:
                    RemoveSelectedVariable();
                    break;
            }
        }

        private void VarList_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            // handle the assignment manually, so LoadValues gets the new variable name
            e.CancelEdit = true;
            VarList.LabelEdit = false;

            if (e.Label == null || string.IsNullOrWhiteSpace(e.Label)) return;

            // if the variable already exists, select that one instead.
            ListViewItem existingItem = GetVariableItem(e.Label);
            if (existingItem != null)
            {
                existingItem.Selected = true;
                return;
            }

            EnvVariable value = environment.AddVariable(e.Label);
            value.CollectionChanged += new NotifyCollectionChangedEventHandler(Entries_CollectionChanged);

            ListViewItem item = VarList.Items[e.Item];
            item.Text = value.Variable;

            VarList.Sort();
            item.EnsureVisible();

            LoadValues();

            AddEntry();
        }

        private void RemoveEntryButton_Click(object sender, EventArgs e)
        {
            RemoveSelectedEntry();
        }

        private void RemoveVarButton_Click(object sender, EventArgs e)
        {
            RemoveSelectedVariable();
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            ExportEnvironment();
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            LoadEnvironment(environment.EnvTarget);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                environment.Save();
                RemoveDeletedVariables();
                UpdateVarStateIndicators();
            }
            catch (SecurityException)
            {
                MessageBox.Show("Permission denied. Unable to save.", "Security Error");
            }
        }

        private void RestoreVariable_Click(object sender, EventArgs e)
        {
            RestoreSelectedVariable();
        }

        private void NewVarButton_Click(object sender, EventArgs e)
        {
            AddVariable();
        }

        private void AddVariable()
        {
            ListViewItem item = new ListViewItem();
            VarList.Items.Add(item);
            item.Selected = true;
            item.EnsureVisible();

            VarList.LabelEdit = true;
            item.BeginEdit();
        }

        private void AddEntryButton_Click(object sender, EventArgs e)
        {
            AddEntry();
        }

        private void ValueDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            this.SelectEnvironmentVariableInValueDisplay();
        }

        private void ValueDisplay_KeyDown(object sender, KeyEventArgs e)
        {
            this.SelectEnvironmentVariableInValueDisplay();
        }

        private void AddEntry()
        {
            ListViewItem item = new ListViewItem();
            EntryList.Items.Add(item);
            item.EnsureVisible();

            EntryList.LabelEdit = true;
            item.BeginEdit();
        }

        #endregion

        private void RemoveDeletedVariables()
        {
            foreach (ListViewItem item in VarList.Items)
            {
                if (!environment.Variables.ContainsKey(item.Text))
                    item.Remove();
            }
        }

        private void ExportEnvironment()
        {
            SaveFileDialog dlg = new SaveFileDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string filepath = dlg.FileName;
                environment.Export(filepath);
            }
        }

        public void RemoveSelectedEntry()
        {
            ListViewItem item = EntryList.SelectedItems[0];
            EnvVariable value = (EnvVariable)item.Tag;

            int index = item.Index;
            value.RemoveEntry(index);
            item.Remove();

            if (index < EntryList.Items.Count)
            {
                EntryList.Items[index].Selected = true;
            }
            else if (EntryList.Items.Count > 0)
            {
                EntryList.Items[index - 1].Selected = true;
            }
        }

        private void RemoveSelectedVariable()
        {
            ListViewItem item = VarList.SelectedItems[0];

            environment.RemoveVariable(item.Text);

            UpdateVarStateIndicators();
            UpdateButtonState();
        }

        private void RestoreSelectedVariable()
        {
            ListViewItem item = VarList.SelectedItems[0];
            environment.RestoreVariable(item.Text);

            UpdateButtonState();
        }

        public void LoadEnvironment(EnvironmentVariableTarget target)
        {
            VarList.Items.Clear();

            environment = new EnvModel(target);

            foreach (string variable in environment.Variables.Keys)
            {
                VarList.Items.Add(variable);
                environment.Variables[variable].CollectionChanged += new NotifyCollectionChangedEventHandler(Entries_CollectionChanged);
            }

            SelectVariable(DefaultVariable);
        }

        private void SelectVariable(string variable)
        {
            ListViewItem item = GetVariableItem(variable);
            if (item != null) item.Selected = true;
        }

        private ListViewItem GetVariableItem(string variable)
        {
            for (int i = 0; i < environment.Variables.Count; i++)
            {
                ListViewItem item = VarList.Items[i];
                if (item.Text.ToLower() == variable)
                {
                    return item;
                }
            }

            return null;
        }

        private void UpdateButtonState() 
        {
            ListViewItem item = VarList.SelectedItems[0];
            EnvVariable value = environment.Variables[item.Text];

            RestoreVarButton.Enabled = value.Deleted;
            RemoveVarButton.Enabled = !value.Deleted;

            AddEntryButton.Enabled = (VarList.SelectedIndices.Count > 0);

            bool selection = (EntryList.SelectedIndices.Count > 0);

            TopButton.Enabled = selection && EntryList.SelectedIndices[0] > 0;
            UpButton.Enabled = selection && EntryList.SelectedIndices[0] > 0;
            DownButton.Enabled = selection && EntryList.SelectedIndices[0] < EntryList.Items.Count - 1;
            BottomButton.Enabled = selection && EntryList.SelectedIndices[0] < EntryList.Items.Count - 1;
            RemoveEntryButton.Enabled = selection;
        }

        private void UpdateVarStateIndicators()
        {
            foreach (ListViewItem item in VarList.Items)
            {
                EnvVariable value = environment.Variables[item.Text];
                item.BackColor = GetIndicatorColor(value);
            }
        }

        private Color GetIndicatorColor(EnvVariable value)
        {
            return (value.Deleted) ? Color.Pink :
                   (value.Added) ? Color.LightGreen :
                   (value.Edited) ? Color.LightBlue :
                   Color.White;
        }

        private void LoadValues()
        {
            EntryList.Items.Clear();
            if (VarList.SelectedIndices.Count == 0)
                return;

            EnvVariable value;
            if (!environment.Variables.TryGetValue(VarList.SelectedItems[0].Text, out value)) return;

            ValueDisplay.Text = value.FullValue;
            foreach (string entry in value.GetEntries())
            {
                ListViewItem item = new ListViewItem(entry);
                item.Tag = value;
                EntryList.Items.Add(item);
            }

            UpdateVarStateIndicators();
            UpdateButtonState();
        }

        void Entries_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            LoadValues();

            if (e.NewStartingIndex >= 0)
            {
                EntryList.Items[e.NewStartingIndex].Selected = true;
            }
        }

        private void SelectEnvironmentVariableInValueDisplay()
        {
            string environmentVariable = this.GetEnvironmentVariableFromString(this.ValueDisplay.Text, this.ValueDisplay.SelectionStart);

            ListViewItem item = this.EntryList.FindItemWithText(environmentVariable);

            if (item != null)
            {
                item.Selected = true;
                this.EntryList.EnsureVisible(item.Index);
            }
        }

        private string GetEnvironmentVariableFromString(string variables, int indexInString)
        {
            string variable = string.Empty;

            if (variables.Substring(0, indexInString).IndexOf(';') > -1)
            {
                int beginningOfVariable = variables.Substring(0, indexInString).LastIndexOf(';');
                int endOfVariable = variables.Substring(beginningOfVariable + 1).IndexOf(';');

                if (endOfVariable > -1)
                {
                    variable = variables.Substring(beginningOfVariable + 1, endOfVariable);
                }
                else
                {
                    variable = variables.Substring(beginningOfVariable + 1);
                }
            }
            else
            {
                // looks like it's the first variable
                variable = variables.Substring(0, variables.IndexOf(';'));
            }

            return variable;
        }
    }
}
