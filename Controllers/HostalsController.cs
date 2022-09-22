using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyAppOfHotal.Models;

namespace MyAppOfHotal.Controllers
{
    public class HostalsController : Controller
    {
        private al_hotalEntities db = new al_hotalEntities();

        // GET: Hostals
        public async Task<ActionResult> Index()
        {
            var hostals = db.hostals.Include(h => h.hostal_state).Include(h => h.Types_hostal);
            return View(await hostals.ToListAsync());
        }

        // GET: Hostals/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hostal hostal = await db.hostals.FindAsync(id);
            if (hostal == null)
            {
                return HttpNotFound();
            }
            return View(hostal);
        }

        // GET: Hostals/Create
        public ActionResult Create()
        {
            ViewBag.id_state = new SelectList(db.hostal_state, "id", "state");
            ViewBag.id_class = new SelectList(db.Types_hostal, "id", "types");
            return View();
        }

        // POST: Hostals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,title_hostal,beds,for_how,rooms,id_class,id_state,cr_user,cr_date")] hostal hostal)
        {
            if (ModelState.IsValid)
            {
                db.hostals.Add(hostal);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.id_state = new SelectList(db.hostal_state, "id", "state", hostal.id_state);
            ViewBag.id_class = new SelectList(db.Types_hostal, "id", "types", hostal.id_class);
            return View(hostal);
        }

        // GET: Hostals/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hostal hostal = await db.hostals.FindAsync(id);
            if (hostal == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_state = new SelectList(db.hostal_state, "id", "state", hostal.id_state);
            ViewBag.id_class = new SelectList(db.Types_hostal, "id", "types", hostal.id_class);
            return View(hostal);
        }

        // POST: Hostals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,title_hostal,beds,for_how,rooms,id_class,id_state,cr_user,cr_date")] hostal hostal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hostal).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.id_state = new SelectList(db.hostal_state, "id", "state", hostal.id_state);
            ViewBag.id_class = new SelectList(db.Types_hostal, "id", "types", hostal.id_class);
            return View(hostal);
        }

        // GET: Hostals/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hostal hostal = await db.hostals.FindAsync(id);
            if (hostal == null)
            {
                return HttpNotFound();
            }
            return View(hostal);
        }

        // POST: Hostals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            hostal hostal = await db.hostals.FindAsync(id);
            db.hostals.Remove(hostal);
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
