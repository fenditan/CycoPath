using System.Collections.Generic;
using System.Linq;
using CycoPath.Models;
using System.Data.Entity;

namespace CycoPath.DAL
{
    public class ParkGateway : IParkGateway

    {
        internal CycoPathEntities db = new CycoPathEntities();
        internal DbSet<Park> data = null;

        public ParkGateway()
        {
            this.data = db.Set<Park>();
        }

        public Park Delete(int? id)
        {
            Park park = db.Parks.Find(id);
            db.Parks.Remove(park);
            db.SaveChanges();
            return park;
        }

        public void Insert(Park park)
        {
            data.Add(park);
            db.SaveChanges();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public IEnumerable<Park> SelectALL()
        {
            return data.ToList();
        }

        public Park SelectById(int? id)
        {
            Park park = data.Find(id);
            return park;
        }

        public void Update(Park park)
        {
            db.Entry(park).State = System.Data.Entity.EntityState.Modified;
            Save();
        }

        public Park SelectByName(string parkName)
        {
            return data.SqlQuery("SELECT TOP 1* From dbo.Parks WHERE Name ='" + parkName + "'").Single();
        }
    }
}
