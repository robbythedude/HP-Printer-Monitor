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
        private List<CheckBox> printerCheckBoxes = new List<CheckBox>();  //Value holding the collection of generated textboxes based on the passed printer objects

        //The main  constructor for the seperate printer viewer form
        public IndividualPrinterViewer(List<Printer> printerList)
        {
            InitializeComponent();
            this.printerList = printerList;
        }

        //This code is the startup code that runs on start
        private void IndividualPrinterViewer_Load(object sender, EventArgs e)
        {
            CheckBox tempCB;
            this.Text = printerList[0].getBuildingName() + " Individual Printers"; //Setting a proper title for the form

            //Producing check boxes based on the printers in the passed printerList
            for (int i = 0; i < printerList.Count; i++)
            {
                tempCB = new CheckBox();
                tempCB.Text = printerList[i].getName();
                printerCheckBoxes.Add(tempCB);

                this.layoutpanelPrinterList.Controls.Add(tempCB);
            }
        }

        //This is the code that will launch specific internet tabs based on user selected checkboxes
        private void buttonOpen_Click(object sender, EventArgs e)
        {
            foreach (CheckBox cb in printerCheckBoxes)
            {
                if (cb.Checked)
                {
                    string name = cb.Text;
                    foreach (Printer printer in printerList)
                    {
                        if (printer.getName().Equals(name))
                            System.Diagnostics.Process.Start("http://" + printer.getIP()); //Should launch in default browser
                    }

                }
            }
        }


        //This is the code that will launch all printers into internet tabs based on the passed printerList
        private void buttonOpenAll_Click(object sender, EventArgs e)
        {
            foreach (CheckBox cb in printerCheckBoxes)
            {
                string name = cb.Text;
                foreach (Printer printer in printerList)
                {
                    if (printer.getName().Equals(name))
                        System.Diagnostics.Process.Start("http://" + printer.getIP()); //Should launch in default browser
                }

            }
        }


    }
}
