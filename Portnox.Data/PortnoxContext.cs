using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portnox.Core.Domain;
using Portnox.Data.Migrations.Map;
using Switch = Portnox.Core.Domain.Switch;

namespace Portnox.Data
{
    public class PortnoxContext : DbContext
    {
        public DbSet<NetworkEvent> NetworkEvents { get; set; }
        public DbSet<Switch> Switches { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Port> Ports { get; set; }
        public DbSet<Device> Devices { get; set; }


        public PortnoxContext() : base("PortnoxContext")
        {
            Database.SetInitializer<PortnoxContext>(new SampleInitializer());

            Database.Log = (x) => Trace.TraceInformation(x);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SwitchMap());
            modelBuilder.Configurations.Add(new EventMap());
            modelBuilder.Configurations.Add(new PortMap());
            modelBuilder.Configurations.Add(new DeviceMap());

            modelBuilder.Entity<Port>()
                .HasMany<Device>(s => s.Devices)
                .WithMany(c => c.Ports)
                .Map(cs =>
                {
                    cs.MapLeftKey("PortId");
                    cs.MapRightKey("DeviceId");
                    cs.ToTable("vw_Port_Devices");
                });
        }

        public class SampleInitializer : CreateDatabaseIfNotExists<PortnoxContext>
        {
            protected override void Seed(PortnoxContext context)
            {
                var table = new List<NetworkEvent>
                {
                    new NetworkEvent
                    {
                        Device_Mac = "AABBCC000001",
                        Event_Id = 1001,
                        Switch_Ip = "1.1.1.1",
                        Port_Id = 12,
                        Remarks = "New device was added to port 12 of switch 1.1.1.1"
                    },
                    new NetworkEvent
                    {
                        Device_Mac = "AABBCC000009",
                        Event_Id = 1001,
                        Switch_Ip = "1.1.1.1",
                        Port_Id = 11,
                        Remarks = "New device was added to port 12 of switch 1.1.1.1"
                    },
                    new NetworkEvent
                    {
                        Device_Mac = null,
                        Event_Id = 1003,
                        Switch_Ip = "192.168.1.1",
                        Port_Id = 48,
                        Remarks = "Port 48 of switch 192.168.1.1 was disabled"
                    },
                    new NetworkEvent
                    {
                        Device_Mac = null,
                        Event_Id = 1002,
                        Switch_Ip = "1.1.1.1",
                        Port_Id = 12,
                        Remarks = "New device was removed from port 12 of switch 1.1.1.1"
                    },
                    new NetworkEvent
                    {
                        Device_Mac = "AABBCC000001",
                        Event_Id = 1001,
                        Switch_Ip = "192.168.1.1",
                        Port_Id = 47,
                        Remarks = "New device was added to port 47 of switch 192.168.1.1"
                    }
                };

                context.NetworkEvents.AddRange(table);

                context.SaveChanges();

                base.Seed(context);
            }
        }
    }
}
