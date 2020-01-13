namespace TrackerLibrary.Models
{
    using System.Collections.Generic;

    public class TeamModel
    {
        public int Id { get; set; }

        public string TeamName { get; set; }

        public List<PersonModel> TeamMembers { get; set; }

        public TeamModel()
        {
            TeamMembers = new List<PersonModel>();
        }
    }
}
