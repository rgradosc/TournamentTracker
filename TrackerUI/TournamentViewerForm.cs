using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class TournamentViewerForm : Form
    {
        private TournamentModel tournament;
        BindingList<int> rounds = new BindingList<int>();
        BindingList<MatchupModel> selectedMatchups = new BindingList<MatchupModel>();

        public TournamentViewerForm(TournamentModel tournamentModel)
        {
            InitializeComponent();
            tournament = tournamentModel;

            WireUpList();
            
            LoadFormData();
            LoadRounds();
        }

        private void LoadFormData()
        {
            tournamentNameLabel.Text = tournament.TournamentName;
        }

        private void WireUpList()
        {
            roundDropDonw.DataSource = rounds;
            matchupListBox.DataSource = selectedMatchups;
            matchupListBox.DisplayMember = "DisplayName";
        }

        private void LoadRounds()
        {
            rounds.Clear();
            rounds.Add(1);
            int currentRound = 1;

            foreach (List<MatchupModel> matchups in tournament.Rounds)
            {
                if (matchups.First().MatchupRound > currentRound)
                {
                    currentRound = matchups.First().MatchupRound;
                    rounds.Add(currentRound);
                }
            }

            LoadMatchups(1);
        }

        private void LoadMatchups(int round)
        {
            foreach (List<MatchupModel> matchups in tournament.Rounds)
            {
                if (matchups.First().MatchupRound == round)
                {
                    selectedMatchups.Clear();
                    foreach (MatchupModel m in matchups)
                    {
                        selectedMatchups.Add(m);
                    }
                }
            }

            LoadMatchup(selectedMatchups.First());
        }

        private void LoadMatchup(MatchupModel m)
        {
            for (int i = 0; i < m.Entries.Count; i++)
            {
                if (i == 0)
                {
                    if (m.Entries[0].TeamCompeting != null)
                    {
                        teamOneNameLabel.Text = m.Entries[0].TeamCompeting.TeamName;
                        teamOneScoreValue.Text = m.Entries[0].Score.ToString();

                        teamTwoNameLabel.Text = "<Bye>";
                        teamTwoScoreValue.Text = "0";
                    }
                    else
                    {
                        teamOneNameLabel.Text = "Not Yet Set";
                        teamOneScoreValue.Text = string.Empty;
                    }
                }

                if (i == 1)
                {
                    if (m.Entries[1].TeamCompeting != null)
                    {
                        teamTwoNameLabel.Text = m.Entries[1].TeamCompeting.TeamName;
                        teamTwoScoreValue.Text = m.Entries[1].Score.ToString();
                    }
                    else
                    {
                        teamTwoNameLabel.Text = "Not Yet Set";
                        teamTwoScoreValue.Text = string.Empty;
                    }
                }
            }
        }

        private void roundDropDonw_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatchups((int)roundDropDonw.SelectedItem);
        }

        private void matchupListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatchup((MatchupModel)matchupListBox.SelectedItem);
        }
    }
}
