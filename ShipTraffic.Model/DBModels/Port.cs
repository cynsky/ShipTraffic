using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipTraffic.Model.DBModels
{
    public class Port:Base
    {
        public string Name { get; set; }
        public virtual List<Ship> Ships { get; set; }
        public virtual City City { get; set; }
        public virtual List<Trip> TripFrom { get; set; }
        public virtual List<Trip> TripTo { get; set; }

        public override string ToString()
        {
            return String.Format(
                "ID = {0}\nName = {1}\nCity = {2} (Id = {3})",
                ID,
                Name,
                City.Name,
                City.ID
                );
        }
    }
}
