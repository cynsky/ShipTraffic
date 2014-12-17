using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShipTraffic.Model.DBModels;
using System.Data.Entity;

namespace ShipTraffic.Application
{
    public class ShipRepository<T>:IRepository<T> where T:Base
    {
        private readonly DbContext context;
        private readonly DbSet<T> dbSet;
        public ShipRepository(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }
        public void Add(T item)
        {
            dbSet.Add(item);
            context.SaveChanges();
        }
        public T GetByID(int id)
        {
            return dbSet.Find(id);
        }
        public IQueryable<T> GetAll()
        {
            return dbSet;
        }
        public void Remove(int itemID)
        {
            var item = dbSet.Find(itemID);
            dbSet.Remove(item);
            context.SaveChanges();
        }
        public void Remove(T item)
        {
            dbSet.Remove(item);
            context.SaveChanges();
        }
    }
}
