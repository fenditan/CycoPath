using CycoPath.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycoPath.DAL
{
    interface ICarparkGateway
    {
        IEnumerable<Carpark> SelectALL();
        IEnumerable<Carpark> SearchCarPark(double lat, double lons);
        Carpark SelectById(int? id);
        void Insert(Carpark carpark);
        void Update(Carpark carpark);
        Carpark Delete(int? id);
        void Save();
    }
}
