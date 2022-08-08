using System;
using System.Windows.Forms;

namespace AzureDevOps_ChangeWorkItemType
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }
        private void SettingsForm_Shown(object sender, EventArgs e)
        {
            var localConfig = Configuration.LocalConfig.ReadFromFile(Program.LocalConfigFilePath()); ;

            if (localConfig != null)
            {
                this.collectionUrl_textBox.Text = localConfig.CollectionUrl;
                this.teamProject_textBox.Text = localConfig.TeamProject;
                this.personalAccessToken_textBox.Text = localConfig.PersonalAccessToken;
                this.query_textBox.Text = localConfig.Query;
            }
        }

        private void Save_button_Click(object sender, EventArgs e)
        {
            var localConfig = new Configuration.LocalConfig()
            {
                CollectionUrl = this.collectionUrl_textBox.Text,
                TeamProject = this.teamProject_textBox.Text,
                PersonalAccessToken = this.personalAccessToken_textBox.Text,
                Query = this.query_textBox.Text,
            };
            localConfig.WriteToFile(Program.LocalConfigFilePath());

            DialogResult = DialogResult.OK;
        }

        private void collectionUrl_textBox_DoubleClick(object sender, EventArgs e) => ((TextBox)sender).Text = "https://dev.azure.com/<yourorganization>";
        private void query_textBox_DoubleClick(object sender, EventArgs e) => ((TextBox)sender).Text = "[System.WorkItemType] = 'Product Backlog Item' AND [System.State] <> 'Closed'";
    }
}
