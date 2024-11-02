using Microsoft.AspNetCore.Mvc;
using NFLTeams.Models;

namespace NFLTeams.Controllers
{
    public class NameController : Controller
    {

        [HttpGet]
        public ViewResult Index()
        {
            var session = new NFLSession(HttpContext.Session);
            var model = new TeamsViewModel
            {
                ActiveConf = session.GetActiveConf(),
                ActiveDiv = session.GetActiveDiv(),
                Teams = session.GetMyTeams(),
                Username = session.GetName()
            };

            return View(model);

        }
        [HttpPost]
        public RedirectToActionResult Change(TeamsViewModel model)
        {
            // delete favorite teams from session
            var session = new NFLSession(HttpContext.Session);
            session.SetName(model.Username);

            // redirect to Home page
            return RedirectToAction("Index", "Home",
                new
                {
                    ActiveConf = session.GetActiveConf(),
                    ActiveDiv = session.GetActiveDiv()
                });
        }
    }
}