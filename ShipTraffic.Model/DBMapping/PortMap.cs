using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using ShipTraffic.Model.DBModels;

namespace ShipTraffic.Model.DBMapping
{
    class PortMap:EntityTypeConfiguration<Port>
    {
        public PortMap()
        {
            this.HasKey(x => x.ID);
            this.HasMany(x => x.Ships);

            this.HasRequired(x => x.City).WithRequiredDependent(x => x.Port);//.Map(x=>x.MapKey("CityID"));
            this.HasMany(x => x.TripFrom).WithRequired(x => x.PortFrom).HasForeignKey(x=>x.PortFromID).WillCascadeOnDelete(false);
            this.HasMany(x => x.TripTo).WithRequired(x => x.PortTo).HasForeignKey(x=>x.PortToID).WillCascadeOnDelete(false);
            
            this.Property(x => x.Name).IsRequired().HasMaxLength(100);
        }
    }
}
