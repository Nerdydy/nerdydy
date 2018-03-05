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
    public class GameMediaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: GameMedia
        public ActionResult Index()
        {
            return View(db.GameMedia.ToList());
        }

        // GET: GameMedia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameMedia gameMedia = db.GameMedia.Find(id);
            if (gameMedia == null)
            {
                return HttpNotFound();
            }
            return View(gameMedia);
        }

        // GET: GameMedia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GameMedia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Date,Filepath,MediaTypeId,GameId")] GameMedia gameMedia)
        {
            if (ModelState.IsValid)
            {
                db.GameMedia.Add(gameMedia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gameMedia);
        }

        // GET: GameMedia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameMedia gameMedia = db.GameMedia.Find(id);
            if (gameMedia == null)
            {
                return HttpNotFound();
            }
            return View(gameMedia);
        }

        // POST: GameMedia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Date,Filepath,MediaTypeId,GameId")] GameMedia gameMedia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gameMedia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gameMedia);
        }

        // GET: GameMedia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameMedia gameMedia = db.GameMedia.Find(id);
            if (gameMedia == null)
            {
                return HttpNotFound();
            }
            return View(gameMedia);
        }

        // POST: GameMedia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GameMedia gameMedia = db.GameMedia.Find(id);
            db.GameMedia.Remove(gameMedia);
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
