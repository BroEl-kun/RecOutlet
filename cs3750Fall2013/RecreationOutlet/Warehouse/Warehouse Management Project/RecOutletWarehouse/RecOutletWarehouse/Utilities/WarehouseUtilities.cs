﻿using RecOutletWarehouse.Models.ItemManagement;
using RecOutletWarehouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Neodynamic.SDK.Printing;

namespace RecOutletWarehouse.Utilities {
    public class WarehouseUtilities {

        //TODO: Investigate alternate approaches that would prevent this class's methods
        //from being static

        public static long GenerateRPC(RecOutletWarehouse.Models.ItemManagement.Item item) {
            DataFetcherSetter db = new DataFetcherSetter();
            //Item convertedItem = db.ConvertNamesToIDs(item); //Convert dept, cat, subcat
            string RPC = Convert.ToByte(item.Department).ToString("D2"); //better way to do this?
            RPC += Convert.ToByte(item.Category).ToString("D2");
            RPC += item.ItemId.ToString("D6");
            RPC += Convert.ToInt16(item.Subcategory).ToString("D3");

            return Convert.ToInt64(RPC);
        }

        private static string SelectZebraPrinter() {
            //TODO: Return an error if multiple printers fit the criteria set forth in this method
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

        public static void PrintRPC(long RPC) {
            //TODO: Exception handling (what happens if the printer is not connected?)
            ThermalLabel RPCLabel = new ThermalLabel(UnitType.Inch, 2, 2);
            RPCLabel.GapLength = 0.2;

            BarcodeItem RPCItem = new BarcodeItem(0.2, 1, 2, 1,
                BarcodeSymbology.Codabar, RPC.ToString());
            RPCItem.AddChecksum = false;
            RPCItem.CodabarStartChar = CodabarStartStopChar.A;
            RPCItem.CodabarStopChar = CodabarStartStopChar.D;
            RPCItem.DisplayStartStopChar = false;

            RPCItem.BarHeight = .75;
            RPCItem.BarWidth = .0101;

            RPCLabel.Items.Add(RPCItem);

            using (PrintJob pj = new PrintJob()) {
                PrinterSettings lp2824 = new PrinterSettings();
                lp2824.Communication.CommunicationType = CommunicationType.USB;
                lp2824.Dpi = 203;
                lp2824.ProgrammingLanguage = ProgrammingLanguage.ZPL;
                lp2824.PrinterName = SelectZebraPrinter();

                pj.PrinterSettings = lp2824;
                pj.Copies = 1;
                pj.Print(RPCLabel);
            }
        }

    }
}