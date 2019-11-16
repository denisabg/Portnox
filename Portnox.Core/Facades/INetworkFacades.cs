using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portnox.Core.Domain;

namespace Portnox.Core.Facades
{
    public interface INetworkFacades
    {
        Task<Port> GetPortAsync(string id);

        Task<Device> GetDeviceAsync(string id);
        Task<Event> GetEventAsync(int id);
        Task<Switch> GetSwitchAsync(string id);
    }

}
