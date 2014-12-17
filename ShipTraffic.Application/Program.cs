using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShipTraffic.Model;
using ShipTraffic.Model.DBModels;

namespace ShipTraffic.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ShipTrafficContext context = new ShipTrafficContext())
            {
                Application app = new Application();
                app.Captains = new ShipRepository<Captain>(context);
                app.Cargos = new ShipRepository<Cargo>(context);
                app.Cities = new ShipRepository<City>(context);
                app.Ports = new ShipRepository<Port>(context);
                app.Ships = new ShipRepository<Ship>(context);
                app.Trips = new ShipRepository<Trip>(context);
                app.Types = new ShipRepository<ShipTraffic.Model.DBModels.Type>(context);
                app.Start();
                try
                {
                    context.SaveChanges();
                }
                catch(Exception)
                {
                    Console.WriteLine("Error of saving results.");
                    Console.ReadKey();
                }
            }
        }
    }
}