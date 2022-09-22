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
    public class BookingsController : Controller
    {
        private al_hotalEntities db = new al_hotalEntities();

        // GET: Bookings
        public async Task<ActionResult> Index()
        {
            var bookings = db.bookings.Include(b => b.checking).Include(b => b.customer).Include(b => b.hostal).Include(b => b.state_booking1);
            return View(await bookings.ToListAsync());
        }

        // GET: Bookings/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            booking booking = await db.bookings.FindAsync(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        public ActionResult Create()
        {
            ViewBag.is_checking = new SelectList(db.checkings, "id", "check_rooms");
            ViewBag.ssn_cust = new SelectList(db.customers, "id", "name");
            ViewBag.id_hostal = new SelectList(db.hostals, "id", "title_hostal");
            ViewBag.state_booking = new SelectList(db.state_booking, "id", "state_booking1");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,ssn_cust,id_hostal,booking_date,check_in,check_out,state_booking,cr_user,is_checking")] booking booking)
        {
            if (ModelState.IsValid)
            {
                db.bookings.Add(booking);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.is_checking = new SelectList(db.checkings, "id", "check_rooms", booking.is_checking);
            ViewBag.ssn_cust = new SelectList(db.customers, "id", "name", booking.ssn_cust);
            ViewBag.id_hostal = new SelectList(db.hostals, "id", "title_hostal", booking.id_hostal);
            ViewBag.state_booking = new SelectList(db.state_booking, "id", "state_booking1", booking.state_booking);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            booking booking = await db.bookings.FindAsync(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.is_checking = new SelectList(db.checkings, "id", "check_rooms", booking.is_checking);
            ViewBag.ssn_cust = new SelectList(db.customers, "id", "name", booking.ssn_cust);
            ViewBag.id_hostal = new SelectList(db.hostals, "id", "title_hostal", booking.id_hostal);
            ViewBag.state_booking = new SelectList(db.state_booking, "id", "state_booking1", booking.state_booking);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,ssn_cust,id_hostal,booking_date,check_in,check_out,state_booking,cr_user,is_checking")] booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.is_checking = new SelectList(db.checkings, "id", "check_rooms", booking.is_checking);
            ViewBag.ssn_cust = new SelectList(db.customers, "id", "name", booking.ssn_cust);
            ViewBag.id_hostal = new SelectList(db.hostals, "id", "title_hostal", booking.id_hostal);
            ViewBag.state_booking = new SelectList(db.state_booking, "id", "state_booking1", booking.state_booking);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            booking booking = await db.bookings.FindAsync(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            booking booking = await db.bookings.FindAsync(id);
            db.bookings.Remove(booking);
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
