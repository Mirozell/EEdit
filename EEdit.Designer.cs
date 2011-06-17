namespace EEdit
{
    partial class EEditForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.EnvSelectionTabs = new System.Windows.Forms.TabControl();
            this.MachineTab = new System.Windows.Forms.TabPage();
            this.MachineEditor = new EEdit.EnvEditor();
            this.UserTab = new System.Windows.Forms.TabPage();
            this.UserEditor = new EEdit.EnvEditor();
            this.EnvSelectionTabs.SuspendLayout();
            this.MachineTab.SuspendLayout();
            this.UserTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // EnvSelectionTabs
            // 
            this.EnvSelectionTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.EnvSelectionTabs.Controls.Add(this.MachineTab);
            this.EnvSelectionTabs.Controls.Add(this.UserTab);
            this.EnvSelectionTabs.Location = new System.Drawing.Point(12, 12);
            this.EnvSelectionTabs.Name = "EnvSelectionTabs";
            this.EnvSelectionTabs.SelectedIndex = 0;
            this.EnvSelectionTabs.Size = new System.Drawing.Size(673, 418);
            this.EnvSelectionTabs.TabIndex = 1;
            // 
            // MachineTab
            // 
            this.MachineTab.Controls.Add(this.MachineEditor);
            this.MachineTab.Location = new System.Drawing.Point(4, 22);
            this.MachineTab.Name = "MachineTab";
            this.MachineTab.Padding = new System.Windows.Forms.Padding(3);
            this.MachineTab.Size = new System.Drawing.Size(665, 392);
            this.MachineTab.TabIndex = 0;
            this.MachineTab.Text = "Machine";
            this.MachineTab.UseVisualStyleBackColor = true;
            // 
            // MachineEditor
            // 
            this.MachineEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MachineEditor.Location = new System.Drawing.Point(0, 0);
            this.MachineEditor.Name = "MachineEditor";
            this.MachineEditor.Size = new System.Drawing.Size(665, 392);
            this.MachineEditor.TabIndex = 0;
            // 
            // UserTab
            // 
            this.UserTab.Controls.Add(this.UserEditor);
            this.UserTab.Location = new System.Drawing.Point(4, 22);
            this.UserTab.Name = "UserTab";
            this.UserTab.Padding = new System.Windows.Forms.Padding(3);
            this.UserTab.Size = new System.Drawing.Size(665, 392);
            this.UserTab.TabIndex = 1;
            this.UserTab.Text = "User";
            this.UserTab.UseVisualStyleBackColor = true;
            // 
            // UserEditor
            // 
            this.UserEditor.Location = new System.Drawing.Point(0, 0);
            this.UserEditor.Name = "UserEditor";
            this.UserEditor.Size = new System.Drawing.Size(665, 392);
            this.UserEditor.TabIndex = 0;
            // 
            // EEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 442);
            this.Controls.Add(this.EnvSelectionTabs);
            this.MinimumSize = new System.Drawing.Size(315, 315);
            this.Name = "EEditForm";
            this.Text = "EEdit";
            this.Load += new System.EventHandler(this.EEdit_Load);
            this.EnvSelectionTabs.ResumeLayout(false);
            this.MachineTab.ResumeLayout(false);
            this.UserTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private EnvEditor MachineEditor;
        private System.Windows.Forms.TabControl EnvSelectionTabs;
        private System.Windows.Forms.TabPage MachineTab;
        private System.Windows.Forms.TabPage UserTab;
        private EnvEditor UserEditor;



    }
}

