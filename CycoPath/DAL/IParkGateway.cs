using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CycoPath.Models;

namespace CycoPath.DAL
{
    interface IParkGateway
    {
        IEnumerable<Park> SelectALL();
        Park SelectById(int? id);
        void Insert(Park park);
        void Update(Park park);
        Park Delete(int? id);
        IEnumerable<Park> SearchPark(List<string> listString);
        void Save();
    }
}
