using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CycoPath.DAL;
using CycoPath.Models;
using System.Dynamic;
using Jmelosegui.Mvc.GoogleMap;

namespace CycoPath.Controllers
{
    public class ParksController : Controller
    {
        private IDataMapper data = new DataMapper();
        // GET: Park
        public ActionResult Index()
        {
            return View(data.SelectAllPark());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ParkResult(string start, string end)
        {
            dynamic ParksPathsModel = new ExpandoObject();
            
            List < String > startEnd = new List<String>();
            startEnd.Add(start);
            startEnd.Add(end);

            IEnumerable<Park> startEndPark = data.SearchPark(startEnd);
            ParksPathsModel.Parks = startEndPark;
            List<Weather> listofWeather= new List<Weather>();
            IEnumerable<Weather> weather;

            double[] startCoord = toDoubleArray(((List<Park>)startEndPark)[0].Coordinates.Split(','));
            double[] endCoord = toDoubleArray(((List<Park>)startEndPark)[1].Coordinates.Split(','));
            
            Dictionary<int,List<double[]>> paths = getPaths();
            List<List<double[]>> route = getRoute(startCoord, endCoord, paths);
            ParksPathsModel.Paths = route;
            listofWeather.Add(data.getParkWeather(((List<Park>)startEndPark)[0].Coordinates));
            listofWeather.Add(data.getParkWeather(((List<Park>)startEndPark)[1].Coordinates));
            weather = listofWeather;
            ParksPathsModel.Weather = weather;
            return View(ParksPathsModel);

        }

        private Dictionary<int, List<double[]>> getPaths()
        {
            Dictionary<int, List<double[]>> result = new Dictionary<int, List<double[]>>();
            int index = 0;
            string[] toParse;

            IEnumerable<Path> AllPaths = data.SelectAllPath();

            foreach (var path in AllPaths)
            {
                List<double[]> Coord = new List<double[]>();
                string[] CoordPoints = path.Coordinates.Split(new string[] { "0 " }, StringSplitOptions.None);
                foreach (string points in CoordPoints)
                {
                    toParse = points.Split(',');
                    double[] parseResult = { double.Parse(toParse[0]), double.Parse(toParse[1]) };
                    Coord.Add(parseResult);
                }
                result.Add(index++, Coord);
            }
            return result;
        }

        private List<List<double[]>> getRoute(double[] start, double[] end, Dictionary<int, List<double[]>> allPaths)
        {
            double startToEnd = getDistance(start, end);
            double currentMin = startToEnd;
            int KeyToRemove = -1;

            List<double[]> partialRoute = new List<double[]>();

            foreach (KeyValuePair<int, List<double[]>> path in allPaths)
            {
                double[] pathStartCoord = path.Value.First();
                double[] pathEndCoord = path.Value.Last();

                double PathStartDistanceFromStart = getDistance(start, pathStartCoord);
                double PathEndDistanceFromStart = getDistance(start, pathEndCoord);
                double PathStartDistanceFromEnd = getDistance(end, pathStartCoord);
                double PathEndDistanceFromEnd = getDistance(end, pathEndCoord);
                
                if ((currentMin > PathStartDistanceFromStart) || (currentMin > PathEndDistanceFromStart))
                {
                    if (PathStartDistanceFromStart < PathEndDistanceFromStart)
                    {
                        if (PathEndDistanceFromEnd < startToEnd)
                        {
                            currentMin = PathStartDistanceFromStart;
                            start = pathEndCoord;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        if (PathStartDistanceFromEnd < startToEnd)
                        {
                            currentMin = PathEndDistanceFromStart;
                            start = pathStartCoord;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    partialRoute = path.Value;
                    KeyToRemove = path.Key;
                }
            }

            if (KeyToRemove != -1)
            {
                allPaths.Remove(KeyToRemove);
            }
            else
            {
                return new List<List<double[]>>();
            }

            List<List<double[]>> route = new List<List<double[]>>();

            route.Add(partialRoute);
            route.AddRange(getRoute(start, end, allPaths));

            return route;
        }

        private double getDistance(double[] pointA, double[] pointB)
        {
            double deltaLongSqr = Math.Pow((pointA[0] - pointB[0]), 2);
            double deltaLatSqr = Math.Pow((pointA[1] - pointB[1]), 2);

            return Math.Sqrt(deltaLongSqr + deltaLatSqr);
        }

        private double[] toDoubleArray(string[] toConvert)
        {
            int size = toConvert.Length;
            double[] result = new double[size];

            for (int i = 0; i<size; i++)
            {
                result[i] = double.Parse(toConvert[i]);
            }

            return result;
        }
    }
}
