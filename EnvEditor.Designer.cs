namespace EEdit
{
    partial class EnvEditor
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.RestoreVarButton = new System.Windows.Forms.Button();
            this.RemoveVarButton = new System.Windows.Forms.Button();
            this.VarList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RemoveEntryButton = new System.Windows.Forms.Button();
            this.BottomButton = new System.Windows.Forms.Button();
            this.DownButton = new System.Windows.Forms.Button();
            this.UpButton = new System.Windows.Forms.Button();
            this.TopButton = new System.Windows.Forms.Button();
            this.CopyValueButton = new System.Windows.Forms.Button();
            this.ValueDisplay = new System.Windows.Forms.TextBox();
            this.EntryList = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SaveButton = new System.Windows.Forms.Button();
            this.BackupButton = new System.Windows.Forms.Button();
            this.ExportButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 32);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.RestoreVarButton);
            this.splitContainer1.Panel1.Controls.Add(this.RemoveVarButton);
            this.splitContainer1.Panel1.Controls.Add(this.VarList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.RemoveEntryButton);
            this.splitContainer1.Panel2.Controls.Add(this.BottomButton);
            this.splitContainer1.Panel2.Controls.Add(this.DownButton);
            this.splitContainer1.Panel2.Controls.Add(this.UpButton);
            this.splitContainer1.Panel2.Controls.Add(this.TopButton);
            this.splitContainer1.Panel2.Controls.Add(this.CopyValueButton);
            this.splitContainer1.Panel2.Controls.Add(this.ValueDisplay);
            this.splitContainer1.Panel2.Controls.Add(this.EntryList);
            this.splitContainer1.Size = new System.Drawing.Size(722, 429);
            this.splitContainer1.SplitterDistance = 238;
            this.splitContainer1.TabIndex = 3;
            this.splitContainer1.TabStop = false;
            // 
            // RestoreVarButton
            // 
            this.RestoreVarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RestoreVarButton.Location = new System.Drawing.Point(84, 403);
            this.RestoreVarButton.Name = "RestoreVarButton";
            this.RestoreVarButton.Size = new System.Drawing.Size(75, 23);
            this.RestoreVarButton.TabIndex = 2;
            this.RestoreVarButton.Text = "Restore";
            this.RestoreVarButton.UseVisualStyleBackColor = true;
            this.RestoreVarButton.Click += new System.EventHandler(this.RestoreVarButton_Click);
            // 
            // RemoveVarButton
            // 
            this.RemoveVarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RemoveVarButton.Location = new System.Drawing.Point(3, 403);
            this.RemoveVarButton.Name = "RemoveVarButton";
            this.RemoveVarButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveVarButton.TabIndex = 1;
            this.RemoveVarButton.Text = "Remove";
            this.RemoveVarButton.UseVisualStyleBackColor = true;
            this.RemoveVarButton.Click += new System.EventHandler(this.RemoveVarButton_Click);
            // 
            // VarList
            // 
            this.VarList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.VarList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.VarList.FullRowSelect = true;
            this.VarList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.VarList.HideSelection = false;
            this.VarList.LabelEdit = true;
            this.VarList.LabelWrap = false;
            this.VarList.Location = new System.Drawing.Point(3, 3);
            this.VarList.MultiSelect = false;
            this.VarList.Name = "VarList";
            this.VarList.Size = new System.Drawing.Size(232, 394);
            this.VarList.TabIndex = 0;
            this.VarList.UseCompatibleStateImageBehavior = false;
            this.VarList.View = System.Windows.Forms.View.Details;
            this.VarList.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.VarList_AfterLabelEdit);
            this.VarList.BeforeLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.VarList_BeforeLabelEdit);
            this.VarList.SelectedIndexChanged += new System.EventHandler(this.VariableList_SelectedIndexChanged);
            this.VarList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VarList_KeyDown);
            this.VarList.Resize += new System.EventHandler(this.List_SizeChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 147;
            // 
            // RemoveEntryButton
            // 
            this.RemoveEntryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveEntryButton.Enabled = false;
            this.RemoveEntryButton.Image = global::EEdit.Properties.Resources.RedX;
            this.RemoveEntryButton.Location = new System.Drawing.Point(402, 238);
            this.RemoveEntryButton.Name = "RemoveEntryButton";
            this.RemoveEntryButton.Size = new System.Drawing.Size(38, 35);
            this.RemoveEntryButton.TabIndex = 8;
            this.RemoveEntryButton.UseVisualStyleBackColor = true;
            this.RemoveEntryButton.Click += new System.EventHandler(this.RemoveEntryButton_Click);
            // 
            // BottomButton
            // 
            this.BottomButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BottomButton.Enabled = false;
            this.BottomButton.Image = global::EEdit.Properties.Resources.Bottom;
            this.BottomButton.Location = new System.Drawing.Point(402, 180);
            this.BottomButton.Name = "BottomButton";
            this.BottomButton.Size = new System.Drawing.Size(38, 38);
            this.BottomButton.TabIndex = 7;
            this.BottomButton.UseVisualStyleBackColor = true;
            this.BottomButton.Click += new System.EventHandler(this.BottomButton_Click);
            // 
            // DownButton
            // 
            this.DownButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DownButton.Enabled = false;
            this.DownButton.Image = global::EEdit.Properties.Resources.Down;
            this.DownButton.Location = new System.Drawing.Point(402, 136);
            this.DownButton.Name = "DownButton";
            this.DownButton.Size = new System.Drawing.Size(38, 38);
            this.DownButton.TabIndex = 6;
            this.DownButton.UseVisualStyleBackColor = true;
            this.DownButton.Click += new System.EventHandler(this.DownButton_Click);
            // 
            // UpButton
            // 
            this.UpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UpButton.Enabled = false;
            this.UpButton.Image = global::EEdit.Properties.Resources.Up;
            this.UpButton.Location = new System.Drawing.Point(402, 76);
            this.UpButton.Name = "UpButton";
            this.UpButton.Size = new System.Drawing.Size(38, 38);
            this.UpButton.TabIndex = 5;
            this.UpButton.UseVisualStyleBackColor = true;
            this.UpButton.Click += new System.EventHandler(this.UpButton_Click);
            // 
            // TopButton
            // 
            this.TopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TopButton.Enabled = false;
            this.TopButton.Image = global::EEdit.Properties.Resources.Top;
            this.TopButton.Location = new System.Drawing.Point(402, 34);
            this.TopButton.Name = "TopButton";
            this.TopButton.Size = new System.Drawing.Size(38, 36);
            this.TopButton.TabIndex = 4;
            this.TopButton.UseVisualStyleBackColor = true;
            this.TopButton.Click += new System.EventHandler(this.TopButton_Click);
            // 
            // CopyValueButton
            // 
            this.CopyValueButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CopyValueButton.Location = new System.Drawing.Point(402, 1);
            this.CopyValueButton.Name = "CopyValueButton";
            this.CopyValueButton.Size = new System.Drawing.Size(75, 23);
            this.CopyValueButton.TabIndex = 3;
            this.CopyValueButton.Text = "Copy";
            this.CopyValueButton.UseVisualStyleBackColor = true;
            this.CopyValueButton.Click += new System.EventHandler(this.CopyValueButton_Click);
            // 
            // ValueDisplay
            // 
            this.ValueDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ValueDisplay.Location = new System.Drawing.Point(3, 3);
            this.ValueDisplay.Name = "ValueDisplay";
            this.ValueDisplay.ReadOnly = true;
            this.ValueDisplay.Size = new System.Drawing.Size(393, 20);
            this.ValueDisplay.TabIndex = 2;
            // 
            // EntryList
            // 
            this.EntryList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.EntryList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.EntryList.FullRowSelect = true;
            this.EntryList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.EntryList.HideSelection = false;
            this.EntryList.LabelEdit = true;
            this.EntryList.LabelWrap = false;
            this.EntryList.Location = new System.Drawing.Point(3, 34);
            this.EntryList.MultiSelect = false;
            this.EntryList.Name = "EntryList";
            this.EntryList.Size = new System.Drawing.Size(393, 392);
            this.EntryList.TabIndex = 1;
            this.EntryList.UseCompatibleStateImageBehavior = false;
            this.EntryList.View = System.Windows.Forms.View.Details;
            this.EntryList.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.EntryList_AfterLabelEdit);
            this.EntryList.SelectedIndexChanged += new System.EventHandler(this.EntryList_SelectedIndexChanged);
            this.EntryList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EntryList_KeyDown);
            this.EntryList.Resize += new System.EventHandler(this.List_SizeChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 303;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(3, 3);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 4;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // BackupButton
            // 
            this.BackupButton.Location = new System.Drawing.Point(165, 3);
            this.BackupButton.Name = "BackupButton";
            this.BackupButton.Size = new System.Drawing.Size(75, 23);
            this.BackupButton.TabIndex = 5;
            this.BackupButton.Text = "Backup";
            this.BackupButton.UseVisualStyleBackColor = true;
            this.BackupButton.Click += new System.EventHandler(this.BackupButton_Click);
            // 
            // ExportButton
            // 
            this.ExportButton.Location = new System.Drawing.Point(84, 3);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(75, 23);
            this.ExportButton.TabIndex = 6;
            this.ExportButton.Text = "Export";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(246, 3);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(75, 23);
            this.ResetButton.TabIndex = 7;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // EnvEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.ExportButton);
            this.Controls.Add(this.BackupButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(484, 307);
            this.Name = "EnvEditor";
            this.Size = new System.Drawing.Size(722, 461);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView VarList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button BottomButton;
        private System.Windows.Forms.Button DownButton;
        private System.Windows.Forms.Button UpButton;
        private System.Windows.Forms.Button TopButton;
        private System.Windows.Forms.Button CopyValueButton;
        private System.Windows.Forms.TextBox ValueDisplay;
        private System.Windows.Forms.ListView EntryList;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button RemoveEntryButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button BackupButton;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Button RemoveVarButton;
        private System.Windows.Forms.Button RestoreVarButton;

    }
}
