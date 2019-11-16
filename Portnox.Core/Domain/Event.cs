using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portnox.Core.Domain
{
    public class Event
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string SwitchId { get; set; }
        public string PortId { get; set; }
        public string DeviceId { get; set; }
        public string Remarks { get; set; }
    }

}
