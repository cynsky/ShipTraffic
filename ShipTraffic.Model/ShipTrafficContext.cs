using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ShipTraffic.Model.DBModels;
using ShipTraffic.Model.DBMapping;
using System.Configuration;

namespace ShipTraffic.Model
{
    public class ShipTrafficContext:DbContext
    {
        public ShipTrafficContext()
            : base("ShipTraffic")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }
        public DbSet<Captain> Captains { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Ship> Ships { get; set; }
        public DbSet<Port> Ports { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<ShipTraffic.Model.DBModels.Type> Types { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CaptainMap());
            modelBuilder.Configurations.Add(new CargoMap());
            modelBuilder.Configurations.Add(new CityMap());
            modelBuilder.Configurations.Add(new PortMap());
            modelBuilder.Configurations.Add(new ShipMap());
            modelBuilder.Configurations.Add(new TripMap());
            modelBuilder.Configurations.Add(new TypeMap());
        }
    }
}