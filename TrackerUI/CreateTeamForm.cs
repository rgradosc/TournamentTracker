namespace TrackerUI
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using TrackerLibrary;
    using TrackerLibrary.Models;
    using TrackerUI.Resources;

    public partial class CreateTeamForm : Form
    {
        private List<PersonModel> availableTeamMembers = GlobalConfig.Connection.GetPerson_All();
        private List<PersonModel> selectedTeamMembers = new List<PersonModel>();

        private ITeamRequester callingForm;

        public CreateTeamForm(ITeamRequester caller)
        {
            InitializeComponent();

            callingForm = caller;

            SettingInputPlaceholder();

            WireUpLists();
        }

        private void WireUpLists()
        {
            selectTeamMemberDropDown.DataSource = null;
            selectTeamMemberDropDown.DataSource = availableTeamMembers;
            selectTeamMemberDropDown.DisplayMember = "FullName";

            teamMembersListBox.DataSource = null;
            teamMembersListBox.DataSource = selectedTeamMembers;
            teamMembersListBox.DisplayMember = "FullName";
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
                case "teamNameValue":
                    HoveredControl(control, Team_Resource.TeamNamePlaceholder);
                    break;
                case "selectTeamMemberDropDown":
                    HoveredControl(control, Team_Resource.MemberPlaceholder);
                    break;
                case "firstNameValue":
                    HoveredControl(control, Team_Resource.FirstNamePlaceholder);
                    break;
                case "lastNameValue":
                    HoveredControl(control, Team_Resource.LastNamePlaceholder);
                    break;
                case "emailValue":
                    HoveredControl(control, Team_Resource.EmailPlaceholder);
                    break;
                case "cellphoneValue":
                    HoveredControl(control, Team_Resource.CellphonePlaceholder);
                    break;
            }
        }

        private void createMemberButton_Click(object sender, EventArgs e)
        {
            if (ValidateMemberInfo())
            {
                PersonModel p = new PersonModel();

                p.FirstName = firstNameValue.Text;
                p.LastName = lastNameValue.Text;
                p.EmailAddress = emailValue.Text;
                p.CellphoneNumber = cellphoneValue.Text;

                GlobalConfig.Connection.CreatePerson(p);

                selectedTeamMembers.Add(p);
                WireUpLists();

                firstNameValue.Text = string.Empty;
                lastNameValue.Text = string.Empty;
                emailValue.Text = string.Empty;
                cellphoneValue.Text = string.Empty;
            }
            else
            {
                MessageBox.Show(Team_Resource.InvalidInformation);
            }
        }

        private bool ValidateMemberInfo()
        {
            if (firstNameValue.Text == Team_Resource.FirstNamePlaceholder)
            {
                firstNameValue.Focus();
                return false;
            }

            if (lastNameValue.Text == Team_Resource.LastNamePlaceholder)
            {
                lastNameValue.Focus();
                return false;
            }

            if (emailValue.Text == Team_Resource.EmailPlaceholder)
            {
                emailValue.Focus();
                return false;
            }

            if (cellphoneValue.Text == Team_Resource.CellphonePlaceholder)
            {
                cellphoneValue.Focus();
                return false;
            }

            return true;
        }

        private bool ValidateTeamInfo()
        {
            if (teamNameValue.Text == Team_Resource.TeamNamePlaceholder)
            {
                teamNameValue.Focus();
                return false;
            }

            if (teamMembersListBox.Items.Count <= 1)
            {
                return false;
            }

            return true;
        }

        private void SettingInputPlaceholder()
        {
            teamNameValue.Text = Team_Resource.TeamNamePlaceholder;
            selectTeamMemberDropDown.Text = Team_Resource.MemberPlaceholder;
            firstNameValue.Text = Team_Resource.FirstNamePlaceholder;
            lastNameValue.Text = Team_Resource.LastNamePlaceholder;
            emailValue.Text = Team_Resource.EmailPlaceholder;
            cellphoneValue.Text = Team_Resource.CellphonePlaceholder;
        }

        private void addMemberButton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel)selectTeamMemberDropDown.SelectedItem;

            if (p != null)
            {
                availableTeamMembers.Remove(p);
                selectedTeamMembers.Add(p);

                WireUpLists();
            }
        }

        private void removeSelectedMemberButton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel)teamMembersListBox.SelectedItem;

            if (p != null)
            {
                selectedTeamMembers.Remove(p);
                availableTeamMembers.Add(p);

                WireUpLists(); 
            }
        }

        private void createTeamButton_Click(object sender, EventArgs e)
        {
            if (ValidateTeamInfo())
            {
                TeamModel t = new TeamModel();

                t.TeamName = teamNameValue.Text;
                t.TeamMembers = selectedTeamMembers;

                GlobalConfig.Connection.CreateTeam(t);

                callingForm.TeamComplete(t);

                this.Close();
            }
            else
            {
                MessageBox.Show(Team_Resource.InvalidInformation);
            }
        }

        private void textBoxControl_Enter(object sender, EventArgs e)
        {
            ManageControl((TextBox)sender);
        }

        private void textBoxControl_Leave(object sender, EventArgs e)
        {
            ManageControl((TextBox)sender);
        }

        private void dropDownControl_Enter(object sender, EventArgs e)
        {
            ManageControl((ComboBox)sender);
        }

        private void dropDownControl_Leave(object sender, EventArgs e)
        {
            ManageControl((ComboBox)sender);
        }
    }
}
