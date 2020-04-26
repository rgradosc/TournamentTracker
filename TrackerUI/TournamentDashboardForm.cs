namespace TrackerUI
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using TrackerLibrary;
    using TrackerLibrary.Models;
    using TrackerUI.Resources;

    public partial class TournamentDashboardForm : Form
    {
        List<TournamentModel> tournaments = GlobalConfig.Connection.GetTournament_All();

        public TournamentDashboardForm()
        {
            InitializeComponent();
            WireUpList();
        }

        private void WireUpList()
        {
            if (tournaments.Count > 0)
            {
                loadExistingTournamentDropDown.DataSource = tournaments;
                loadExistingTournamentDropDown.DisplayMember = "TournamentName";
                loadExistingTournamentDropDown.ForeColor = Color.FromArgb(45, 53, 64);
            }
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
                case "loadExistingTournamentDropDown":
                    HoveredControl(control, Tournament_Resource.SelectTeamPlaceholder);
                    break;
            }
        }

        private void loadTournamentButton_Click(object sender, EventArgs e)
        {
            if (loadExistingTournamentDropDown.SelectedItem != null)
            {
                TournamentModel tm = (TournamentModel)loadExistingTournamentDropDown.SelectedItem;
                TournamentViewerForm frm = new TournamentViewerForm(tm);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show(Tournament_Resource.InvalidInformation, Tournament_Resource.InvalidCaption);
            }
        }

        private void loadExistingTournamentDropDown_Enter(object sender, EventArgs e)
        {
            ManageControl((ComboBox)sender);
        }

        private void loadExistingTournamentDropDown_Leave(object sender, EventArgs e)
        {
            ManageControl((ComboBox)sender);
        }

        private void createTournamentButton_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateTournamentForm frm = new CreateTournamentForm();
            frm.ShowDialog();
        }
    }
}
