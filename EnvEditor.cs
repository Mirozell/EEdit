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
            value.UpdateState(EnvValueState.Edited);

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
                value.Entries.Move(item.Index, item.Index + 1);
            }
        }

        private void BottomButton_Click(object sender, EventArgs e)
        {
            if (this.ValueList.SelectedIndices.Count == 0)
                return;

            ListViewItem item = this.ValueList.SelectedItems[0];
            EnvValue value = ((EnvValue)item.Tag);
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

            EnvValue value = new EnvValue(e.Label, "");
            value.UpdateState(EnvValueState.Added);
            environment.Variables[e.Label] = value;
            value.Entries.CollectionChanged += new NotifyCollectionChangedEventHandler(Entries_CollectionChanged);

            VarList.Items[e.Item].Text = e.Label;
            VarList.Items.Add(new ListViewItem("[new]"));
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
            // TODO
            MessageBox.Show("This program is still under development and may still have bugs.  Please backup your existing settings.");
            BackupExistingEnvironment();

            environment.Save();

            // TODO: Don't reload from scratch. 
            LoadEnvironment(environment.EnvTarget);
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

            value.UpdateState(EnvValueState.Edited);
            value.Entries.RemoveAt(item.Index);
            LoadValues();
        }

        private void RemoveSelectedVariable()
        {
            ListViewItem item = VarList.SelectedItems[0];
            if (item.Text == "[new]") return;

            EnvValue value = environment.Variables[item.Text];

            value.UpdateState(EnvValueState.Deleted);
            UpdateVarStateIndicators();
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

            this.VarList.Items.Add(new ListViewItem("[new]"));

            SelectDefault();
        }

        private void SelectDefault()
        {
            string defaultVar = "path";

            for (int i = 0; i < this.environment.Variables.Count; i++)
            {
                ListViewItem item = VarList.Items[i];
                if (item.Text.ToLower() == defaultVar)
                {
                    item.Selected = true;
                    break;
                }
            }
        }

        private void UpdateButtonState()
        {
            bool selection = (ValueList.SelectedIndices.Count > 0);

            TopButton.Enabled = selection && ValueList.SelectedIndices[0] > 0 && ValueList.SelectedIndices[0] < ValueList.Items.Count - 1;
            UpButton.Enabled = selection && ValueList.SelectedIndices[0] > 0 && ValueList.SelectedIndices[0] < ValueList.Items.Count - 1;
            DownButton.Enabled = selection && ValueList.SelectedIndices[0] < ValueList.Items.Count - 2;
            BottomButton.Enabled = selection && ValueList.SelectedIndices[0] < ValueList.Items.Count - 2;
            RemoveEntryButton.Enabled = selection && ValueList.SelectedIndices[0] > 0 && ValueList.SelectedIndices[0] < ValueList.Items.Count - 1;
        }

        private void UpdateVarStateIndicators()
        {
            foreach (ListViewItem item in VarList.Items)
            {
                if (item.Text == "[new]") continue;

                EnvValue value = environment.Variables[item.Text];
                item.BackColor = GetIndicatorColor(value.State);
            }
        }

        private Color GetIndicatorColor(EnvValueState state)
        {
            switch (state)
            {
                case EnvValueState.Edited:
                    return Color.LightBlue;

                case EnvValueState.Added:
                    return Color.LightGreen;

                case EnvValueState.Deleted:
                    return Color.Pink;

                default:
                    return Color.White;
            }
        }

        private void LoadValues()
        {
            ValueList.Items.Clear();
            if (VarList.SelectedIndices.Count == 0 || VarList.SelectedIndices[0] == VarList.Items.Count - 1)
                return;

            EnvValue value = this.environment.Variables[VarList.SelectedItems[0].Text];
            ValueDisplay.Text = value.ToString();
            foreach (string entry in value.Entries)
            {
                ListViewItem item = new ListViewItem(entry);
                item.Tag = value;
                ValueList.Items.Add(item);
            }

            ValueList.Items.Add(new ListViewItem("[New]"));

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
