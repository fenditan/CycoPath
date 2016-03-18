using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Web;
using System.Xml;

namespace CycoPath.Services
{
    public class WeatherService
    {
        private const string URL = "http://www.nea.gov.sg/api/WebAPI/?dataset=nowcast&keyref=781CF461BB6606AD4AF8F309C0CCE9941C98AB71D91D487D";
        public string GetWeatherForecast()
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

            string areaList = "";

            // Attributes[0] = name
            var areaName = xmlDoc.GetElementsByTagName("area").Item(0).Attributes[0].Value;

            // Attributes[1] = forecast condition
            var areaForecast = xmlDoc.GetElementsByTagName("area").Item(0).Attributes[1].Value;

            // Count the number of attributes in each area tag = 6
            var areaNameCount = xmlDoc.GetElementsByTagName("area").Item(0).Attributes.Count;

            // Counting the number of areas
            var areaCount = xmlDoc.GetElementsByTagName("weatherForecast").Item(0).ChildNodes.Count;

            // Item[i] = next area
            // Attributes[i] = name, forecast condition, etc....
            int i = 0;
            for (i = 0; i < areaCount + 1; i++)
            {
                // During the start of the run, NullReferenceException will occur
                // There is a need to catch the Null Error
                try
                {
                    // Get all the area names
                    string allAreaNames = xmlDoc.GetElementsByTagName("area").Item(i).Attributes[0].InnerText;

                    // Get all the area forecast
                    string allAreaForecast = xmlDoc.GetElementsByTagName("area").Item(i).Attributes[1].InnerText;

                    // Append into the areaList
                    areaList += allAreaNames + ", " + allAreaForecast;

                }
                catch (NullReferenceException nre)
                {
                   
                }
            }
            return areaList;

        }
    }
}