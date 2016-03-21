using CycoPath.Models;
using CycoPath.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycoPath.DAL
{
    public class WeatherGateway : IWeatherGateway
    {

        private WeatherService weatherService = new WeatherService();

        public Weather getParkWeather(String coordinates) {
            String[] coordinate = coordinates.Split(',');
            double[] parseCoodinate = { double.Parse(coordinate[0]), double.Parse(coordinate[1]) };

            IEnumerable<Weather> listOfWeather = weatherService.GetWeatherForecast();
            double tempDistance=0;
            Weather areaWeather = new Weather();
            foreach (Weather points in listOfWeather)
            {
                double[] parseResult = { points.Lat, points.Lon};
                double distance = getDistance(parseCoodinate, parseResult);
                //first foreach loop
                if (tempDistance==0)
                {
                    tempDistance = distance;
                    areaWeather = points;
                }else if (tempDistance > distance) {
                    tempDistance = distance;
                    areaWeather = points;
                }
            }

            return areaWeather;
        }

        private double getDistance(double[] pointA, double[] pointB)
        {
            double deltaLongSqr = Math.Pow((pointA[0] - pointB[0]), 2);
            double deltaLatSqr = Math.Pow((pointA[1] - pointB[1]), 2);

            return Math.Sqrt(deltaLongSqr + deltaLatSqr);
        }

    }
}
