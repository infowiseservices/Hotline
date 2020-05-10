using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IW_Hotline
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
            loginTxtLbl.Text = IW_Hotline.ThisAddIn.loginText;
        }

        private void cancelLoginBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void userLoginBtn_Click(object sender, EventArgs e)
        {
            IW_Hotline.ThisAddIn.username = userNameInput.Text;
            IW_Hotline.ThisAddIn.password = UserPasswordInput.Text;
            IW_Hotline.ThisAddIn.getPopup();

            this.Close();
        }
    }
}
