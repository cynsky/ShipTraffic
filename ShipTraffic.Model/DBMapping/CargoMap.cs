using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using ShipTraffic.Model.DBModels;

namespace ShipTraffic.Model.DBMapping
{
    class CargoMap:EntityTypeConfiguration<Cargo>
    {
        public CargoMap()
        {
            this.HasKey(x => x.ID);
            this.HasRequired(x => x.Trip);
            this.HasRequired(x => x.Type);

            this.Property(x => x.Weight).IsRequired();
            this.Property(x => x.Price).IsRequired();
            this.Property(x => x.Number).IsRequired();
            this.Property(x => x.InsurancePrice).IsRequired();
        }
    }
}
