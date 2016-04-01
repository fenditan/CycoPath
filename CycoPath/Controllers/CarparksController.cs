using System;
using System.Web.Mvc;
using CycoPath.DAL;

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

            return View(carparkGateway.SearchCarPark(lat, lon));
        }
    }
}
