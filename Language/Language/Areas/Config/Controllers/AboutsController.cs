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
    public class AboutsController : Controller
    {
        private LanguageEntities db = new LanguageEntities();

        // GET: Config/Abouts/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.aboutactive = "active";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About about = db.About.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }

        
        // GET: Config/Abouts/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.aboutactive = "active";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About about = db.About.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }

        // POST: Config/Abouts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Exclude = "Top_Left_Photo,Bottom_Left_Photo,Right_Photo")] About about, HttpPostedFileBase Top_Left_Photo, HttpPostedFileBase Bottom_Left_Photo, HttpPostedFileBase Right_Photo, string Top_Left_Photo_String, string Bottom_Left_Photo_String, string Right_Photo_String)
        {
            About activeAbout = db.About.Find(about.Id);

            #region EDIT TOP LEFT PHOTO
            if (Top_Left_Photo != null)
            {
                if ((double)Top_Left_Photo.ContentLength / (1024 * 1024) <= 3)
                {
                    if (Top_Left_Photo.ContentType == "image/jpeg" ||
                        Top_Left_Photo.ContentType == "image/png" ||
                        Top_Left_Photo.ContentType == "image/jpg" ||
                        Top_Left_Photo.ContentType == "image/gif")
                    {
                        string currentTopPhoto = db.About.Find(1).Top_Left_Photo;
                        string deleteTopPath = Path.Combine(Server.MapPath("~/Public/images/index"), currentTopPhoto);
                        if (System.IO.File.Exists(deleteTopPath))
                        {
                            System.IO.File.Delete(deleteTopPath);
                        }

                        string filenameTL = DateTime.Now.ToString("_yyyyMMdd_hhmmss") + Path.GetFileName(Top_Left_Photo.FileName);
                        string path = Path.Combine(Server.MapPath("~/Public/images/index/"), filenameTL);

                        Top_Left_Photo.SaveAs(path);

                        activeAbout.Top_Left_Photo = filenameTL;
                    }
                    else
                    {
                        ModelState.AddModelError("Top_Left_Photo", "Image type is not valid");
                    }
                }
                else
                {
                    ModelState.AddModelError("Top_Left_Photo", "Image size can not be more than 3 MB");
                }
            }
            else
            {
                activeAbout.Top_Left_Photo = Top_Left_Photo_String;
            }
            #endregion

            #region EDIT BOTTOM LEFT PHOTO
            if (Bottom_Left_Photo != null)
            {
                if ((double)Bottom_Left_Photo.ContentLength / (1024 * 1024) <= 3)
                {
                    if (Bottom_Left_Photo.ContentType == "image/jpeg" ||
                        Bottom_Left_Photo.ContentType == "image/png" ||
                        Bottom_Left_Photo.ContentType == "image/jpg" ||
                        Bottom_Left_Photo.ContentType == "image/gif")
                    {
                        string currentBottomPhoto = db.About.Find(1).Bottom_Left_Photo;
                        string deleteBottomPath = Path.Combine(Server.MapPath("~/Public/images/index"), currentBottomPhoto);
                        if (System.IO.File.Exists(deleteBottomPath))
                        {
                            System.IO.File.Delete(deleteBottomPath);
                        }

                        string filename = DateTime.Now.ToString("_yyyyMMdd_hhmmss") + Path.GetFileName(Bottom_Left_Photo.FileName);
                        string path = Path.Combine(Server.MapPath("~/Public/images/index/"), filename);

                        Bottom_Left_Photo.SaveAs(path);

                        activeAbout.Bottom_Left_Photo = filename;
                    }
                    else
                    {
                        ModelState.AddModelError("Bottom_Left_Photo", "Image type is not valid");
                    }
                }
                else
                {
                    ModelState.AddModelError("Bottom_Left_Photo", "Image size can not be more than 3 MB");
                }
            }
            else
            {
                activeAbout.Bottom_Left_Photo = Bottom_Left_Photo_String;
            }
            #endregion

            #region EDIT RIGHT PHOTO
            if (Right_Photo != null)
            {
                if ((double)Right_Photo.ContentLength / (1024 * 1024) <= 3)
                {
                    if (Right_Photo.ContentType == "image/jpeg" ||
                        Right_Photo.ContentType == "image/png" ||
                        Right_Photo.ContentType == "image/jpg" ||
                        Right_Photo.ContentType == "image/gif")
                    {
                        string currentRightPhoto = db.About.Find(1).Right_Photo;
                        string deleteRightPath = Path.Combine(Server.MapPath("~/Public/images/index"), currentRightPhoto);
                        if (System.IO.File.Exists(deleteRightPath))
                        {
                            System.IO.File.Delete(deleteRightPath);
                        }

                        string filename = DateTime.Now.ToString("_yyyyMMdd_hhmmss") + Path.GetFileName(Right_Photo.FileName);
                        string path = Path.Combine(Server.MapPath("~/Public/images/index/"), filename);

                        Right_Photo.SaveAs(path);

                        activeAbout.Right_Photo = filename;
                    }
                    else
                    {
                        ModelState.AddModelError("Right_Photo", "Image type is not valid");
                    }
                }
                else
                {
                    ModelState.AddModelError("Right_Photo", "Image size can not be more than 3 MB");
                }
            }
            else
            {
                activeAbout.Right_Photo = Right_Photo_String;
            }
            #endregion

            if (ModelState.IsValid)
            {
                activeAbout.Header = about.Header;
                activeAbout.Content = about.Content;
                db.Entry(activeAbout).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details/1");
            }
            return View(activeAbout);
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
