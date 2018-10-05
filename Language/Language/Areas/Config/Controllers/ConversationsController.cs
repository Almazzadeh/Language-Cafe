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
    public class ConversationsController : Controller
    {
        private LanguageEntities db = new LanguageEntities();

        // GET: Config/Conversations/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.conversationactive = "active";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conversation conversation = db.Conversation.Find(id);
            if (conversation == null)
            {
                return HttpNotFound();
            }
            return View(conversation);
        }

        // GET: Config/Conversations/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.conversationactive = "active";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conversation conversation = db.Conversation.Find(id);
            if (conversation == null)
            {
                return HttpNotFound();
            }
            return View(conversation);
        }

        // POST: Config/Conversations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Exclude = "Image")] Conversation conversation, HttpPostedFileBase Image, string ImageName)
        {
            Conversation activeConversation = db.Conversation.Find(conversation.Id);

            if (Image != null)
            {
                if ((double)Image.ContentLength / (1024 * 1024) <= 2)
                {
                    if (Image.ContentType == "image/jpeg" ||
                        Image.ContentType == "image/png" ||
                        Image.ContentType == "image/jpg" ||
                        Image.ContentType == "image/gif")
                    {
                        string currentPhoto = db.Conversation.Find(1).Image;
                        string deletePath = Path.Combine(Server.MapPath("~/Public/images/index"), currentPhoto);
                        if (System.IO.File.Exists(deletePath))
                        {
                            System.IO.File.Delete(deletePath);
                        }

                        string filename = DateTime.Now.ToString("_yyyyMMdd_hhmmss") + Path.GetFileName(Image.FileName);
                        string path = Path.Combine(Server.MapPath("~/Public/images/index/"), filename);

                        Image.SaveAs(path);

                        activeConversation.Image = filename;
                    }
                    else
                    {
                        ModelState.AddModelError("Image", "Image type is not valid");
                    }
                }
                else
                {
                    ModelState.AddModelError("Image", "Image size can not be more than 2 MB");
                }
            }
            else
            {
                activeConversation.Image = ImageName;
            }
            if (ModelState.IsValid)
            {
                activeConversation.Header = conversation.Header;
                activeConversation.Content = conversation.Content;
                db.Entry(activeConversation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details/1");
            }
            return View(activeConversation);
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
