using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShipTraffic.Model.DBModels;
using System.Data.Entity;

namespace ShipTraffic.Application
{
    public enum ActiveTable
    {
        Captains,
        Trips,
        Ships,
        Ports,
        Cities,
        Cargos,
        Types
    }

    public class Application
    {
        public Application()
        {

        }
        private ShipTraffic.UI.UI ui = new ShipTraffic.UI.UI();
        public IRepository<Captain> Captains { get; set; }
        public IRepository<Cargo> Cargos { get; set; }
        public IRepository<City> Cities { get; set; }
        public IRepository<Port> Ports { get; set; }
        public IRepository<Ship> Ships { get; set; }
        public IRepository<Trip> Trips { get; set; }
        public IRepository<ShipTraffic.Model.DBModels.Type> Types { get; set; }
#region Edit
        private bool modifiIt(string value)
        {
            Console.WriteLine(String.Format("{0}\nModify it? (Y(y)/N(n))", value));
            char answr = Console.ReadLine()[0];
            if (
                answr == 'y'
                ||
                answr == 'Y'
                )
            {
                Console.WriteLine();
                return true;
            }
            Console.WriteLine();
            return false;
        }
        public void EditCaptain()
        {
            Console.Write("Enter captain id: ");
            int id;
            if (!int.TryParse(Console.ReadLine(),out id))
            {
                Console.WriteLine("Wrong data");
                Console.ReadKey();
                return;
            }
            Captain captain;
            if ((captain = Captains.GetAll().FirstOrDefault(c=>c.ID==id))==null)
            {
                Console.WriteLine("Captain with this id don't exist");
                Console.ReadKey();
                return;
            }
            if (modifiIt(String.Format("FirstName = {0}",captain.FirstName)))
            {
                Console.Write("Enter new FirstName: ");
                captain.FirstName = Console.ReadLine();
            }

            if (modifiIt(String.Format("LastName = {0}", captain.LastName)))
            {
                Console.Write("Enter new LastName: ");
                captain.LastName = Console.ReadLine();
            }
            
        }
        public void EditCargo() 
        {
            int id;
            Console.Write("Enter id: ");
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Wrong data");
                Console.ReadKey();
                return;
            }
            Cargo cargo;
            if ((cargo = Cargos.GetAll().FirstOrDefault(c => c.ID == id)) == null)
            {
                Console.WriteLine("City with is id don't exist");
                Console.ReadKey();
                return;
            }

            int iValue;
            if (modifiIt(String.Format("Trip = {0}", cargo.TripID)))
            {
                Console.Write("Enter trip id");
                if (!int.TryParse(Console.ReadLine(), out iValue))
                {
                    Console.WriteLine("Wrong data");
                    Console.ReadKey();
                    return;
                }
                if (Trips.GetAll().FirstOrDefault(t => t.ID == iValue) == null)
                {
                    Console.WriteLine("Trip with is id do't exist");
                    Console.ReadKey();
                    return;
                }
                cargo.TripID = iValue;
            }
            if (modifiIt(String.Format("Type = {0}({1})", cargo.Type.Name, cargo.TypeID)))
            {
                Console.Write("Enter type id: ");
                if (!int.TryParse(Console.ReadLine(), out iValue))
                {
                    Console.WriteLine("Wrong data");
                    Console.ReadKey();
                    return;
                }
                if (Types.GetAll().FirstOrDefault(t => t.ID == iValue) == null)
                {
                    Console.WriteLine("Trip with is id do't exist");
                    Console.ReadKey();
                    return;
                }
                cargo.TypeID = iValue;
            }
            double dValue;
            if (modifiIt(String.Format("Weight = {0}", cargo.Weight)))
            {
                Console.Write("Enter weight: ");
                if (!double.TryParse(Console.ReadLine(), out dValue))
                {
                    Console.WriteLine("Wrong data");
                    Console.ReadKey();
                    return;
                }
                cargo.Weight = dValue;
            }
            if (modifiIt(String.Format("Number = {0}", cargo.Number)))
            {
                Console.Write("Enter number: ");
                if (!int.TryParse(Console.ReadLine(), out iValue))
                {
                    Console.WriteLine("Wrong data");
                    Console.ReadKey();
                    return;
                }
                cargo.Number = iValue;
            }

