using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using ShipTraffic.Model.DBModels;

namespace ShipTraffic.Model.DBMapping
{
    class ShipMap:EntityTypeConfiguration<Ship>
    {
        public ShipMap()
        {
            this.HasKey(x => x.ID);

            this.HasMany(x => x.Trips);
            this.HasRequired(x => x.Port);

            this.Property(x => x.Capacity).IsRequired();
            this.Property(x => x.CreateDate).IsRequired();
            this.Property(x => x.MaxDistance).IsRequired();
            this.Property(x => x.TeamCount).IsRequired();
        }
    }
}
