using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Final_Project_Chess
{
    public partial class MainScreen : Form
    {
        User currentUser;

        List<User> users = new List<User>();
        
        private bool complete = false; //JP
        private string _username = "";
        private string _password = "";
        private User t = new User("",""); //JP
        private int account = 0;
        private string textpath;
        private string filepath = System.IO.Path.GetDirectoryName(Application.ExecutablePath); //JP
        public MainScreen()
        {
            InitializeComponent();
        }
        public string getUserName() { return _username; } //JP
        private void signInButton_Click(object sender, EventArgs e) //JP
        {
            _username = usernameTextbox.Text;
            _password = passwordTextbox.Text;

            if (users.Count == 0)
            {
                MessageBox.Show("No User or Password found");
            }
            if ((_username != "") && (_password != ""))
            {
                foreach (User u in users)
                {
                    if ((u.getUsername() == _username) && (u.getPassword() == _password))
                    {
                        MessageBox.Show("Welcome back " + _username + "");
                        //switch screens
                        using (GameSettings goal = new GameSettings(this))
                        {
                            if (goal.ShowDialog() == DialogResult.OK)
                            { }
                        }
                        return;
                    }
                    else if ((u.getUsername() == _username) && (u.getPassword() != _password))
                    {
                        account++;
                        
                        if (account == users.Count)
                        {
                            MessageBox.Show("Incorrect Password");
                            account = 0;
                            break;
                        }
                    }
                    else if (users[users.Count - 1] == u)
                    {
                        MessageBox.Show("No User or Password found");
                        account = 0;
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Fill out all fields");
            }
        }//JP
        private void createAccButton_Click(object sender, EventArgs e)//JP
        {
            _username = usernameTextbox.Text;
            _password = passwordTextbox.Text;

            if ((_username != "") && (_password != ""))
            {
                bool userAlreadyExists = false;
                foreach (User u in users)
                {
                    if ((u.getUsername() == _username) && (u.getPassword() == _password))
                    {
                        MessageBox.Show("Account already exists");
                        userAlreadyExists = true;
                        break;
                    }
                    else if ((u.getUsername() == _username) && (u.getPassword() != _password))
                    {
                        MessageBox.Show("Username is in use");
                        userAlreadyExists = true;
                        break;
                    }
                }
                if (!userAlreadyExists)
                {
                    using (StreamWriter userText = File.AppendText($"UserData.txt")) //JP
                    {
                        userText.WriteLine(_username + "," + _password);
                    }
                    t.setUsername(_username);
                    t.setPassword(_password);
                    users.Add(t);
                    MessageBox.Show("Account created! Welcome " + _username);
                    using (GameSettings goal = new GameSettings(this))
                    {
                        if (goal.ShowDialog() == DialogResult.OK)
                        { }
                    }
                }
            }
            else
            {
                MessageBox.Show("Fill out all fields");
            }
        }//JP
        public void clearUserPassword() //THP, called when signing out
        {
            _username = "";
            _password = "";
            passwordTextbox.Text = "";
            usernameTextbox.Text = "";
            account = 0;
        }
        private void MainScreen_Load(object sender, EventArgs e) //JP
        {
            complete = false;
            if (File.Exists("UserData.txt") == false)
            {
                using (System.IO.FileStream userText = File.Create(filepath + $"\\UserData.txt")) ;
                using (StreamWriter userText = File.AppendText($"UserData.txt"))
                {
                    userText.WriteLine("Tester,password");
                }
            }
            if (!complete)
            {
                textpath = Path.Combine(filepath, "UserData.txt");
                using (StreamReader r = new StreamReader(textpath))
                {
                    string line;
                    while ((line = r.ReadLine()) != null)
                    {
                        string[] data = line.Split(',');
                        if (data.Length == 2)
                        {
                            
                            string Tusername = data[0].Trim();
                            string Tpassword = data[1].Trim();
                            User f = new User(Tusername, Tpassword);
                            users.Add(f);
                        }
                    }
                    complete = true;
                }
            }
        }//JP
    }
}
