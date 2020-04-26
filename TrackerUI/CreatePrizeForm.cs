namespace TrackerUI
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using TrackerLibrary;
    using TrackerLibrary.Models;
    using Resources;

    public partial class CreatePrizeForm : Form
    {
        IPrizeRequester callingForm;

        public CreatePrizeForm(IPrizeRequester caller)
        {
            InitializeComponent();

            callingForm = caller;

            SettingInputPlaceholder();
        }

        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PrizeModel model = new PrizeModel(placeNameValue.Text, placeNumberValue.Text, prizeAmountValue.Text, prizePercentageValue.Text);

                GlobalConfig.Connection.CreatePrize(model);

                callingForm.PrizeComplete(model);

                this.Close();

                //placeNameValue.Text = string.Empty;
                //placeNumberValue.Text = string.Empty;
                //prizeAmountValue.Text = "0";
                //prizePercentageValue.Text = "0";
            }
            else
            {
                MessageBox.Show(Prize_Resource.InvalidInformation, 
                                Prize_Resource.InvalidCaption, 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            bool output = true;
            int placeNumber = 0;
            bool placeNumberValidNumber = int.TryParse(placeNumberValue.Text, out placeNumber);

            if (!placeNumberValidNumber)
            {
                output = false;
            }

            if (placeNumber < 1)
            {
                output = false;
            }

            if (placeNameValue.Text.Length == 0)
            {
                output = false;
            }

            decimal prizeAmount = 0;
            double prizePercentage = 0;

            bool prizeAmountValid = decimal.TryParse(prizeAmountValue.Text, out prizeAmount);

            bool prizePercentageValid = double.TryParse(prizePercentageValue.Text, out prizePercentage);

            if (!prizeAmountValid || !prizePercentageValid)
            {
                output = false;
            }

            if (prizeAmount <= 0 && prizePercentage <= 0)
            {
                output = false;
            }

            if (prizePercentage < 0 || prizePercentage > 100)
            {
                output = false;
            }

            return output;
        }

        private void SettingInputPlaceholder()
        {
            placeNumberValue.Text = Prize_Resource.NumberPlaceholder;
            placeNameValue.Text = Prize_Resource.NamePlaceholder;
            prizeAmountValue.Text = Prize_Resource.AmountPlaceholder;
            prizePercentageValue.Text = Prize_Resource.PercentagePlaceholder;
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
                case "placeNumberValue":
                    HoveredControl(control, Prize_Resource.NumberPlaceholder);
                    break;
                case "placeNameValue":
                    HoveredControl(control, Prize_Resource.NamePlaceholder);
                    break;
                case "prizeAmountValue":
                    HoveredControl(control, Prize_Resource.AmountPlaceholder);
                    break;
                case "prizePercentageValue":
                    HoveredControl(control, Prize_Resource.PercentagePlaceholder);
                    break;
            }
        }

        private void textBoxControl_Leave(object sender, EventArgs e)
        {
            ManageControl((TextBox)sender);
        }

        private void textBoxControl_Enter(object sender, EventArgs e)
        {
            ManageControl((TextBox)sender);
        }
    }
}
