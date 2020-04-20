namespace MVCUI.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using TrackerLibrary;
    using TrackerLibrary.Models;
    using Models;

    public class TeamsController : Controller
    {
        public ActionResult Index()
        {
            List<TeamModel> allTeams = GlobalConfig.Connection.GetTeam_All();

            return View(allTeams);
        }
        
        public ActionResult Create()
        {
            List<PersonModel> people = GlobalConfig.Connection.GetPerson_All();
            TeamViewModel input = new TeamViewModel();

            input.TeamMembers = people.Select(x => new SelectListItem { Text = x.FullName, Value = x.Id.ToString() }).ToList();

            return View(input);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Create(TeamViewModel model)
        {
            try
            {
                if (ModelState.IsValid && model.SelectedTeamMembers.Count > 0)
                {
                    TeamModel t = new TeamModel
                    {
                        TeamName = model.TeamName,
                        TeamMembers = model.SelectedTeamMembers.Select(x => new PersonModel { Id = int.Parse(x) }).ToList(),
                    };

                    GlobalConfig.Connection.CreateTeam(t);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }
            }
            catch
            {
                return View(model);
            }
        }
    }
}
