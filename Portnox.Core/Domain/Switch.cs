using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portnox.Core.Domain;

namespace Portnox.Core.Domain
{
    public class Switch
    {
        public string Id { get; set; }
        public ICollection<Port> Ports { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
