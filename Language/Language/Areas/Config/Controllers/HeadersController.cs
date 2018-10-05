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
    public class HeadersController : Controller
    {
        private LanguageEntities db = new LanguageEntities();


        // GET: Config/Headers/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.headeractive = "active";

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Header header = db.Header.Find(id);
            if (header == null)
            {
                return HttpNotFound();
            }
            return View(header);
        }

        // GET: Config/Headers/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.headeractive = "active";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Header header = db.Header.Find(id);
            if (header == null)
            {
                return HttpNotFound();
            }
            return View(header);
        }

        // POST: Config/Headers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Exclude = "Background_Image")] Header header, HttpPostedFileBase Background_Image, string ImageName)
        {
            Header activeheader = db.Header.Find(header.Id);

            if (Background_Image != null)
            {
                if ((double)Background_Image.ContentLength / (1024 * 1024) <= 2)
                {
                    if (Background_Image.ContentType == "image/jpeg" ||
                        Background_Image.ContentType == "image/png" ||
                        Background_Image.ContentType == "image/jpg" ||
                        Background_Image.ContentType == "image/gif")
                    {
                        string currentPhoto = db.Header.Find(1).Background_Image;
                        string deletePath = Path.Combine(Server.MapPath("~/Public/images/index"), currentPhoto); 
                        if (System.IO.File.Exists(deletePath))
                        {
                            System.IO.File.Delete(deletePath);
                        }

                        string filename = DateTime.Now.ToString("_yyyyMMdd_hhmmss") + Path.GetFileName(Background_Image.FileName);
                        string path = Path.Combine(Server.MapPath("~/Public/images/index/"), filename);

                        Background_Image.SaveAs(path);

                        activeheader.Background_Image = filename;
                    }
                    else
                    {
                        ModelState.AddModelError("Background_Image", "Image type is not valid");
                    }
                }
                else
                {
                    ModelState.AddModelError("Background_Image", "Image size can not be more than 2 MB");
                }
            }
            else
            {
                activeheader.Background_Image = ImageName;
            }

            if (ModelState.IsValid)
            {
                activeheader.After_Brand = header.After_Brand;
                activeheader.Before_Brand = header.Before_Brand;
                activeheader.Brand_Name = header.Brand_Name;
                db.Entry(activeheader).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details/1");
            }
            return View(activeheader);
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
