using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;

namespace EEdit
{
    public partial class EnvEditor : UserControl
    {
        private const string DefaultVariable = "path";
        private const string NewItemText = "[New]";

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

        private void ValueList_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (e.Label == null)
            {
                e.CancelEdit = true;
                return;
            }

            EnvValue value = environment.Variables[VarList.SelectedItems[0].Text];
            value.Edited = true;

            if (string.IsNullOrWhiteSpace(e.Label))
            {
                e.CancelEdit = true;
                value.Entries.RemoveAt(e.Item);
                return;
            }
            
            if (e.Item == value.Entries.Count)
                value.Entries.Add(e.Label);
            else
                value.Entries[e.Item] = e.Label;
        }

        private void CopyValueButton_Click(object sender, EventArgs e)
        {
            ValueDisplay.Focus();
            ValueDisplay.SelectAll();
            Clipboard.SetText(ValueDisplay.Text);
        }

        private void ValueList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtonState();
        }

        private void TopButton_Click(object sender, EventArgs e)
        {
            if (this.ValueList.SelectedIndices.Count == 0)
                return;

            ListViewItem item = this.ValueList.SelectedItems[0];
            EnvValue value = ((EnvValue)item.Tag);
            value.Edited = true;
            value.Entries.Move(item.Index, 0);
        }

        private void UpButton_Click(object sender, EventArgs e)
        {
            if (this.ValueList.SelectedIndices.Count == 0)
                return;

            ListViewItem item = this.ValueList.SelectedItems[0];

            if (item.Index > 0)
            {
                EnvValue value = ((EnvValue)item.Tag);
                value.Edited = true;
                value.Entries.Move(item.Index, item.Index - 1);
            }
        }

        private void DownButton_Click(object sender, EventArgs e)
        {
            if (this.ValueList.SelectedIndices.Count == 0)
                return;

            ListViewItem item = this.ValueList.SelectedItems[0];

            if (item.Index < ValueList.Items.Count - 1)
            {
                EnvValue value = ((EnvValue)item.Tag);
                value.Edited = true;
                value.Entries.Move(item.Index, item.Index + 1);
            }
        }

        private void BottomButton_Click(object sender, EventArgs e)
        {
            if (this.ValueList.SelectedIndices.Count == 0)
                return;

            ListViewItem item = this.ValueList.SelectedItems[0];
            EnvValue value = ((EnvValue)item.Tag);
            value.Edited = true;
            value.Entries.Move(item.Index, ValueList.Items.Count - 2);
        }

        private void ValueList_KeyDown(object sender, KeyEventArgs e)
        {
            if (ValueList.SelectedIndices.Count == 0) return;
            
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    RemoveSelectedEntry();
                    break;

                case Keys.Enter:
                    ListViewItem item = ValueList.SelectedItems[0];
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

        private void VarList_BeforeLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (e.Item != VarList.Items.Count - 1)
                e.CancelEdit = true;
        }

        private void VarList_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            //handle the assignment manually, so LoadValues gets the new variable name
            e.CancelEdit = true;

            if (e.Label == null || string.IsNullOrWhiteSpace(e.Label)) return;

            ListViewItem existingItem = GetVariableItem(e.Label);
            if (existingItem != null)
            {
                existingItem.Selected = true;
                return;
            }

            EnvValue value = new EnvValue(e.Label, "") { Added = true };
            environment.Variables[e.Label] = value;
            value.Entries.CollectionChanged += new NotifyCollectionChangedEventHandler(Entries_CollectionChanged);

            VarList.Items[e.Item].Text = e.Label;
            VarList.Items.Add(new ListViewItem(NewItemText));
            LoadValues();
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

        private void ResetButton_Click(object sender, EventArgs e)
        {
            LoadEnvironment(environment.EnvTarget);
        }

        private void BackupButton_Click(object sender, EventArgs e)
        {
            BackupExistingEnvironment();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            environment.Save();

            // TODO: Don't reload from scratch. 
            LoadEnvironment(environment.EnvTarget);
        }

        private void RestoreVarButton_Click(object sender, EventArgs e)
        {
            RestoreSelectedVariable();
        }

        #endregion

        private void BackupExistingEnvironment()
        {
            SaveFileDialog dlg = new SaveFileDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string filepath = dlg.FileName;
                EnvModel env = new EnvModel(environment.EnvTarget);
                env.Export(filepath);
            }
        }

        private void ExportEnvironment()
        {
            SaveFileDialog dlg = new SaveFileDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string filepath = dlg.FileName;
                this.environment.Export(filepath);
            }
        }

        public void RemoveSelectedEntry()
        {
            ListViewItem item = ValueList.SelectedItems[0];
            EnvValue value = (EnvValue)item.Tag;

            if (value == null) return;

            value.Edited = true;
            value.Entries.RemoveAt(item.Index);
            LoadValues();
        }

        private void RemoveSelectedVariable()
        {
            ListViewItem item = VarList.SelectedItems[0];
            if (item.Text == NewItemText) return;

            EnvValue value = environment.Variables[item.Text];

            value.Deleted = true;
            UpdateVarStateIndicators();
            UpdateButtonState();
        }

        private void RestoreSelectedVariable()
        {
            ListViewItem item = VarList.SelectedItems[0];
            if (item.Text == NewItemText) return;

            EnvValue value = environment.Variables[item.Text];
            value.Deleted = false;
            
            UpdateButtonState();
        }

        public void LoadEnvironment(EnvironmentVariableTarget target)
        {
            VarList.Items.Clear();

            this.environment = new EnvModel(target);
            foreach (string variable in this.environment.Variables.Keys)
            {
                this.VarList.Items.Add(variable);
                this.environment.Variables[variable].Entries.CollectionChanged += new NotifyCollectionChangedEventHandler(Entries_CollectionChanged);
            }

            this.VarList.Items.Add(new ListViewItem(NewItemText));

            SelectVariable(DefaultVariable);
        }

        private void SelectVariable(string variable)
        {
            ListViewItem item = GetVariableItem(variable);
            if (item != null) item.Selected = true;
        }

        private ListViewItem GetVariableItem(string variable)
        {
            for (int i = 0; i < this.environment.Variables.Count; i++)
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
            bool selection = (ValueList.SelectedIndices.Count > 0);

            TopButton.Enabled = selection && ValueList.SelectedIndices[0] > 0 && ValueList.SelectedIndices[0] < ValueList.Items.Count - 1;
            UpButton.Enabled = selection && ValueList.SelectedIndices[0] > 0 && ValueList.SelectedIndices[0] < ValueList.Items.Count - 1;
            DownButton.Enabled = selection && ValueList.SelectedIndices[0] < ValueList.Items.Count - 2;
            BottomButton.Enabled = selection && ValueList.SelectedIndices[0] < ValueList.Items.Count - 2;
            RemoveEntryButton.Enabled = selection && ValueList.SelectedIndices[0] < ValueList.Items.Count - 1;

            ListViewItem item = VarList.SelectedItems[0];
            EnvValue value = environment.Variables[item.Text];

            RestoreButton.Enabled = value.Deleted;
            RemoveVarButton.Enabled = !value.Deleted;
        }

        private void UpdateVarStateIndicators()
        {
            foreach (ListViewItem item in VarList.Items)
            {
                if (item.Text == NewItemText) continue;

                EnvValue value = environment.Variables[item.Text];
                item.BackColor = GetIndicatorColor(value);
            }
        }

        private Color GetIndicatorColor(EnvValue value)
        {
            return (value.Deleted) ? Color.Pink :
                   (value.Added) ? Color.LightGreen :
                   (value.Edited) ? Color.LightBlue :
                   Color.White;
        }

        private void LoadValues()
        {
            ValueList.Items.Clear();
            if (VarList.SelectedIndices.Count == 0 || VarList.SelectedIndices[0] == VarList.Items.Count - 1)
                return;

            EnvValue value = this.environment.Variables[VarList.SelectedItems[0].Text];
            ValueDisplay.Text = value.FullValue;
            foreach (string entry in value.Entries)
            {
                ListViewItem item = new ListViewItem(entry);
                item.Tag = value;
                ValueList.Items.Add(item);
            }

            ValueList.Items.Add(new ListViewItem(NewItemText));

            ValueList.Focus();

            UpdateVarStateIndicators();
            UpdateButtonState();
        }

        void Entries_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            LoadValues();

            if (e.NewStartingIndex >= 0)
            {
                ValueList.Items[e.NewStartingIndex].Selected = true;
            }
        }
    }
}
