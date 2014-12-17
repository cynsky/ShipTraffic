using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipTraffic.Application
{
    public interface IRepository<T> where T:class
    {
        void Add(T item);
        void Remove(int itemID);
        void Remove(T item);
        T GetByID(int id);
        IQueryable<T> GetAll();
    }
}
