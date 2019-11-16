using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portnox.Data.Migrations.Map
{
    class DeviceMap : EntityTypeConfiguration<Portnox.Core.Domain.Device>
    {
        public DeviceMap()
        {
            this.ToTable("dbo.vw_Devices");

            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Primary Key
            this.HasKey(t => t.Id);
        }
    }
}
