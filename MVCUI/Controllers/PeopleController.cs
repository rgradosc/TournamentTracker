namespace MVCUI.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using TrackerLibrary;
    using TrackerLibrary.Models;

    public class PeopleController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            List<PersonModel> availableTeamMembers = GlobalConfig.Connection.GetPerson_All();

            return View(availableTeamMembers);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PersonModel p)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    GlobalConfig.Connection.CreatePerson(p);

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(p);
                }
            }
            catch
            {
                return View(p);
            }
        }
    }
}
