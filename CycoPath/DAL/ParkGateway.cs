using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CycoPath.Models;
using System.Data.Entity;

namespace CycoPath.DAL
{
    public class ParkGateway : IParkGateway

    {
        internal CycoPathContext db = new CycoPathContext();
        internal DbSet<Park> data = null;

        public ParkGateway()
        {
            this.data = db.Set<Park>();
        }

        public Park Delete(int? id)
        {
            Park park = db.Park.Find(id);
            db.Park.Remove(park);
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


        public IEnumerable<Park> SearchPark(List<string> listString)
        {

            List<Park> list = new List<Park>();

            foreach (var abc in listString)
            {
                Park model = data.SqlQuery("SELECT TOP 1* From dbo.Parks WHERE Name ='" + abc + "'").Single();
                list.Add(model);
            }
            IEnumerable<Park> listPark = list;

            return listPark;
        }


    }
}
