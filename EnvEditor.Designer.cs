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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnvEditor));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.NewVarButton = new System.Windows.Forms.Button();
            this.RestoreVarButton = new System.Windows.Forms.Button();
            this.RemoveVarButton = new System.Windows.Forms.Button();
            this.VarList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AddEntryButton = new System.Windows.Forms.Button();
            this.RemoveEntryButton = new System.Windows.Forms.Button();
            this.BottomButton = new System.Windows.Forms.Button();
            this.imageList32 = new System.Windows.Forms.ImageList(this.components);
            this.DownButton = new System.Windows.Forms.Button();
            this.UpButton = new System.Windows.Forms.Button();
            this.TopButton = new System.Windows.Forms.Button();
            this.CopyValueButton = new System.Windows.Forms.Button();
            this.ValueDisplay = new System.Windows.Forms.TextBox();
            this.EntryList = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BackupButton = new System.Windows.Forms.Button();
            this.ExportButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.imageList16 = new System.Windows.Forms.ImageList(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SaveButton = new System.Windows.Forms.Button();
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
            this.splitContainer1.Location = new System.Drawing.Point(0, 48);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.NewVarButton);
            this.splitContainer1.Panel1.Controls.Add(this.RestoreVarButton);
            this.splitContainer1.Panel1.Controls.Add(this.RemoveVarButton);
            this.splitContainer1.Panel1.Controls.Add(this.VarList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.AddEntryButton);
            this.splitContainer1.Panel2.Controls.Add(this.RemoveEntryButton);
            this.splitContainer1.Panel2.Controls.Add(this.BottomButton);
            this.splitContainer1.Panel2.Controls.Add(this.DownButton);
            this.splitContainer1.Panel2.Controls.Add(this.UpButton);
            this.splitContainer1.Panel2.Controls.Add(this.TopButton);
            this.splitContainer1.Panel2.Controls.Add(this.CopyValueButton);
            this.splitContainer1.Panel2.Controls.Add(this.ValueDisplay);
            this.splitContainer1.Panel2.Controls.Add(this.EntryList);
            this.splitContainer1.Size = new System.Drawing.Size(722, 413);
            this.splitContainer1.SplitterDistance = 238;
            this.splitContainer1.TabIndex = 3;
            this.splitContainer1.TabStop = false;
            // 
            // NewVarButton
            // 
            this.NewVarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NewVarButton.Location = new System.Drawing.Point(0, 374);
            this.NewVarButton.Name = "NewVarButton";
            this.NewVarButton.Size = new System.Drawing.Size(38, 36);
            this.NewVarButton.TabIndex = 7;
            this.NewVarButton.Text = "Add";
            this.toolTip1.SetToolTip(this.NewVarButton, "Delete");
            this.NewVarButton.UseVisualStyleBackColor = true;
            this.NewVarButton.Click += new System.EventHandler(this.NewVarButton_Click);
            // 
            // RestoreVarButton
            // 
            this.RestoreVarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RestoreVarButton.Enabled = false;
            this.RestoreVarButton.Image = global::EEdit.Properties.Resources.Restore;
            this.RestoreVarButton.Location = new System.Drawing.Point(88, 374);
            this.RestoreVarButton.Name = "RestoreVarButton";
            this.RestoreVarButton.Size = new System.Drawing.Size(38, 36);
            this.RestoreVarButton.TabIndex = 6;
            this.toolTip1.SetToolTip(this.RestoreVarButton, "Restore");
            this.RestoreVarButton.UseVisualStyleBackColor = true;
            this.RestoreVarButton.Click += new System.EventHandler(this.RestoreVariable_Click);
            // 
            // RemoveVarButton
            // 
            this.RemoveVarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RemoveVarButton.Enabled = false;
            this.RemoveVarButton.Image = global::EEdit.Properties.Resources.RedX;
            this.RemoveVarButton.Location = new System.Drawing.Point(44, 374);
            this.RemoveVarButton.Name = "RemoveVarButton";
            this.RemoveVarButton.Size = new System.Drawing.Size(38, 36);
            this.RemoveVarButton.TabIndex = 5;
            this.toolTip1.SetToolTip(this.RemoveVarButton, "Delete");
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
            this.VarList.LabelWrap = false;
            this.VarList.Location = new System.Drawing.Point(0, 3);
            this.VarList.MultiSelect = false;
            this.VarList.Name = "VarList";
            this.VarList.Size = new System.Drawing.Size(238, 365);
            this.VarList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.VarList.TabIndex = 0;
            this.VarList.UseCompatibleStateImageBehavior = false;
            this.VarList.View = System.Windows.Forms.View.Details;
            this.VarList.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.VarList_AfterLabelEdit);
            this.VarList.SelectedIndexChanged += new System.EventHandler(this.VariableList_SelectedIndexChanged);
            this.VarList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VarList_KeyDown);
            this.VarList.Resize += new System.EventHandler(this.List_SizeChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 147;
            // 
            // AddEntryButton
            // 
            this.AddEntryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddEntryButton.Enabled = false;
            this.AddEntryButton.Location = new System.Drawing.Point(439, 281);
            this.AddEntryButton.Name = "AddEntryButton";
            this.AddEntryButton.Size = new System.Drawing.Size(38, 35);
            this.AddEntryButton.TabIndex = 9;
            this.AddEntryButton.Text = "Add";
            this.toolTip1.SetToolTip(this.AddEntryButton, "Delete");
            this.AddEntryButton.UseVisualStyleBackColor = true;
            this.AddEntryButton.Click += new System.EventHandler(this.AddEntryButton_Click);
            // 
            // RemoveEntryButton
            // 
            this.RemoveEntryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveEntryButton.Enabled = false;
            this.RemoveEntryButton.Image = global::EEdit.Properties.Resources.RedX;
            this.RemoveEntryButton.Location = new System.Drawing.Point(439, 322);
            this.RemoveEntryButton.Name = "RemoveEntryButton";
            this.RemoveEntryButton.Size = new System.Drawing.Size(38, 35);
            this.RemoveEntryButton.TabIndex = 8;
            this.toolTip1.SetToolTip(this.RemoveEntryButton, "Delete");
            this.RemoveEntryButton.UseVisualStyleBackColor = true;
            this.RemoveEntryButton.Click += new System.EventHandler(this.RemoveEntryButton_Click);
            // 
            // BottomButton
            // 
            this.BottomButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BottomButton.Enabled = false;
            this.BottomButton.ImageIndex = 0;
            this.BottomButton.ImageList = this.imageList32;
            this.BottomButton.Location = new System.Drawing.Point(439, 206);
            this.BottomButton.Name = "BottomButton";
            this.BottomButton.Size = new System.Drawing.Size(38, 38);
            this.BottomButton.TabIndex = 7;
            this.toolTip1.SetToolTip(this.BottomButton, "Move to Bottom");
            this.BottomButton.UseVisualStyleBackColor = true;
            this.BottomButton.Click += new System.EventHandler(this.BottomButton_Click);
            // 
            // imageList32
            // 
            this.imageList32.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList32.ImageStream")));
            this.imageList32.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList32.Images.SetKeyName(0, "Bottom.ico");
            this.imageList32.Images.SetKeyName(1, "CopyToClipboard.ico");
            this.imageList32.Images.SetKeyName(2, "Down.ico");
            this.imageList32.Images.SetKeyName(3, "RedX.ico");
            this.imageList32.Images.SetKeyName(4, "Top.ico");
            this.imageList32.Images.SetKeyName(5, "Up.ico");
            this.imageList32.Images.SetKeyName(6, "Save.ico");
            // 
            // DownButton
            // 
            this.DownButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DownButton.Enabled = false;
            this.DownButton.ImageIndex = 2;
            this.DownButton.ImageList = this.imageList32;
            this.DownButton.Location = new System.Drawing.Point(439, 162);
            this.DownButton.Name = "DownButton";
            this.DownButton.Size = new System.Drawing.Size(38, 38);
            this.DownButton.TabIndex = 6;
            this.toolTip1.SetToolTip(this.DownButton, "Move Down");
            this.DownButton.UseVisualStyleBackColor = true;
            this.DownButton.Click += new System.EventHandler(this.DownButton_Click);
            // 
            // UpButton
            // 
            this.UpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UpButton.Enabled = false;
            this.UpButton.ImageIndex = 5;
            this.UpButton.ImageList = this.imageList32;
            this.UpButton.Location = new System.Drawing.Point(439, 102);
            this.UpButton.Name = "UpButton";
            this.UpButton.Size = new System.Drawing.Size(38, 38);
            this.UpButton.TabIndex = 5;
            this.toolTip1.SetToolTip(this.UpButton, "Move Up");
            this.UpButton.UseVisualStyleBackColor = true;
            this.UpButton.Click += new System.EventHandler(this.UpButton_Click);
            // 
            // TopButton
            // 
            this.TopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TopButton.Enabled = false;
            this.TopButton.ImageIndex = 4;
            this.TopButton.ImageList = this.imageList32;
            this.TopButton.Location = new System.Drawing.Point(439, 60);
            this.TopButton.Name = "TopButton";
            this.TopButton.Size = new System.Drawing.Size(38, 36);
            this.TopButton.TabIndex = 4;
            this.toolTip1.SetToolTip(this.TopButton, "Move to Top");
            this.TopButton.UseVisualStyleBackColor = true;
            this.TopButton.Click += new System.EventHandler(this.TopButton_Click);
            // 
            // CopyValueButton
            // 
            this.CopyValueButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CopyValueButton.Image = global::EEdit.Properties.Resources.CopyToClipboard;
            this.CopyValueButton.Location = new System.Drawing.Point(439, 3);
            this.CopyValueButton.Name = "CopyValueButton";
            this.CopyValueButton.Size = new System.Drawing.Size(38, 36);
            this.CopyValueButton.TabIndex = 3;
            this.toolTip1.SetToolTip(this.CopyValueButton, "Copy to Clipboard");
            this.CopyValueButton.UseVisualStyleBackColor = true;
            this.CopyValueButton.Click += new System.EventHandler(this.CopyValueButton_Click);
            // 
            // ValueDisplay
            // 
            this.ValueDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ValueDisplay.Location = new System.Drawing.Point(2, 3);
            this.ValueDisplay.Name = "ValueDisplay";
            this.ValueDisplay.ReadOnly = true;
            this.ValueDisplay.Size = new System.Drawing.Size(430, 20);
            this.ValueDisplay.TabIndex = 2;
            this.ValueDisplay.TextChanged += new System.EventHandler(this.ValueDisplay_TextChanged);
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
            this.EntryList.Location = new System.Drawing.Point(3, 29);
            this.EntryList.MultiSelect = false;
            this.EntryList.Name = "EntryList";
            this.EntryList.Size = new System.Drawing.Size(430, 381);
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
            // BackupButton
            // 
            this.BackupButton.Location = new System.Drawing.Point(132, 11);
            this.BackupButton.Name = "BackupButton";
            this.BackupButton.Size = new System.Drawing.Size(75, 23);
            this.BackupButton.TabIndex = 5;
            this.BackupButton.Text = "Backup";
            this.toolTip1.SetToolTip(this.BackupButton, "Back up to File");
            this.BackupButton.UseVisualStyleBackColor = true;
            this.BackupButton.Click += new System.EventHandler(this.BackupButton_Click);
            // 
            // ExportButton
            // 
            this.ExportButton.Location = new System.Drawing.Point(51, 11);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(75, 23);
            this.ExportButton.TabIndex = 6;
            this.ExportButton.Text = "Export";
            this.toolTip1.SetToolTip(this.ExportButton, "Export to File");
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(213, 11);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(75, 23);
            this.ResetButton.TabIndex = 7;
            this.ResetButton.Text = "Reset";
            this.toolTip1.SetToolTip(this.ResetButton, "Reset to Initial State");
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.Reset_Click);
            // 
            // imageList16
            // 
            this.imageList16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList16.ImageStream")));
            this.imageList16.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList16.Images.SetKeyName(0, "Bottom.ico");
            this.imageList16.Images.SetKeyName(1, "CopyToClipboard.ico");
            this.imageList16.Images.SetKeyName(2, "Down.ico");
            this.imageList16.Images.SetKeyName(3, "RedX.ico");
            this.imageList16.Images.SetKeyName(4, "Top.ico");
            this.imageList16.Images.SetKeyName(5, "Up.ico");
            this.imageList16.Images.SetKeyName(6, "Save.ico");
            // 
            // SaveButton
            // 
            this.SaveButton.ImageIndex = 6;
            this.SaveButton.ImageList = this.imageList32;
            this.SaveButton.Location = new System.Drawing.Point(3, 3);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(42, 39);
            this.SaveButton.TabIndex = 4;
            this.toolTip1.SetToolTip(this.SaveButton, "Save Environment Variables");
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
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
        private System.Windows.Forms.ImageList imageList32;
        private System.Windows.Forms.ImageList imageList16;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button RemoveVarButton;
        private System.Windows.Forms.Button RestoreVarButton;
        private System.Windows.Forms.Button NewVarButton;
        private System.Windows.Forms.Button AddEntryButton;

    }
}
