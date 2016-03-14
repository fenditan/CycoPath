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

namespace CycoPath.Controllers
{
    public class ParksController : Controller
    {
        private DataMapper data = new DataMapper();
        // GET: Park
        public ActionResult Index()
        {
            return View(data.SelectALLPark());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ParkResult(string start, string end)
        {
            List<String> listString = new List<String>();
            listString.Add(start);
            listString.Add(end);
            return View(data.SearchAllParksPath(listString));

        }

    }
}
