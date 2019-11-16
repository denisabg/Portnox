using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portnox.Data.Migrations.Map
{
    class EventMap : EntityTypeConfiguration<Portnox.Core.Domain.Event>
    {
        public EventMap()
        {
            this.ToTable("dbo.vw_Events");

            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Primary Key
            this.HasKey(t => t.Id);
        }
    }
}
