using CycoPath.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CycoPath.DAL
{
    public class PathGateway : IPathGateway
    {

        internal CycoPathEntities db = new CycoPathEntities();
        internal DbSet<Path> data = null;

        public PathGateway()
        {
            this.data = db.Set<Path>();
        }

        public Path Delete(int? id)
        {
            Path Path = db.Paths.Find(id);
            db.Paths.Remove(Path);
            db.SaveChanges();
            return Path;
        }

        public void Insert(Path Path)
        {
            data.Add(Path);
            db.SaveChanges();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public IEnumerable<Path> SearchPath(List<string> listString)
        {

            List<Path> list = new List<Path>();

            foreach (var abc in listString)
            {
                Path model = data.SqlQuery("SELECT TOP 1 * From dbo.Paths WHERE ConnectorName LIKE '%" + abc + "%'").Single();
                list.Add(model);
            }
            IEnumerable<Path> listConnector = list;
            return listConnector;
        }



        public IEnumerable<Path> SelectALL()
        {
            return data.ToList();
        }

        public Path SelectById(int? id)
        {
            Path Path = data.Find(id);
            return Path;
        }

        public void Update(Path Path)
        {
            db.Entry(Path).State = System.Data.Entity.EntityState.Modified;
            Save();
        }
    }
}