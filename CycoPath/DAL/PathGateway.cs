using CycoPath.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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

        public Path SearchPath(string park) {
            Path model = data.SqlQuery("SELECT TOP 1 * From dbo.Paths WHERE ConnectorName LIKE '%" + park + "%'").Single();
            return model;
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
            db.Entry(Path).State = EntityState.Modified;
            Save();
        }
    }
}