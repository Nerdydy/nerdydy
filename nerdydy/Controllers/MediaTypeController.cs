using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using nerdydy.Models;

namespace nerdydy.Controllers
{
    public class MediaTypeController : Controller
    {
        private nerdydyModels db = new nerdydyModels();

        // GET: MediaType
        public ActionResult Index()
        {
            return View(db.MediaType.ToList());
        }

        // GET: MediaType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MediaType mediaType = db.MediaType.Find(id);
            if (mediaType == null)
            {
                return HttpNotFound();
            }
            return View(mediaType);
        }

        // GET: MediaType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MediaType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] MediaType mediaType)
        {
            if (ModelState.IsValid)
            {
                db.MediaType.Add(mediaType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mediaType);
        }

        // GET: MediaType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MediaType mediaType = db.MediaType.Find(id);
            if (mediaType == null)
            {
                return HttpNotFound();
            }
            return View(mediaType);
        }

        // POST: MediaType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] MediaType mediaType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mediaType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mediaType);
        }

        // GET: MediaType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MediaType mediaType = db.MediaType.Find(id);
            if (mediaType == null)
            {
                return HttpNotFound();
            }
            return View(mediaType);
        }

        // POST: MediaType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MediaType mediaType = db.MediaType.Find(id);
            db.MediaType.Remove(mediaType);
            db.SaveChanges();
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
