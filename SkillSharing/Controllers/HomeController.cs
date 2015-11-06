using System.Linq;
using System.Web.Mvc;
using SkillSharing.Data;

namespace SkillSharing.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            using (var ctx = new SkillSharingContext())
            {
                var org = ctx.OrgStructures.FirstOrDefault();

                var channel = org.Channels.FirstOrDefault();
                var user = org.Users.FirstOrDefault();
            }

            return View();
        }
    }
}
