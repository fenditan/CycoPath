using CycoPath.Models;
using System.Collections.Generic;

namespace CycoPath.DAL
{
    interface IPathGateway
    {
        IEnumerable<Path> SelectALL();
        Path SearchPath(string park);
        Path SelectById(int? id);
        void Insert(Path path);
        void Update(Path path);
        Path Delete(int? id);
        void Save();
    }
}
