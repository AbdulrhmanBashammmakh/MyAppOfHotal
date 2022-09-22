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
    public class customersController : Controller
    {
        private al_hotalEntities db = new al_hotalEntities();

        // GET: customers
        public async Task<ActionResult> Index()
        {
            var customers = db.customers.Include(c => c.gender1).Include(c => c.Nationalty1).Include(c => c.type_documant);
            return View(await customers.ToListAsync());
        }

        // GET: customers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customer customer = await db.customers.FindAsync(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: customers/Create
        public ActionResult Create()
        {
            ViewBag.gender = new SelectList(db.genders, "id", "gend");
            ViewBag.nationalty = new SelectList(db.Nationalties, "id", "name_of_nation");
            ViewBag.type_doc = new SelectList(db.type_documant, "id", "doc");
            return View();
        }

        // POST: customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,name,phone,gender,type_doc,nationalty,serial_number,cr_user,cr_date")] customer customer)
        {
            if (ModelState.IsValid)
            {
                db.customers.Add(customer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.gender = new SelectList(db.genders, "id", "gend", customer.gender);
            ViewBag.nationalty = new SelectList(db.Nationalties, "id", "name_of_nation", customer.nationalty);
            ViewBag.type_doc = new SelectList(db.type_documant, "id", "doc", customer.type_doc);
            return View(customer);
        }

        // GET: customers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customer customer = await db.customers.FindAsync(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.gender = new SelectList(db.genders, "id", "gend", customer.gender);
            ViewBag.nationalty = new SelectList(db.Nationalties, "id", "name_of_nation", customer.nationalty);
            ViewBag.type_doc = new SelectList(db.type_documant, "id", "doc", customer.type_doc);
            return View(customer);
        }

        // POST: customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,name,phone,gender,type_doc,nationalty,serial_number,cr_user,cr_date")] customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.gender = new SelectList(db.genders, "id", "gend", customer.gender);
            ViewBag.nationalty = new SelectList(db.Nationalties, "id", "name_of_nation", customer.nationalty);
            ViewBag.type_doc = new SelectList(db.type_documant, "id", "doc", customer.type_doc);
            return View(customer);
        }

        // GET: customers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customer customer = await db.customers.FindAsync(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            customer customer = await db.customers.FindAsync(id);
            db.customers.Remove(customer);
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
