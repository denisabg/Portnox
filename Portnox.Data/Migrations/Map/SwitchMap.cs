using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Portnox.Data.Migrations.Map
{
    public class SwitchMap : EntityTypeConfiguration<Portnox.Core.Domain.Switch>
    {
        public SwitchMap()
        {
            this.ToTable("dbo.vw_Switches");

            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Primary Key
            this.HasKey(t => t.Id);

            //this.Ignore(x => x.Events);
            //this.Ignore(x => x.Ports);
        }   
    }
}