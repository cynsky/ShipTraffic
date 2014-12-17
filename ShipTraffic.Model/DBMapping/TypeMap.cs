using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using ShipTraffic.Model.DBModels;

namespace ShipTraffic.Model.DBMapping
{
    class TypeMap:EntityTypeConfiguration<Type>
    {
        public TypeMap()
        {
            this.HasKey(x => x.ID);
            this.HasMany(x => x.Cargos);

            this.Property(x => x.Name).IsRequired();
        }
    }
}
