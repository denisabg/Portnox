using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portnox.Data;
using Portnox.Facades;

namespace Portnox.Tests
{
    [TestClass]
    public class NetworkEventsUnitTest
    {
        [TestMethod]
        public async Task GetSwitchesDataTask()
        {
            var switchId = "1.1.1.1";

            var factory = NetworkFacadeFactory.Create();

            var switchesResultAsync = await factory.GetSwitchAsync(switchId);

            Assert.IsNotNull(switchesResultAsync);
        }




        [TestMethod]
        public async Task GetPortsDataTask()
        {
            var portId = "1.1.1.1:12";

            var factory = NetworkFacadeFactory.Create();

            var portsResultAsync = await factory.GetPortAsync(portId);

            Assert.IsNotNull(portsResultAsync);
        }


        [TestMethod]
        public async Task GetEventsDataTask()
        {
            var eventId = 4;

            var factory = NetworkFacadeFactory.Create();

            var eventsResultAsync = await factory.GetEventAsync(eventId);

            Assert.IsNotNull(eventsResultAsync);
        }



        [TestMethod]
        public async Task GetDeviceDataTask()
        {
            var deviceId = "AABBCC000001";

            var factory = NetworkFacadeFactory.Create();

            var devicesResultAsync = await factory.GetDeviceAsync(deviceId);

            Assert.IsNotNull(devicesResultAsync);
        }




        [TestMethod]
        public async Task TestMethodFacadesTasks()
        {

            var portId = "1.1.1.1:12";
            var switchId = "1.1.1.1";
            var eventId = 4;
            var deviceId = "AABBCC000001";

            var facade = new NetworkFacades();

            var portsResultAsync = await facade.GetPortAsync(portId);
            var switchesResultAsync = await facade.GetSwitchAsync(switchId);
            var eventsResultAsync = await facade.GetEventAsync(eventId);
            var devicesResultAsync = await facade.GetDeviceAsync(deviceId);
        }


        [TestMethod]
        public void TestMethodGetData()
        {

            using (var ctx = new PortnoxContext())
            {

                var sw = ctx.Switches
                    .Include(x => x.Ports)
                    .Include(x => x.Events)
                    .FirstOrDefault(x => x.Id == "1.1.1.1");

                var p = ctx.Ports
                    .Include(x => x.Events)
                    .Include(x => x.Devices)
                    .Single(x => x.Id == "1.1.1.1:12");

                var dIds = ctx.Events
                    .Where(x => x.PortId == p.Id && x.DeviceId != null)
                    .Select(x => x.DeviceId)
                    .Distinct().ToArray();

                var f = ctx.Devices.First();
                var d = ctx.Devices.Where(x => dIds.Contains(x.Id)).ToArray();

                p.Devices = ctx.Devices
                    .Where(x => dIds.Contains(x.Id)).ToArray();

            }

        }
    }
}
