namespace TrackerUI
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Linq;
    using TrackerLibrary;
    using TrackerLibrary.Models;
    using Resources;

    public partial class CreateTournamentForm : Form, IPrizeRequester, ITeamRequester
    {
        List<TeamModel> availableTeams = GlobalConfig.Connection.GetTeam_All();

        List<TeamModel> selectedTeams = new List<TeamModel>();

        List<PrizeModel> selectedPrizes = new List<PrizeModel>();

        public CreateTournamentForm()
        {
            InitializeComponent();
            WireUpLists();
            SettingInputPlaceholder();
            SetForeColorDropDown();
        }

        private void WireUpLists()
        {
            selectTeamDropDown.DataSource = null;
            selectTeamDropDown.DataSource = availableTeams;
            selectTeamDropDown.DisplayMember = "TeamName";
            selectTeamDropDown.SelectedIndex = -1;

            tournamentTeamsListBox.DataSource = null;
            tournamentTeamsListBox.DataSource = selectedTeams;
            tournamentTeamsListBox.DisplayMember = "TeamName";

            prizesListBox.DataSource = null;
            prizesListBox.DataSource = selectedPrizes;
            prizesListBox.DisplayMember = "PlaceName";
        }

        private void SetForeColorDropDown()
        {
            if (selectTeamDropDown.SelectedIndex == -1)
            {
                selectTeamDropDown.ForeColor = Color.FromArgb(164, 162, 165);
                selectTeamDropDown.Text = Tournament_Resource.SelectTeamPlaceholder;
                return;
            }
        }

        private void SettingInputPlaceholder()
        {
            tournamentNameValue.Text = Tournament_Resource.TournamentNamePlaceholder;
            entryFeeValue.Text = Tournament_Resource.EntryFeePlaceholder;
            selectTeamDropDown.Text = Tournament_Resource.SelectTeamPlaceholder;
        }

        private void HoveredControl(Control control, string message)
        {
            if (control.Text.ToLower() == message.ToLower())
            {
                control.Text = string.Empty;
                control.ForeColor = Color.FromArgb(45, 53, 64);
                return;
            }

            if (string.IsNullOrWhiteSpace(control.Text))
            {
                control.Text = message;
                control.ForeColor = Color.FromArgb(164, 162, 165);
                return;
            }
        }

        private void ManageControl(Control control)
        {
            switch (control.Name)
            {
                case "tournamentNameValue":
                    HoveredControl(control, Tournament_Resource.TournamentNamePlaceholder);
                    break;
                case "entryFeeValue":
                    HoveredControl(control, Tournament_Resource.EntryFeePlaceholder);
                    break;
                case "selectTeamDropDown":
                    HoveredControl(control, Tournament_Resource.SelectTeamPlaceholder);
                    break;
            }
        }

        private void addTeamButton_Click(object sender, EventArgs e)
        {
            TeamModel t = (TeamModel)selectTeamDropDown.SelectedItem;

            if (t != null)
            {
                availableTeams.Remove(t);
                var temp = availableTeams.ToList();
                availableTeams = null;
                availableTeams = temp;
                selectedTeams.Add(t);
                WireUpLists();
                SetForeColorDropDown();
            }
        }

        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            // Call the CreatePrizeForm
            CreatePrizeForm frm = new CreatePrizeForm(this);
            frm.ShowDialog();
        }

        public void PrizeComplete(PrizeModel model)
        {
            // Get back from the form a PrizeModel
            // Take the PrizeModel and put into our list of selected prizes
            selectedPrizes.Add(model);
            WireUpLists();
        }

        public void TeamComplete(TeamModel model)
        {
            selectedTeams.Add(model);
            WireUpLists();
        }

        private void createNewTeamLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateTeamForm frm = new CreateTeamForm(this);
            frm.ShowDialog();
        }

        private void removeSelectedPlayerButton_Click(object sender, EventArgs e)
        {
            TeamModel t = (TeamModel)tournamentTeamsListBox.SelectedItem;

            if (t != null)
            {
                selectedTeams.Remove(t);
                availableTeams.Add(t);
                WireUpLists();
            }
        }

        private void removeSelectedPrizeButton_Click(object sender, EventArgs e)
        {
            PrizeModel p = (PrizeModel)prizesListBox.SelectedItem;

            if (p != null)
            {
                selectedPrizes.Remove(p);

                WireUpLists();
            }
        }

        private void createTournamentButton_Click(object sender, EventArgs e)
        {
            // Validate data

            string tournamentName = tournamentNameValue.Text;

            if (tournamentName == Tournament_Resource.TournamentNamePlaceholder)
            {
                MessageBox.Show(Tournament_Resource.InvalidNameDescription, 
                                Tournament_Resource.InvalidNameCaption, 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                tournamentNameValue.Focus();

                return;
            }

            decimal fee = 0;
            bool feeAceptable = decimal.TryParse(entryFeeValue.Text, out fee);

            if (!feeAceptable)
            {
                MessageBox.Show(Tournament_Resource.InvalidFeeDescription, 
                                Tournament_Resource.InvalidFeeCaption, 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                entryFeeValue.Focus();

                return;
            }
            // Create our tournament model
            TournamentModel tm = new TournamentModel();

            tm.TournamentName = tournamentNameValue.Text;
            tm.EntryFee = fee;

            tm.Prizes = selectedPrizes;
            tm.EnteredTeams = selectedTeams;

            // Wire our matchups
            TournamentLogic.CreateRounds(tm);


            // Create Tournament entry
            // Create all of the prizes entries
            // Create all of team entries
            GlobalConfig.Connection.CreateTournament(tm);

            tm.AlertUsersToNewRound();

            TournamentViewerForm frm = new TournamentViewerForm(tm);
            frm.Show();
            this.Close();
        }

        private void textBoxControl_Leave(object sender, EventArgs e)
        {
            ManageControl((TextBox)sender);
        }

        private void textBoxControl_Enter(object sender, EventArgs e)
        {
            ManageControl((TextBox)sender);
        }

        private void dropDownControl_Leave(object sender, EventArgs e)
        {
            ManageControl((ComboBox)sender);
        }

        private void dropDownControl_Enter(object sender, EventArgs e)
        {
            ManageControl((ComboBox)sender);
        }
    }
}
