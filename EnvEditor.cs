using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Security;
using System.Windows.Forms;

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

        private void EntryList_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (e.Label == null)
            {
                e.CancelEdit = true;
                return;
            }

            EnvVariable value = environment.Variables[VarList.SelectedItems[0].Text];

            if (string.IsNullOrWhiteSpace(e.Label))
            {
                e.CancelEdit = true;
                value.RemoveEntry(e.Item);
                return;
            }
            
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

            EnvVariable value = environment.AddVariable(e.Label);

            environment.Variables[e.Label] = value;
            value.CollectionChanged += new NotifyCollectionChangedEventHandler(Entries_CollectionChanged);

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
            try
            {
                environment.Save();

                // TODO: Don't reload from scratch. 
                LoadEnvironment(environment.EnvTarget);
            }
            catch (SecurityException)
            {
                MessageBox.Show("Permission denied. Unable to save.", "Security Error");
            }
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
                environment.Export(filepath);
            }
        }

        public void RemoveSelectedEntry()
        {
            ListViewItem item = EntryList.SelectedItems[0];
            EnvVariable value = (EnvVariable)item.Tag;

            if (value == null) return;

            value.RemoveEntry(item.Index);
            LoadValues();
        }

        private void RemoveSelectedVariable()
        {
            ListViewItem item = VarList.SelectedItems[0];
            if (item.Text == NewItemText) return;

            environment.RemoveVariable(item.Text);

            UpdateVarStateIndicators();
            UpdateButtonState();
        }

        private void RestoreSelectedVariable()
        {
            ListViewItem item = VarList.SelectedItems[0];
            if (item.Text == NewItemText) return;

            EnvVariable value = environment.Variables[item.Text];
            value.ClearDeletedState();

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

            VarList.Items.Add(new ListViewItem(NewItemText));

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
            bool selection = (EntryList.SelectedIndices.Count > 0);

            TopButton.Enabled = selection && EntryList.SelectedIndices[0] > 0 && EntryList.SelectedIndices[0] < EntryList.Items.Count - 1;
            UpButton.Enabled = selection && EntryList.SelectedIndices[0] > 0 && EntryList.SelectedIndices[0] < EntryList.Items.Count - 1;
            DownButton.Enabled = selection && EntryList.SelectedIndices[0] < EntryList.Items.Count - 2;
            BottomButton.Enabled = selection && EntryList.SelectedIndices[0] < EntryList.Items.Count - 2;
            RemoveEntryButton.Enabled = selection && EntryList.SelectedIndices[0] < EntryList.Items.Count - 1;

            ListViewItem item = VarList.SelectedItems[0];
            EnvVariable value = environment.Variables[item.Text];

            RestoreVarButton.Enabled = value.Deleted;
            RemoveVarButton.Enabled = !value.Deleted;
        }

        private void UpdateVarStateIndicators()
        {
            foreach (ListViewItem item in VarList.Items)
            {
                if (item.Text == NewItemText) continue;

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
            if (VarList.SelectedIndices.Count == 0 || VarList.SelectedIndices[0] == VarList.Items.Count - 1)
                return;

            EnvVariable value = environment.Variables[VarList.SelectedItems[0].Text];
            ValueDisplay.Text = value.FullValue;
            foreach (string entry in value.GetEntries())
            {
                ListViewItem item = new ListViewItem(entry);
                item.Tag = value;
                EntryList.Items.Add(item);
            }

            EntryList.Items.Add(new ListViewItem(NewItemText));

            EntryList.Focus();

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
    }
}
