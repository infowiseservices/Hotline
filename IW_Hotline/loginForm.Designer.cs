namespace IW_Hotline
{
    partial class loginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loginForm));
            this.userLoginBtn = new System.Windows.Forms.Button();
            this.cancelLoginBtn = new System.Windows.Forms.Button();
            this.userNameInput = new System.Windows.Forms.TextBox();
            this.UserPasswordInput = new System.Windows.Forms.TextBox();
            this.userName = new System.Windows.Forms.Label();
            this.userPassword = new System.Windows.Forms.Label();
            this.loginTxtLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // userLoginBtn
            // 
            this.userLoginBtn.Location = new System.Drawing.Point(12, 126);
            this.userLoginBtn.Name = "userLoginBtn";
            this.userLoginBtn.Size = new System.Drawing.Size(125, 41);
            this.userLoginBtn.TabIndex = 0;
            this.userLoginBtn.Text = "Login";
            this.userLoginBtn.UseVisualStyleBackColor = true;
            this.userLoginBtn.Click += new System.EventHandler(this.userLoginBtn_Click);
            // 
            // cancelLoginBtn
            // 
            this.cancelLoginBtn.Location = new System.Drawing.Point(207, 126);
            this.cancelLoginBtn.Name = "cancelLoginBtn";
            this.cancelLoginBtn.Size = new System.Drawing.Size(125, 41);
            this.cancelLoginBtn.TabIndex = 1;
            this.cancelLoginBtn.Text = "Annuller";
            this.cancelLoginBtn.UseVisualStyleBackColor = true;
            this.cancelLoginBtn.Click += new System.EventHandler(this.cancelLoginBtn_Click);
            // 
            // userNameInput
            // 
            this.userNameInput.Location = new System.Drawing.Point(12, 34);
            this.userNameInput.Name = "userNameInput";
            this.userNameInput.Size = new System.Drawing.Size(320, 20);
            this.userNameInput.TabIndex = 2;
            // 
            // UserPasswordInput
            // 
            this.UserPasswordInput.Location = new System.Drawing.Point(12, 90);
            this.UserPasswordInput.Name = "UserPasswordInput";
            this.UserPasswordInput.PasswordChar = '*';
            this.UserPasswordInput.Size = new System.Drawing.Size(320, 20);
            this.UserPasswordInput.TabIndex = 3;
            // 
            // userName
            // 
            this.userName.AutoSize = true;
            this.userName.Location = new System.Drawing.Point(9, 17);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(62, 13);
            this.userName.TabIndex = 4;
            this.userName.Text = "Brugernavn";
            // 
            // userPassword
            // 
            this.userPassword.AutoSize = true;
            this.userPassword.Location = new System.Drawing.Point(9, 73);
            this.userPassword.Name = "userPassword";
            this.userPassword.Size = new System.Drawing.Size(53, 13);
            this.userPassword.TabIndex = 5;
            this.userPassword.Text = "Password";
            // 
            // loginTxtLbl
            // 
            this.loginTxtLbl.AutoSize = true;
            this.loginTxtLbl.BackColor = System.Drawing.SystemColors.Control;
            this.loginTxtLbl.ForeColor = System.Drawing.Color.Red;
            this.loginTxtLbl.Location = new System.Drawing.Point(13, 184);
            this.loginTxtLbl.Name = "loginTxtLbl";
            this.loginTxtLbl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.loginTxtLbl.Size = new System.Drawing.Size(0, 13);
            this.loginTxtLbl.TabIndex = 6;
            // 
            // loginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 203);
            this.Controls.Add(this.loginTxtLbl);
            this.Controls.Add(this.userPassword);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.UserPasswordInput);
            this.Controls.Add(this.userNameInput);
            this.Controls.Add(this.cancelLoginBtn);
            this.Controls.Add(this.userLoginBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "loginForm";
            this.Text = "Jira Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button userLoginBtn;
        private System.Windows.Forms.Button cancelLoginBtn;
        private System.Windows.Forms.TextBox userNameInput;
        private System.Windows.Forms.TextBox UserPasswordInput;
        private System.Windows.Forms.Label userName;
        private System.Windows.Forms.Label userPassword;
        private System.Windows.Forms.Label loginTxtLbl;
    }
}