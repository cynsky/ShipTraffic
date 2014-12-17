using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipTraffic.Model.DBModels
{
    public class Cargo:Base
    {
        public int TypeID { get; set; }
        public virtual Type Type { get; set; }
        public int TripID { get; set; }
        public virtual Trip Trip { get; set; }
        public double Weight { get; set; }
        public decimal Price { get; set; }
        public decimal InsurancePrice { get; set; }
        public int Number { get; set; }

        public override string ToString()
        {
            return String.Format(
                "ID = {0}\nTrip = {1}\nType = {2}\nWeight = {3}\nNumber = {4}\nPrice = {5}\nInsurancePrice = {6}",
                ID,
                TripID,
                Type.Name,
                Weight,
                Number,
                Price,
                InsurancePrice
                );
        }
    }
}
