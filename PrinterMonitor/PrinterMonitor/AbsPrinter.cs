using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrinterMonitor
{
    public abstract class AbsPrinter
    {

        protected static List<Printer> printerList = new List<Printer>();  //List of all printers found on start-up

        //Returns the printerList with all printer objects
        public static List<Printer> getPrinterObjs()
        {
            return printerList;
        }


    }
}