            decimal mValue;
            if (modifiIt(String.Format("Price = {0}", cargo.Price)))
            {
                Console.Write("Enter Price: ");
                if (!decimal.TryParse(Console.ReadLine(), out mValue))
                {
                    Console.WriteLine("Wrong data");
                    Console.ReadKey();
                    return;
                }
                cargo.Price = mValue;
            }
            if (modifiIt(String.Format("Insurance price = {0}", cargo.InsurancePrice)))
            {
                Console.Write("Enter insurance price: ");
                if (!decimal.TryParse(Console.ReadLine(), out mValue))
                {
                    Console.WriteLine("Wrong data");
                    Console.ReadKey();
                    return;
                }
                cargo.InsurancePrice = mValue;
            }
            
        }
        public void EditCity()
        {
            int id;
            Console.Write("Enter id: ");
            if (!int.TryParse(Console.ReadLine(),out id))
            {
                Console.WriteLine("Wrong data");
                Console.ReadKey();
                return;
            }
            City city;
            if ((city = Cities.GetAll().FirstOrDefault(c=>c.ID==id))==null)
            {
                Console.WriteLine("City with is id don't exist");
                Console.ReadKey();
                return;
            }
            if (modifiIt(String.Format("Name = {0}",city.Name)))
            {
                Console.Write("Enter new name: ");
                city.Name = Console.ReadLine();
            }
        }
        public void EditPort()
        {
            Console.Write("Enter port id: ");
            int id;
            if (!int.TryParse(Console.ReadLine(),out id))
            {
                Console.WriteLine("Wrong data");
                Console.ReadKey();
                return;
            }
            Port port = new Port();
            if ((port = Ports.GetAll().FirstOrDefault(p=>p.ID==id))==null)
            {
                Console.WriteLine("Port with this id don't exist");
                Console.ReadKey();
                return;
            }
            if (modifiIt(String.Format("Name = {0}",port.Name)))
            {
                Console.WriteLine("Enter new name: ");
                port.Name = Console.ReadLine();
            }
            if (modifiIt(String.Format("City = {0} (Id = {1}",port.City.Name,port.City.ID)))
            {
                Console.Write("Enter city id: ");
                int iValue;
                if (!int.TryParse(Console.ReadLine(), out iValue))
                {
                    Console.WriteLine("Wrong data");
                    Console.ReadLine();
                    return;
                }
                City city;
                if ((city = Cities.GetAll().FirstOrDefault((c) => c.ID == iValue)) == null)
                {
                    Console.WriteLine("City with this id do't exist");
                    Console.ReadKey();
                    return;
                }
                port.City = city;
            }
        }
        public void EditShip()
        {
            Console.WriteLine("Enter ship id: ");
            int id;
            if (!int.TryParse(Console.ReadLine(),out id))
            {
                Console.WriteLine("Wrong data");
                Console.ReadKey();
                return;
            }
            Ship ship;
            if ((ship=Ships.GetAll().FirstOrDefault(s=>s.ID == id)) == null)
            {
                Console.WriteLine("Ship with this id don't exist");
                Console.ReadKey();
                return;
            }
            int iValue;
            double dValue;
            if (modifiIt(String.Format("Port = {0} ({1})",ship.Port.Name,ship.PortID)))
            {
                Console.Write("Enter port ID: ");
                if (!int.TryParse(Console.ReadLine(), out iValue))
                {
                    Console.WriteLine("Wrong data");
                    Console.ReadKey();
                    return;
                }
                if (Ports.GetAll().FirstOrDefault((p) => p.ID == iValue) == null)
                {
                    Console.WriteLine("Port with this id don't exist");
                    Console.ReadKey();
                    return;
                }
                ship.PortID = iValue;
            }
            if (modifiIt(String.Format("Capacity = {0}",ship.Capacity)))
            {

                Console.Write("Enter capacity: ");
                if (!double.TryParse(Console.ReadLine(), out dValue))
                {
                    Console.WriteLine("Wrong data");
                    Console.ReadKey();
                    return;
                }
                ship.Capacity = dValue;
            }
            if (modifiIt(String.Format("Max distnace = {0}",ship.MaxDistance)))
            {
                Console.Write("Enter max distance: ");
                if (!double.TryParse(Console.ReadLine(), out dValue))
                {
                    Console.WriteLine("Wrong data");
                    Console.ReadKey();
                    return;
                }
                ship.MaxDistance = dValue;
            }
            if (modifiIt(String.Format("Team count: ", ship.TeamCount)))
            {
                Console.Write("Enter team count: ");
                if (!int.TryParse(Console.ReadLine(), out iValue))
                {
                    Console.WriteLine("Wrong data");
                    Console.ReadKey();
                    return;
                }
                ship.TeamCount = iValue;
            }
            if (modifiIt(String.Format("Creat date = {0}",ship.CreateDate.ToShortDateString())))
            {
                DateTime date;
                Console.Write("Enter create date: ");
                if (!DateTime.TryParse(Console.ReadLine(), out date))
                {
                    Console.WriteLine("Wrong data");
                    Console.ReadKey();
                    return;
                }
                ship.CreateDate = date;
            }

        }
        public void EditTrip()
        {
            Console.WriteLine("Enter trip id: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Wrong data");
                Console.ReadKey();
                return;
            }
            Trip trip;
            if ((trip = Trips.GetAll().FirstOrDefault(s => s.ID == id)) == null)
            {
                Console.WriteLine("Trip with this id don't exist");
                Console.ReadKey();
                return;
            }

