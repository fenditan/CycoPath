using System;
using System.Web.Mvc;
using CycoPath.DAL;
using System.Dynamic;

namespace CycoPath.Controllers
{
    public class CarparksController : Controller
    {
        private ICarparkGateway carparkGateway = new CarparkGateway();

        // GET: Carparks
        public ActionResult Index(string hiddenTab1, string hiddenTab, string Answer)

        {
            Session["ParksPathsModel"] = Session["ParksPathsModelTemp"];
            Session["ParksPathsModelTemp"] = 0;
            if (Answer.Contains("Set as path and search carpark!"))
            {
                double lat = Convert.ToDouble(hiddenTab);
                double lon = Convert.ToDouble(hiddenTab1);
                ViewBag.lat = lat;
                ViewBag.lon = lon;

                return View(carparkGateway.SearchCarPark(lat, lon));
            }
            else {
                return RedirectToAction("Index", "TrackMe");
            }

        }
    }
}
