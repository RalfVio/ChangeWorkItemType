using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AzureDevOps_ChangeWorkItemType
{
    public partial class MigrationConfirmation_Form : Form
    {
        Rest.BL_WorkItem.WorkItem _workItem = null;
        public MigrationConfirmation_Form(Rest.BL_WorkItem.WorkItem workItem)
        {
            InitializeComponent();
            _workItem = workItem;
        }

        private void MigrationConfirmation_Form_Shown(object sender, EventArgs e)
        {
            this.wiTitle_textBox.Text = _workItem.GetFullName();
        }
    }
}
