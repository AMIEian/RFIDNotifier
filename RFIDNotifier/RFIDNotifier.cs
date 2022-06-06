using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
//using Newtonsoft.Json.Schema;

/// <summary>
/// This DLL file is a template for handling RFID events generated from Ginesys POS systems.
/// RFID integration patterns with Ginesys POS are of following types - 
/// 
/// 1. Single SKU scanning with RFID scanner through regular barcode scanning option in Ginesys POS
///    In this case though barcodes are read in bulk by the RFID scanner, they are added one by one
///    through the regular barcode scanning window in Ginesys POS. The barcodes are scanned one after
///    the other and the cashier does not get to review the barcodes being scanned.
///    
/// 2. Multiple SKU scanning with RFID scanner through bulk barcode scanning option in Ginesys POS
///    In this case barcodes are scanned by the RFID scanner and are populated in a bulk scanning
///    window of Ginesys POS. In this mode, the cashier gets a chance to review the scanned barcodes,
///    check the quantities and verify if all were scanned properly.
///    
/// 3. Any one of the above options can also be integrated with anti-theft alarm systems installed
///    in POS stores where the "checked-out" RFIDs can be detected by the alarm system and allow them
///    to pass without firing the alarm. This way of RFID integration removes the need for using 
///    additional EAS tags and Sensormatic gates. Instead, RFID scanning gates are used to allow
///    checked out RFID tags and fire alarms for not checked-out tags.
///    
/// However, the additional integration for using RFID based anti-theft system, will require the POS
/// system to notify the RFID scanning system about the "checked-out" tags. The RFID scanning system
/// will then use the notification from POS to notify the RFID based gate with the unique RFID tag IDs.
/// In this way, the POS system does not store the unique RFID. The POS system can supply the follwing -
/// 1. SERIALNO (serial number of the item in the cart)
/// 1. ICODE (unique Ginesys SKU code)
/// 2. BARCODE (the scanning barcode)
/// 3. QTY (+ for Sale, - for Return) 
/// The RFID scanning system can then check its local cache to find out the respective unique RFIDs
/// and inform the RFID scanning gate with the unique IDs. This is because multiple pieces of the
/// same SKU will carry same barcode but may carry different RFID codes.
/// 
/// This handler gets notified by the POS system after the bill is successfully saved.
/// If handling is not successful, the handler should throw an exception with proper message set in the error message.
/// </summary>
namespace RFIDNotifier
{
    public class RFIDNotifier
    {
        /// <summary>
        /// Receive notification from POS
        /// </summary>
        /// <param name="posBillItemsJSON">The items that have been checked out from POS.</param>
        /// <param name="plugin_status">Status returned by the handler. Currently POS does not take any action on this.</param>
        /// <param name="plugin_message">Message returned by the handler. Currently POS does not take any action on this.</param>
        /// <param name="plugin_output">Output data structure (JSON) returned by the handler. Currently POS does not take any action on this.</param>
        /// <returns></returns>
        public void Notify(string posBillItemsJSON, out string plugin_status,  out string plugin_message,  out string plugin_output)
        {
            object[] parameters = new object[4];
            try
            {
                // trying to parse json
                PosBillItemModel posBillItems = new PosBillItemModel();
                var items = JsonConvert.DeserializeObject<List<PosBillItemModel>>(posBillItemsJSON);

                // PLEASE REPLACE THE FOLLOWING CODE WITH YOUR CODE FOR RFID INTEGRATION

                // Successful execution sample
                // ---------------------------------------------------------------------------------------------------------
                // Intialize plugin status
                plugin_status = "";
                plugin_message = "Gate notified successfully";
                plugin_output = null;

                Clipboard.Clear();
                string data = "Tgid";
                data = data + posBillItemsJSON;
                Clipboard.SetText(data);
                // ---------------------------------------------------------------------------------------------------------


                // ---------------------------------------------------------------------------------------------------------
            }
            catch (Exception ex)
            {
                //Intialize plugin status
                plugin_status = null;
                plugin_message = null;
                plugin_output = null;
                parameters[0] = null;

                // Failed execution sample
                // ---------------------------------------------------------------------------------------------------------
                // Intialize plugin status
                plugin_status = "Hardware_Init_Failed";
                plugin_message = "Gate could not be notified. Please contact support.";
                plugin_output = "<JSONDATA>";
                throw new Exception(plugin_message);

            }
           
        }
    }


}
