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

namespace CycoPath.Controllers
{
    public class ParksController : Controller
    {
        private DataMapper data = new DataMapper();
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

            ParksPathsModel.Parks = data.SearchPark(startEnd);

            List <List<double[]>> paths = new List<List<double[]>>();
            
            string[] toParse;

            IEnumerable<Path> AllPaths = data.SelectAllPath();

            foreach (var path in AllPaths)
            {
                List<double[]> Coord = new List<double[]>();
                string[] CoordPoints = path.Coordinates.Split(new string[] { "0 " }, StringSplitOptions.None);
                foreach(string points in CoordPoints)
                {
                    toParse = points.Split(',');
                    double[] parseResult = { double.Parse(toParse[0]), double.Parse(toParse[1]) };
                    Coord.Add(parseResult);
                }
                paths.Add(Coord);
            }

            ParksPathsModel.Paths = paths;

            return View(ParksPathsModel);

        }

    }
}
