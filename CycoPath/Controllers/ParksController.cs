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

        // GET: Park/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Park park = data.SelectParkById(id);

            if (park == null)
            {
                return HttpNotFound();
            }
            return View(park);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ParkResult(string start, string end)
        {
            List<String> listString = new List<String>();
            listString.Add(start);
            listString.Add(end);
            return View(data.SearchPark(listString));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PathResult(string no0, string no1)
        {
            List<String> listString = new List<String>();
            listString.Add(no0);
            listString.Add(no1);
            return View(data.SearchPath(listString));

        }
    }
}
