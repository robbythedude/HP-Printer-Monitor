//Penn State Behrend Live Printer Monitor
//This application is developed to monitor printers around the campus to check for paper shortages and errors
//Created by: Robert E. Steiner III (res5304/968685984)
//Created on: 10/15/14
//Modified by:
//Modified on:

//This is the main form of the application. The reoccuring timer and all functionality code is found here.
//The code for loading printers on startup is found here too.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrinterMonitor
{
    public partial class Main : Form
    {
        private string pathNameToPrinters = @"C:\Temp\Printers.txt"; //This is the path name to the Printers.txt
        private Thread timerExecute; //This thread handles timinig and execution of testing printers
        private bool hasCriticalHappened = false;   //This value toggles off/on based on when a critical output has occured
        private List<CheckBox> buildingCheckBoxes = new List<CheckBox>();  //Value holding the collection of generated textboxes based on the Printers.txt
        private int timer = 60;  //Timer used to calculate how long in between each printer check
        private bool isScanRunning = false; //This is used to make sure no more than two scans run
        private NotifyIcon trayIcon = null;  //The tray icon object used throughout project

        //Main function that prepares all components on the form, such as textboxes, buttons, etc.
        public Main(string[] args)
        {
            InitializeComponent();

            //If an argument is passed, assuming it is a file path, then overwite default path.
            try
            {
                pathNameToPrinters = args[0];
            }
            catch(Exception e){}  //Nothing was passed in
        }

        //This code excutes right before the form would display, thus all the start-up code executes from here
        //The creation of the tray icon is handled here
        private void Main_Load(object sender, EventArgs e)
        {
            this.Visible = false;  //Hiding form on startup
            this.ShowInTaskbar = false;  //Hides the form from the task bar below

            //Loading printers/workstations and starting monitor thread
            loadPrinters();
            timerExecute = new Thread(printerHandle);
            timerExecute.Start();

            //Creating the context menu that goes with the icon
            ContextMenu tempMenu = new ContextMenu();
            tempMenu.MenuItems.Add("Monitor App", showMonitor);
            tempMenu.MenuItems.Add("Scan Now", startScan);
            tempMenu.MenuItems.Add("-");
            tempMenu.MenuItems.Add("Exit", trayExit);

            //Creating the tray icon
            trayIcon = new NotifyIcon();
            trayIcon.Text = "PSB Printer Monitor";
            trayIcon.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            trayIcon.Visible = true;

            trayIcon.ContextMenu = tempMenu; //Setting the tray icon to have the created context menu

        }

        //This function contains the timer that launches the scan after countdown
        private void printerHandle()
        {

            while (true)
            {
                //This for loop handles the countdown timer 
                for (int i = timer; i >= 0; i--)
                {
                    this.Invoke((MethodInvoker)delegate  //This allows for accessing the forms buttons/textbox
                    {
                        textboxTimer.Text = i.ToString();
                    });
                    trayIcon.Text = "PSB Printer Monitor (" + i + ")";  //Displaying timer in the Icon title to keep user updated
                    Thread.Sleep(1000);
                }

                startScan();

            }
        }

        //This function will allow for input to display in according color
        //0 - Good (Black)
        //1 - Semi-important (Blue)
        //2 - Critical (Red)
        public void pushOutput(string output, int importance)
        {
            Invoke((MethodInvoker)delegate //This allows for accessing the forms buttons/textbox
                {
                    textboxPrompt.SelectionStart = textboxPrompt.TextLength;  //Preparing to alter output color
                    textboxPrompt.SelectionLength = 0;  //Preparing to alter output color

                    if (importance == 1)
                        textboxPrompt.SelectionColor = Color.Blue;  //Altering output color
                    else if (importance == 2)
                    {
                        textboxPrompt.SelectionColor = Color.Red;  //Altering output color
                        hasCriticalHappened = true;
                    }
                    else
                        textboxPrompt.SelectionColor = Color.Black;  //Altering output color

                    textboxPrompt.AppendText(output + "\n");  //Outputting
                    textboxPrompt.SelectionColor = textboxPrompt.ForeColor;  //Reset
                    textboxPrompt.ScrollToCaret();//Force focus to autoscroll with output
                });

        }

        //This function will perform various tasked based on critical output occuring (Bells, popups, etc)
        private void criticalCheck()
        {
            if (hasCriticalHappened) //Check if critical output occured
            {

                if (!checkboxSilent.Checked)  //Play sound if silent is not checked
                    System.Media.SystemSounds.Exclamation.Play();
                if (checkboxPopup.Checked)  //Refocus the screen and pop it up if checked
                {
                    Invoke((MethodInvoker)delegate //This allows for accessing the forms buttons/textbox
                        {
                            this.Visible = true;
                            this.ShowInTaskbar = true;
                            this.WindowState = FormWindowState.Normal;
                            this.Activate();
                        });
                }

                hasCriticalHappened = false;  //Reset critical for next scan
            }
        }

        //This function will handle the launching of individual printer viewer.
        private void printersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Printer> printerList = AbsPrinter.getPrinterObjs();  //Get whole list of printers loaded on start

            foreach (CheckBox cb in buildingCheckBoxes)  //Go through each Checkbox created
            {

                List<Printer> tempPrinterList = new List<Printer>();

                if (cb.Checked)  //If the chechbox is checked, start pulling individual printers based on Checkbox name
                {
                    string name = cb.Text;
                    foreach (Printer printer in printerList)
                    {
                        if (printer.getBuildingName().Equals(name))  //Check whole printer list for printers with matching names
                            tempPrinterList.Add(printer);
                    }
                    new IndividualPrinterViewer(tempPrinterList).Show();  //Launch individual viewer with altered printer list
                }
            }
        }

        //This function finds Printer.txt and loads all the printers lists and alters GUI to contain printer buildings
        //This function will check checkboxes that match the workstations found Printers.txt too
        private void loadPrinters()
        {

            List<string> tempBuildingList = new List<string>();  //Temporary building list for the printers
            bool onPrinters = true;  //Distinguising between printers and work stations
            string tempMachineNameMatch = null;  //Name of matching building name and workstation computer

            try
            {
                StreamReader sr = new StreamReader(pathNameToPrinters);
                string line;


                //Gathering all printer information and creating printer objects
                while ((line = sr.ReadLine()) != null)
                {
                    if (!line.Equals("") && !line.Substring(0, 3).Equals("-#-"))  //This is handling comments in the Printer.txt document and any linebreaks or weird stuff
                    {
                        if (!line.Equals("--[]--") && onPrinters)  //This is catching the toggle from printers to workstations
                        {
                            string[] items = line.Split(',');
                            new Printer(items[1].Replace(" ", string.Empty), items[0].Trim(), items[2].Trim(), this);  //Using trims and replace to remove unwanted spaces

                            if (!tempBuildingList.Contains(items[2].Trim()))  //Checking to see if printer location has been already added to a list of printer locations
                                tempBuildingList.Add(items[2].Trim());
                        }
                        else
                        {
                            onPrinters = false;  //Moving onto workstation computers
                            if (!line.Equals("--[]--")) //Gotta do this test again to dodge the first check
                            {
                                string[] items = line.Split(',');
                                if (items[0].ToUpper().Equals(System.Environment.MachineName))  //Computers name matches a computer marked in Printers.txt
                                {
                                    tempMachineNameMatch = items[1].Trim();  //Stores the building name that matches the computer
                                }
                            }

                        }
                    }
                }

                //Creating the GUI based on gathered printer locations
                foreach (string name in tempBuildingList)
                {
                    CheckBox tempCheckBox = new CheckBox();
                    tempCheckBox.Text = name;
                    flowlayoutMonitors.Controls.Add(tempCheckBox);
                    buildingCheckBoxes.Add(tempCheckBox);
                }

                //Going to enable the proper check box based on previously found default workstation
                foreach (CheckBox cb in buildingCheckBoxes)
                {
                    if (cb.Text.Equals(tempMachineNameMatch))
                    {
                        cb.Checked = true;
                    }
                }

            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(@"/!\ ERROR FINDING PRINTERS.TXT /!\");

                Environment.Exit(0);  //Terminates application
            }
        }

        //This function will be handling timer changers from the user on the dropbox
        private void comboboxTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboboxTime.Text)  //Bases the timer off the Text value of the dropdown menu
            {
                case "One Minute":
                    timer = 60;
                    break;
                case "Five Minutes":
                    timer = 60 * 5;
                    break;
                case "Fifteen Minutes":
                    timer = 60 * 15;
                    break;
                case "Thirty Minutes":
                    timer = 60 * 30;
                    break;
                case "One Hour":
                    timer = 60 * 60;
                    break;
                case "Two Hours":
                    timer = 60 * 60 * 2;
                    break;
            }
        }

        //Function that handles the Scan Now button push
        private void buttonScanNow_Click(object sender, EventArgs e)
        {
            timerExecute.Abort();  //Abort the current timer/thread
            timerExecute = new Thread(printerHandle);  //Restart the countdown thread
            timerExecute.Start();
            Thread tempThread = new Thread(startScan); //Starting a temp thread to start a scan
            tempThread.Start();
        }

        //Where the scan is handled when execute during the form
        private void startScan()
        {
            
                    if (!isScanRunning)  //Making sure a scan is not already running.
                    {
                        isScanRunning = true;
                        trayIcon.Text = "PSB Printer Monitor (SCANNING)";  //Altering icon title to match what is happening
                        Invoke((MethodInvoker)delegate //This allows for accessing the forms buttons/textbox
                            {
                                buttonScanNow.Enabled = false;
                            });

                        //Conditional statements to handle the checking of printers
                        pushOutput("------", 0);
                        pushOutput("Scan Started: " + DateTime.Now.ToString(), 0);
                        List<Printer> tempPrinterList = AbsPrinter.getPrinterObjs();
                        foreach (CheckBox cb in buildingCheckBoxes)
                        {
                            if (cb.Checked)
                            {
                                string name = cb.Text;
                                foreach (Printer printer in tempPrinterList)
                                {
                                    if (printer.getBuildingName().Equals(name))
                                        printer.test();
                                }

                            }
                        }

                        pushOutput("Scan Ended: " + DateTime.Now.TimeOfDay.ToString().Substring(0, 8), 0);
                        pushOutput("------", 0);

                        criticalCheck(); //This function will perform popups/sounds based on scan

                        Invoke((MethodInvoker)delegate //This allows for accessing the forms buttons/textbox
                        {
                            buttonScanNow.Enabled = true;
                        });

                        isScanRunning = false;

                    }

        }

        //Where the scan is handled when launched from tray
        private void startScan(object sender, EventArgs e)
        {
            if (!isScanRunning)  //Making sure a scan is not already running.
            {
                isScanRunning = true;
                Invoke((MethodInvoker)delegate //This allows for accessing the forms buttons/textbox
                {
                    buttonScanNow.Enabled = false;
                });

                //Conditional statements to handle the checking of printers
                pushOutput("------", 0);
                pushOutput("Scan Started: " + DateTime.Now.ToString(), 0);
                List<Printer> tempPrinterList = AbsPrinter.getPrinterObjs();
                foreach (CheckBox cb in buildingCheckBoxes)
                {
                    if (cb.Checked)
                    {
                        string name = cb.Text;
                        foreach (Printer printer in tempPrinterList)
                        {
                            if (printer.getBuildingName().Equals(name))
                                printer.test();
                        }

                    }
                }

                pushOutput("Scan Ended: " + DateTime.Now.TimeOfDay.ToString().Substring(0, 8), 0);
                pushOutput("------", 0);

                criticalCheck(); //This function will perform popups/sounds based on scan

                Invoke((MethodInvoker)delegate //This allows for accessing the forms buttons/textbox
                {
                    buttonScanNow.Enabled = true;
                });

                isScanRunning = false;
            }
        }


        //This function handles the closing X found on the form itself. Only alters the visibility of the form, does not close
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)  //Only executes if the closing is executed via user clicking the 'X'. Windows Shutdown will terminate the app properly.
            {
                e.Cancel = true;  //Cancels the actual closing
                Invoke((MethodInvoker)delegate //This allows for accessing the forms buttons/textbox
                {
                    this.Visible = false;
                    this.ShowInTaskbar = false;
                });
            }

        }

        //This is the code that actually exits the program. The button is found in the tray menu
        private void trayExit(object sender, EventArgs e)
        {

            while (timerExecute.ThreadState == ThreadState.WaitSleepJoin)  //Waits for the sleep session to end, then aborts the thread. Stops an error of aborting a thread while it sleeps.
            {
                timerExecute.Abort();
            }
            Application.Exit();  //Terminates application
        }

        //This is the code that will unhide the form when clicked in the tray icon
        private void showMonitor(object sender, EventArgs e)
        {
            Invoke((MethodInvoker)delegate //This allows for accessing the forms buttons/textbox
            {
                this.Visible = true;
                this.ShowInTaskbar = true;
            });
        }




    }
}
