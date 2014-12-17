using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using ShipTraffic.Model.DBModels;

namespace ShipTraffic.Model.DBMapping
{
    class CityMap:EntityTypeConfiguration<City>
    {
        public CityMap()
        {
            this.HasKey(x => x.ID);
            this.HasRequired(x => x.Port).WithRequiredPrincipal(x=>x.City);
            
            this.Property(x => x.Name).IsRequired().HasMaxLength(100);
        }
    }
}