            int iValue;
            if (modifiIt(String.Format("Captain = {0} {1}({2})", trip.Captain.FirstName, trip.Captain.LastName, trip.CaptainID)))
            {
                Console.Write("Enter captain id: ");
                if (!int.TryParse(Console.ReadLine(), out iValue))
                {
                    Console.WriteLine("Wrong data");
                    Console.ReadKey();
                    return;
                }
                if (Captains.GetAll().FirstOrDefault(t => t.ID == iValue) == null)
                {
                    Console.WriteLine("Captain with is id do't exist");
                    Console.ReadKey();
                    return;
                }
                if (Trips.GetAll().FirstOrDefault(t => t.CaptainID == iValue) != null)
                {
                    Console.WriteLine("Catain is busy");
                    Console.ReadKey();
                    return;
                }
                trip.CaptainID = iValue;
            }
            if (modifiIt(String.Format("Ship = {0}", trip.ShipID)))
            {
                Console.Write("Enter ship id: ");
                if (!int.TryParse(Console.ReadLine(), out iValue))
                {
                    Console.WriteLine("Wrong data");
                    Console.ReadKey();
                    return;
                }
                if (Ships.GetAll().FirstOrDefault(t => t.ID == iValue) == null)
                {
                    Console.WriteLine("Ship with this id do't exist");
                    Console.ReadKey();
                    return;
                }
                if (Trips.GetAll().FirstOrDefault(t => t.ShipID == iValue) != null)
                {
                    Console.WriteLine("Ship is busy");
                    Console.ReadKey();
                    return;
                }
                trip.ShipID = iValue;
            }
            if (modifiIt(String.Format("Port from = {0}({1})", trip.PortFrom.Name, trip.PortFromID)))
            {
                Console.Write("Enter port from: ");
                if (!int.TryParse(Console.ReadLine(), out iValue))
                {
                    Console.WriteLine("Wrong data");
                    Console.ReadKey();
                    return;
                }
                if (Ports.GetAll().FirstOrDefault((p) => p.ID == iValue) == null)
                {
                    Console.WriteLine("Port with this id don't exist");
                    Console.ReadKey();
                    return;
                }
                trip.PortFromID = iValue;
            }
            if (modifiIt(String.Format("Port to = {0}({1})", trip.PortTo.Name, trip.PortToID)))
            {
                Console.Write("Enter port to: ");
                if (!int.TryParse(Console.ReadLine(), out iValue))
                {
                    Console.WriteLine("Wrong data");
                    Console.ReadKey();
                    return;
                }
                if (trip.PortFromID == trip.PortToID)
                {
                    Console.WriteLine("Port from and to can't be same");
                    Console.ReadKey();
                    return;
                }
                if (Ports.GetAll().FirstOrDefault((p) => p.ID == iValue) == null)
                {
                    Console.WriteLine("Port with this id don't exist");
                    Console.ReadKey();
                    return;
                }
                trip.PortToID = iValue;
            }
            DateTime date;
            if (modifiIt(String.Format("Start date = {0}", trip.StartDate)))
            {
                Console.Write("Enter start date: ");
                if (!DateTime.TryParse(Console.ReadLine(), out date))
                {
                    Console.WriteLine("Wrong data");
                    Console.ReadKey();
                    return;
                }
                trip.StartDate = date;
            }
            if (modifiIt(String.Format("End date = {0}", trip.EndDate)))
            {
                Console.Write("Enter end date: ");
                if (!DateTime.TryParse(Console.ReadLine(), out date))
                {
                    Console.WriteLine("Wrong data");
                    Console.ReadKey();
                    return;
                }
                trip.EndDate = date;
            }
        }
        public void EditType()
        {
            int id;
            Console.Write("Enter id of type: ");
            if (!int.TryParse(Console.ReadLine(),out id))
            {
                Console.WriteLine("Wrond data");
                Console.ReadKey();
                return;
            }
            ShipTraffic.Model.DBModels.Type type = new Model.DBModels.Type();
            if ((type=Types.GetAll().FirstOrDefault(t=>t.ID == id))==null)
            {
                Console.WriteLine("Type with this id don't exist");
                Console.ReadKey();
                return;
            }
            if (modifiIt(String.Format("Name = {0}",type.Name)))
            {
                Console.Write("Enter new name: ");
                type.Name = Console.ReadLine();
            }
        }
