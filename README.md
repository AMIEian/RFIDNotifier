# RFIDNotifier
GINESYS RFID NOTIFIER
This dll code template has been shared by Ginesys Software team. Inside this template Tagid team has implemented clipboard sharing method to share JSON string of POS billed items with Tagid's reader software.
Ginesys team now has to use this dll inside there code and call it's 
public void Notify(string posBillItemsJSON, out string plugin_status, out string plugin_message,  out string plugin_output)
method with respective parameters on every bill generation.
