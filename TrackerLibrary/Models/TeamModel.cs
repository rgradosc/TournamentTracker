namespace TrackerLibrary.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class TeamModel
    {
        public int Id { get; set; }

        [Display(Name = "Team Name")]
        public string TeamName { get; set; }

        [Display(Name = "Team Member List")]
        public List<PersonModel> TeamMembers { get; set; }

        public TeamModel()
        {
            TeamMembers = new List<PersonModel>();
        }
    }
}
