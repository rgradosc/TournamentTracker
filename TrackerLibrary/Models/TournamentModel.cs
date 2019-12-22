﻿namespace TrackerLibrary.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents one tournament, with all of the rounds, matchups, prizes and outcomes.
    /// </summary>
    public class TournamentModel
    {
        public event EventHandler<DateTime> OnTournamentComplete;

        /// <summary>
        /// The unique identifier for the tournament.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name given to this tournament.
        /// </summary>
        public string TournamentName { get; set; }

        /// <summary>
        /// The amount of money each team needs to put up to enter.
        /// </summary>
        public decimal EntryFee { get; set; }

        /// <summary>
        /// The set of teams that have been entered.
        /// </summary>
        public List<TeamModel> EnteredTeams { get; set; }

        /// <summary>
        /// The list of prizes for the various places.
        /// </summary>
        public List<PrizeModel> Prizes { get; set; }

        /// <summary>
        /// The matchups per round.
        /// </summary>
        public List<List<MatchupModel>> Rounds { get; set; }

        public TournamentModel()
        {
            EnteredTeams = new List<TeamModel>();
            Prizes = new List<PrizeModel>();
            Rounds = new List<List<MatchupModel>>();
        }

        public void CompleteTournament()
        {
            if (OnTournamentComplete != null)
            {
                OnTournamentComplete.Invoke(this, DateTime.Now);
            }

            // OnTournamentComplete?.Invoke(this, DateTime.Now);
        }
    }
}
