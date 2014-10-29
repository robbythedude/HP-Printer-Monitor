using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrinterMonitor
{
    public partial class PrinterViewer : Form
    {
        PrinterViewer(List<Printer> printerList)
        {
            InitializeComponent();

            LinkLabel tempLL;

            for (int i = 0; i < printerList.Count; i++)
            {
                tempLL = new LinkLabel();
                tempLL.Text = printerList[i].getName();
                LinkLabel.Link tLink = new LinkLabel.Link();
                tLink.LinkData = "http://" + printerList[i].getIP();
                tempLL.LinkClicked += new LinkLabelLinkClickedEventHandler(LinkedLabelClicked);
                tempLL.Links.Add(tLink);

                this.panelMain.Controls.Add(tempLL);

            }



            //THIS NEEDS TO BE A DYNAMICALLY PRODUCING LIST OF PRINTERS THAT CAN BE CLICKED TO OPEN IN WEB BROWSER!
        }

        private void LinkedLabelClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(((LinkLabel)sender).Links[0].LinkData.ToString());
        }


    }
}
