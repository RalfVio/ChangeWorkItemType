using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace AzureDevOps_ChangeWorkItemType
{
    public partial class StartForm : Form
    {
        Configuration.LocalConfig _localConfig = null;

        Rest.BL_WorkItem _blRest = null;
        Rest.BL_WorkItem.WorkItem _workItem = null;
        List<Rest.BL_WorkItem.WorkItem> _workItems = null;

        bool _active = false;
        public StartForm()
        {
            InitializeComponent();
            this.query_groupBox.Location = this.wi_groupBox.Location;
            this.wi_groupBox.Width = this.query_groupBox.Width = radioButtons_groupBox.Width;
        }

        #region Events

        #region Form
        private async void StartForm_Shown(object sender, EventArgs e)
        {
            try
            {
                this.wi_groupBox.Visible = this.query_groupBox.Visible=this.radioButtons_groupBox.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                _localConfig = Configuration.LocalConfig.ReadFromFile(Program.LocalConfigFilePath()); ;

                if (_localConfig != null && !_localConfig.IsValid())
                    _localConfig = null;

                if (_localConfig == null)
                    throw new Exception("Not able to read configuration");
                _blRest = GetBL();
                if (_blRest == null)
                    throw new Exception("Invalid configuration");

                if (string.IsNullOrEmpty(_localConfig.Query))
                {
                    this.wiId_textBox.SelectAll();
                    this.wiId_textBox.Focus();
                    this.wi_radioButton.Checked = true;
                    this.query_radioButton.Enabled = false;
                    ActivateGroupControl();
                }
                else
                {
                    await WorkItemsRead(false);
                    PopulateQueryResult();

                    this.query_radioButton.Enabled = true;
                    this.query_radioButton.Checked = true;
                    ActivateGroupControl();
                }

            }
            catch (Exception ex) { MessageBox.Show($"Not able to read configuration. Please update configuration in Options/Settings.\r\n\r\nMessage:\r\n{ex.Message}"); }

            this.Cursor = Cursors.Default;
            this.radioButtons_groupBox.Enabled = true;
            _active = true;
        }

         private void StartForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_blRest != null)
                _blRest.Dispose();
        }

        private void StartForm_DoubleClick(object sender, EventArgs e) => this.Refresh();
        #endregion

        #region Controls
        private async void WiRead_button_Click(object sender, EventArgs e) 
        {
            if (!int.TryParse(this.wiId_textBox.Text, out int id))
                return;
            if (id <= 0)
                return;

            await ReadWorkItem(id);

            if (_workItem != null)
            {
                DialogResult dialogResult = DialogResult.None;
                using (var f = new MigrationConfirmation_Form(_workItem))
                {
                    dialogResult = f.ShowDialog();
                }
                if (dialogResult == DialogResult.OK)
                    await MigrateWorkItem();
            }
        }
        private async void WiId_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!int.TryParse(this.wiId_textBox.Text, out int id))
                    return;
                if (id <= 0)
                    return;

                await ReadWorkItem(id);

                if (_workItem != null)
                {
                    DialogResult dialogResult = DialogResult.None;
                    using (var f = new MigrationConfirmation_Form(_workItem))
                    {
                        dialogResult = f.ShowDialog();
                    }
                    if (dialogResult == DialogResult.OK)
                        await MigrateWorkItem();
                }
            }
        }

        private async void Wis_dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!_active)
                return;
            if (e.RowIndex >= 0 && e.RowIndex < queryResult_dataGridView.Rows.Count && e.ColumnIndex== migrate_dataGridViewColumn.Index)
            {
                await ReadWorkItem((int)queryResult_dataGridView.Rows[e.RowIndex].Cells[0].Value);
                if (_workItem != null)
                {
                    DialogResult dialogResult = DialogResult.None;
                    using (var f = new MigrationConfirmation_Form(_workItem))
                    {
                        dialogResult = f.ShowDialog();
                    }
                    if (dialogResult == DialogResult.OK)
                        await MigrateWorkItem();
                }
            }
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!_active)
                return;
            if (!((RadioButton)sender).Checked)
                return;
            ActivateGroupControl();
        }
        private async void queryResultRefresh_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.wi_groupBox.Visible = this.query_groupBox.Visible = this.radioButtons_groupBox.Enabled = false;
            this.Cursor = Cursors.WaitCursor;

            _localConfig = Configuration.LocalConfig.ReadFromFile(Program.LocalConfigFilePath());

            if (_localConfig != null && !_localConfig.IsValid())
                _localConfig = null;

            if (_localConfig == null)
                throw new Exception("Not able to read configuration");
            _blRest = GetBL();
            if (_blRest == null)
                throw new Exception("Invalid configuration");

            if (string.IsNullOrEmpty(_localConfig.Query))
            {
                this.wiId_textBox.SelectAll();
                this.wiId_textBox.Focus();
                this.wi_radioButton.Checked = true;
                this.query_radioButton.Enabled = false;
                ActivateGroupControl();
            }
            else
            {
                await WorkItemsRead(true);
                PopulateQueryResult();

                this.query_radioButton.Enabled = true;
                this.query_radioButton.Checked = true;
                ActivateGroupControl();
            }

            this.Cursor = Cursors.Default;
            this.radioButtons_groupBox.Enabled = true;
        }
        #endregion

        #region Menu
        private void Close_ToolStripMenuItem_Click(object sender, EventArgs e) => Application.Exit();

        private async void Settings_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialogResult = DialogResult.None;
            using (var form = new SettingsForm())
            {
                dialogResult = form.ShowDialog();
            }
            if (dialogResult != DialogResult.OK)
                return;
            try
            {
                this.wi_groupBox.Visible = this.query_groupBox.Visible = this.radioButtons_groupBox.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                _localConfig = Configuration.LocalConfig.ReadFromFile(Program.LocalConfigFilePath());

                if (_localConfig != null && !_localConfig.IsValid())
                    _localConfig = null;

                if (_localConfig == null)
                    throw new Exception("Not able to read configuration");
                _blRest = GetBL();
                if (_blRest == null)
                    throw new Exception("Invalid configuration");

                if (string.IsNullOrEmpty(_localConfig.Query))
                {
                    this.wiId_textBox.SelectAll();
                    this.wiId_textBox.Focus();
                    this.wi_radioButton.Checked = true;
                    this.query_radioButton.Enabled = false;
                    ActivateGroupControl();
                }
                else
                {
                    await WorkItemsRead(true);
                    PopulateQueryResult();

                    this.query_radioButton.Enabled = true;
                    this.query_radioButton.Checked = true;
                    ActivateGroupControl();
                }

                this.Cursor = Cursors.Default;
                this.radioButtons_groupBox.Enabled = true;
            }
            catch (Exception ex) { MessageBox.Show($"Not able to read configuration. Please update configuration in Options/Settings.\r\n\r\nMessage:\r\n{ex.Message}"); }

        }
        private void SettingsFolder_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
            {
                    FileName= Path.GetDirectoryName(Program.LocalConfigFilePath()),
                    UseShellExecute=true,
                });
            }
        private void About_ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using var form = new AboutBox();
            form.ShowDialog();
        }
        #endregion

        #endregion 

        #region Helper functions
        Rest.BL_WorkItem GetBL()
        {
            if (_localConfig == null)
                return null;
            return new Rest.BL_WorkItem(_localConfig);
        }
        async Task ReadWorkItem(int id)
        {
            if (_blRest == null)
                _blRest = GetBL();
            if (_blRest == null)
                return;
            try
            {
                _workItem = await _blRest.GetWorkItem(id);
            }
            catch (System.Net.Http.HttpRequestException  ex) { _workItem = null; }
            if ((_workItem!=null && _workItem.WorkItemType != "Product Backlog Item"))
                _workItem = null;
        }
        async Task MigrateWorkItem()
        {
            if (_blRest == null)
                _blRest = GetBL();
            if (_blRest == null)
                return;

            var updateJson = Rest.BLBase.GetUpdateJson("Requirement", _workItem.WorkItemType, "System.WorkItemType", null);
            updateJson = Rest.BLBase.GetUpdateJson("Design", _workItem.State, "System.State", updateJson);
            updateJson = Rest.BLBase.GetUpdateJson("New", _workItem.Reason, "System.Reason", updateJson);
            bool isMigrated = await _blRest.UpdateWorkItem(_workItem, updateJson);
            if (isMigrated)
                await _blRest.WorkItemAddComment(_workItem, _workItem.Description);
        }
        private void WorkItemsSave()
        {
            if (_workItems == null)
                return;
            var json = JsonConvert.SerializeObject(_workItems, Formatting.Indented);
            File.WriteAllText(Program.LocalWICacheFilePath(), json, Encoding.UTF8);
        }
        private async Task WorkItemsRead(bool refresh)
        {
            List<Rest.BL_WorkItem.WorkItem> result = null;

            _workItems = null;
            if (!refresh && File.Exists(Program.LocalWICacheFilePath()))
            {
                using StreamReader file = File.OpenText(Program.LocalWICacheFilePath());
                JsonSerializer serializer = new JsonSerializer();
                result = (List<Rest.BL_WorkItem.WorkItem>)serializer.Deserialize(file, typeof(List<Rest.BL_WorkItem.WorkItem>));
                _workItems = result;
            }
            if (refresh || _workItems == null)
            {
                var ids = await _blRest.GetFlatQueryResult(_localConfig.Query);

                _workItems = new List<Rest.BL_WorkItem.WorkItem>();
                var idBatches = Rest.BL_WorkItem.SplitIdsIntoBatches(ids);
                foreach (var idBatch in idBatches)
                    _workItems.AddRange(await _blRest.GetWorkItems(idBatch));

                if (_workItems != null)
                    WorkItemsSave();
            }
                
        }
        private void PopulateQueryResult()
        {
            this.queryResult_dataGridView.Rows.Clear();
            foreach (var workItem in _workItems.OrderByDescending(w=>w.Id))
            {
                int rowNumber = this.queryResult_dataGridView.Rows.Add();
                this.queryResult_dataGridView.Rows[rowNumber].Cells[0].Value = workItem.Id;
                this.queryResult_dataGridView.Rows[rowNumber].Cells[1].Value = workItem.WorkItemType;
                this.queryResult_dataGridView.Rows[rowNumber].Cells[2].Value = workItem.Title;
            }
            this.query_groupBox.Text = $" {_workItems.Count} work items ";
        }
        private void ActivateGroupControl()
        {
            this.wi_groupBox.Visible = this.wi_radioButton.Checked;
            this.query_groupBox.Visible = !this.wi_groupBox.Visible;
            if (this.wi_groupBox.Visible)
            {
                this.wiId_textBox.SelectAll();
                this.wiId_textBox.Focus();
            }
        }

        #endregion
    }
}
