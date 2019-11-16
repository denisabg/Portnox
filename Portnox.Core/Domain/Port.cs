using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portnox.Core.Domain
{
    public class Port
    {
        public string Id { get; set; }

        public int Number { get; set; }

        public string SwitchId { get; set; }

        public ICollection<Device> Devices { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
