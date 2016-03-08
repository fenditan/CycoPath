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
        IEnumerable<Parks> SelectALL();
        Parks SelectById(int? id);
        void Insert(Parks park);
        void Update(Parks park);
        Parks Delete(int? id);
        IEnumerable<Parks> SearchPark(List<string> listString);
        void Save();
    }
}
