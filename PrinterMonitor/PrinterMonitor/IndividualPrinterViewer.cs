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
    public partial class IndividualPrinterViewer : Form
    {

        List<Printer> printerList;

        //The main  constructor for the seperate printer viewer form
        public IndividualPrinterViewer(List<Printer> printerList)
        {
            InitializeComponent();
            this.printerList = printerList;
        }

        //This code is the startup code that runs on start
        private void IndividualPrinterViewer_Load(object sender, EventArgs e)
        {
            LinkLabel tempLL;
            this.Text = printerList[0].getBuildingName() + " Individual Printers"; //Setting a proper title for the form

            //Producing linked labels based on the IP's of the printers in the passed printerList
            for (int i = 0; i < printerList.Count; i++)
            {
                tempLL = new LinkLabel();
                tempLL.Text = printerList[i].getName();
                LinkLabel.Link tLink = new LinkLabel.Link();
                tLink.LinkData = "https://" + printerList[i].getIP();  //Even as https.. The printers still have an invalid security certificate
                tempLL.LinkClicked += new LinkLabelLinkClickedEventHandler(LinkedLabelClicked);
                tempLL.Links.Add(tLink);

                this.layoutpanelPrinterList.Controls.Add(tempLL);
            }
        }

        //This is the event that launches for when the LinkedLabels are clicked
        private void LinkedLabelClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(((LinkLabel)sender).Links[0].LinkData.ToString()); //Should launch in default browser
        }


    }
}
