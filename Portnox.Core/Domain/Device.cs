using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portnox.Core.Domain
{
    public class Device
    {
        public string Id { get; set; }
        public ICollection<Event> Events { get; set; }
        public ICollection<Port> Ports { get; set; }
    }
}