#endregion
#region Add
        public void Add<T>(IRepository<T> list, T item) where T:class
        {
            try
            {
                Console.WriteLine("Addition..");
                list.Add(item);
                
                Console.WriteLine("Item has been added");
            }
            catch (Exception e)
            {
                Console.WriteLine(String.Format("Error of operation: {0}", e.ToString()));
            }
        }
        public void AddCaptain()
        {
            Captain captain = new Captain();
            Console.Write("Enter FirstName: ");
            captain.FirstName = Console.ReadLine();
            Console.Write("Enter LastName: ");
            captain.LastName = Console.ReadLine();
            Add(Captains, captain);
            Console.ReadKey();
        }
        public void AddCargo()
        {
            Cargo cargo = new Cargo();

            int iValue;
            Console.Write("Enter trip id: ");
            if (!int.TryParse(Console.ReadLine(),out iValue))
            {
                Console.WriteLine("Wrong data");
                Console.ReadKey();
                return;
            }
            if (Trips.GetAll().FirstOrDefault(t=>t.ID==iValue)==null)
            {
                Console.WriteLine("Trip with this id don't exist");
                Console.ReadKey();
                return;
            }
            cargo.TripID = iValue;

            Console.Write("Enter type id: ");
            if (!int.TryParse(Console.ReadLine(), out iValue))
            {
                Console.WriteLine("Wrong data");
                Console.ReadKey();
                return;
            }
            if (Types.GetAll().FirstOrDefault(t => t.ID == iValue) == null)
            {
                Console.WriteLine("Type with is id do't exist");
                Console.ReadKey();
                return;
            }
            cargo.TypeID = iValue;

            double dValue;
            Console.Write("Enter weight: ");
            if (!double.TryParse(Console.ReadLine(), out dValue))
            {
                Console.WriteLine("Wrong data");
                Console.ReadKey();
                return;
            }
            cargo.Weight = dValue;

            Console.Write("Enter number: ");
            if (!int.TryParse(Console.ReadLine(), out iValue))
            {
                Console.WriteLine("Wrong data");
                Console.ReadKey();
                return;
            }
            cargo.Number = iValue;

            decimal mValue;
            Console.Write("Enter Price: ");
            if (!decimal.TryParse(Console.ReadLine(), out mValue))
            {
                Console.WriteLine("Wrong data");
                Console.ReadKey();
                return;
            }
            cargo.Price = mValue;

            Console.Write("Enter insurance price: ");
            if (!decimal.TryParse(Console.ReadLine(), out mValue))
            {
                Console.WriteLine("Wrong data");
                Console.ReadKey();
                return;
            }
            cargo.InsurancePrice = mValue;

            Add(Cargos, cargo);
            Console.ReadKey();
        }
        public void AddCity()
        {
            City city = new City();
            Console.Write("Enter city name: ");
            city.Name = Console.ReadLine();
            Add(Cities, city);
            Console.ReadKey();
        }
        public void AddPort()
        {
            Port port = new Port();
            Console.Write("Enter port name: ");
            port.Name = Console.ReadLine();
            Console.Write("Enter city id: ");
            int iValue;
            if (!int.TryParse(Console.ReadLine(), out iValue))
            {
                Console.WriteLine("Wrong data");
                Console.ReadLine();
                return;
            }
            if ((port.City=Cities.GetAll().FirstOrDefault((c)=>c.ID==iValue))==null)
            {
                Console.WriteLine("City with this id do't exist");
                Console.ReadKey();
                return;
            }
            Add(Ports,port);
            Console.ReadKey();
        }
        public void AddShip()
        {
            Ship ship = new Ship();
            int iValue;
            Console.Write("Enter port ID: ");
            if (!int.TryParse(Console.ReadLine(),out iValue))
            {
                Console.WriteLine("Wrong data");
                Console.ReadKey();
                return;
            }
            if (Ports.GetAll().FirstOrDefault((p)=>p.ID==iValue)==null)
            {
                Console.WriteLine("Port with this id don't exist");
                Console.ReadKey();
                return;
            }
            ship.PortID = iValue;
           
            double dValue;
            Console.Write("Enter capacity: ");
            if (!double.TryParse(Console.ReadLine(), out dValue))
            {
                Console.WriteLine("Wrong data");
                Console.ReadKey();
                return;
            }
            ship.Capacity = dValue;

            Console.Write("Enter max distance: ");
            if (!double.TryParse(Console.ReadLine(), out dValue))
            {
                Console.WriteLine("Wrong data");
                Console.ReadKey();
                return;
            }
            ship.MaxDistance = dValue;

            Console.Write("Enter team count: ");
            if (!int.TryParse(Console.ReadLine(), out iValue))
            {
                Console.WriteLine("Wrong data");
                Console.ReadKey();
                return;
            }
            ship.TeamCount = iValue;

            DateTime date;
            Console.Write("Enter create date: ");
            if (!DateTime.TryParse(Console.ReadLine(), out date))
            {
                Console.WriteLine("Wrong data");
                Console.ReadKey();
                return;
            }
            ship.CreateDate = date;

            Add(Ships, ship);
            Console.ReadKey();
        }
        public void AddTrip()
        {
            Trip trip = new Trip();
            int iValue; 
            Console.Write("Enter captain id: ");
            if (!int.TryParse(Console.ReadLine(), out iValue))
            {
                Console.WriteLine("Wrong data");
                Console.ReadKey();
                return;
            }
            if (Captains.GetAll().FirstOrDefault(t => t.ID == iValue) == null)
            {
                Console.WriteLine("Captain with is id do't exist");
                Console.ReadKey();
                return;
            }
            if (Trips.GetAll().FirstOrDefault(t => t.CaptainID == iValue) != null)
            {
                Console.WriteLine("Catain is busy");
                Console.ReadKey();
                return;
            }
            trip.CaptainID = iValue;

            Console.Write("Enter ship id: ");
            if (!int.TryParse(Console.ReadLine(), out iValue))
            {
                Console.WriteLine("Wrong data");
                Console.ReadKey();
                return;
            }
            if (Ships.GetAll().FirstOrDefault(t => t.ID == iValue) == null)
            {
                Console.WriteLine("Ship with this id do't exist");
                Console.ReadKey();
                return;
            }
            if (Trips.GetAll().FirstOrDefault(t => t.ShipID == iValue) != null)
            {
                Console.WriteLine("Ship is busy");
                Console.ReadKey();
                return;
            }
            trip.ShipID = iValue;

            Console.Write("Enter port from: ");
            if (!int.TryParse(Console.ReadLine(), out iValue))
            {
                Console.WriteLine("Wrong data");
                Console.ReadKey();
                return;
            }
            if (Ports.GetAll().FirstOrDefault((p) => p.ID == iValue) == null)
            {
                Console.WriteLine("Port with this id don't exist");
                Console.ReadKey();
                return;
            }
            trip.PortFromID = iValue;
            Console.Write("Enter port to: ");
            if (!int.TryParse(Console.ReadLine(), out iValue))
            {
                Console.WriteLine("Wrong data");
                Console.ReadKey();
                return;
            }
            if (trip.PortFromID == trip.PortToID)
            {
                Console.WriteLine("Port from and to can't be same");
                Console.ReadKey();
                return;
            }
            if (Ports.GetAll().FirstOrDefault((p) => p.ID == iValue) == null)
            {
                Console.WriteLine("Port with this id don't exist");
                Console.ReadKey();
                return;
            }
            trip.PortToID = iValue;

            DateTime date;
            Console.Write("Enter start date: ");
            if (!DateTime.TryParse(Console.ReadLine(), out date))
            {
                Console.WriteLine("Wrong data");
                Console.ReadKey();
                return;
            }
            trip.StartDate = date;

            Console.Write("Enter end date: ");
            if (!DateTime.TryParse(Console.ReadLine(), out date))
            {
                Console.WriteLine("Wrong data");
                Console.ReadKey();
                return;
            }
            trip.EndDate = date;

            Add(Trips, trip);
            Console.ReadKey();

        }
        public void AddType()
        {
            ShipTraffic.Model.DBModels.Type type = new Model.DBModels.Type();
            Console.Write("Enter name: ");
            type.Name = Console.ReadLine();
            Add(Types, type);
            Console.ReadKey();
        }
