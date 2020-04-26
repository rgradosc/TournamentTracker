namespace TrackerUI
{
    partial class CreatePrizeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreatePrizeForm));
            this.prizePercentageValue = new System.Windows.Forms.TextBox();
            this.prizeAmountValue = new System.Windows.Forms.TextBox();
            this.placeNameValue = new System.Windows.Forms.TextBox();
            this.placeNumberValue = new System.Windows.Forms.TextBox();
            this.orLabel = new System.Windows.Forms.Label();
            this.createPrizeButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.createPrizeLabel = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape4 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape3 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // prizePercentageValue
            // 
            this.prizePercentageValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.prizePercentageValue.Font = new System.Drawing.Font("Arial Narrow", 11.25F);
            this.prizePercentageValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(162)))), ((int)(((byte)(165)))));
            this.prizePercentageValue.Location = new System.Drawing.Point(201, 161);
            this.prizePercentageValue.Margin = new System.Windows.Forms.Padding(2);
            this.prizePercentageValue.Name = "prizePercentageValue";
            this.prizePercentageValue.Size = new System.Drawing.Size(150, 18);
            this.prizePercentageValue.TabIndex = 16;
            this.prizePercentageValue.Text = "Prize Percentage";
            this.prizePercentageValue.Enter += new System.EventHandler(this.textBoxControl_Enter);
            this.prizePercentageValue.Leave += new System.EventHandler(this.textBoxControl_Leave);
            // 
            // prizeAmountValue
            // 
            this.prizeAmountValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.prizeAmountValue.Font = new System.Drawing.Font("Arial Narrow", 11.25F);
            this.prizeAmountValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(162)))), ((int)(((byte)(165)))));
            this.prizeAmountValue.Location = new System.Drawing.Point(22, 161);
            this.prizeAmountValue.Margin = new System.Windows.Forms.Padding(2);
            this.prizeAmountValue.Name = "prizeAmountValue";
            this.prizeAmountValue.Size = new System.Drawing.Size(143, 18);
            this.prizeAmountValue.TabIndex = 14;
            this.prizeAmountValue.Text = "Prize Amount";
            this.prizeAmountValue.Enter += new System.EventHandler(this.textBoxControl_Enter);
            this.prizeAmountValue.Leave += new System.EventHandler(this.textBoxControl_Leave);
            // 
            // placeNameValue
            // 
            this.placeNameValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.placeNameValue.Font = new System.Drawing.Font("Arial Narrow", 11.25F);
            this.placeNameValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(162)))), ((int)(((byte)(165)))));
            this.placeNameValue.Location = new System.Drawing.Point(22, 122);
            this.placeNameValue.Margin = new System.Windows.Forms.Padding(2);
            this.placeNameValue.Name = "placeNameValue";
            this.placeNameValue.Size = new System.Drawing.Size(329, 18);
            this.placeNameValue.TabIndex = 12;
            this.placeNameValue.Text = "Place Name";
            this.placeNameValue.Enter += new System.EventHandler(this.textBoxControl_Enter);
            this.placeNameValue.Leave += new System.EventHandler(this.textBoxControl_Leave);
            // 
            // placeNumberValue
            // 
            this.placeNumberValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.placeNumberValue.Font = new System.Drawing.Font("Arial Narrow", 11.25F);
            this.placeNumberValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(162)))), ((int)(((byte)(165)))));
            this.placeNumberValue.Location = new System.Drawing.Point(22, 80);
            this.placeNumberValue.Margin = new System.Windows.Forms.Padding(2);
            this.placeNumberValue.Name = "placeNumberValue";
            this.placeNumberValue.Size = new System.Drawing.Size(329, 18);
            this.placeNumberValue.TabIndex = 10;
            this.placeNumberValue.Text = "Place Number";
            this.placeNumberValue.Enter += new System.EventHandler(this.textBoxControl_Enter);
            this.placeNumberValue.Leave += new System.EventHandler(this.textBoxControl_Leave);
            // 
            // orLabel
            // 
            this.orLabel.AutoSize = true;
            this.orLabel.Font = new System.Drawing.Font("Arial Narrow", 11.25F);
            this.orLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(64)))));
            this.orLabel.Location = new System.Drawing.Point(169, 161);
            this.orLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.orLabel.Name = "orLabel";
            this.orLabel.Size = new System.Drawing.Size(28, 20);
            this.orLabel.TabIndex = 17;
            this.orLabel.Text = "-or-";
            // 
            // createPrizeButton
            // 
            this.createPrizeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(140)))), ((int)(((byte)(21)))));
            this.createPrizeButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.createPrizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createPrizeButton.Font = new System.Drawing.Font("Arial Narrow", 11.25F);
            this.createPrizeButton.ForeColor = System.Drawing.Color.White;
            this.createPrizeButton.Location = new System.Drawing.Point(94, 206);
            this.createPrizeButton.Margin = new System.Windows.Forms.Padding(2);
            this.createPrizeButton.Name = "createPrizeButton";
            this.createPrizeButton.Size = new System.Drawing.Size(187, 42);
            this.createPrizeButton.TabIndex = 26;
            this.createPrizeButton.Text = "Create Prize";
            this.createPrizeButton.UseVisualStyleBackColor = false;
            this.createPrizeButton.Click += new System.EventHandler(this.createPrizeButton_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.createPrizeLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(375, 58);
            this.panel2.TabIndex = 27;
            // 
            // createPrizeLabel
            // 
            this.createPrizeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.createPrizeLabel.BackColor = System.Drawing.Color.Transparent;
            this.createPrizeLabel.Font = new System.Drawing.Font("Arial Narrow", 26.25F);
            this.createPrizeLabel.ForeColor = System.Drawing.Color.White;
            this.createPrizeLabel.Location = new System.Drawing.Point(114, 9);
            this.createPrizeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.createPrizeLabel.Name = "createPrizeLabel";
            this.createPrizeLabel.Size = new System.Drawing.Size(181, 42);
            this.createPrizeLabel.TabIndex = 1;
            this.createPrizeLabel.Text = "Create Prize";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape4,
            this.lineShape3,
            this.lineShape2,
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(375, 274);
            this.shapeContainer1.TabIndex = 28;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape4
            // 
            this.lineShape4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(162)))), ((int)(((byte)(165)))));
            this.lineShape4.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.lineShape4.Enabled = false;
            this.lineShape4.Name = "lineShape4";
            this.lineShape4.X1 = 200;
            this.lineShape4.X2 = 350;
            this.lineShape4.Y1 = 181;
            this.lineShape4.Y2 = 181;
            // 
            // lineShape3
            // 
            this.lineShape3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(162)))), ((int)(((byte)(165)))));
            this.lineShape3.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.lineShape3.Enabled = false;
            this.lineShape3.Name = "lineShape3";
            this.lineShape3.X1 = 22;
            this.lineShape3.X2 = 165;
            this.lineShape3.Y1 = 181;
            this.lineShape3.Y2 = 181;
            // 
            // lineShape2
            // 
            this.lineShape2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(162)))), ((int)(((byte)(165)))));
            this.lineShape2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.lineShape2.Enabled = false;
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 22;
            this.lineShape2.X2 = 350;
            this.lineShape2.Y1 = 142;
            this.lineShape2.Y2 = 142;
            // 
            // lineShape1
            // 
            this.lineShape1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(162)))), ((int)(((byte)(165)))));
            this.lineShape1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.lineShape1.Enabled = false;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 21;
            this.lineShape1.X2 = 350;
            this.lineShape1.Y1 = 100;
            this.lineShape1.Y2 = 100;
            // 
            // CreatePrizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(375, 274);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.createPrizeButton);
            this.Controls.Add(this.orLabel);
            this.Controls.Add(this.prizePercentageValue);
            this.Controls.Add(this.prizeAmountValue);
            this.Controls.Add(this.placeNameValue);
            this.Controls.Add(this.placeNumberValue);
            this.Controls.Add(this.shapeContainer1);
            this.Font = new System.Drawing.Font("Arial Narrow", 15.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.Name = "CreatePrizeForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Prize";
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox placeNumberValue;
        private System.Windows.Forms.TextBox prizePercentageValue;
        private System.Windows.Forms.TextBox prizeAmountValue;
        private System.Windows.Forms.TextBox placeNameValue;
        private System.Windows.Forms.Label orLabel;
        private System.Windows.Forms.Button createPrizeButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label createPrizeLabel;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape3;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape4;
    }
}