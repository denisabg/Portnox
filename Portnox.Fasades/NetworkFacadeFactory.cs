using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portnox.Core.Facades;
using Portnox.Facades;

namespace Portnox.Facades
{
    public static class NetworkFacadeFactory
    {
        public static INetworkFacades Create()
        {
            return new NetworkFacades();
        }
    }
}
