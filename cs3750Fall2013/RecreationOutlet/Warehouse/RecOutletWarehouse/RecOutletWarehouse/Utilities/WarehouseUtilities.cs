using RecOutletWarehouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Neodynamic.SDK.Printing;
using System.IO;

namespace RecOutletWarehouse.Utilities
{
    public class WarehouseUtilities
    {
        RecreationOutletContext db = new RecreationOutletContext();
        //TODO: Investigate alternate approaches that would prevent this class's methods
        //from being static

        /// <summary>
        /// Adds an exception's error text to an error log file.
        /// </summary>
        /// <param name="ex">The exception to log.</param>
        public static void LogError(Exception ex) {
            var writepath = "~/Logs/ERRORLOG.txt";
            StreamWriter errorFile = new StreamWriter(HttpContext.Current.Server.MapPath(writepath), true);
            string strTimeStamp = DateTime.Now.ToString("dd MMM yyyy HH:mm");
            errorFile.WriteLine("Error at " + strTimeStamp);
            errorFile.WriteLine("------------------------");
            errorFile.WriteLine("Error Text: " + ex);
            errorFile.WriteLine("------------------------ X -------------------------");
            errorFile.WriteLine();
            errorFile.Close();
        }

        /// <summary>
        /// Generates an RPC based on provided ITEM_DEPARTMENT, ITEM_CATEGORY, ITEM_SUBCATEGORY,
        /// and ITEM.ItemID parameters
        /// </summary>
        /// <param name="item">The ITEM object supplying the required parameters</param>
        /// <returns>An RPC in long form</returns>
        public static long GenerateRPC(RecOutletWarehouse.Models.ITEM item) {
            //Item convertedItem = db.ConvertNamesToIDs(item); //Convert dept, cat, subcat
            string RPC = Convert.ToByte(item.DepartmentID).ToString("D2"); //better way to do this?
            RPC += Convert.ToByte(item.CategoryID).ToString("D2");
            RPC += item.ItemID.ToString("D6");
            RPC += Convert.ToInt16(item.SubcategoryID).ToString("D3");

            return Convert.ToInt64(RPC);
        }

        /// <summary>
        /// Finds the Zebra thermal label printer
        /// </summary>
        /// <returns>If found, the name of the Zebra printer</returns>
        private static string SelectZebraPrinter() {
            //TODO: Return an error if multiple printers fit the criteria set forth in this method
            //TODO: Gracefully handle errors if the printer is not found
            string zebraPrinter = "";
            string[] installedPrinters = new String[System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count];
            System.Drawing.Printing.PrinterSettings.InstalledPrinters.CopyTo(installedPrinters, 0);
            for (int i = 0; i < installedPrinters.Count(); i++) {
                if (installedPrinters[i].Contains("LP 2824")){
                    zebraPrinter = installedPrinters[i];
                }
            }

            return zebraPrinter;
        }
        
        /// <summary>
        /// Constructs the bar code label and sends printing requests to the Zebra label printer
        /// </summary>
        /// <param name="item">The ITEM whose RPC is to be printed</param>
        /// <param name="qty">The quantity of labels desired</param>
        public static void PrintRPCLabel(ITEM item, int qty) {
            // TODO: Exception handling (what happens if the printer is not connected?)
            // TODO: Modify the ThermalLabel object to work with the "shorter" labels provided by the university;
            // it currently uses a 2" by 2" label that you will not have access to
            ThermalLabel RPCLabel = new ThermalLabel(UnitType.Inch, 2, 2); // The labeling object
            RPCLabel.GapLength = 0.2;

            // Create a Codabar for the RPC
            BarcodeItem RPCItem = new BarcodeItem(0.15, 1.35, 2, 1,
                BarcodeSymbology.Codabar, item.RecRPC.ToString()); // Convert the RPC to a string and position the bar code
            RPCItem.AddChecksum = false;
            RPCItem.CodabarStartChar = CodabarStartStopChar.A; //Beginning delimiting character (required for Codabar standard)
            RPCItem.CodabarStopChar = CodabarStartStopChar.D; // Ending delimiting character (required)
            RPCItem.DisplayStartStopChar = false; // Do not show the delimiting characters

            RPCItem.BarHeight = .5;
            RPCItem.BarWidth = .0101;
            RPCItem.Font.Size = 6; //must be less than 8 or digits will be left off RPC # at the bottom of label

            //Add descriptive text above bar code
            TextItem itemName = new TextItem(0.15, 1.2, 2, 1, item.Name);
            itemName.Font.Name = Neodynamic.SDK.Printing.Font.NativePrinterFontB;
            itemName.Font.Unit = FontUnit.Point;
            itemName.Font.Size = 6;

            RPCLabel.Items.Add(RPCItem);
            RPCLabel.Items.Add(itemName);

            // The following creates a PrintJob object, which is required to print labels
            using (PrintJob pj = new PrintJob()) {
                PrinterSettings lp2824 = new PrinterSettings();
                // The following statement assumes the printer will be connected via USB;
                // you may need to work with it to make it a network printer if the client
                // wants one printer shared among multiple computers
                lp2824.Communication.CommunicationType = CommunicationType.USB;
                lp2824.Dpi = 203;
                lp2824.ProgrammingLanguage = ProgrammingLanguage.ZPL;
                lp2824.PrinterName = SelectZebraPrinter();

                pj.PrinterSettings = lp2824; // Set the printer settings
                pj.Copies = qty; // Set the number of labels to what the user requested
                pj.Print(RPCLabel);
            }
        }

        /// <summary>
        /// Gets the count of Purchase Orders for today's date
        /// </summary>
        /// <returns>An int count of PURCHASE_ORDER objects</returns>
        public static int getPODateCount()
        {
            RecreationOutletContext entityDb = new RecreationOutletContext();

            List<PURCHASE_ORDER> poList = entityDb.PURCHASE_ORDER.ToList();

            int count = 0;

            for (int i = 0; i < poList.Count; i++)
            {
                if (poList[i].POOrderDate == DateTime.Now.Date)
                {
                    count++;
                }
            }
                
            return count;
        }
    }
}