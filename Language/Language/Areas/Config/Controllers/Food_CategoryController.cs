using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Language.Models;

namespace Language.Areas.Config.Controllers
{
    public class Food_CategoryController : Controller
    {
        private LanguageEntities db = new LanguageEntities();

        // GET: Config/Food_Category
        public ActionResult Index()
        {
            return View(db.Food_Category.ToList());
        }

        // GET: Config/Food_Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food_Category food_Category = db.Food_Category.Find(id);
            if (food_Category == null)
            {
                return HttpNotFound();
            }
            return View(food_Category);
        }

        // GET: Config/Food_Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Config/Food_Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Image")] Food_Category food_Category)
        {
            if (ModelState.IsValid)
            {
                db.Food_Category.Add(food_Category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(food_Category);
        }

        // GET: Config/Food_Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food_Category food_Category = db.Food_Category.Find(id);
            if (food_Category == null)
            {
                return HttpNotFound();
            }
            return View(food_Category);
        }

        // POST: Config/Food_Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Image")] Food_Category food_Category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(food_Category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(food_Category);
        }

        // GET: Config/Food_Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food_Category food_Category = db.Food_Category.Find(id);
            if (food_Category == null)
            {
                return HttpNotFound();
            }
            return View(food_Category);
        }

        // POST: Config/Food_Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Food_Category food_Category = db.Food_Category.Find(id);
            db.Food_Category.Remove(food_Category);
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
