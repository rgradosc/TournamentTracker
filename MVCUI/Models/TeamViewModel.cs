namespace MVCUI.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class TeamViewModel
    {
        [Required]
        [Display(Name = "Team Name")]
        [StringLength(100, MinimumLength = 2)]
        public string TeamName { get; set; }

        [Display(Name = "Team Member List")]
        public List<SelectListItem> TeamMembers { get; set; }

        public List<string> SelectedTeamMembers { get; set; }

        public TeamViewModel()
        {
            TeamMembers = new List<SelectListItem>();
            SelectedTeamMembers = new List<string>();
        }
    }
}