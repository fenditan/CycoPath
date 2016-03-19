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
    public class CarparksController : Controller
    {
        private CarparkGateway carparkGateway = new CarparkGateway();

        // GET: Carparks
        public ActionResult Index(string hiddenTab1, string hiddenTab)

        {

            double lat = Convert.ToDouble(hiddenTab);
            double lon = Convert.ToDouble(hiddenTab1);
            ViewBag.lat = lat;
            ViewBag.lon = lon;

            //  IEnumerable<Carpark> data = carparkGateway.SearchCarPark(lat, lon);

            return View(carparkGateway.SearchCarPark(lat, lon));
        }
    }
}
