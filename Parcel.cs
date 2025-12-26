using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parcel_sending
{
    public class Parcel
    {
        public int Id { get; set; } = 0;
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
        public string Status { get; set; }
        public string Location { get; set; } = null;

    }
}
