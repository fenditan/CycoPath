using System.Collections.Generic;
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
        Park SelectByName(string parkName);
        void Save();
    }
}
