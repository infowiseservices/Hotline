namespace IW_Hotline
{
    partial class hotlineForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(hotlineForm));
            this.projectListbox = new System.Windows.Forms.ComboBox();
            this.issueTextBox = new System.Windows.Forms.RichTextBox();
            this.issueCreateBtn = new System.Windows.Forms.Button();
            this.reLoginBtn = new System.Windows.Forms.Button();
            this.cancelIssueBtn = new System.Windows.Forms.Button();
            this.userLabel = new System.Windows.Forms.Label();
            this.searchText = new System.Windows.Forms.TextBox();
            this.projectDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.resultLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.projectDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // projectListbox
            // 
            this.projectListbox.FormattingEnabled = true;
            this.projectListbox.Location = new System.Drawing.Point(36, 109);
            this.projectListbox.Name = "projectListbox";
            this.projectListbox.Size = new System.Drawing.Size(404, 21);
            this.projectListbox.TabIndex = 0;
            this.projectListbox.TextChanged += new System.EventHandler(this.projectListbox_SelectedIndexChanged);
            // 
            // issueTextBox
            // 
            this.issueTextBox.Location = new System.Drawing.Point(36, 176);
            this.issueTextBox.Name = "issueTextBox";
            this.issueTextBox.Size = new System.Drawing.Size(404, 238);
            this.issueTextBox.TabIndex = 1;
            this.issueTextBox.Text = "";
            // 
            // issueCreateBtn
            // 
            this.issueCreateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.issueCreateBtn.Location = new System.Drawing.Point(482, 45);
            this.issueCreateBtn.Name = "issueCreateBtn";
            this.issueCreateBtn.Size = new System.Drawing.Size(169, 98);
            this.issueCreateBtn.TabIndex = 2;
            this.issueCreateBtn.Text = "Opret";
            this.issueCreateBtn.UseVisualStyleBackColor = true;
            this.issueCreateBtn.Click += new System.EventHandler(this.issueCreateBtn_Click);
            // 
            // reLoginBtn
            // 
            this.reLoginBtn.Location = new System.Drawing.Point(482, 164);
            this.reLoginBtn.Name = "reLoginBtn";
            this.reLoginBtn.Size = new System.Drawing.Size(169, 23);
            this.reLoginBtn.TabIndex = 3;
            this.reLoginBtn.Text = "re-login";
            this.reLoginBtn.UseVisualStyleBackColor = true;
            this.reLoginBtn.Click += new System.EventHandler(this.reLoginBtn_Click);
            // 
            // cancelIssueBtn
            // 
            this.cancelIssueBtn.Location = new System.Drawing.Point(482, 205);
            this.cancelIssueBtn.Name = "cancelIssueBtn";
            this.cancelIssueBtn.Size = new System.Drawing.Size(169, 23);
            this.cancelIssueBtn.TabIndex = 4;
            this.cancelIssueBtn.Text = "Annuller";
            this.cancelIssueBtn.UseVisualStyleBackColor = true;
            this.cancelIssueBtn.Click += new System.EventHandler(this.cancelIssueBtn_Click);
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Location = new System.Drawing.Point(36, 441);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(0, 13);
            this.userLabel.TabIndex = 6;
            // 
            // searchText
            // 
            this.searchText.Location = new System.Drawing.Point(36, 45);
            this.searchText.Name = "searchText";
            this.searchText.Size = new System.Drawing.Size(404, 20);
            this.searchText.TabIndex = 7;
            this.searchText.TextChanged += new System.EventHandler(this.searchText_TextChanged);
            // 
            // projectDataBindingSource
            // 
            this.projectDataBindingSource.DataSource = typeof(IW_Hotline.projectData);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Søg Kunde / Art";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tekst til opgave og tidsregistrering";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Kunde / Art opgaven skal oprettes til";
            // 
            // resultLbl
            // 
            this.resultLbl.AutoSize = true;
            this.resultLbl.Location = new System.Drawing.Point(482, 247);
            this.resultLbl.Name = "resultLbl";
            this.resultLbl.Size = new System.Drawing.Size(0, 13);
            this.resultLbl.TabIndex = 11;
            // 
            // hotlineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 471);
            this.Controls.Add(this.resultLbl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchText);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.cancelIssueBtn);
            this.Controls.Add(this.reLoginBtn);
            this.Controls.Add(this.issueCreateBtn);
            this.Controls.Add(this.issueTextBox);
            this.Controls.Add(this.projectListbox);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "hotlineForm";
            this.Text = "Jira Hotline";
            this.Load += new System.EventHandler(this.hotlineForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.projectDataBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox projectListbox;
        private System.Windows.Forms.RichTextBox issueTextBox;
        private System.Windows.Forms.Button issueCreateBtn;
        private System.Windows.Forms.Button reLoginBtn;
        private System.Windows.Forms.Button cancelIssueBtn;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.BindingSource projectDataBindingSource;
        private System.Windows.Forms.TextBox searchText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label resultLbl;
    }
}