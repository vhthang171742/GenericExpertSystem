﻿namespace DataMining
{
    partial class FrmMain
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPagePreprocess = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblInstancesCount = new System.Windows.Forms.Label();
            this.lblSumOfWeight = new System.Windows.Forms.Label();
            this.lblAttributesCount = new System.Windows.Forms.Label();
            this.lblRelationName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnDeselectAll = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnRemove = new System.Windows.Forms.Button();
            this.dgvAttributes = new System.Windows.Forms.DataGridView();
            this.Class = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblSUnique = new System.Windows.Forms.Label();
            this.lblSType = new System.Windows.Forms.Label();
            this.lblSMissingRate = new System.Windows.Forms.Label();
            this.lblSAttributeName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvSAttributes = new System.Windows.Forms.DataGridView();
            this.selectedLabel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selectedCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selectedWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbxAttributes = new System.Windows.Forms.ComboBox();
            this.chtAttribute = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tabMain.SuspendLayout();
            this.tabPagePreprocess.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttributes)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSAttributes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtAttribute)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPagePreprocess);
            this.tabMain.Controls.Add(this.tabPage2);
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Controls.Add(this.tabPage3);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1336, 850);
            this.tabMain.TabIndex = 0;
            // 
            // tabPagePreprocess
            // 
            this.tabPagePreprocess.Controls.Add(this.tableLayoutPanel1);
            this.tabPagePreprocess.Location = new System.Drawing.Point(4, 25);
            this.tabPagePreprocess.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPagePreprocess.Name = "tabPagePreprocess";
            this.tabPagePreprocess.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPagePreprocess.Size = new System.Drawing.Size(1328, 821);
            this.tabPagePreprocess.TabIndex = 0;
            this.tabPagePreprocess.Text = "Preprocess";
            this.tabPagePreprocess.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1320, 813);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 53);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1312, 756);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(648, 748);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(640, 66);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current relation";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblInstancesCount);
            this.panel2.Controls.Add(this.lblSumOfWeight);
            this.panel2.Controls.Add(this.lblAttributesCount);
            this.panel2.Controls.Add(this.lblRelationName);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 19);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(632, 43);
            this.panel2.TabIndex = 1;
            // 
            // lblInstancesCount
            // 
            this.lblInstancesCount.AutoSize = true;
            this.lblInstancesCount.Location = new System.Drawing.Point(105, 23);
            this.lblInstancesCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInstancesCount.Name = "lblInstancesCount";
            this.lblInstancesCount.Size = new System.Drawing.Size(13, 17);
            this.lblInstancesCount.TabIndex = 1;
            this.lblInstancesCount.Text = "-";
            // 
            // lblSumOfWeight
            // 
            this.lblSumOfWeight.AutoSize = true;
            this.lblSumOfWeight.Location = new System.Drawing.Point(501, 23);
            this.lblSumOfWeight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSumOfWeight.Name = "lblSumOfWeight";
            this.lblSumOfWeight.Size = new System.Drawing.Size(13, 17);
            this.lblSumOfWeight.TabIndex = 1;
            this.lblSumOfWeight.Text = "-";
            // 
            // lblAttributesCount
            // 
            this.lblAttributesCount.AutoSize = true;
            this.lblAttributesCount.Location = new System.Drawing.Point(501, 4);
            this.lblAttributesCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAttributesCount.Name = "lblAttributesCount";
            this.lblAttributesCount.Size = new System.Drawing.Size(13, 17);
            this.lblAttributesCount.TabIndex = 1;
            this.lblAttributesCount.Text = "-";
            // 
            // lblRelationName
            // 
            this.lblRelationName.AutoSize = true;
            this.lblRelationName.Location = new System.Drawing.Point(105, 4);
            this.lblRelationName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRelationName.Name = "lblRelationName";
            this.lblRelationName.Size = new System.Drawing.Size(13, 17);
            this.lblRelationName.TabIndex = 1;
            this.lblRelationName.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Instances:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(399, 23);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Sum of weights:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(436, 4);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Attributes:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Relation:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(4, 78);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(640, 666);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Attributes";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.panel4, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.dgvAttributes, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(4, 19);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(632, 643);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnDeselectAll);
            this.panel3.Controls.Add(this.btnSelectAll);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(4, 4);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(624, 41);
            this.panel3.TabIndex = 0;
            // 
            // btnDeselectAll
            // 
            this.btnDeselectAll.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDeselectAll.Location = new System.Drawing.Point(376, 5);
            this.btnDeselectAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDeselectAll.Name = "btnDeselectAll";
            this.btnDeselectAll.Size = new System.Drawing.Size(173, 28);
            this.btnDeselectAll.TabIndex = 0;
            this.btnDeselectAll.Text = "None";
            this.btnDeselectAll.UseVisualStyleBackColor = true;
            this.btnDeselectAll.Click += new System.EventHandler(this.btnDeselectAll_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSelectAll.Location = new System.Drawing.Point(24, 5);
            this.btnSelectAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(173, 28);
            this.btnSelectAll.TabIndex = 0;
            this.btnSelectAll.Text = "All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnRemove);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(4, 598);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(624, 41);
            this.panel4.TabIndex = 1;
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Location = new System.Drawing.Point(5, 4);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(614, 33);
            this.btnRemove.TabIndex = 0;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // dgvAttributes
            // 
            this.dgvAttributes.AllowUserToAddRows = false;
            this.dgvAttributes.AllowUserToDeleteRows = false;
            this.dgvAttributes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttributes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Class,
            this.Select,
            this.status,
            this.name});
            this.dgvAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAttributes.Location = new System.Drawing.Point(4, 53);
            this.dgvAttributes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvAttributes.MultiSelect = false;
            this.dgvAttributes.Name = "dgvAttributes";
            this.dgvAttributes.RowHeadersWidth = 51;
            this.dgvAttributes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAttributes.Size = new System.Drawing.Size(624, 537);
            this.dgvAttributes.TabIndex = 2;
            this.dgvAttributes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAttributes_CellClick);
            this.dgvAttributes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAttributes_CellContentClick);
            this.dgvAttributes.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvAttributes_DataBindingComplete);
            // 
            // Class
            // 
            this.Class.HeaderText = "Class";
            this.Class.MinimumWidth = 6;
            this.Class.Name = "Class";
            this.Class.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Class.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Class.Width = 40;
            // 
            // Select
            // 
            this.Select.HeaderText = "Affect";
            this.Select.MinimumWidth = 6;
            this.Select.Name = "Select";
            this.Select.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Select.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Select.Width = 45;
            // 
            // status
            // 
            this.status.DataPropertyName = "Enabled";
            this.status.HeaderText = "Enable";
            this.status.MinimumWidth = 6;
            this.status.Name = "status";
            this.status.Width = 50;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.DataPropertyName = "Name";
            this.name.HeaderText = "Name";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel5);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(660, 4);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(648, 748);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Selected attribute";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.panel5, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.dgvSAttributes, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.cbxAttributes, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.chtAttribute, 0, 3);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(4, 19);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 4;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(640, 725);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblSUnique);
            this.panel5.Controls.Add(this.lblSType);
            this.panel5.Controls.Add(this.lblSMissingRate);
            this.panel5.Controls.Add(this.lblSAttributeName);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(4, 4);
            this.panel5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(632, 41);
            this.panel5.TabIndex = 2;
            // 
            // lblSUnique
            // 
            this.lblSUnique.AutoSize = true;
            this.lblSUnique.Location = new System.Drawing.Point(475, 23);
            this.lblSUnique.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSUnique.Name = "lblSUnique";
            this.lblSUnique.Size = new System.Drawing.Size(13, 17);
            this.lblSUnique.TabIndex = 1;
            this.lblSUnique.Text = "-";
            // 
            // lblSType
            // 
            this.lblSType.AutoSize = true;
            this.lblSType.Location = new System.Drawing.Point(475, 4);
            this.lblSType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSType.Name = "lblSType";
            this.lblSType.Size = new System.Drawing.Size(13, 17);
            this.lblSType.TabIndex = 1;
            this.lblSType.Text = "-";
            // 
            // lblSMissingRate
            // 
            this.lblSMissingRate.AutoSize = true;
            this.lblSMissingRate.Location = new System.Drawing.Point(91, 23);
            this.lblSMissingRate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSMissingRate.Name = "lblSMissingRate";
            this.lblSMissingRate.Size = new System.Drawing.Size(13, 17);
            this.lblSMissingRate.TabIndex = 1;
            this.lblSMissingRate.Text = "-";
            // 
            // lblSAttributeName
            // 
            this.lblSAttributeName.AutoSize = true;
            this.lblSAttributeName.Location = new System.Drawing.Point(91, 4);
            this.lblSAttributeName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSAttributeName.Name = "lblSAttributeName";
            this.lblSAttributeName.Size = new System.Drawing.Size(13, 17);
            this.lblSAttributeName.TabIndex = 1;
            this.lblSAttributeName.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 23);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Missing:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(423, 23);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Unique:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(436, 4);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Type:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(47, 4);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "Name:";
            // 
            // dgvSAttributes
            // 
            this.dgvSAttributes.AllowUserToAddRows = false;
            this.dgvSAttributes.AllowUserToDeleteRows = false;
            this.dgvSAttributes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSAttributes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selectedLabel,
            this.selectedCount,
            this.selectedWeight});
            this.dgvSAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSAttributes.Location = new System.Drawing.Point(4, 53);
            this.dgvSAttributes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvSAttributes.Name = "dgvSAttributes";
            this.dgvSAttributes.ReadOnly = true;
            this.dgvSAttributes.RowHeadersWidth = 51;
            this.dgvSAttributes.Size = new System.Drawing.Size(632, 314);
            this.dgvSAttributes.TabIndex = 3;
            // 
            // selectedLabel
            // 
            this.selectedLabel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.selectedLabel.DataPropertyName = "Label";
            this.selectedLabel.HeaderText = "Label";
            this.selectedLabel.MinimumWidth = 6;
            this.selectedLabel.Name = "selectedLabel";
            this.selectedLabel.ReadOnly = true;
            // 
            // selectedCount
            // 
            this.selectedCount.DataPropertyName = "Count";
            this.selectedCount.HeaderText = "Count";
            this.selectedCount.MinimumWidth = 6;
            this.selectedCount.Name = "selectedCount";
            this.selectedCount.ReadOnly = true;
            this.selectedCount.Width = 125;
            // 
            // selectedWeight
            // 
            this.selectedWeight.DataPropertyName = "Count";
            this.selectedWeight.HeaderText = "Weight";
            this.selectedWeight.MinimumWidth = 6;
            this.selectedWeight.Name = "selectedWeight";
            this.selectedWeight.ReadOnly = true;
            this.selectedWeight.Width = 125;
            // 
            // cbxAttributes
            // 
            this.cbxAttributes.FormattingEnabled = true;
            this.cbxAttributes.Location = new System.Drawing.Point(4, 375);
            this.cbxAttributes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxAttributes.Name = "cbxAttributes";
            this.cbxAttributes.Size = new System.Drawing.Size(629, 24);
            this.cbxAttributes.TabIndex = 4;
            this.cbxAttributes.SelectedIndexChanged += new System.EventHandler(this.cbxAttributes_SelectedIndexChanged);
            // 
            // chtAttribute
            // 
            this.chtAttribute.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chtAttribute.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chtAttribute.Legends.Add(legend1);
            this.chtAttribute.Location = new System.Drawing.Point(4, 406);
            this.chtAttribute.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chtAttribute.Name = "chtAttribute";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chtAttribute.Series.Add(series1);
            this.chtAttribute.Size = new System.Drawing.Size(632, 315);
            this.chtAttribute.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnGenerate);
            this.panel1.Controls.Add(this.btnOpenFile);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1312, 41);
            this.panel1.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSave.Location = new System.Drawing.Point(1095, 6);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(173, 28);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnEdit.Location = new System.Drawing.Point(744, 6);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(173, 28);
            this.btnEdit.TabIndex = 0;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnGenerate.Location = new System.Drawing.Point(391, 6);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(173, 28);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnOpenFile.Location = new System.Drawing.Point(40, 6);
            this.btnOpenFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(173, 28);
            this.btnOpenFile.TabIndex = 0;
            this.btnOpenFile.Text = "Open file...";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Size = new System.Drawing.Size(1328, 821);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Generate ruleset";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(1328, 821);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Optimize ruleset";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel6);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage3.Size = new System.Drawing.Size(1328, 821);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Inference";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Location = new System.Drawing.Point(775, 175);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(200, 100);
            this.panel6.TabIndex = 0;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1336, 850);
            this.Controls.Add(this.tabMain);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmMain";
            this.Text = "Generic Expert System";
            this.tabMain.ResumeLayout(false);
            this.tabPagePreprocess.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttributes)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSAttributes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtAttribute)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPagePreprocess;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnDeselectAll;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.DataGridView dgvAttributes;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvSAttributes;
        private System.Windows.Forms.ComboBox cbxAttributes;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtAttribute;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label lblInstancesCount;
        private System.Windows.Forms.Label lblSumOfWeight;
        private System.Windows.Forms.Label lblAttributesCount;
        private System.Windows.Forms.Label lblRelationName;
        private System.Windows.Forms.Label lblSUnique;
        private System.Windows.Forms.Label lblSType;
        private System.Windows.Forms.Label lblSMissingRate;
        private System.Windows.Forms.Label lblSAttributeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn selectedLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn selectedCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn selectedWeight;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Class;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewCheckBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.Panel panel6;
    }
}

