using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Web;
using System.Xml;
using CycoPath.Models;
namespace CycoPath.Services
{
    public class WeatherService
    {
        private const string URL = "http://www.nea.gov.sg/api/WebAPI/?dataset=nowcast&keyref=781CF461BB6606AD4AF8F309C0CCE9941C98AB71D91D487D";
        public List<Weather> GetWeatherForecast()
        {   
            // Create the request
            WebRequest request = WebRequest.Create(URL);
            // Define a cache policy for this request only.
            HttpRequestCachePolicy noCachePolicy = new HttpRequestCachePolicy
            (HttpRequestCacheLevel.NoCacheNoStore);
            request.CachePolicy = noCachePolicy;

            request.Method = "GET";
            WebResponse response = request.GetResponse();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(response.GetResponseStream());

            // Counting the number of areas
            var areaCount = xmlDoc.GetElementsByTagName("weatherForecast").Item(0).ChildNodes.Count;

            List<Weather> weatherAll = new List<Weather>();
            Weather weather = new Weather();
            // Item[i] = next area
            // Attributes[i] = name, forecast condition, etc....
            int i = 0;
            for (i = 0; i < areaCount; i++)
            {
                try
                {
                    string allAreaNames = xmlDoc.GetElementsByTagName("area").Item(i).Attributes[0].InnerText;
                    string allAreaForecast = xmlDoc.GetElementsByTagName("area").Item(i).Attributes[1].InnerText;
                    string allAreaLat = xmlDoc.GetElementsByTagName("area").Item(i).Attributes[4].InnerText;
                    string allAreaLon = xmlDoc.GetElementsByTagName("area").Item(i).Attributes[5].InnerText;

                    weather.Name = allAreaNames;
                    weather.Forecast = allAreaForecast;
                    
                    weather.Lat = double.Parse(allAreaLat);
                    weather.Lon = double.Parse(allAreaLon);

                    weatherAll.Add(weather);

                }
                catch (NullReferenceException nre)
                {
                     
                }
            }


            return weatherAll;

        }
    }
}