using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationServices
{
    public class EmailModel
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string[] CC { get; set; }
        public string Message { get; set; }
    }
    

}
