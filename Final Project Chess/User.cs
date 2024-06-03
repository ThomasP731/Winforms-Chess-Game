using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_Chess
{
    internal class User //ER, creates base for the user's username, and password
    {
        private string username;
        private string password;

        public User(string username, string password)
        {
            this.username = username; 
            this.password = password;
        }
        public string getUsername() { return username; }
        public string getPassword() { return password; }    
        public void setUsername(string newUsername) { username = newUsername; }
        public void setPassword(string newPassword) { password = newPassword; }

    }
}
