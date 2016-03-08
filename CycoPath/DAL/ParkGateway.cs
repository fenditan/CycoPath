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
        internal DbSet<Parks> data = null;

        public ParkGateway()
        {
            this.data = db.Set<Parks>();
        }

        public Parks Delete(int? id)
        {
            Parks park = db.Park.Find(id);
            db.Park.Remove(park);
            db.SaveChanges();
            return park;
        }

        public void Insert(Parks park)
        {
            data.Add(park);
            db.SaveChanges();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public IEnumerable<Parks> SelectALL()
        {
            return data.ToList();
        }

        public Parks SelectById(int? id)
        {
            Parks park = data.Find(id);
            return park;
        }

        public void Update(Parks park)
        {
            db.Entry(park).State = System.Data.Entity.EntityState.Modified;
            Save();
        }


        public IEnumerable<Parks> SearchPark(List<string> listString)
        {

            List<Parks> list = new List<Parks>();

            foreach (var abc in listString)
            {
                Parks model = data.SqlQuery("SELECT TOP 1* From dbo.Parks WHERE Name ='" + abc + "'").Single();
                list.Add(model);
            }
            IEnumerable<Parks> listPark = list;

            return listPark;
        }


    }
}
