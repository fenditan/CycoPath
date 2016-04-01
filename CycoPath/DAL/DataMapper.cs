using System.Collections.Generic;
using CycoPath.Models;

namespace CycoPath.DAL
{
    public class DataMapper : IDataMapper
    {
        private IPathGateway pathGateway = new PathGateway();
        private IParkGateway parkGateway = new ParkGateway();
        private IWeatherGateway weatherGateway = new WeatherGateway();

        public IEnumerable<Park> SelectAllPark()
        {
            return parkGateway.SelectALL();
        }

        public IEnumerable<Park> getStartEndParks(string start, string end)
        {
            List<Park> result = new List<Park>();
            result.Add(parkGateway.SelectByName(start));
            result.Add(parkGateway.SelectByName(end));

            return result;
        }

        public IEnumerable<Path> SelectAllPath()
        {
            return pathGateway.SelectALL();
        }

        public Weather getParkWeather(string coordinates)
        {
            return weatherGateway.getParkWeather(coordinates);
        }
    }
}