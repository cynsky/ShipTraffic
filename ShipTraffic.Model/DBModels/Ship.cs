using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipTraffic.Model.DBModels
{
    public class Ship:Base
    {
        public int PortID { get; set; }
        public virtual Port Port { get; set; }
        public double Capacity { get; set; }
        public DateTime CreateDate { get; set; }
        public double MaxDistance { get; set; }
        public int TeamCount { get; set; }

        public virtual List<Trip> Trips { get; set; }

        public override string ToString()
        {
            return String.Format(
                "ID = {0}\nPort = {1}({2})\nCapacity = {3}\nCreateDate = {4}\nMaxdistance = {5}\nTeamCount = {6}",
                ID,
                Port.Name,
                Port.ID,
                Capacity,
                CreateDate.ToShortDateString(),
                MaxDistance,
                TeamCount
                );
        }
    }
}
