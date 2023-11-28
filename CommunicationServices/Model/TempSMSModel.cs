using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationServices
{
    public class TempSMSModel
    {
        public string To { get; set; }
        public string BodyId { get; set; }
        public string[] Text { get; set; }
    }
}
