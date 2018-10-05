using System.Web.Mvc;

namespace Language.Areas.Config
{
    public class ConfigAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Config";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Config_default",
                "Config/{controller}/{action}/{id}",
                new { controller = "Headers", action = "Details", id = 1 },
                new string[] { "Language.Areas.Config.Controllers" }
            );
        }
    }
}