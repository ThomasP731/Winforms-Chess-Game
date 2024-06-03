using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Final_Project_Chess
{
    public partial class GameSettings : Form
    {
        public MainScreen originalScreen;
        public int timeChoice = 0; //JP
        public int opponentChoice = 0;
        bool userClickedSignOut = false;
        private string timeText = ""; //JP
        private string username = ""; //JP
        public GameSettings(MainScreen originalScreen) //JP
        {
            this.originalScreen = originalScreen;
            originalScreen.Hide();
            InitializeComponent();
            radioLocal.Checked = true;
            casualButton.Checked = true;
            DifEasy.Checked = true;
        }//JP
        public string getTimeText() { return timeText; } //JP
        public string getUsername() { return username; } //JP
        public int getTimeChoice() {return timeChoice;}//JP
        private void radioAI_CheckedChanged(object sender, EventArgs e) //JP
        {
            if (radioAI.Checked == true)
            {
                DifEasy.Visible = true;
                DifHard.Visible = true;
                DifMedium.Visible = true;
            }
            else if (radioAI.Checked == false)
            {
                DifEasy.Visible = false;
                DifHard.Visible = false;
                DifMedium.Visible = false;
            }
        }//JP
        private void DifEasy_CheckedChanged(object sender, EventArgs e) //JP
        {
            opponentChoice = 2;
        } //JP
        private void customButton_CheckedChanged(object sender, EventArgs e) //JP
        {
            if (customButton.Checked == true) 
            {
                customTimeTextbox.Visible = true;
                CustomTimeLabel.Visible = true;
                timeChoice = 4; // variable for identifying which button is clicked
            }
            else if (customButton.Checked == false)
            {
                customTimeTextbox.Visible = false;
                CustomTimeLabel.Visible = false;
            }
        } //JP
        private void casualButton_CheckedChanged(object sender, EventArgs e)//ER
        {
            timeChoice = 1; // variable for identifying which button is clicked
        }//ER
        private void blitzButton_CheckedChanged(object sender, EventArgs e)//ER
        {
            timeChoice = 2; // variable for identifying which button is clicked
        }//ER
        private void interButton_CheckedChanged(object sender, EventArgs e)//ER
        {
            timeChoice = 3; // variable for identifying which button is clicked
        }//ER
        private void radioLocal_CheckedChanged(object sender, EventArgs e)//ER
        {
            opponentChoice = 1; // variable for identifying which button is clicked
        }//ER
        private void DifMedium_CheckedChanged(object sender, EventArgs e) //ER
        {
            opponentChoice = 2; // variable for identifying which button is clicked
        }//ER
        private void DifHard_CheckedChanged(object sender, EventArgs e) //ER
        {
            opponentChoice = 3; // variable for identifying which button is clicked
        }//ER
        private void playButton_Click(object sender, EventArgs e) //JP
        {
            if((opponentChoice != 0) && (timeChoice != 0))
            {
                timeText = customTimeTextbox.Text;
                using (GameScreen goal = new GameScreen(this))
                {
                    if (goal.ShowDialog() == DialogResult.OK)
                    {
                        //no unique property, previous method not refactored
                    }
                }
            }
        } //JP
        private void signOutSettingsButton_Click(object sender, EventArgs e)
        {
            userClickedSignOut = true;
            originalScreen.Show();
            originalScreen.clearUserPassword();
            this.Close();
        }
        private void GameSettings_FormClosing(object sender, FormClosingEventArgs e) //THP
        {
            // When user hits x button show main form
            // This is necessary because otherwise the main form would run in the background but still be hidden, and create issues when trying to run the app again

            if (userClickedSignOut)
                originalScreen.Show();
            else
                Application.Exit();
        } //THP

        private void GameSettings_Load(object sender, EventArgs e) //JP
        {
            username = originalScreen.getUserName();
            helloUserLabel.Text = "Hello " + username + "!";
        } //JP
    }
}
