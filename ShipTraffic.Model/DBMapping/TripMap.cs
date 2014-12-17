using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using ShipTraffic.Model.DBModels;

namespace ShipTraffic.Model.DBMapping
{
    class TripMap:EntityTypeConfiguration<Trip>
    {
        public TripMap()
        {
            this.HasKey(x => x.ID);

            this.HasRequired(x => x.Captain);
            this.HasRequired(x => x.Ship);
           // this.HasRequired(x => x.PortTo);
           // this.HasRequired(x => x.PortFrom);

            this.Property(x => x.EndDate).IsRequired();
            this.Property(x => x.StartDate).IsRequired();

           
        }
    }
}
