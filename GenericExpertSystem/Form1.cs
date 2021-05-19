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
        #region VHTHANG
        #region Declare
        public List<Attribute> attributes;
        private List<List<String>> dataset;
        private List<List<AttributeValue>> attributeValues;
        private List<TRule> ruleset;
        private BindingSource dgvAttributesSource;
        private BindingSource dgvSAttributesSource;
        private BindingSource cbxAttributesSource;
        private BindingSource dgvRulesSource;
        private BindingSource dgvEventsSource;
        string relationName;

        private List<AttributeValue> assumptions = new List<AttributeValue>();
        private AttributeValue conclusion;

        TRule newRule = new TRule();
        List<AttributeValue> eventList = new List<AttributeValue>();
        int selectedRow;
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
            dgvAttributes1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRawRuleset.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOptimizedRuleset.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEvents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRules1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRules.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvAttributes.AutoGenerateColumns = false;
            dgvSAttributes.AutoGenerateColumns = false;
            dgvRules.AutoGenerateColumns = false;
            dgvEvents.AutoGenerateColumns = false;
            dgvAttributes1.AutoGenerateColumns = false;
            dgvRawRuleset.AutoGenerateColumns = false;
            dgvOptimizedRuleset.AutoGenerateColumns = false;
            dgvRules1.AutoGenerateColumns = false;

            dataset = new List<List<string>>();
            attributes = new List<Attribute>();
            attributeValues = new List<List<AttributeValue>>();
            ruleset = new List<TRule>();

            dgvAttributesSource = new BindingSource();
            dgvAttributesSource.DataSource = attributes;
            dgvAttributes.DataSource = dgvAttributesSource;

            cbxAttributesSource = new BindingSource();
            cbxAttributesSource.DataSource = attributes;
            cbxAttributes.DataSource = cbxAttributesSource;
            cbxAttributes1.DataSource = cbxAttributesSource;

            cbxAttributes.DisplayMember = "Name";
            cbxAttributes.ValueMember = "Name";
            cbxAttributes.SelectedIndex = -1;
            cbxAttributes.Text = "- -Choose an attribute to visualize- -";

            cbxAttributes1.DisplayMember = "Name";
            cbxAttributes1.ValueMember = "Name";
            cbxAttributes1.SelectedIndex = -1;
            cbxAttributes.Text = "- -Choose an attribute- -";

            dgvRulesSource = new BindingSource();
            dgvRulesSource.DataSource = ruleset;
            dgvRules.DataSource = dgvRulesSource;
            dgvRules1.DataSource = dgvRulesSource;

            dgvRulesSource = new BindingSource();
            dgvRulesSource.DataSource = ruleset;
            dgvRules.DataSource = dgvRulesSource;

            dgvEventsSource = new BindingSource();
            dgvEventsSource.DataSource = eventList;
            dgvEvents.DataSource = dgvEventsSource;

            //Disable buttons by default
            btnSelectAll.Enabled = false;
            btnDeselectAll.Enabled = false;
            btnRemove.Enabled = false;

            cbxAttributes.Enabled = false;
        }
        #endregion

        #region Method
        public void AddNewAttribute(List<Attribute> la, List<List<AttributeValue>> lav)
        {
            attributes.AddRange(la);
            attributeValues.AddRange(lav);
           
            MessageBox.Show("Added " + la.Count.ToString() +" attributes");
            dgvAttributesSource.ResetBindings(false);
            foreach (DataGridViewRow row in dgvAttributes.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
            cbxAttributesSource.ResetBindings(false);
            cbxAttributes.Enabled = false;
        }
        #region Preprocess
        /// <summary>
        /// Open file dialog to select source data file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Created by VHTHANG{02/05/2021}
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            if(!rdoLabeled.Checked&&!rdoUnlabeled.Checked)
            {
                MessageBox.Show("Please choose input data structure");
                return;
            }
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
                    btnSelectAll.Enabled = true;
                    btnDeselectAll.Enabled = true;
                    btnRemove.Enabled = true;
                    cbxAttributes.Enabled = true;

                    dgvSAttributes.Rows.Clear();
                    chtAttribute.Series.Clear();
                    dgvRawRuleset.Rows.Clear();
                    dgvOptimizedRuleset.Rows.Clear();

                    ruleset.Clear();
                    dataset.Clear();
                    attributes.Clear();
                    attributeValues.Clear();

                    var filePath = o.FileName;
                    relationName = Path.GetFileNameWithoutExtension(filePath);
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        attributes.Clear();
                        dataset.Clear();
                        attributeValues.Clear();

                        if (rdoLabeled.Checked)
                        {
                            var line = reader.ReadLine();
                            var values = line.Split(',').ToList();
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
                                values = line.Split(',').ToList();
                                for (int i = 0; i < values.Count; i++)
                                    if (values[i] == "")
                                        values[i] = "?";
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
                                    av.Count = (from x in dataset select x[i]).Count(x => x == s);
                                    av.Label = s;
                                    av.Attribute = attributes[i].Name;
                                    avl.Add(av);
                                }
                                attributeValues.Add(avl);
                            }

                            for (int i = 0; i < dataset.Count; i++)
                            {
                                TRule tr = new TRule();
                                for (int j = 0; j < values.Count; j++)
                                {
                                    if (dataset[i][j] != "?")
                                    {
                                        AttributeValue av = new AttributeValue();
                                        av.Attribute = attributes[j].Name;
                                        av.Label = dataset[i][j];
                                        tr.Rule.Add(av);
                                    }
                                }
                                ruleset.Add(tr);
                            }
                        }
                        else
                        {
                            while (!reader.EndOfStream)
                            {
                                var line = reader.ReadLine();
                                var values = line.Split(',').ToList();
                                values.RemoveAll(x => x == "");
                                dataset.Add(values.ToList());
                            }
                            attributes.Add(new Attribute("Unknown", true));

                            attributeValues.Add(new List<AttributeValue>());

                            List<String> tempList = new List<string>();
                            foreach (List<String> row in dataset)
                                tempList.AddRange(row);

                            foreach (String s in tempList)
                            {
                                AttributeValue av = new AttributeValue();
                                av.Attribute = "Unknown";
                                av.Label = s;
                                av.Count = tempList.Count(x => x == s);
                                av.Statistic.Add(s, av.Count);
                                if (!attributeValues[0].Contains(av))
                                    attributeValues[0].Add(av);
                            }

                            for (int i = 0; i < dataset.Count; i++)
                            {
                                TRule tr = new TRule();
                                for (int j = 0; j < dataset[i].Count; j++)
                                {
                                    AttributeValue av = new AttributeValue();
                                    av.Attribute = "Unknown";
                                    av.Label = dataset[i][j];
                                    tr.Rule.Add(av);
                                }
                                ruleset.Add(tr);
                            }
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
            dgvAttributesSource.ResetBindings(false);
            cbxAttributesSource.ResetBindings(false);
            foreach (DataGridViewRow row in dgvAttributes.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }

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
        /// Add new attributes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Created by VHTHANG{19/05/2021}
        private void btnAddAttribute_Click(object sender, EventArgs e)
        {
            FormAddAttributes frmAdd = new FormAddAttributes(this);
            frmAdd.Show();
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
            lblSMissingRate.Text = ((float)attributeValues[rowIndex].Count(x => x.Label == "?") * 100 / dataset.Count).ToString() + "%";
            if (Double.TryParse(attributeValues[rowIndex][0].Label, out _))
                lblSType.Text = "Numeric";
            else
                lblSType.Text = "Nominal";

            int uniqueCount = 0;
            foreach (AttributeValue av in attributeValues[rowIndex])
                if (av.Statistic.Sum(x => x.Value) == 1)
                    uniqueCount++;
            lblSUnique.Text = uniqueCount.ToString();

            List<AttributeValue> sAttributeValues  = attributeValues[rowIndex];
            dgvSAttributesSource = new BindingSource();
            dgvSAttributesSource.DataSource = sAttributeValues;
            dgvSAttributes.DataSource = dgvSAttributesSource;
            dgvSAttributesSource.ResetBindings(false);
            foreach (DataGridViewRow row in dgvSAttributes.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
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
                chtAttribute.Titles.Add("Classify by " + attributes[classIndex].Name);
                foreach (AttributeValue av in attributeValues[classIndex])
                {
                    Series series1 = new Series(av.Label);
                    series1.ChartType = SeriesChartType.StackedColumn;
                    series1.IsValueShownAsLabel = true;
                    chtAttribute.Series.Add(series1);
                }
                foreach (AttributeValue av in attributeValues[cbxAttributes.SelectedIndex])
                {
                    foreach (AttributeValue av1 in attributeValues[classIndex])
                    {
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

        #region OptimizeRule
        /// <summary>
        /// Determine whether a rule is unnecessary in ruleset and remove it
        /// </summary>
        /// <param name="ruleSet">Ruleset</param>
        /// <param name="i">Index of rule in ruleset</param>
        /// <returns>True if rule is unnecessary</returns>
        /// Created by VHTHANG{11/05/2021}
        public bool RemoveUnnecessaryRule(ref List<TRule> ruleSet, int i)
        {
            HashSet<String> complement = new HashSet<String>();
            Queue<TRule> SAT = new Queue<TRule>();
            for (int j = 0; j < ruleSet[i].Rule.Count - 1; j++)
                complement.Add(ruleSet[i].Rule[j].Label);
            for (int k = 0; k < ruleSet.Count; k++)
            {
                if (k == i)
                    continue;
                if ((from x in ruleSet[k].Rule select x.Label).ToList().GetRange(0, ruleSet[k].Rule.Count - 1).Intersect(complement).Count() == ruleSet[k].Rule.Count() - 1)
                    SAT.Enqueue(ruleSet[k]);
            }
            List<int> served = new List<int>();
            while (SAT.Count != 0)
            {
                TRule s = SAT.Dequeue();
                served.Add(ruleSet.IndexOf(s));
                complement.Add(s.Rule.Last().Label);
                for (int k = 0; k < ruleSet.Count; k++)
                {
                    if (k == i)
                        continue;
                    if (served.Contains(k))
                        continue;
                    if ((from x in ruleSet[k].Rule select x.Label).ToList().GetRange(0, ruleSet[k].Rule.Count - 1).Intersect(complement).Count() == ruleSet[k].Rule.Count() - 1)
                        if (!SAT.Contains(ruleSet[k]))
                            SAT.Enqueue(ruleSet[k]);
                }
            }
            if (complement.Contains(ruleSet[i].Rule.Last().Label))
            {
                ruleSet.RemoveAt(i);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Determine whether an event is unnecessary in rule and remove it
        /// </summary>
        /// <typeparam name="T">Type of event</typeparam>
        /// <param name="ruleSet">Ruleset</param>
        /// <param name="i">Index of rule in ruleset</param>
        /// <param name="j">Index of event in rule</param>
        /// <returns>True if event is unnecessary</returns>
        public bool RemoveUnnecessaryEvent(ref List<TRule> ruleSet, int i, int j)
        {
            List<TRule> tempRuleSet = new List<TRule>();
            foreach (TRule tr in ruleSet)
                tempRuleSet.Add(tr.DeepCopy());
            tempRuleSet[i].Rule.RemoveAt(j);

            HashSet<String> complement = new HashSet<String>();
            Queue<TRule> SAT = new Queue<TRule>();
            for (int k = 0; k < tempRuleSet[i].Rule.Count - 1; k++)
                complement.Add(tempRuleSet[i].Rule[k].Label);
            for (int l = 0; l < tempRuleSet.Count; l++)
            {
                if ((from x in tempRuleSet[l].Rule select x.Label).ToList().GetRange(0, tempRuleSet[l].Rule.Count - 1).Intersect(complement).Count() == tempRuleSet[l].Rule.Count() - 1)
                    SAT.Enqueue(tempRuleSet[l]);
            }
            List<int> served = new List<int>();
            while (SAT.Count != 0)
            {
                TRule s = SAT.Dequeue();
                served.Add(tempRuleSet.IndexOf(s));
                complement.Add(s.Rule.Last().Label);
                for (int m = 0; m < tempRuleSet.Count; m++)
                {
                    if (served.Contains(m))
                        continue;
                    if ((from x in tempRuleSet[m].Rule select x.Label).ToList().GetRange(0, tempRuleSet[m].Rule.Count - 1).Intersect(complement).Count() == tempRuleSet[m].Rule.Count() - 1)
                        if (!SAT.Contains(tempRuleSet[m]))
                            SAT.Enqueue(tempRuleSet[m]);
                }
            }
            if (complement.Contains(ruleSet[i].Rule[j].Label))
            {
                ruleSet = tempRuleSet;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Optimize ruleset
        /// </summary>
        /// <typeparam name="T">Type of events</typeparam>
        /// <param name="ruleSet">Ruleset</param>
        /// Created by VHTHANG{11/05/2021}
        public void OptimizeRuleSet(ref List<TRule> ruleSet)
        {
            List<bool> rFlag = new List<bool>();
            List<TRule> rawRuleset = new List<TRule>(ruleSet);
            List<TRule> eFlag = new List<TRule>();
            //Remove unnecessary rules
            for (int i = 0; i < ruleSet.Count; i++)
            {
                rFlag.Add(true);
                if (RemoveUnnecessaryRule(ref ruleSet, i))
                {
                    rFlag[rFlag.Count - 1] = false;
                    lsbProcess.Items.Add("Removed r" + rFlag.Count + ": " + rawRuleset[rFlag.Count - 1].RuleText);
                    i--;
                }
            }

            //Remove unnecessary events
            for (int i = 0; i < ruleSet.Count; i++)
            {
                if (ruleSet[i].Rule.Count == 2)
                    continue;
                for (int j = 0; j < ruleSet[i].Rule.Count - 1; j++)
                {
                    if (RemoveUnnecessaryEvent(ref ruleSet, i, j))
                    {
                        if (RemoveUnnecessaryRule(ref ruleSet, i))
                        {
                            int temp = -1;
                            for (int t = 0; t < ruleSet.Count; t++)
                            {
                                if (rFlag[t] == true)
                                {
                                    temp++;
                                }
                                if (temp == i)
                                {
                                    lsbProcess.Items.Add("Removed r" + (t + 1) + ": " + rawRuleset[t].RuleText);
                                    rFlag[t] = false;
                                    i--;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            int temp = -1;
                            for (int t = 0; t < ruleSet.Count; t++)
                            {
                                if (rFlag[t] == true)
                                {
                                    temp++;
                                }
                                if (temp == i)
                                {
                                    lsbProcess.Items.Add("Removed " + rawRuleset[t].Rule.Except(ruleSet[i].Rule).ToList().Last().Text + " from r" + (i + 1) + ": " + rawRuleset[t].RuleText + " => " + ruleset[i].RuleText);
                                    break;
                                }
                            }
                            j--;
                        }
                    }
                }
            }
        }

        private void btnOptimize_Click(object sender, EventArgs e)
        {
            OptimizeRuleSet(ref ruleset);
            dgvOptimizedRuleset.Rows.Clear();
            for (int i = 0; i < ruleset.Count; i++)
            {
                dgvOptimizedRuleset.Rows.Add();
                dgvOptimizedRuleset.Rows[i].HeaderCell.Value = "r" + (i + 1).ToString();
                dgvOptimizedRuleset.Rows[i].Cells[0].Value = ruleset[i].RuleText;
            }
        }

        #endregion
        #endregion
        #endregion

        #region VXTHANH

        private void cbxAttributes1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxAttributeValues.DataSource = attributeValues[cbxAttributes1.SelectedIndex];
            cbxAttributeValues.DisplayMember = "Label";
            cbxAttributeValues.SelectedIndex = -1;
            cbxAttributeValues.Text = "- -Choose an event- -";
        }

        private void btnAddAssumptions_Click(object sender, EventArgs e)
        {
            if (cbxAttributeValues.Items.Count == 0 || cbxAttributeValues.SelectedIndex == -1)
            {
                MessageBox.Show("Selected event not found!");
                return;
            }
            assumptions.Add(cbxAttributeValues.SelectedItem as AttributeValue);
            lsbAssumptions.Items.Add(assumptions.Last().Text);
        }

        private void btnAddConclusions_Click(object sender, EventArgs e)
        {
            if (cbxAttributeValues.Items.Count == 0 || cbxAttributeValues.SelectedIndex == -1)
            {
                MessageBox.Show("Selected event not found!");
                return;
            }
            conclusion = new AttributeValue();
            conclusion = cbxAttributeValues.SelectedItem as AttributeValue;
            txtConclusion.Text = conclusion.Text;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            assumptions.Clear();
            lsbAssumptions.Items.Clear();
            conclusion = new AttributeValue();
            txtConclusion.Clear();
            lsbInferenceProcess.Items.Clear();
            txtResult.Clear();
            txtTG.Clear();
            txtVET.Clear();
        }

        private void btnForwardInfer_Click(object sender, EventArgs e)
        {
            if (lsbAssumptions.Items.Count == 0 || txtConclusion.Text == "")
            {
                MessageBox.Show("Chọn GT và KL phù hợp");
                return;
            }

            InferEngine InferEngine = new InferEngine(ruleset, assumptions, conclusion);

            InferEngine.ForwardInfer(ruleset, conclusion);

            if (InferEngine.result)
            {
                string tg = "", vet = "";
                foreach (var item in InferEngine.TG)
                {
                    tg += item.Text + " , ";
                }
                foreach (var item in InferEngine.VET)
                {
                    vet += item.Name + " , ";
                }
                txtResult.Text = "GT ->  KL là TRUE được chứng minh";
                txtVET.Text = vet;
                txtTG.Text = tg;
            }
            else
            {
                txtResult.Text = "GT ->  KL là FALSE";
                txtVET.Text = "FALSE";
                txtTG.Text = "FALSE";
            }

        }
        #endregion

        #region PTTHE
        // <Generate ruleset>

        //Tạo danh sáchthuộc tính

        //Hiển thị lên các thuộc tính được chọn, cần ấn nút trước khi thực hiện các thao tác thêm, sửa
        private void btnHienThi_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ruleset.Add(newRule);
            dgvRulesSource.ResetBindings(false);
            foreach (DataGridViewRow dgr in dgvRules.Rows)
            {
                dgr.HeaderCell.Value = "r" + (dgr.Index + 1).ToString();
            }
            newRule = new TRule();
            txtLuat.Clear();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            ruleset[selectedRow] = newRule;
            MessageBox.Show("Sửa luật số " + (selectedRow + 1) + " thành công.");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            ruleset.RemoveAt(selectedRow);
            MessageBox.Show("Xóa luật số " + (selectedRow + 1) + " thành công.");
        }

        private void dgvLuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            btnThem.Enabled = false;
            btnSua.Enabled = false;

            if (selectedRow >= 0)
            {
                btnXoa.Enabled = true;

                txtLuat.Text = dgvRules.Rows[selectedRow].Cells[0].Value.ToString();

                TRule luat = ruleset[selectedRow];

                string tam;

                //duyệt dgvThuocTinh
                foreach (DataGridViewRow row in dgvEvents.Rows)
                {
                    if (row.Cells[2].Value != null)
                    {
                        row.Cells[0].Value = false;
                        row.Cells[1].Value = false;

                        tam = (string)row.Cells[2].Value;
                        if ((Boolean)tam.Equals(luat.Rule[luat.Rule.Count - 1]))
                        {
                            row.Cells[1].Value = true;
                        }

                        for (int i = 0; i < luat.Rule.Count - 1; i++)
                        {
                            if ((Boolean)tam.Equals(luat.Rule[i]))
                            {
                                row.Cells[0].Value = true;
                            }
                        }
                    }
                }
            }
            else
            {
                txtLuat.Text = "Dòng bạn chọn luật không đúng";
                btnXoa.Enabled = false;
            }
        }

        private void MacDinh()
        {
            txtLuat.Text = "";
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void dgvAttributes1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvEvents.Rows.Clear();
            eventList.AddRange(attributeValues[attributes.IndexOf(dgvAttributes1.SelectedRows[0].DataBoundItem as Attribute)]);
            dgvEventsSource.ResetBindings(false);
            foreach (AttributeValue av in eventList)
                dgvEvents.Rows[dgvEvents.Rows.Count - 1].HeaderCell.Value = dgvEvents.Rows.Count.ToString();
        }

        private void dgvThuocTinh_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            int i = (from x in newRule.Rule select x.Attribute).ToList().IndexOf((dgvEvents.SelectedRows[0].DataBoundItem as AttributeValue).Attribute);
            if (i != -1)
            {
                newRule.Rule.RemoveAt(i);
                newRule.Rule.Insert(i, dgvEvents.SelectedRows[0].DataBoundItem as AttributeValue);
                txtLuat.Text = newRule.RuleText;
            }
            else
            {
                var newEvent = dgvEvents.SelectedRows[0].DataBoundItem as AttributeValue;
                newRule.Rule.Add(newEvent);
                txtLuat.Text = newRule.RuleText;
            }
        }
        // </Generate ruleset>
        #endregion

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (TRule tr in ruleset)
            {
                tr.Name = "r" + (ruleset.IndexOf(tr) + 1).ToString();
            }

            dgvAttributes1.DataSource = attributes.Where(x => x.Enabled == true).ToList();
            foreach (DataGridViewRow dgr in dgvAttributes1.Rows)
            {
                dgr.HeaderCell.Value = (dgr.Index + 1).ToString();
            }

            dgvRulesSource.ResetBindings(false);
            foreach (DataGridViewRow dgr in dgvRules.Rows)
            {
                dgr.HeaderCell.Value = "r" + (dgr.Index + 1).ToString();
            }
            foreach (DataGridViewRow dgr in dgvRules1.Rows)
            {
                dgr.HeaderCell.Value = "r" + (dgr.Index + 1).ToString();
            }

            lsbProcess.Items.Clear();
            dgvOptimizedRuleset.Rows.Clear();

            dgvRawRuleset.Rows.Clear();
            foreach (TRule tr in ruleset)
            {
                dgvRawRuleset.Rows.Add();
                dgvRawRuleset.Rows[dgvRawRuleset.Rows.Count - 1].Cells[0].Value = tr.RuleText;
                dgvRawRuleset.Rows[dgvRawRuleset.Rows.Count - 1].HeaderCell.Value = "r" + dgvRawRuleset.Rows.Count.ToString();
            }
        }
    }
}
