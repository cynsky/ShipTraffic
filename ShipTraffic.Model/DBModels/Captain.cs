using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipTraffic.Model.DBModels
{
    public class Captain:Base
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual List<Trip> Trips { get; set; }

        public override string ToString()
        {
            return String.Format("ID = {0}\nFirstName = {1}\nLastName = {2}", ID, FirstName, LastName);
        }
    }
}
