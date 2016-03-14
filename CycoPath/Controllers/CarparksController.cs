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
        public ActionResult Index()
        {
            return View(carparkGateway.SelectALL());
        }
        
    }
}
