using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Language.Models;

namespace Language.Areas.Config.Controllers
{
    public class FoodsController : Controller
    {
        private LanguageEntities db = new LanguageEntities();

        #region INDEX & DETAILS
        // GET: Config/Foods
        public ActionResult Index()
        {
            ViewBag.foodactive = "active";
            var food = db.Food.Include(f => f.Food_Category);
            return View(food.OrderByDescending(s => s.Id).ToList());
        }

        // GET: Config/Foods/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.foodactive = "active";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food food = db.Food.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            return View(food);
        }
        #endregion

        #region CREATE
        // GET: Config/Foods/Create
        public ActionResult Create()
        {
            ViewBag.foodactive = "active";
            ViewBag.Category_Id = new SelectList(db.Food_Category, "Id", "Name");
            return View();
        }

        // POST: Config/Foods/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Image")] Food food, HttpPostedFileBase Image)
        {
            ViewBag.foodactive = "active";

            if (Image != null)
            {
                if ((double)Image.ContentLength / (1024 * 1024) <= 3)
                {
                    if (Image.ContentType == "image/jpeg" ||
                        Image.ContentType == "image/png" ||
                        Image.ContentType == "image/jpg" ||
                        Image.ContentType == "image/gif")
                    {
                        string filename = DateTime.Now.ToString("_yyyyMMdd_hhmmss") + Path.GetFileName(Image.FileName);
                        string path = Path.Combine(Server.MapPath("~/Public/images/food/"), filename);

                        Image.SaveAs(path);

                        food.Image = filename;
                    }
                    else
                    {
                        ModelState.AddModelError("Image", "Image type is not valid");
                    }
                }
                else
                {
                    ModelState.AddModelError("Image", "Image size can not be more than 3 MB");
                }
            }
            else
            {
                ModelState.AddModelError("Image", "Image should be selected");
            }

            if (ModelState.IsValid)
            {
                db.Food.Add(food);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Category_Id = new SelectList(db.Food_Category, "Id", "Name", food.Category_Id);
            return View(food);
        }
        #endregion

        #region EDIT
        // GET: Config/Foods/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.foodactive = "active";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food food = db.Food.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category_Id = new SelectList(db.Food_Category, "Id", "Name", food.Category_Id);
            return View(food);
        }

        // POST: Config/Foods/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Exclude = "Image")] Food food, HttpPostedFileBase Image, string ImageName)
        {
            ViewBag.foodactive = "active";
            Food activeFood = db.Food.Find(food.Id);

            if (Image != null)
            {
                if ((double)Image.ContentLength / (1024 * 1024) <= 3)
                {
                    if (Image.ContentType == "image/jpeg" ||
                        Image.ContentType == "image/png" ||
                        Image.ContentType == "image/jpg" ||
                        Image.ContentType == "image/gif")
                    {
                        string currentPhoto = db.Food.Find(activeFood.Id).Image;
                        string deletePath = Path.Combine(Server.MapPath("~/Public/images/food"), currentPhoto);
                        if (System.IO.File.Exists(deletePath))
                        {
                            System.IO.File.Delete(deletePath);
                        }

                        string filename = DateTime.Now.ToString("_yyyyMMdd_hhmmss") + Path.GetFileName(Image.FileName);
                        string path = Path.Combine(Server.MapPath("~/Public/images/food/"), filename);

                        Image.SaveAs(path);

                        activeFood.Image = filename;
                    }
                    else
                    {
                        ModelState.AddModelError("Image", "Image type is not valid");
                    }
                }
                else
                {
                    ModelState.AddModelError("Image", "Image size can not be more than 3 MB");
                }
            }
            else
            {
                activeFood.Image = ImageName;
            }
            if (ModelState.IsValid)
            {
                activeFood.Name = food.Name;
                activeFood.Price = food.Price;
                activeFood.Category_Id = food.Category_Id;
                db.Entry(activeFood).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category_Id = new SelectList(db.Food_Category, "Id", "Name", food.Category_Id);
            return View(activeFood);
        }
        #endregion

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
