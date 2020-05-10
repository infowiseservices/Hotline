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
    public partial class hotlineForm : Form
    {
        private List<projectData> accounts;
        public hotlineForm()
        {
            InitializeComponent();
        }

        private void hotlineForm_Load(object sender, EventArgs e)
        {
            userLabel.Text = "Du er logget ind som: " + IW_Hotline.ThisAddIn.username;
            string data = projectListbox.Text;
            accounts = IW_Hotline.ThisAddIn.GetProjectsSearch(data);
            if (accounts.Count == 0)
            {
                IW_Hotline.ThisAddIn.password = "";
                IW_Hotline.ThisAddIn.username = "";
                IW_Hotline.ThisAddIn.getPopup("FELJ ved login - ved gentagende fejl log ind via web");
                this.Close();
            }
            else {
                projectListbox.DataSource = accounts;
                projectListbox.DisplayMember = "name";
            }
            
        }

        private void reLoginBtn_Click(object sender, EventArgs e)
        {
            IW_Hotline.ThisAddIn.username = "";
            IW_Hotline.ThisAddIn.password = "";
            IW_Hotline.ThisAddIn.getPopup();
            this.Close();
        }

        private void cancelIssueBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void issueCreateBtn_Click(object sender, EventArgs e)
        {
            object data = projectListbox.SelectedItem;
            string accId = data.GetType().GetProperty("accountId").GetValue(data).ToString();
            string accKey = data.GetType().GetProperty("accountKey").GetValue(data).ToString();
            string custId = data.GetType().GetProperty("customerId").GetValue(data).ToString();
            string description = issueTextBox.Text;
            IW_Hotline.ThisAddIn.runCreation(accId, accKey, custId, description);
            resultLbl.Text = IW_Hotline.ThisAddIn.resultText;
            IW_Hotline.ThisAddIn.ResetGlobals();
            searchText.Text = "";
            issueTextBox.Text = "";

        }

        private void projectListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void searchText_TextChanged(object sender, EventArgs e)
        {
            string data = searchText.Text;
            accounts = IW_Hotline.ThisAddIn.GetProjectsSearch(data);
            projectListbox.DataSource = accounts;
            projectListbox.DisplayMember = "name";
        }
    }
}
