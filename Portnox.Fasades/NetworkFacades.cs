using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portnox.Core.Domain;
using Portnox.Core.Facades;
using Portnox.Data;

namespace Portnox.Facades
{

    public class NetworkFacades : INetworkFacades
    {
        public async Task<Port> GetPortAsync(string id)
        {
            using (var ctx = new PortnoxContext())
            {
                return await ctx.Ports
                    .Include(x => x.Events)
                    .Include(x => x.Devices)
                    .SingleAsync(x => x.Id == id);
            }
        }

        public async Task<Device> GetDeviceAsync(string id)
        {
            using (var ctx = new PortnoxContext())
            {
                return await ctx.Devices
                        .Include(x => x.Ports)
                        .Include(x => x.Events)
                        .SingleAsync(x => x.Id == id);
            }
        }

        public async Task<Event> GetEventAsync(int id)
        {
            using (var ctx = new PortnoxContext())
            {
                return await ctx.Events
                    .SingleAsync(x => x.Id == id);
            }
        }

        public async Task<Switch> GetSwitchAsync(string id)
        {
            using (var ctx = new PortnoxContext())
            {
                return await ctx.Switches
                    .Include(x => x.Ports)
                    .Include(x => x.Events)
                    .SingleAsync(x => x.Id == id);
            }
        }
    }
}
