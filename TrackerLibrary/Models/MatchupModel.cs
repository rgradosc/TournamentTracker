namespace TrackerLibrary.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents one match in the tournament.
    /// </summary>
    public class MatchupModel
    {
        /// <summary>
        /// The unique identifier for the matchup.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The set of teams that were involved in this match.
        /// </summary>
        public List<MatchupEntryModel> Entries { get; set; }

        /// <summary>
        /// The ID from the database that will be used to identity the winner.
        /// </summary>
        public int WinnerId { get; set; }

        /// <summary>
        /// The winner of the match.
        /// </summary>
        public TeamModel Winner { get; set; }

        /// <summary>
        /// Which round this match is a part of.
        /// </summary>
        public int MatchupRound { get; set; }

        public MatchupModel()
        {
            Entries = new List<MatchupEntryModel>();
        }

        public string DisplayName
        {
            get
            {
                string output = string.Empty;

                foreach (MatchupEntryModel me in Entries)
                {
                    if (me.TeamCompeting != null)
                    {
                        if (output.Length == 0)
                        {
                            output = me.TeamCompeting.TeamName;
                        }
                        else
                        {
                            output += string.Format(" vs. {0}", me.TeamCompeting.TeamName);
                        }
                    }
                    else
                    {
                        output = "Matchup not yet determined.";
                        break;
                    }
                }

                return output;
            }
        }
    }
}
