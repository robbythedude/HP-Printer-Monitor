using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterMonitor
{
    public class Printer : AbsPrinter
    {

        private string ip; //Ip for the printer
        private string name;  //Name of the printer
        private string buildingName; //Name of building where printer located
        private Main mainApp;  //The main GUI application Form obj. Used to push messages to prompt

        //Constructor
        public Printer(string ip, string name, string building, Main main)
        {
            this.ip = ip;
            this.name = name;
            this.buildingName = building;
            this.mainApp = main;
            printerList.Add(this);
        }

        //Returns the printer's IP
        public string getIP()
        {
            return ip;
        }

        //Returns the printer's name
        public string getName()
        {
            return name;
        }

        public string getBuildingName()
        {
            return buildingName;
        }

        //Function that will test printers found in the set's printerList
        public void test()
        {
            System.Net.WebClient wc = new System.Net.WebClient(); //Establishsing an object to call the printer's inernal site
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };  //Bypasses security certificate error
            //int goodPrinterCount = 0;

            try
            {

                string webData = wc.DownloadString("http://" + this.getIP()).ToUpper();

                if (webData.Contains("SLEEP MODE ON") || webData.Contains("READY") || webData.Contains("PROCESSING JOB FROM TRAY") || webData.Contains("PROCESSING COPY") || webData.Contains("PRINTING") || webData.Contains("WARMING UP")) //Working as planned
                {
                    mainApp.pushOutput(this.getName() + " is good!", 0);
                }
                else  //Has some type of problem, but needs to be determined how severe
                {
                    if (webData.Contains("ORDER CARTRIDGE")) //Runing out of ink
                    {
                        mainApp.pushOutput(this.getName() + " might need ink replacement!", 1);
                    }
                    else if (webData.Contains("TRAY 1 OPEN") || webData.Contains("TRAY 2 OPEN") || webData.Contains("TRAY 3 OPEN"))  //Has a tray open
                    {
                        mainApp.pushOutput(this.getName() + " has a tray open!", 1);
                    }
                    else if (webData.Contains("JAM"))  //Has a paper jam
                    {
                        mainApp.pushOutput(this.getName() + " has a JAM!", 2);
                    }
                    else if (webData.Contains("TRAY 1 EMPTY") || webData.Contains("TRAY 2 EMPTY") || webData.Contains("TRAY 3 EMPTY"))  //Needs paper filled
                    {
                        mainApp.pushOutput(this.getName() + " out of paper!", 2);
                    }
                    else if (webData.Contains("SUPPLIES VERY LOW"))  //Usually means both ink and maintenance are low
                    {
                        mainApp.pushOutput(this.getName() + " might need ink and a maintenance kit!", 1);
                    }
                    else if (webData.Contains("CLOSE TOP COVER"))  // The printer is open in some way
                    {
                        mainApp.pushOutput(this.getName() + " is open!", 1);
                    }
                    else if (webData.Contains("MAINTENANCE KIT LOW") || webData.Contains("MAINTENANCE KIT VERY LOW"))  //might need a maintenance kit
                    {
                        mainApp.pushOutput(this.getName() + " might need a maintenance kit!", 1);
                    }
                    else  //Weird error...
                        mainApp.pushOutput(this.getName() + " experiencing unknown error!", 2);
                }
            }

            catch (Exception e)  //Printer is not responding to request, most likely OFFLINE!
            {
                mainApp.pushOutput(this.getName() + " is OFFLINE!", 2);
            }


            //mainApp.pushOutput(goodPrinterCount + " printers in " + buildingName + " are GOOD!", 0);

        }

    }
}
