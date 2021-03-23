using System;
using System.Collections.Generic;
using System.Text;
namespace ImageScann.Models
{
    public class Message
    {
        public string MsgContent { get; set; }
        public string CrtDate { get; set; }
        public int ID { get; set; }
        public string FromUser { get; set; }
        public string DataNbr { get; set; }
        public bool? bRead { get; set; }
    }
}
