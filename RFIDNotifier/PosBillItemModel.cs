using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFIDNotifier
{
   public class PosBillItemModel
    {
        public int SerialNo { get; set; }
        public string Barcode { get; set; }
        public string ItemId { get; set; }
        public decimal Qty { get; set; }
    }
}
