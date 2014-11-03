namespace PrinterMonitor
{
    partial class IndividualPrinterViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IndividualPrinterViewer));
            this.layoutpanelPrinterList = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonOpenAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // layoutpanelPrinterList
            // 
            this.layoutpanelPrinterList.Location = new System.Drawing.Point(12, 12);
            this.layoutpanelPrinterList.Name = "layoutpanelPrinterList";
            this.layoutpanelPrinterList.Size = new System.Drawing.Size(260, 268);
            this.layoutpanelPrinterList.TabIndex = 0;
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(278, 12);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(85, 23);
            this.buttonOpen.TabIndex = 1;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonOpenAll
            // 
            this.buttonOpenAll.Location = new System.Drawing.Point(278, 41);
            this.buttonOpenAll.Name = "buttonOpenAll";
            this.buttonOpenAll.Size = new System.Drawing.Size(85, 23);
            this.buttonOpenAll.TabIndex = 2;
            this.buttonOpenAll.Text = "Open All";
            this.buttonOpenAll.UseVisualStyleBackColor = true;
            this.buttonOpenAll.Click += new System.EventHandler(this.buttonOpenAll_Click);
            // 
            // IndividualPrinterViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 292);
            this.Controls.Add(this.buttonOpenAll);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.layoutpanelPrinterList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IndividualPrinterViewer";
            this.Text = "IndividualPrinterViewer";
            this.Load += new System.EventHandler(this.IndividualPrinterViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel layoutpanelPrinterList;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonOpenAll;
    }
}