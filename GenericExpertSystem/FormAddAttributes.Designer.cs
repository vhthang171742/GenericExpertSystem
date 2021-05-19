
namespace DataMining
{
    partial class FormAddAttributes
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClearInput = new System.Windows.Forms.Button();
            this.btnAddAttribute = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNewAttribute = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvNewAttributeValues = new System.Windows.Forms.DataGridView();
            this.AttributeValues = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvNewAttributes = new System.Windows.Forms.DataGridView();
            this.AddedAttributes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFinishAdding = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewAttributeValues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewAttributes)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnFinishAdding, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtNewAttribute);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnAddAttribute);
            this.panel1.Controls.Add(this.btnClearInput);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 39);
            this.panel1.TabIndex = 0;
            // 
            // btnClearInput
            // 
            this.btnClearInput.Location = new System.Drawing.Point(672, 3);
            this.btnClearInput.Name = "btnClearInput";
            this.btnClearInput.Size = new System.Drawing.Size(113, 33);
            this.btnClearInput.TabIndex = 0;
            this.btnClearInput.Text = "Clear";
            this.btnClearInput.UseVisualStyleBackColor = true;
            this.btnClearInput.Click += new System.EventHandler(this.btnClearInput_Click);
            // 
            // btnAddAttribute
            // 
            this.btnAddAttribute.Location = new System.Drawing.Point(546, 3);
            this.btnAddAttribute.Name = "btnAddAttribute";
            this.btnAddAttribute.Size = new System.Drawing.Size(113, 33);
            this.btnAddAttribute.TabIndex = 1;
            this.btnAddAttribute.Text = "Add";
            this.btnAddAttribute.UseVisualStyleBackColor = true;
            this.btnAddAttribute.Click += new System.EventHandler(this.btnAddAttribute_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 48);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(794, 354);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // txtNewAttribute
            // 
            this.txtNewAttribute.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewAttribute.Location = new System.Drawing.Point(41, 9);
            this.txtNewAttribute.Name = "txtNewAttribute";
            this.txtNewAttribute.Size = new System.Drawing.Size(499, 22);
            this.txtNewAttribute.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvNewAttributeValues);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(391, 348);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Attribute values";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvNewAttributes);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(400, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(391, 348);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Added attributes";
            // 
            // dgvNewAttributeValues
            // 
            this.dgvNewAttributeValues.AllowUserToOrderColumns = true;
            this.dgvNewAttributeValues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNewAttributeValues.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AttributeValues});
            this.dgvNewAttributeValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNewAttributeValues.Location = new System.Drawing.Point(3, 16);
            this.dgvNewAttributeValues.Name = "dgvNewAttributeValues";
            this.dgvNewAttributeValues.Size = new System.Drawing.Size(385, 329);
            this.dgvNewAttributeValues.TabIndex = 1;
            // 
            // AttributeValues
            // 
            this.AttributeValues.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AttributeValues.HeaderText = "Attribute values";
            this.AttributeValues.Name = "AttributeValues";
            // 
            // dgvNewAttributes
            // 
            this.dgvNewAttributes.AllowUserToAddRows = false;
            this.dgvNewAttributes.AllowUserToDeleteRows = false;
            this.dgvNewAttributes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNewAttributes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AddedAttributes});
            this.dgvNewAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNewAttributes.Location = new System.Drawing.Point(3, 16);
            this.dgvNewAttributes.Name = "dgvNewAttributes";
            this.dgvNewAttributes.ReadOnly = true;
            this.dgvNewAttributes.Size = new System.Drawing.Size(385, 329);
            this.dgvNewAttributes.TabIndex = 0;
            // 
            // AddedAttributes
            // 
            this.AddedAttributes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AddedAttributes.HeaderText = "Attribute name";
            this.AddedAttributes.Name = "AddedAttributes";
            this.AddedAttributes.ReadOnly = true;
            // 
            // btnFinishAdding
            // 
            this.btnFinishAdding.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFinishAdding.Location = new System.Drawing.Point(3, 408);
            this.btnFinishAdding.Name = "btnFinishAdding";
            this.btnFinishAdding.Size = new System.Drawing.Size(794, 39);
            this.btnFinishAdding.TabIndex = 2;
            this.btnFinishAdding.Text = "Done";
            this.btnFinishAdding.UseVisualStyleBackColor = true;
            this.btnFinishAdding.Click += new System.EventHandler(this.btnFinishAdding_Click);
            // 
            // FormAddAttributes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormAddAttributes";
            this.Text = "Add new attributes";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewAttributeValues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewAttributes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAddAttribute;
        private System.Windows.Forms.Button btnClearInput;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox txtNewAttribute;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvNewAttributeValues;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttributeValues;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvNewAttributes;
        private System.Windows.Forms.DataGridViewTextBoxColumn AddedAttributes;
        private System.Windows.Forms.Button btnFinishAdding;
    }
}