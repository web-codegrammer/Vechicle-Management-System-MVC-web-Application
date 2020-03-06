using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vechicle_mngmt.Models;

namespace Vechicle_mngmt.Controllers
{
    public class VehicletblsController : Controller
    {
        private VehicleDB db = new VehicleDB();

        // GET: Vehicletbls
        public async Task<ActionResult> Index()
        {
            return View(await db.Vehicletbls.ToListAsync());
        }

        // GET: Vehicletbls/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicletbl vehicletbl = await db.Vehicletbls.FindAsync(id);
            if (vehicletbl == null)
            {
                return HttpNotFound();
            }
            return View(vehicletbl);
        }

        // GET: Vehicletbls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vehicletbls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,Displayname,Make,VehicleType,FuelType,VehicleMass,EngineCapacity_cc_,MaxSpeed,MaxPower,OnRoadPrice,Description")] Vehicletbl vehicletbl)
        {
            if (ModelState.IsValid)
            {
                db.Vehicletbls.Add(vehicletbl);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(vehicletbl);
        }

        // GET: Vehicletbls/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicletbl vehicletbl = await db.Vehicletbls.FindAsync(id);
            if (vehicletbl == null)
            {
                return HttpNotFound();
            }
            return View(vehicletbl);
        }

        // POST: Vehicletbls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,Displayname,Make,VehicleType,FuelType,VehicleMass,EngineCapacity_cc_,MaxSpeed,MaxPower,OnRoadPrice,Description")] Vehicletbl vehicletbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicletbl).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(vehicletbl);
        }

        // GET: Vehicletbls/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicletbl vehicletbl = await db.Vehicletbls.FindAsync(id);
            if (vehicletbl == null)
            {
                return HttpNotFound();
            }
            return View(vehicletbl);
        }

        // POST: Vehicletbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Vehicletbl vehicletbl = await db.Vehicletbls.FindAsync(id);
            db.Vehicletbls.Remove(vehicletbl);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
