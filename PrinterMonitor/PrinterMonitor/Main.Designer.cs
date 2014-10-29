namespace PrinterMonitor
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.groupboxMonitors = new System.Windows.Forms.GroupBox();
            this.flowlayoutMonitors = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkboxSilent = new System.Windows.Forms.CheckBox();
            this.checkboxPopup = new System.Windows.Forms.CheckBox();
            this.textboxPrompt = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.printersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textboxTimer = new System.Windows.Forms.TextBox();
            this.comboboxTime = new System.Windows.Forms.ComboBox();
            this.buttonScanNow = new System.Windows.Forms.Button();
            this.groupboxMonitors.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupboxMonitors
            // 
            this.groupboxMonitors.Controls.Add(this.flowlayoutMonitors);
            this.groupboxMonitors.Location = new System.Drawing.Point(12, 27);
            this.groupboxMonitors.Name = "groupboxMonitors";
            this.groupboxMonitors.Size = new System.Drawing.Size(151, 254);
            this.groupboxMonitors.TabIndex = 0;
            this.groupboxMonitors.TabStop = false;
            this.groupboxMonitors.Text = "Monitor";
            // 
            // flowlayoutMonitors
            // 
            this.flowlayoutMonitors.Location = new System.Drawing.Point(7, 19);
            this.flowlayoutMonitors.Name = "flowlayoutMonitors";
            this.flowlayoutMonitors.Size = new System.Drawing.Size(138, 229);
            this.flowlayoutMonitors.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkboxSilent);
            this.groupBox2.Controls.Add(this.checkboxPopup);
            this.groupBox2.Location = new System.Drawing.Point(12, 287);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(151, 77);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mode";
            // 
            // checkboxSilent
            // 
            this.checkboxSilent.AutoSize = true;
            this.checkboxSilent.Location = new System.Drawing.Point(7, 44);
            this.checkboxSilent.Name = "checkboxSilent";
            this.checkboxSilent.Size = new System.Drawing.Size(52, 17);
            this.checkboxSilent.TabIndex = 1;
            this.checkboxSilent.Text = "Silent";
            this.checkboxSilent.UseVisualStyleBackColor = true;
            // 
            // checkboxPopup
            // 
            this.checkboxPopup.AutoSize = true;
            this.checkboxPopup.Checked = true;
            this.checkboxPopup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkboxPopup.Location = new System.Drawing.Point(7, 20);
            this.checkboxPopup.Name = "checkboxPopup";
            this.checkboxPopup.Size = new System.Drawing.Size(57, 17);
            this.checkboxPopup.TabIndex = 0;
            this.checkboxPopup.Text = "Popup";
            this.checkboxPopup.UseVisualStyleBackColor = true;
            // 
            // textboxPrompt
            // 
            this.textboxPrompt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textboxPrompt.Location = new System.Drawing.Point(169, 27);
            this.textboxPrompt.Name = "textboxPrompt";
            this.textboxPrompt.ReadOnly = true;
            this.textboxPrompt.Size = new System.Drawing.Size(350, 417);
            this.textboxPrompt.TabIndex = 2;
            this.textboxPrompt.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printersToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(531, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // printersToolStripMenuItem
            // 
            this.printersToolStripMenuItem.Name = "printersToolStripMenuItem";
            this.printersToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.printersToolStripMenuItem.Text = "Printers";
            this.printersToolStripMenuItem.Click += new System.EventHandler(this.printersToolStripMenuItem_Click);
            // 
            // textboxTimer
            // 
            this.textboxTimer.Location = new System.Drawing.Point(61, 370);
            this.textboxTimer.Name = "textboxTimer";
            this.textboxTimer.ReadOnly = true;
            this.textboxTimer.Size = new System.Drawing.Size(48, 20);
            this.textboxTimer.TabIndex = 4;
            this.textboxTimer.Text = "123";
            // 
            // comboboxTime
            // 
            this.comboboxTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboboxTime.FormattingEnabled = true;
            this.comboboxTime.Items.AddRange(new object[] {
            "One Minute",
            "Five Minutes",
            "Fifteen Minutes",
            "Thirty Minutes",
            "One Hour",
            "Two Hours"});
            this.comboboxTime.Location = new System.Drawing.Point(12, 396);
            this.comboboxTime.Name = "comboboxTime";
            this.comboboxTime.Size = new System.Drawing.Size(151, 21);
            this.comboboxTime.TabIndex = 5;
            this.comboboxTime.SelectedIndexChanged += new System.EventHandler(this.comboboxTime_SelectedIndexChanged);
            // 
            // buttonScanNow
            // 
            this.buttonScanNow.Location = new System.Drawing.Point(45, 423);
            this.buttonScanNow.Name = "buttonScanNow";
            this.buttonScanNow.Size = new System.Drawing.Size(75, 23);
            this.buttonScanNow.TabIndex = 6;
            this.buttonScanNow.Text = "Scan Now";
            this.buttonScanNow.UseVisualStyleBackColor = true;
            this.buttonScanNow.Click += new System.EventHandler(this.buttonScanNow_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 456);
            this.Controls.Add(this.buttonScanNow);
            this.Controls.Add(this.comboboxTime);
            this.Controls.Add(this.textboxTimer);
            this.Controls.Add(this.textboxPrompt);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupboxMonitors);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PSB Printer Monitor";
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupboxMonitors.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupboxMonitors;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox textboxPrompt;
        private System.Windows.Forms.CheckBox checkboxSilent;
        private System.Windows.Forms.CheckBox checkboxPopup;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TextBox textboxTimer;
        private System.Windows.Forms.ToolStripMenuItem printersToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flowlayoutMonitors;
        private System.Windows.Forms.ComboBox comboboxTime;
        private System.Windows.Forms.Button buttonScanNow;
    }
}

