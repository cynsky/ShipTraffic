using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipTraffic.Model.DBModels
{
    public class Trip:Base
    {
        public int CaptainID { get; set; }
        public virtual Captain Captain{get;set;}
        public int ShipID { get; set; }
        public virtual Ship Ship{get;set;}
        public int PortToID { get; set; }
        public virtual Port PortTo { get; set; }
        public int PortFromID { get; set; }
        public virtual Port PortFrom { get; set; }
        public DateTime StartDate{get;set;}
        public DateTime EndDate { get; set; }

        public override string ToString()
        {
            return String.Format(
                "ID = {0}\nCaptain = {1}({2})\nShip = {3}\nPortFrom = {4}({5})\nPortTo = {6}({7})",
                ID,
                String.Format("{0} {1}",Captain.LastName,Captain.FirstName),
                CaptainID,
                Ship.ID,
                PortFrom.Name,
                PortFromID,
                PortTo.Name,
                PortToID
                );
        }
    }
}
