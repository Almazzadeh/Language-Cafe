using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Language.Models;
using Language.ViewModel;

namespace Language.Controllers
{
    public class HomeController : Controller
    {
        LanguageEntities db = new LanguageEntities();

        public ActionResult Index()
        {
            IndexVM indexvm = new IndexVM
            {
                header = db.Header.First(),
                about = db.About.First(),
                conversation = db.Conversation.First(),
                foodList = db.Food.OrderByDescending(s => s.Id).Take(8),
                setting = db.Setting.First()
            };
            return View(indexvm);
        }

        public ActionResult Menu()
        {
            MenuVM menuvm = new MenuVM
            {
                category = db.Food_Category.ToList(),
                food = db.Food.ToList(),
                setting = db.Setting.First()
            };
            return View(menuvm);
        }

        public ActionResult MobileMenu()
        {
            MenuVM menuvm = new MenuVM
            {
                category = db.Food_Category.ToList(),
                food = db.Food.ToList(),
                setting = db.Setting.First()
            };
            return View(menuvm);
        }
    }
}