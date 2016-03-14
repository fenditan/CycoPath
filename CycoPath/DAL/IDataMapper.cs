using CycoPath.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycoPath.DAL
{
    interface IDataMapper
    {
        IEnumerable<Park> SelectALLPark();
        Park SelectParkById(int? id);
        IEnumerable<Park> SearchPark(List<string> listString);
        IEnumerable<Path> SearchPath(List<string> listString);
        IEnumerable<Path> SelectALLPath();
        Path SelectPathById(int? id);
    }
}
