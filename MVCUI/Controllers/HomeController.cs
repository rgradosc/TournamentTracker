namespace MVCUI.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using TrackerLibrary;
    using TrackerLibrary.Models;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<TournamentModel> tournaments = GlobalConfig.Connection.GetTournament_All();
 
            return View(tournaments);
        }

    }
}