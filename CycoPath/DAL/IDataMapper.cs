using CycoPath.Models;
using System.Collections.Generic;

namespace CycoPath.DAL
{
    interface IDataMapper
    {
        IEnumerable<Park> SelectAllPark();
        IEnumerable<Path> SelectAllPath();
        IEnumerable<Park> getStartEndParks(string start, string end);
        Weather getParkWeather(string coordinates);
    }
}
