using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using ShipTraffic.Model.DBModels;

namespace ShipTraffic.Model.DBMapping
{
    class CaptainMap:EntityTypeConfiguration<Captain>
    {
        public CaptainMap()
        {
            this.HasKey(x => x.ID);
            this.HasMany(x => x.Trips);

            this.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
            this.Property(x => x.LastName).IsRequired().HasMaxLength(100);

        }
    }
}
