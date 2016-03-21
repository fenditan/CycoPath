using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CycoPath.Models;
using System.Data.Entity;
using System.Diagnostics;
using ReamSGOneMap.Utils;

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

        public IEnumerable<Carpark> SearchCarPark(double lat, double lon)
        {

            double radius = 5; //km


            IEnumerable<Carpark> listCarpark = data.ToList();
            List<Carpark> list = new List<Carpark>();

            foreach (Carpark item in listCarpark)
            {
                //Convert one map xy to x is long, y is lat
                GeoCoordinates geoLL = new GeoCoordinates(item.x_coord, item.y_coord, false);
                double iLong = geoLL.Longitude;
                double iLat = geoLL.Latitude;
                item.x_coord = iLong;
                item.y_coord = iLat;

                double theta = lon - iLong;
                double dist = Math.Sin(deg2rad(lat)) * Math.Sin(deg2rad(iLat)) + Math.Cos(deg2rad(lat)) * Math.Cos(deg2rad(iLat)) * Math.Cos(deg2rad(theta));
                dist = Math.Acos(dist);
                dist = rad2deg(dist);
                dist = dist * 60 * 1.1515;
                dist = dist * 1.609344; //km

                if (dist < radius)
                {
                    list.Add(item);
                }
            }
            int size = list.Count();
            Trace.WriteLine("Size is" + size);
            IEnumerable<Carpark> listSearched = list;
            return listSearched;
        }


        private double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        private double rad2deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }
        public double ToRadians(double valueInDegrees)
        {
            return (Math.PI / 180) * valueInDegrees;
        }
    }
}