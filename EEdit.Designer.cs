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
            this.AboutTab = new System.Windows.Forms.TabPage();
            this.LicenseLink = new System.Windows.Forms.LinkLabel();
            this.label9 = new System.Windows.Forms.Label();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.WebsiteLink = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.EnvSelectionTabs.SuspendLayout();
            this.MachineTab.SuspendLayout();
            this.UserTab.SuspendLayout();
            this.AboutTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // EnvSelectionTabs
            // 
            this.EnvSelectionTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.EnvSelectionTabs.Controls.Add(this.MachineTab);
            this.EnvSelectionTabs.Controls.Add(this.UserTab);
            this.EnvSelectionTabs.Controls.Add(this.AboutTab);
            this.EnvSelectionTabs.Location = new System.Drawing.Point(12, 12);
            this.EnvSelectionTabs.Name = "EnvSelectionTabs";
            this.EnvSelectionTabs.SelectedIndex = 0;
            this.EnvSelectionTabs.Size = new System.Drawing.Size(690, 437);
            this.EnvSelectionTabs.TabIndex = 1;
            // 
            // MachineTab
            // 
            this.MachineTab.Controls.Add(this.MachineEditor);
            this.MachineTab.Location = new System.Drawing.Point(4, 22);
            this.MachineTab.Name = "MachineTab";
            this.MachineTab.Padding = new System.Windows.Forms.Padding(3);
            this.MachineTab.Size = new System.Drawing.Size(682, 411);
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
            this.UserTab.Size = new System.Drawing.Size(682, 411);
            this.UserTab.TabIndex = 1;
            this.UserTab.Text = "User";
            this.UserTab.UseVisualStyleBackColor = true;
            // 
            // UserEditor
            // 
            this.UserEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.UserEditor.Location = new System.Drawing.Point(0, 0);
            this.UserEditor.Name = "UserEditor";
            this.UserEditor.Size = new System.Drawing.Size(665, 392);
            this.UserEditor.TabIndex = 0;
            // 
            // AboutTab
            // 
            this.AboutTab.Controls.Add(this.LicenseLink);
            this.AboutTab.Controls.Add(this.label9);
            this.AboutTab.Controls.Add(this.VersionLabel);
            this.AboutTab.Controls.Add(this.label7);
            this.AboutTab.Controls.Add(this.label6);
            this.AboutTab.Controls.Add(this.label5);
            this.AboutTab.Controls.Add(this.label4);
            this.AboutTab.Controls.Add(this.label3);
            this.AboutTab.Controls.Add(this.WebsiteLink);
            this.AboutTab.Controls.Add(this.label2);
            this.AboutTab.Controls.Add(this.label1);
            this.AboutTab.Location = new System.Drawing.Point(4, 22);
            this.AboutTab.Name = "AboutTab";
            this.AboutTab.Size = new System.Drawing.Size(682, 411);
            this.AboutTab.TabIndex = 2;
            this.AboutTab.Text = "About";
            this.AboutTab.UseVisualStyleBackColor = true;
            // 
            // LicenseLink
            // 
            this.LicenseLink.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LicenseLink.AutoSize = true;
            this.LicenseLink.Location = new System.Drawing.Point(286, 263);
            this.LicenseLink.Name = "LicenseLink";
            this.LicenseLink.Size = new System.Drawing.Size(40, 13);
            this.LicenseLink.TabIndex = 10;
            this.LicenseLink.TabStop = true;
            this.LicenseLink.Text = "GPLv3";
            this.LicenseLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LicenseLink_LinkClicked);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(233, 263);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "License:";
            // 
            // VersionLabel
            // 
            this.VersionLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.Location = new System.Drawing.Point(286, 227);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(123, 13);
            this.VersionLabel.TabIndex = 8;
            this.VersionLabel.Text = "current assembly version";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(235, 227);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Version:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(286, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Mirozell";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(239, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Author:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(244, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(194, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "A Windows environment variable editor.";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(311, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "EEdit";
            // 
            // WebsiteLink
            // 
            this.WebsiteLink.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.WebsiteLink.AutoSize = true;
            this.WebsiteLink.Location = new System.Drawing.Point(286, 155);
            this.WebsiteLink.Name = "WebsiteLink";
            this.WebsiteLink.Size = new System.Drawing.Size(165, 13);
            this.WebsiteLink.TabIndex = 2;
            this.WebsiteLink.TabStop = true;
            this.WebsiteLink.Text = "https://github.com/Mirozell/EEdit";
            this.WebsiteLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.WebsiteLink_LinkClicked);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(231, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Website:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // EEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 461);
            this.Controls.Add(this.EnvSelectionTabs);
            this.MinimumSize = new System.Drawing.Size(315, 315);
            this.Name = "EEditForm";
            this.Text = "EEdit";
            this.Load += new System.EventHandler(this.EEdit_Load);
            this.EnvSelectionTabs.ResumeLayout(false);
            this.MachineTab.ResumeLayout(false);
            this.UserTab.ResumeLayout(false);
            this.AboutTab.ResumeLayout(false);
            this.AboutTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private EnvEditor MachineEditor;
        private System.Windows.Forms.TabControl EnvSelectionTabs;
        private System.Windows.Forms.TabPage MachineTab;
        private System.Windows.Forms.TabPage UserTab;
        private EnvEditor UserEditor;
        private System.Windows.Forms.TabPage AboutTab;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel WebsiteLink;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel LicenseLink;
        private System.Windows.Forms.Label label9;



    }
}

