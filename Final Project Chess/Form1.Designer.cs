namespace Final_Project_Chess
{
    partial class MainScreen
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
            this.mainScreenTitle = new System.Windows.Forms.Label();
            this.usernameTextbox = new System.Windows.Forms.TextBox();
            this.passwordTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.userLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.createAccButton = new System.Windows.Forms.Button();
            this.signInButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainScreenTitle
            // 
            this.mainScreenTitle.AutoSize = true;
            this.mainScreenTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainScreenTitle.Location = new System.Drawing.Point(302, 29);
            this.mainScreenTitle.Name = "mainScreenTitle";
            this.mainScreenTitle.Size = new System.Drawing.Size(197, 46);
            this.mainScreenTitle.TabIndex = 0;
            this.mainScreenTitle.Text = "My Chess";
            // 
            // usernameTextbox
            // 
            this.usernameTextbox.Location = new System.Drawing.Point(394, 126);
            this.usernameTextbox.Name = "usernameTextbox";
            this.usernameTextbox.Size = new System.Drawing.Size(119, 22);
            this.usernameTextbox.TabIndex = 1;
            // 
            // passwordTextbox
            // 
            this.passwordTextbox.Location = new System.Drawing.Point(394, 154);
            this.passwordTextbox.Name = "passwordTextbox";
            this.passwordTextbox.Size = new System.Drawing.Size(119, 22);
            this.passwordTextbox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(340, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Credentials:";
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userLabel.Location = new System.Drawing.Point(284, 128);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(91, 20);
            this.userLabel.TabIndex = 4;
            this.userLabel.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(287, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password:";
            // 
            // createAccButton
            // 
            this.createAccButton.Location = new System.Drawing.Point(310, 194);
            this.createAccButton.Name = "createAccButton";
            this.createAccButton.Size = new System.Drawing.Size(108, 30);
            this.createAccButton.TabIndex = 6;
            this.createAccButton.Text = "Create Account";
            this.createAccButton.UseVisualStyleBackColor = true;
            this.createAccButton.Click += new System.EventHandler(this.createAccButton_Click);
            // 
            // signInButton
            // 
            this.signInButton.Location = new System.Drawing.Point(424, 194);
            this.signInButton.Name = "signInButton";
            this.signInButton.Size = new System.Drawing.Size(75, 30);
            this.signInButton.TabIndex = 7;
            this.signInButton.Text = "Sign in";
            this.signInButton.UseVisualStyleBackColor = true;
            this.signInButton.Click += new System.EventHandler(this.signInButton_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.signInButton);
            this.Controls.Add(this.createAccButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passwordTextbox);
            this.Controls.Add(this.usernameTextbox);
            this.Controls.Add(this.mainScreenTitle);
            this.Name = "MainScreen";
            this.Text = "MainScreen";
            this.Load += new System.EventHandler(this.MainScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mainScreenTitle;
        private System.Windows.Forms.TextBox usernameTextbox;
        private System.Windows.Forms.TextBox passwordTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button createAccButton;
        private System.Windows.Forms.Button signInButton;
    }
}

