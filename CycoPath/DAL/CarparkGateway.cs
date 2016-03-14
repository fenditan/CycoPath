using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CycoPath.Models;
using System.Data.Entity;

namespace CycoPath.DAL
{
    public class CarparkGateway : ICarparkGateway
    {
        internal CycoPathEntities db = new CycoPathEntities();
        internal DbSet<Carpark> data = null;

        public CarparkGateway()
        {
            this.data = db.Set<Carpark>();
        }

        public Carpark Delete(int? id)
        {
            Carpark carpark = db.Carparks.Find(id);
            db.Carparks.Remove(carpark);
            db.SaveChanges();
            return carpark;
        }

        public void Insert(Carpark carpark)
        {
            data.Add(carpark);
            db.SaveChanges();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public IEnumerable<Carpark> SelectALL()
        {
            return data.ToList();
        }

        public Carpark SelectById(int? id)
        {
            Carpark carpark = data.Find(id);
            return carpark;
        }

        public void Update(Carpark carpark)
        {
            db.Entry(carpark).State = System.Data.Entity.EntityState.Modified;
            Save();
        }
    }
}