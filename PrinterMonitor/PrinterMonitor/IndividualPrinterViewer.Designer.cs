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
            this.SuspendLayout();
            // 
            // layoutpanelPrinterList
            // 
            this.layoutpanelPrinterList.Location = new System.Drawing.Point(12, 12);
            this.layoutpanelPrinterList.Name = "layoutpanelPrinterList";
            this.layoutpanelPrinterList.Size = new System.Drawing.Size(260, 238);
            this.layoutpanelPrinterList.TabIndex = 0;
            // 
            // IndividualPrinterViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.layoutpanelPrinterList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IndividualPrinterViewer";
            this.Text = "IndividualPrinterViewer";
            this.Load += new System.EventHandler(this.IndividualPrinterViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel layoutpanelPrinterList;
    }
}