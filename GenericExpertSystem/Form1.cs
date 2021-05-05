using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DataMining
{
    public partial class FrmMain : Form
    {
        #region Declare
        public List<Attribute> attributes;
        public List<List<String>> dataset;
        public List<List<AttributeValue>> attributeValues;
        public BindingSource dgvAttributesSource;
        public BindingSource dgvSAttributesSource;
        public BindingSource cbxAttributesSource;
        string relationName;
        #endregion

        #region Constructor
        /// <summary>
        /// Initialize properties
        /// </summary>
        /// Created by VHTHANG{02/05/2021}
        public FrmMain()
        {
            InitializeComponent();
            dgvAttributes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSAttributes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAttributes.AutoGenerateColumns = false;
            dgvSAttributes.AutoGenerateColumns = false;
            dataset = new List<List<string>>();
            attributes = new List<Attribute>();
            attributeValues = new List<List<AttributeValue>>();
            dgvAttributesSource = new BindingSource();
            dgvAttributesSource.DataSource = attributes;
            dgvAttributes.DataSource = dgvAttributesSource;

            cbxAttributesSource = new BindingSource();
            cbxAttributesSource.DataSource = attributes;
            cbxAttributes.DataSource = cbxAttributesSource;
            cbxAttributes.DisplayMember = "Name";
            cbxAttributes.ValueMember = "Name";
            cbxAttributes.Text = "- -Choose an attribute to visualize- -";

            dgvSAttributesSource = new BindingSource();

            //Disable buttons by default
            btnEdit.Enabled = false;
            btnSave.Enabled = false;
            btnSelectAll.Enabled = false;
            btnDeselectAll.Enabled = false;
            btnRemove.Enabled = false;

            cbxAttributes.Enabled = false;
        }
        #endregion

        #region Method
        /// <summary>
        /// Open file dialog to select source data file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Created by VHTHANG{02/05/2021}
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog()
            {
                FileName = "Select a csv file",
                Filter = "Text files (*.csv)|*.csv",
                Title = "Open csv file"
            };

            if (o.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //Enable file actions
                    btnEdit.Enabled = true;
                    btnSave.Enabled = true;
                    btnSelectAll.Enabled = true;
                    btnDeselectAll.Enabled = true;
                    btnRemove.Enabled = true;
                    cbxAttributes.Enabled = true;
                    dgvSAttributes.Rows.Clear();
                    chtAttribute.Series.Clear();

                    var filePath = o.FileName;
                    relationName = Path.GetFileNameWithoutExtension(filePath);
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        attributes.Clear();
                        dataset.Clear();
                        attributeValues.Clear();

                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        foreach (String s in values)
                        {
                            Attribute attr = new Attribute();
                            attr.Enabled = true;
                            attr.Name = s;
                            attributes.Add(attr);
                        }

                        while (!reader.EndOfStream)
                        {
                            line = reader.ReadLine();
                            values = line.Split(',');
                            dataset.Add(values.ToList());
                        }

                        for (int i = 0; i < attributes.Count; i++)
                        {
                            var avs = (from x in dataset select x[i]).Distinct().ToList();
                            List<AttributeValue> avl = new List<AttributeValue>();
                            foreach (String s in avs)
                            {
                                AttributeValue av = new AttributeValue();
                                av.Statistic.Add(s, (from x in dataset select x[i]).Count(x => x == s));
                                av.Label = s;
                                avl.Add(av);
                            }
                            attributeValues.Add(avl);
                        }
                    }
                    UpdateAttributes();
                    dgvAttributes.CurrentRow.Selected = false;
                    cbxAttributes.SelectedIndex = -1;
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        /// <summary>
        /// Update attributes list
        /// </summary>
        /// Created by VHTHANG{02/05/2021}
        private void UpdateAttributes()
        {
            foreach (DataGridViewRow row in dgvAttributes.Rows)
            {
                row.HeaderCell.Value = row.Index + 1;
            }
            dgvAttributesSource.ResetBindings(false);
            cbxAttributesSource.ResetBindings(false);

            lblAttributesCount.Text = attributes.Count.ToString();
            lblInstancesCount.Text = dataset.Count.ToString();
            lblRelationName.Text = relationName.ToString();
            lblSumOfWeight.Text = dataset.Count.ToString();
        }

        /// <summary>
        /// Select all attributes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Created by VHTHANG{02/05/2021}
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgr in dgvAttributes.Rows)
                dgr.Cells[1].Value = true;
        }

        /// <summary>
        /// Deselect all attributes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Created by VHTHANG{02/05/2021}
        private void btnDeselectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgr in dgvAttributes.Rows)
                dgr.Cells[1].Value = false;
        }

        /// <summary>
        /// Remove selected attributes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Created by VHTHANG{02/05/2021}
        private void btnRemove_Click(object sender, EventArgs e)
        {
            for (int i = attributes.Count - 1; i >= 0; i--)
                if (dgvAttributes.Rows[i].Cells[1].Value != null && (Boolean)dgvAttributes.Rows[i].Cells[1].Value == true)
                {
                    attributes.RemoveAt(i);
                    attributeValues.RemoveAt(i);
                }
            UpdateAttributes();
        }

        /// <summary>
        /// CellCLick events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Created by VHTHANG{03/05/2021}
        private void dgvAttributes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = dgvAttributes.Rows.IndexOf(dgvAttributes.SelectedRows[0]);
            lblSAttributeName.Text = attributes[rowIndex].Name;
            lblSMissingRate.Text = ((float)attributeValues[rowIndex].Count(x => x.Label == "") * 100 / dataset.Count).ToString() + "%";
            if (Double.TryParse(attributeValues[rowIndex][0].Label, out _))
                lblSType.Text = "Numeric";
            else
                lblSType.Text = "Nominal";

            int uniqueCount = 0;
            foreach (AttributeValue av in attributeValues[rowIndex])
                if (av.Statistic.Sum(x => x.Value) == 1)
                    uniqueCount++;
            lblSUnique.Text = uniqueCount.ToString();

            dgvSAttributesSource.DataSource = attributeValues[rowIndex];
            dgvSAttributes.DataSource = dgvSAttributesSource;
            dgvSAttributesSource.ResetBindings(false);
            foreach (DataGridViewRow row in dgvSAttributes.Rows)
            {
                row.HeaderCell.Value = row.Index + 1;
            }
            dgvSAttributes.CurrentRow.Selected = false;
        }

        /// <summary>
        /// Change button availablity based on datasource changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Created by  VHTHANG{03/05/2021}
        private void dgvAttributes_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvAttributes.Rows.Count == 0)
            {
                btnEdit.Enabled = false;
                btnSave.Enabled = false;
                btnSelectAll.Enabled = false;
                btnDeselectAll.Enabled = false;
                btnRemove.Enabled = false;
                cbxAttributes.Enabled = false;
            }
        }

        /// <summary>
        /// Visualize selected attribute in combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Created by  VHTHANG{03/05/2021}
        private void cbxAttributes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxAttributes.SelectedIndex == -1)
            {
                cbxAttributes.Text = "- -Choose an attribute to visualize- -";
                return;
            }
            chtAttribute.Titles.Clear();

            chtAttribute.Series.Clear();
            int classIndex = -1;
            foreach (Attribute a in attributes)
                if (a.IsClassAttribute == true)
                {
                    classIndex = attributes.IndexOf(a);
                    break;
                }
            if (classIndex == -1)
            {
                chtAttribute.Titles.Add("No class attribute");
                Series series1 = new Series(cbxAttributes.SelectedText);
                series1.ChartType = SeriesChartType.Column;
                series1.IsValueShownAsLabel = true;
                chtAttribute.Series.Add(series1);
                foreach (AttributeValue av in attributeValues[cbxAttributes.SelectedIndex])
                {
                    chtAttribute.Series[0].Points.AddXY(av.Label, av.Statistic[av.Label]);
                }
            }
            else if (classIndex == cbxAttributes.SelectedIndex)
            {
                chtAttribute.Titles.Add("Classify by " + attributes[classIndex].Name);
                Series series1 = new Series(cbxAttributes.SelectedText);
                series1.ChartType = SeriesChartType.Column;
                series1.IsValueShownAsLabel = true;
                chtAttribute.Series.Add(series1);
                foreach (AttributeValue av in attributeValues[cbxAttributes.SelectedIndex])
                {
                    chtAttribute.Series[0].Points.AddXY(av.Label, av.Statistic[av.Label]);
                }
            }
            else
            {
                chtAttribute.Titles.Add("Classify by "+attributes[classIndex].Name);
                foreach (AttributeValue av in attributeValues[classIndex])
                {
                    Series series1 = new Series(av.Label);
                    series1.ChartType = SeriesChartType.StackedColumn;
                    series1.IsValueShownAsLabel = true;
                    chtAttribute.Series.Add(series1);
                }
                foreach(AttributeValue av in attributeValues[cbxAttributes.SelectedIndex])
                {
                    foreach (AttributeValue av1 in attributeValues[classIndex]) {
                        chtAttribute.Series[av1.Label].Points.AddXY(av.Label, av.Statistic[av1.Label]);
                    }
                }
            }
            chtAttribute.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
        }

        /// <summary>
        /// Allow only one class attribute to be selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Created by  VHTHANG{03/05/2021}
        private void dgvAttributes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAttributes.Rows.Count == 0 || e.ColumnIndex != 0)
                return;
            else
            {
                chtAttribute.Titles.Clear();
                chtAttribute.Series.Clear();
                foreach (DataGridViewRow dgr in dgvAttributes.Rows)
                    if (dgvAttributes.Rows.IndexOf(dgr) != e.RowIndex)
                    {
                        dgr.Cells[0].Value = false;
                        attributes[dgr.Index].IsClassAttribute = false;
                    }
                    else
                    {
                        if (dgr.Cells[0].Value == null || (bool)dgr.Cells[0].Value == false)
                        {
                            dgr.Cells[0].Value = true;
                            attributes[dgr.Index].IsClassAttribute = true;
                            
                        }
                        else
                        {
                            dgr.Cells[0].Value = false;
                            attributes[dgr.Index].IsClassAttribute = false;
                        }
                    }
            }
            AnalyzeByClassAttribute();
        }

        /// <summary>
        /// Analyze all attributes by class attributes
        /// </summary>
        /// <param></param>
        /// Created by  VHTHANG{03/05/2021}
        private void AnalyzeByClassAttribute()
        {
            int classIndex = -1;
            foreach (Attribute a in attributes)
                if (a.IsClassAttribute == true)
                {
                    classIndex = attributes.IndexOf(a);
                    break;
                }
            if (classIndex != -1)
            {
                //Loop through each attributes
                for (int i = 0; i < attributes.Count; i++)
                {
                    //Except class attribute
                    if (i == classIndex)
                        continue;
                    //Loop through each value of attributes
                    for (int j = 0; j < attributeValues[i].Count; j++)
                    {
                        attributeValues[i][j].Statistic.Clear();
                        //Iterate through class attribute values
                        foreach (AttributeValue av in attributeValues[classIndex])
                        {
                            //Variable for class attribute counting
                            int count = 0;
                            for (int k = 0; k < dataset.Count; k++)
                                if (av.Label == dataset[k][classIndex] && dataset[k][i] == attributeValues[i][j].Label)
                                    count++;
                            attributeValues[i][j].Statistic.Add(av.Label, count);
                        }
                    }
                }
            }
            else
            {
                attributeValues.Clear();
                for (int i = 0; i < attributes.Count; i++)
                {
                    var avs = (from x in dataset select x[i]).Distinct().ToList();
                    List<AttributeValue> avl = new List<AttributeValue>();
                    foreach (String s in avs)
                    {
                        AttributeValue av = new AttributeValue();
                        av.Statistic.Add(s, (from x in dataset select x[i]).Count(x => x == s));
                        av.Label = s;
                        avl.Add(av);
                    }
                    attributeValues.Add(avl);
                }
            }
        }
        #endregion
    }

    /// <summary>
    /// Attribute class
    /// </summary>
    /// Created by VHTHANG{02/05/2021}
    public class Attribute
    {
        #region Declare
        public bool Enabled { get; set; }
        public String Name { get; set; }
        public bool IsClassAttribute { get; set; }
        #endregion
    }

    public class AttributeValue
    {
        #region Declare
        public string Label { get; set; }
        public Dictionary<string, int> Statistic { get; set; }
        #endregion

        #region Constructor
        public AttributeValue()
        {
            Statistic = new Dictionary<string, int>();
        }
        #endregion
    }
}
