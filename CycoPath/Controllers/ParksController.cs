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
        private PathGateway pathGateway = new PathGateway();
        private ParkGateway parkGateway = new ParkGateway();
        // GET: Park
        public ActionResult Index()
        {
            return View(parkGateway.SelectALL());
        }

        // GET: Park/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parks park = parkGateway.SelectById(id);

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
            return View(parkGateway.SearchPark(listString));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult pathResult(string no0, string no1)
        {
            List<String> listString = new List<String>();
            listString.Add(no0);
            listString.Add(no1);
            return View(pathGateway.SearchConnector(listString));

        }

        // GET: Park/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Park/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Color,DescriptionAndPostalCode,Coordinates")] Parks park)
        {
            if (ModelState.IsValid)
            {
                parkGateway.Insert(park);
                return RedirectToAction("Index");
            }

            return View(park);
        }

        // GET: Park/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parks park = parkGateway.SelectById(id);
            if (park == null)
            {
                return HttpNotFound();
            }
            return View(park);
        }

        // POST: Park/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Color,DescriptionAndPostalCode,Coordinates")] Parks park)
        {
            if (ModelState.IsValid)
            {
                parkGateway.Update(park);
                parkGateway.Save();
                return RedirectToAction("Index");
            }
            return View(park);
        }

        // GET: Park/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parks park = parkGateway.SelectById(id);
            if (park == null)
            {
                return HttpNotFound();
            }
            return View(park);
        }

        // POST: Park/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Parks park = parkGateway.SelectById(id);
            parkGateway.Delete(id);
            parkGateway.Save();
            return RedirectToAction("Index");
        }

    }
}
