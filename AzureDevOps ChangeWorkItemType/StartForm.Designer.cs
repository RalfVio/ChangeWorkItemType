
namespace AzureDevOps_ChangeWorkItemType
{
    partial class StartForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.wi_groupBox = new System.Windows.Forms.GroupBox();
            this.wiRead_button = new System.Windows.Forms.Button();
            this.wiId_textBox = new System.Windows.Forms.TextBox();
            this.wiId_label = new System.Windows.Forms.Label();
            this.query_groupBox = new System.Windows.Forms.GroupBox();
            this.queryResultRefresh_linkLabel = new System.Windows.Forms.LinkLabel();
            this.queryResult_dataGridView = new System.Windows.Forms.DataGridView();
            this.id_dataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wiType_dataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.title_dataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.migrate_dataGridViewColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.close_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settings_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsFolder_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.about_ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.radioButtons_groupBox = new System.Windows.Forms.GroupBox();
            this.query_radioButton = new System.Windows.Forms.RadioButton();
            this.wi_radioButton = new System.Windows.Forms.RadioButton();
            this.wi_groupBox.SuspendLayout();
            this.query_groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.queryResult_dataGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.radioButtons_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // wi_groupBox
            // 
            this.wi_groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wi_groupBox.Controls.Add(this.wiRead_button);
            this.wi_groupBox.Controls.Add(this.wiId_textBox);
            this.wi_groupBox.Controls.Add(this.wiId_label);
            this.wi_groupBox.Location = new System.Drawing.Point(30, 134);
            this.wi_groupBox.Name = "wi_groupBox";
            this.wi_groupBox.Size = new System.Drawing.Size(942, 109);
            this.wi_groupBox.TabIndex = 0;
            this.wi_groupBox.TabStop = false;
            this.wi_groupBox.Text = "Work Item";
            this.wi_groupBox.Visible = false;
            // 
            // wiRead_button
            // 
            this.wiRead_button.Location = new System.Drawing.Point(209, 41);
            this.wiRead_button.Name = "wiRead_button";
            this.wiRead_button.Size = new System.Drawing.Size(65, 34);
            this.wiRead_button.TabIndex = 3;
            this.wiRead_button.Text = "Read";
            this.wiRead_button.UseVisualStyleBackColor = true;
            this.wiRead_button.Click += new System.EventHandler(this.WiRead_button_Click);
            // 
            // wiId_textBox
            // 
            this.wiId_textBox.Location = new System.Drawing.Point(81, 41);
            this.wiId_textBox.Name = "wiId_textBox";
            this.wiId_textBox.Size = new System.Drawing.Size(99, 31);
            this.wiId_textBox.TabIndex = 1;
            this.wiId_textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WiId_textBox_KeyDown);
            // 
            // wiId_label
            // 
            this.wiId_label.AutoSize = true;
            this.wiId_label.Location = new System.Drawing.Point(28, 41);
            this.wiId_label.Name = "wiId_label";
            this.wiId_label.Size = new System.Drawing.Size(32, 25);
            this.wiId_label.TabIndex = 0;
            this.wiId_label.Text = "Id:";
            // 
            // query_groupBox
            // 
            this.query_groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.query_groupBox.Controls.Add(this.queryResultRefresh_linkLabel);
            this.query_groupBox.Controls.Add(this.queryResult_dataGridView);
            this.query_groupBox.Location = new System.Drawing.Point(30, 200);
            this.query_groupBox.Name = "query_groupBox";
            this.query_groupBox.Size = new System.Drawing.Size(942, 580);
            this.query_groupBox.TabIndex = 1;
            this.query_groupBox.TabStop = false;
            this.query_groupBox.Visible = false;
            // 
            // queryResultRefresh_linkLabel
            // 
            this.queryResultRefresh_linkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.queryResultRefresh_linkLabel.AutoSize = true;
            this.queryResultRefresh_linkLabel.Location = new System.Drawing.Point(28, 534);
            this.queryResultRefresh_linkLabel.Name = "queryResultRefresh_linkLabel";
            this.queryResultRefresh_linkLabel.Size = new System.Drawing.Size(70, 25);
            this.queryResultRefresh_linkLabel.TabIndex = 1;
            this.queryResultRefresh_linkLabel.TabStop = true;
            this.queryResultRefresh_linkLabel.Text = "Refresh";
            this.queryResultRefresh_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.queryResultRefresh_linkLabel_LinkClicked);
            // 
            // queryResult_dataGridView
            // 
            this.queryResult_dataGridView.AllowUserToAddRows = false;
            this.queryResult_dataGridView.AllowUserToDeleteRows = false;
            this.queryResult_dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.queryResult_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.queryResult_dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_dataGridViewColumn,
            this.wiType_dataGridViewColumn,
            this.title_dataGridViewColumn,
            this.migrate_dataGridViewColumn});
            this.queryResult_dataGridView.Location = new System.Drawing.Point(10, 35);
            this.queryResult_dataGridView.MultiSelect = false;
            this.queryResult_dataGridView.Name = "queryResult_dataGridView";
            this.queryResult_dataGridView.ReadOnly = true;
            this.queryResult_dataGridView.RowHeadersWidth = 20;
            this.queryResult_dataGridView.RowTemplate.Height = 50;
            this.queryResult_dataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.queryResult_dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.queryResult_dataGridView.Size = new System.Drawing.Size(909, 470);
            this.queryResult_dataGridView.TabIndex = 0;
            this.queryResult_dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Wis_dataGridView_CellClick);
            // 
            // id_dataGridViewColumn
            // 
            this.id_dataGridViewColumn.Frozen = true;
            this.id_dataGridViewColumn.HeaderText = "ID";
            this.id_dataGridViewColumn.MinimumWidth = 8;
            this.id_dataGridViewColumn.Name = "id_dataGridViewColumn";
            this.id_dataGridViewColumn.ReadOnly = true;
            this.id_dataGridViewColumn.Width = 75;
            // 
            // wiType_dataGridViewColumn
            // 
            this.wiType_dataGridViewColumn.HeaderText = "Type";
            this.wiType_dataGridViewColumn.MinimumWidth = 8;
            this.wiType_dataGridViewColumn.Name = "wiType_dataGridViewColumn";
            this.wiType_dataGridViewColumn.ReadOnly = true;
            this.wiType_dataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.wiType_dataGridViewColumn.Width = 150;
            // 
            // title_dataGridViewColumn
            // 
            this.title_dataGridViewColumn.HeaderText = "Title";
            this.title_dataGridViewColumn.MinimumWidth = 8;
            this.title_dataGridViewColumn.Name = "title_dataGridViewColumn";
            this.title_dataGridViewColumn.ReadOnly = true;
            this.title_dataGridViewColumn.Width = 400;
            // 
            // migrate_dataGridViewColumn
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            this.migrate_dataGridViewColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.migrate_dataGridViewColumn.HeaderText = "";
            this.migrate_dataGridViewColumn.MinimumWidth = 8;
            this.migrate_dataGridViewColumn.Name = "migrate_dataGridViewColumn";
            this.migrate_dataGridViewColumn.ReadOnly = true;
            this.migrate_dataGridViewColumn.Text = "Migrate";
            this.migrate_dataGridViewColumn.UseColumnTextForButtonValue = true;
            this.migrate_dataGridViewColumn.Width = 120;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1006, 33);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.close_ToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // close_ToolStripMenuItem
            // 
            this.close_ToolStripMenuItem.Name = "close_ToolStripMenuItem";
            this.close_ToolStripMenuItem.Size = new System.Drawing.Size(141, 34);
            this.close_ToolStripMenuItem.Text = "Exit";
            this.close_ToolStripMenuItem.Click += new System.EventHandler(this.Close_ToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settings_ToolStripMenuItem,
            this.settingsFolder_ToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(92, 29);
            this.settingsToolStripMenuItem.Text = "Options";
            // 
            // settings_ToolStripMenuItem
            // 
            this.settings_ToolStripMenuItem.Name = "settings_ToolStripMenuItem";
            this.settings_ToolStripMenuItem.Size = new System.Drawing.Size(230, 34);
            this.settings_ToolStripMenuItem.Text = "Settings";
            this.settings_ToolStripMenuItem.Click += new System.EventHandler(this.Settings_ToolStripMenuItem_Click);
            // 
            // settingsFolder_ToolStripMenuItem
            // 
            this.settingsFolder_ToolStripMenuItem.Name = "settingsFolder_ToolStripMenuItem";
            this.settingsFolder_ToolStripMenuItem.Size = new System.Drawing.Size(230, 34);
            this.settingsFolder_ToolStripMenuItem.Text = "Settings folder";
            this.settingsFolder_ToolStripMenuItem.Click += new System.EventHandler(this.SettingsFolder_ToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.about_ToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(78, 29);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // about_ToolStripMenuItem1
            // 
            this.about_ToolStripMenuItem1.Name = "about_ToolStripMenuItem1";
            this.about_ToolStripMenuItem1.Size = new System.Drawing.Size(164, 34);
            this.about_ToolStripMenuItem1.Text = "About";
            this.about_ToolStripMenuItem1.Click += new System.EventHandler(this.About_ToolStripMenuItem1_Click);
            // 
            // radioButtons_groupBox
            // 
            this.radioButtons_groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtons_groupBox.Controls.Add(this.query_radioButton);
            this.radioButtons_groupBox.Controls.Add(this.wi_radioButton);
            this.radioButtons_groupBox.Location = new System.Drawing.Point(30, 53);
            this.radioButtons_groupBox.Name = "radioButtons_groupBox";
            this.radioButtons_groupBox.Size = new System.Drawing.Size(942, 64);
            this.radioButtons_groupBox.TabIndex = 3;
            this.radioButtons_groupBox.TabStop = false;
            // 
            // query_radioButton
            // 
            this.query_radioButton.AutoSize = true;
            this.query_radioButton.Location = new System.Drawing.Point(230, 25);
            this.query_radioButton.Name = "query_radioButton";
            this.query_radioButton.Size = new System.Drawing.Size(85, 29);
            this.query_radioButton.TabIndex = 1;
            this.query_radioButton.Text = "Query";
            this.query_radioButton.UseVisualStyleBackColor = true;
            this.query_radioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // wi_radioButton
            // 
            this.wi_radioButton.AutoSize = true;
            this.wi_radioButton.Checked = true;
            this.wi_radioButton.Location = new System.Drawing.Point(28, 25);
            this.wi_radioButton.Name = "wi_radioButton";
            this.wi_radioButton.Size = new System.Drawing.Size(169, 29);
            this.wi_radioButton.TabIndex = 0;
            this.wi_radioButton.TabStop = true;
            this.wi_radioButton.Text = "Single work item";
            this.wi_radioButton.UseVisualStyleBackColor = true;
            this.wi_radioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 739);
            this.Controls.Add(this.radioButtons_groupBox);
            this.Controls.Add(this.query_groupBox);
            this.Controls.Add(this.wi_groupBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "StartForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Work Item Type PBI>>Requirement";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StartForm_FormClosing);
            this.Shown += new System.EventHandler(this.StartForm_Shown);
            this.DoubleClick += new System.EventHandler(this.StartForm_DoubleClick);
            this.wi_groupBox.ResumeLayout(false);
            this.wi_groupBox.PerformLayout();
            this.query_groupBox.ResumeLayout(false);
            this.query_groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.queryResult_dataGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.radioButtons_groupBox.ResumeLayout(false);
            this.radioButtons_groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox wi_groupBox;
        private System.Windows.Forms.TextBox wiId_textBox;
        private System.Windows.Forms.Label wiId_label;
        private System.Windows.Forms.Button wiRead_button;
        private System.Windows.Forms.GroupBox query_groupBox;
        private System.Windows.Forms.DataGridView queryResult_dataGridView;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem close_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settings_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem about_ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem settingsFolder_ToolStripMenuItem;
        private System.Windows.Forms.GroupBox radioButtons_groupBox;
        private System.Windows.Forms.RadioButton query_radioButton;
        private System.Windows.Forms.RadioButton wi_radioButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_dataGridViewColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn wiType_dataGridViewColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn title_dataGridViewColumn;
        private System.Windows.Forms.DataGridViewButtonColumn migrate_dataGridViewColumn;
        private System.Windows.Forms.LinkLabel queryResultRefresh_linkLabel;
    }
}

