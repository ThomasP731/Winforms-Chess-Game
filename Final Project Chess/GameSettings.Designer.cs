namespace Final_Project_Chess
{
    partial class GameSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameSettings));
            this.gameSettingsTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.blitzButton = new System.Windows.Forms.RadioButton();
            this.interButton = new System.Windows.Forms.RadioButton();
            this.customButton = new System.Windows.Forms.RadioButton();
            this.customTimeTextbox = new System.Windows.Forms.TextBox();
            this.casualButton = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.playButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.helloUserLabel = new System.Windows.Forms.Label();
            this.signOutSettingsButton = new System.Windows.Forms.Button();
            this.DifEasy = new System.Windows.Forms.RadioButton();
            this.radioAI = new System.Windows.Forms.RadioButton();
            this.radioLocal = new System.Windows.Forms.RadioButton();
            this.DifHard = new System.Windows.Forms.RadioButton();
            this.DifMedium = new System.Windows.Forms.RadioButton();
            this.GameType = new System.Windows.Forms.Panel();
            this.Diffculty = new System.Windows.Forms.Panel();
            this.CustomTimeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.GameType.SuspendLayout();
            this.Diffculty.SuspendLayout();
            this.SuspendLayout();
            // 
            // gameSettingsTitle
            // 
            this.gameSettingsTitle.AutoSize = true;
            this.gameSettingsTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameSettingsTitle.Location = new System.Drawing.Point(195, 30);
            this.gameSettingsTitle.Name = "gameSettingsTitle";
            this.gameSettingsTitle.Size = new System.Drawing.Size(421, 46);
            this.gameSettingsTitle.TabIndex = 1;
            this.gameSettingsTitle.Text = "Welcome to My Chess";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(125, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Choose your Opponent:";
            // 
            // blitzButton
            // 
            this.blitzButton.AutoSize = true;
            this.blitzButton.Location = new System.Drawing.Point(527, 222);
            this.blitzButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.blitzButton.Name = "blitzButton";
            this.blitzButton.Size = new System.Drawing.Size(119, 20);
            this.blitzButton.TabIndex = 9;
            this.blitzButton.Text = "Blitz (5 minutes)";
            this.blitzButton.UseVisualStyleBackColor = true;
            this.blitzButton.CheckedChanged += new System.EventHandler(this.blitzButton_CheckedChanged);
            // 
            // interButton
            // 
            this.interButton.AutoSize = true;
            this.interButton.Location = new System.Drawing.Point(527, 247);
            this.interButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.interButton.Name = "interButton";
            this.interButton.Size = new System.Drawing.Size(176, 20);
            this.interButton.TabIndex = 10;
            this.interButton.Text = "Intermediate (15 minutes)";
            this.interButton.UseVisualStyleBackColor = true;
            this.interButton.CheckedChanged += new System.EventHandler(this.interButton_CheckedChanged);
            // 
            // customButton
            // 
            this.customButton.AutoSize = true;
            this.customButton.Location = new System.Drawing.Point(527, 273);
            this.customButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.customButton.Name = "customButton";
            this.customButton.Size = new System.Drawing.Size(107, 20);
            this.customButton.TabIndex = 11;
            this.customButton.Text = "Custom Time";
            this.customButton.UseVisualStyleBackColor = true;
            this.customButton.CheckedChanged += new System.EventHandler(this.customButton_CheckedChanged);
            // 
            // customTimeTextbox
            // 
            this.customTimeTextbox.Location = new System.Drawing.Point(652, 301);
            this.customTimeTextbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.customTimeTextbox.Name = "customTimeTextbox";
            this.customTimeTextbox.Size = new System.Drawing.Size(77, 22);
            this.customTimeTextbox.TabIndex = 12;
            this.customTimeTextbox.Visible = false;
            // 
            // casualButton
            // 
            this.casualButton.AutoSize = true;
            this.casualButton.Location = new System.Drawing.Point(527, 194);
            this.casualButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.casualButton.Name = "casualButton";
            this.casualButton.Size = new System.Drawing.Size(127, 20);
            this.casualButton.TabIndex = 13;
            this.casualButton.Text = "Casual (No time)";
            this.casualButton.UseVisualStyleBackColor = true;
            this.casualButton.CheckedChanged += new System.EventHandler(this.casualButton_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(493, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Choose your Time Settings:";
            // 
            // playButton
            // 
            this.playButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playButton.Location = new System.Drawing.Point(320, 363);
            this.playButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(159, 38);
            this.playButton.TabIndex = 15;
            this.playButton.Text = "Play!";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(332, 143);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(136, 214);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // helloUserLabel
            // 
            this.helloUserLabel.AutoSize = true;
            this.helloUserLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helloUserLabel.Location = new System.Drawing.Point(349, 82);
            this.helloUserLabel.Name = "helloUserLabel";
            this.helloUserLabel.Size = new System.Drawing.Size(108, 25);
            this.helloUserLabel.TabIndex = 17;
            this.helloUserLabel.Text = "Hello User!";
            this.helloUserLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // signOutSettingsButton
            // 
            this.signOutSettingsButton.Location = new System.Drawing.Point(16, 412);
            this.signOutSettingsButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.signOutSettingsButton.Name = "signOutSettingsButton";
            this.signOutSettingsButton.Size = new System.Drawing.Size(77, 26);
            this.signOutSettingsButton.TabIndex = 18;
            this.signOutSettingsButton.Text = "Sign out";
            this.signOutSettingsButton.UseVisualStyleBackColor = true;
            this.signOutSettingsButton.Click += new System.EventHandler(this.signOutSettingsButton_Click);
            // 
            // DifEasy
            // 
            this.DifEasy.AutoSize = true;
            this.DifEasy.Location = new System.Drawing.Point(21, 7);
            this.DifEasy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DifEasy.Name = "DifEasy";
            this.DifEasy.Size = new System.Drawing.Size(59, 20);
            this.DifEasy.TabIndex = 19;
            this.DifEasy.Text = "Easy";
            this.DifEasy.UseVisualStyleBackColor = true;
            this.DifEasy.Visible = false;
            this.DifEasy.CheckedChanged += new System.EventHandler(this.DifEasy_CheckedChanged);
            // 
            // radioAI
            // 
            this.radioAI.AutoSize = true;
            this.radioAI.Location = new System.Drawing.Point(3, 30);
            this.radioAI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioAI.Name = "radioAI";
            this.radioAI.Size = new System.Drawing.Size(80, 20);
            this.radioAI.TabIndex = 20;
            this.radioAI.TabStop = true;
            this.radioAI.Text = "AI Game";
            this.radioAI.UseVisualStyleBackColor = true;
            this.radioAI.CheckedChanged += new System.EventHandler(this.radioAI_CheckedChanged);
            // 
            // radioLocal
            // 
            this.radioLocal.AutoSize = true;
            this.radioLocal.Location = new System.Drawing.Point(3, 2);
            this.radioLocal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioLocal.Name = "radioLocal";
            this.radioLocal.Size = new System.Drawing.Size(101, 20);
            this.radioLocal.TabIndex = 21;
            this.radioLocal.Text = "Local Game";
            this.radioLocal.UseVisualStyleBackColor = true;
            this.radioLocal.CheckedChanged += new System.EventHandler(this.radioLocal_CheckedChanged);
            // 
            // DifHard
            // 
            this.DifHard.AutoSize = true;
            this.DifHard.Location = new System.Drawing.Point(21, 59);
            this.DifHard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DifHard.Name = "DifHard";
            this.DifHard.Size = new System.Drawing.Size(58, 20);
            this.DifHard.TabIndex = 22;
            this.DifHard.Text = "Hard";
            this.DifHard.UseVisualStyleBackColor = true;
            this.DifHard.Visible = false;
            this.DifHard.CheckedChanged += new System.EventHandler(this.DifHard_CheckedChanged);
            // 
            // DifMedium
            // 
            this.DifMedium.AutoSize = true;
            this.DifMedium.Location = new System.Drawing.Point(21, 33);
            this.DifMedium.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DifMedium.Name = "DifMedium";
            this.DifMedium.Size = new System.Drawing.Size(76, 20);
            this.DifMedium.TabIndex = 23;
            this.DifMedium.Text = "Medium";
            this.DifMedium.UseVisualStyleBackColor = true;
            this.DifMedium.Visible = false;
            this.DifMedium.CheckedChanged += new System.EventHandler(this.DifMedium_CheckedChanged);
            // 
            // GameType
            // 
            this.GameType.Controls.Add(this.Diffculty);
            this.GameType.Controls.Add(this.radioLocal);
            this.GameType.Controls.Add(this.radioAI);
            this.GameType.Location = new System.Drawing.Point(153, 194);
            this.GameType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GameType.Name = "GameType";
            this.GameType.Size = new System.Drawing.Size(129, 162);
            this.GameType.TabIndex = 25;
            // 
            // Diffculty
            // 
            this.Diffculty.Controls.Add(this.DifEasy);
            this.Diffculty.Controls.Add(this.DifHard);
            this.Diffculty.Controls.Add(this.DifMedium);
            this.Diffculty.Location = new System.Drawing.Point(3, 48);
            this.Diffculty.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Diffculty.Name = "Diffculty";
            this.Diffculty.Size = new System.Drawing.Size(101, 111);
            this.Diffculty.TabIndex = 26;
            // 
            // CustomTimeLabel
            // 
            this.CustomTimeLabel.AutoSize = true;
            this.CustomTimeLabel.Location = new System.Drawing.Point(549, 305);
            this.CustomTimeLabel.Name = "CustomTimeLabel";
            this.CustomTimeLabel.Size = new System.Drawing.Size(97, 16);
            this.CustomTimeLabel.TabIndex = 26;
            this.CustomTimeLabel.Text = "Amount of time:";
            this.CustomTimeLabel.Visible = false;
            // 
            // GameSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CustomTimeLabel);
            this.Controls.Add(this.GameType);
            this.Controls.Add(this.signOutSettingsButton);
            this.Controls.Add(this.helloUserLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.casualButton);
            this.Controls.Add(this.customTimeTextbox);
            this.Controls.Add(this.customButton);
            this.Controls.Add(this.interButton);
            this.Controls.Add(this.blitzButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gameSettingsTitle);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GameSettings";
            this.Text = "GameSettings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameSettings_FormClosing);
            this.Load += new System.EventHandler(this.GameSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.GameType.ResumeLayout(false);
            this.GameType.PerformLayout();
            this.Diffculty.ResumeLayout(false);
            this.Diffculty.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label gameSettingsTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton blitzButton;
        private System.Windows.Forms.RadioButton interButton;
        private System.Windows.Forms.RadioButton customButton;
        private System.Windows.Forms.TextBox customTimeTextbox;
        private System.Windows.Forms.RadioButton casualButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label helloUserLabel;
        private System.Windows.Forms.Button signOutSettingsButton;
        private System.Windows.Forms.RadioButton DifEasy;
        private System.Windows.Forms.RadioButton radioAI;
        private System.Windows.Forms.RadioButton radioLocal;
        private System.Windows.Forms.RadioButton DifHard;
        private System.Windows.Forms.RadioButton DifMedium;
        private System.Windows.Forms.Panel GameType;
        private System.Windows.Forms.Panel Diffculty;
        private System.Windows.Forms.Label CustomTimeLabel;
    }
}