#endregion
        public void View<T>(IQueryable<T> items)
        {
            Console.WriteLine("Загрузка..\n");
            try
            {
                if (items.Count() == 0) Console.WriteLine("Данных в базе нет");
                foreach (var c in items)
                {
                    Console.WriteLine("{0}\n",c);
                }
                Console.WriteLine("\nЗагрузка завершена");
            }
            catch(Exception)
            {
                Console.WriteLine("Database error");
            }
            Console.ReadKey();
        }
        private void Search<T>(IRepository<T> items) where T:Base
        {
            int id;
            Console.Write("Enter record id: ");
            if (!int.TryParse(Console.ReadLine(),out id))
            {
                Console.WriteLine("Wrong data");
                Console.ReadKey();
                return;
            }
            try
            {
                Console.WriteLine("Searching..");
                T item = items.GetAll().FirstOrDefault(i => i.ID == id); 
                if (item == null)
                {
                    Console.WriteLine("Record with is id don't exist");
                }
                else Console.WriteLine(item);
            }
            catch(Exception e)
            {
                Console.WriteLine(String.Format("Error of operation",e.ToString()));
            }
            
            Console.ReadKey();
        }
        private void Remove<T>(IRepository<T> items) where T : Base
        {
            Console.Write("Enter record id to removing: ");
            int id;
            if (!int.TryParse(Console.ReadLine(),out id))
            {
                Console.WriteLine("Wrong data");
                Console.ReadKey();
                return;
            }
            try
            {
                Console.WriteLine("Removing..");
                items.Remove(items.GetAll().FirstOrDefault(i => i.ID == id));
                Console.WriteLine("Complete.");
            }
            catch(Exception e)
            {
                Console.WriteLine(String.Format("Error of operation: {0}",e));
            }
            Console.ReadKey();
        } 
        private void AllShipInPort()
        {
            int id;
            Console.Write("Enter port id: ");
            if (!int.TryParse(Console.ReadLine(),out id))
            {
                Console.WriteLine("Wrong date");
                Console.ReadKey();
                return;
            }
            Port port;
            Console.WriteLine("Проверка данных..");
            try
            {
                if ((port = Ports.GetAll().FirstOrDefault(p => p.ID == id)) == null)
                {
                    Console.WriteLine("Port with this id don't exist");
                    Console.ReadKey();
                    return;
                }
                var ships = from s in Ships.GetAll()
                            where s.PortID == id
                            select s;
                View(ships);
            }
            catch (Exception) 
            {
                Console.WriteLine("Error of operation.");
            }
            Console.ReadKey();
        }
        private void TableOperation(ActiveTable activeTable)
        {
            Dictionary<string, Action> menu = new Dictionary<string, Action>()
            {
                {"Добавление",null},
                {"Удаление",null},
                {"Изменение",null},
                {"Поиск",null},
                {"Просмотр",null},
            };
            switch(activeTable)
            {
                case ActiveTable.Captains:
                    menu["Добавление"] = AddCaptain;
                    menu["Удаление"] = ()=>Remove(Captains);
                    menu["Изменение"] = EditCaptain;
                    menu["Поиск"] = ()=>Search(Captains);
                    menu["Просмотр"] = ()=> View(Captains.GetAll());
                    break;
                case ActiveTable.Cargos:
                    menu["Добавление"] = AddCargo;
                    menu["Удаление"] = ()=>Remove(Cargos);
                    menu["Изменение"] = EditCargo;
                    menu["Поиск"] =()=>Search(Cargos);
                    menu["Просмотр"] = ()=> View(Cargos.GetAll());
                    break;
                case ActiveTable.Cities:
                    menu["Добавление"] = AddCity;
                    menu["Удаление"] = ()=>Remove(Cities);
                    menu["Изменение"] = EditCity;
                    menu["Поиск"] = ()=>Search(Cities);
                    menu["Просмотр"] = () => View(Cities.GetAll());
                    break;
                case ActiveTable.Ports:
                    menu["Добавление"] = AddPort;
                    menu["Удаление"] = ()=>Remove(Ports);
                    menu["Изменение"] = EditPort;
                    menu["Поиск"] = ()=>Search(Ports);
                    menu["Просмотр"] = () => View(Ports.GetAll());
                    menu.Add("Просмотр всех кораблей", AllShipInPort);
                    break;
                case ActiveTable.Ships:
                    menu["Добавление"] = AddShip;
                    menu["Удаление"] = ()=>Remove(Ships);
                    menu["Изменение"] = EditShip;
                    menu["Поиск"] = ()=>Search(Ships);
                    menu["Просмотр"] = () => View(Ships.GetAll());
                    break;
                case ActiveTable.Trips:
                    menu["Добавление"] = AddTrip;
                    menu["Удаление"] = () => Remove(Types);
                    menu["Изменение"] = EditTrip;
                    menu["Поиск"] = ()=>Search(Trips);
                    menu["Просмотр"] = () => View(Trips.GetAll());
                    break;
                case ActiveTable.Types:
                    menu["Добавление"] = AddType;
                    menu["Удаление"] = () => Remove(Types);
                    menu["Изменение"] = EditType;
                    menu["Поиск"] = ()=>Search(Types);
                    menu["Просмотр"] = () => View(Types.GetAll());
                    break;
            }
            ui.Menu(menu);
        }
        public void Start()
        {
            Dictionary<string, Action> menu = new Dictionary<string, Action>
            {
                {"Капитаны", ()=>TableOperation(ActiveTable.Captains)},
                {"Грузы", ()=>TableOperation(ActiveTable.Cargos)},
                {"Города", ()=>TableOperation(ActiveTable.Cities)},
                {"Порты", ()=>TableOperation(ActiveTable.Ports)},
                {"Судна", ()=>TableOperation(ActiveTable.Ships)},
                {"Рейсы", ()=>TableOperation(ActiveTable.Trips)},
                {"Типы груза", ()=>TableOperation(ActiveTable.Types)},
            };
            ui.Menu(menu);
        }
    }
}
