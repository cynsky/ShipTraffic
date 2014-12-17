using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipTraffic.Model.DBModels
{
    public class Type:Base
    {
        public string Name { get; set; }
        public virtual List<Cargo> Cargos { get; set; }

        public override string ToString()
        {
            return String.Format(
                "ID = {0}\nName = {1}",
                ID,
                Name
                );
        }
    }
}
