using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Language.Models;

namespace Language.Areas.Config.Controllers
{
    public class AJAXController : Controller
    {
        LanguageEntities db = new LanguageEntities();

        public ActionResult DeleteFood(int? foodId)
        {
            if (foodId != null)
            {
                Food food = db.Food.Find(foodId);
                var foodName = food.Name;

                string currentPhoto = db.Food.Find(foodId).Image;
                string deletePath = Path.Combine(Server.MapPath("~/Public/images/food"), currentPhoto);
                if (System.IO.File.Exists(deletePath))
                {
                    System.IO.File.Delete(deletePath);
                }

                db.Food.Remove(food);
                db.SaveChanges();
                return Json(
                        new
                        {
                            status = 200,
                            error = "",
                            message = $"{foodName} removed successfully.",
                        },
                        JsonRequestBehavior.AllowGet
                 );
            }

            return Json(
                        new
                        {
                            status = 404,
                            error = "",
                            message = "Something went wrong",
                        },
                        JsonRequestBehavior.AllowGet
                 );
        }
    }
}