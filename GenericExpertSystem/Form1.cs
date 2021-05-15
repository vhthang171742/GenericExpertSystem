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
        public List<List<String>> dataset;
        public List<List<AttributeValue>> attributeValues;
        public List<TRule> ruleset;
        public BindingSource dgvAttributesSource;
        public BindingSource dgvSAttributesSource;
        public BindingSource cbxAttributesSource;
        public BindingSource dgvLuatSource;
        public BindingSource dgvThuocTinhSource;
        public BindingSource dgvAttributes1Source;
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
            dgvAttributes1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvAttributes.AutoGenerateColumns = false;
            dgvSAttributes.AutoGenerateColumns = false;
            dgvLuat.AutoGenerateColumns = false;
            dgvThuocTinh.AutoGenerateColumns = false;
            dgvAttributes1.AutoGenerateColumns = false;

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

            cbxAttributes.DisplayMember = "Name";
            cbxAttributes.ValueMember = "Name";
            cbxAttributes.Text = "- -Choose an attribute to visualize- -";

            dgvLuatSource = new BindingSource();
            dgvLuatSource.DataSource = ruleset;
            dgvLuat.DataSource = dgvLuatSource;

            dgvThuocTinhSource = new BindingSource();
            dgvThuocTinhSource.DataSource = dsTT;
            dgvThuocTinh.DataSource = dgvThuocTinhSource;

            dgvAttributes1Source = new BindingSource();
            dgvAttributes1Source.DataSource = attributes;
            dgvAttributes1.DataSource = dgvAttributes1Source;

            dgvSAttributesSource = new BindingSource();

            //Disable buttons by default
            btnSelectAll.Enabled = false;
            btnDeselectAll.Enabled = false;
            btnRemove.Enabled = false;

            cbxAttributes.Enabled = false;
        }
        #endregion

        #region Method
        #region Preporcess
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
                                av.Count = (from x in dataset select x[i]).Count(x => x == s);
                                av.Label = s;
                                av.Attribute = attributes[i].Name;
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
                complement.Add(ruleSet[i].Rule[j]);
            for (int k = 0; k < ruleSet.Count; k++)
            {
                if (k == i)
                    continue;
                if (ruleSet[k].Rule.GetRange(0, ruleSet[k].Rule.Count - 1).Intersect(complement).Count() == ruleSet[k].Rule.Count() - 1)
                    SAT.Enqueue(ruleSet[k]);
            }
            List<int> served = new List<int>();
            while (SAT.Count != 0)
            {
                TRule s = SAT.Dequeue();
                served.Add(ruleSet.IndexOf(s));
                complement.Add(s.Rule.Last());
                for (int k = 0; k < ruleSet.Count; k++)
                {
                    if (k == i)
                        continue;
                    if (served.Contains(k))
                        continue;
                    if (ruleSet[k].Rule.GetRange(0, ruleSet[k].Rule.Count - 1).Intersect(complement).Count() == ruleSet[k].Rule.Count() - 1)
                        if (!SAT.Contains(ruleSet[k]))
                            SAT.Enqueue(ruleSet[k]);
                }
            }
            if (complement.Contains(ruleSet[i].Rule.Last()))
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
            ruleSet.ForEach((item) =>
            {
                tempRuleSet.Add(item);
            });
            tempRuleSet[i].Rule.RemoveAt(j);

            HashSet<String> complement = new HashSet<String>();
            Queue<TRule> SAT = new Queue<TRule>();
            for (int k = 0; k < tempRuleSet[i].Rule.Count - 1; k++)
                complement.Add(tempRuleSet[i].Rule[k]);
            for (int l = 0; l < tempRuleSet.Count; l++)
            {
                if (tempRuleSet[l].Rule.GetRange(0, tempRuleSet[l].Rule.Count - 1).Intersect(complement).Count() == tempRuleSet[l].Rule.Count() - 1)
                    SAT.Enqueue(tempRuleSet[l]);
            }
            List<int> served = new List<int>();
            while (SAT.Count != 0)
            {
                TRule s = SAT.Dequeue();
                served.Add(tempRuleSet.IndexOf(s));
                complement.Add(s.Rule.Last());
                for (int m = 0; m < tempRuleSet.Count; m++)
                {
                    if (served.Contains(m))
                        continue;
                    if (tempRuleSet[m].Rule.GetRange(0, tempRuleSet[m].Rule.Count - 1).Intersect(complement).Count() == tempRuleSet[m].Rule.Count() - 1)
                        if (!SAT.Contains(tempRuleSet[m]))
                            SAT.Enqueue(tempRuleSet[m]);
                }
            }
            if (complement.Contains(ruleSet[i].Rule[j]))
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
                    lsbProcess.Items.Add("Removed unnecessary rule r" + rFlag.Count + ": " + rawRuleset[rFlag.Count - 1].RuleText);
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
                                    lsbProcess.Items.Add("Removed unnecessary rule r" + (t + 1) + ": " + rawRuleset[t].RuleText);
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
                                    lsbProcess.Items.Add("Removed unnecessary event " + ruleSet[i].Rule[j] + " from r" + (i + 1) + ": " + rawRuleset[t].RuleText + " => " + ruleset[i].RuleText);
                                    break;
                                }
                            }
                            j--;
                        }
                    }
                }
            }
        }

        private void btnInsertRule_Click(object sender, EventArgs e)
        {
            try
            {
                String s = txtInsertRule.Text;
                var values = s.Split(' ').ToList();
                TRule newRule = new TRule(values);
                ruleset.Add(newRule);
                lsbRawRuleset.Items.Add(newRule.RuleText);
                txtInsertRule.Clear();
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOptimize_Click(object sender, EventArgs e)
        {
            OptimizeRuleSet(ref ruleset);
            for (int i = 0; i < ruleset.Count; i++)
                lsbOptimizedRuleset.Items.Add(ruleset[i].RuleText);
        }

        private void txtInsertRule_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnInsertRule_Click((object)sender, (EventArgs)e);
            }
        }
        #endregion
        #endregion
        #endregion

        #region VXTHANH
        static List<RuleItem> list = new List<RuleItem>();
        static int i = 1;
        private void btnKhoiTao_Click(object sender, EventArgs e)
        {

        }

        private void btnThemGT_Click(object sender, EventArgs e)
        {
            string text = lstTapSuKien.GetItemText(lstTapSuKien.SelectedItem);
            if (String.IsNullOrEmpty(text))
            {

                MessageBox.Show("Hãy chọn sự kiện thêm vào GT");
                return;
            }
            lstGiaThiet.Items.Add(text);
        }

        private void btnThemKL_Click(object sender, EventArgs e)
        {
            string text = lstTapSuKien.GetItemText(lstTapSuKien.SelectedItem);
            if (String.IsNullOrEmpty(text))
            {
                MessageBox.Show("Hãy chọn sự kiện thêm vào KL");
                return;
            }
            txtKetLuan.Text = text;
        }
        private void btnThemLuat_Click(object sender, EventArgs e)
        {
            if (lstGiaThiet.Items.Count == 0 || txtKetLuan.Text == "")
            {
                MessageBox.Show("Chọn GT và KL phù hợp");
                return;
            }
            RuleItem rule;
            List<string> left = new List<string>();
            string right = txtKetLuan.Text;
            for (int i = 0; i < lstGiaThiet.Items.Count; i++)
            {
                left.Add(lstGiaThiet.Items[i].ToString());
            }
            string nameRule = "r" + i.ToString();
            rule = new RuleItem(nameRule, left, right);
            list.Add(rule);
            i++;
            lstTapLuat.Items.Add(rule.Name + " : " + rule.ToString());
            lstGiaThiet.Items.Clear();
            txtKetLuan.Text = "";
        }

        private void btnXoaLuat_Click(object sender, EventArgs e)
        {
            if (lstTapLuat.Items.Count == 0)
            {
                MessageBox.Show("Tập luật rỗng");
                return;
            }
            lstTapLuat.Items.Remove(lstTapLuat.SelectedItem);

        }

        private void btnSuyDienTien_Click(object sender, EventArgs e)
        {
            if (lstGiaThiet.Items.Count == 0 || txtKetLuan.Text == "")
            {
                MessageBox.Show("Chọn GT và KL phù hợp");
                return;
            }
            List<string> gt = new List<string>();
            for (int i = 0; i < lstGiaThiet.Items.Count; i++)
            {
                gt.Add(lstGiaThiet.Items[i].ToString());
            }
            string kl = txtKetLuan.Text;
            Rule rule = new Rule(list, gt, kl);

            rule.SuyDienTien(list, kl);

            if (rule.ketQua)
            {
                string tg = "", vet = "";
                foreach (var item in rule.TG)
                {
                    tg += item.ToString() + " , ";
                }
                foreach (var item in rule.VET)
                {
                    vet += item.Name + " , ";
                }
                lblKetQua.Text = "GT ->  KL là TRUE được chứng minh";
                txtDuongDi.Text = vet;
                txtTapSuKienDich.Text = tg;
            }
            else
            {
                lblKetQua.Text = "GT ->  KL là FALSE";
                txtDuongDi.Text = "FALSE";
                txtTapSuKienDich.Text = "FALSE";
            }

        }
        #endregion

        #region PTTHE
        // <Generate ruleset>

        //Tạo danh sáchthuộc tính
        List<AttributeValue> dsTT = new List<AttributeValue>();

        //Tạo một luật mới, vế phải là gtri cuối
        TRule luatMoi;
        int dongChonLuat;

        //Hiển thị lên các thuộc tính được chọn, cần ấn nút trước khi thực hiện các thao tác thêm, sửa
        private void btnHienThi_Click(object sender, EventArgs e)
        {
            luatMoi = new TRule();

            //thao tác thêm luật
            themLuat(luatMoi);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ruleset.Add(luatMoi);
            MessageBox.Show("Thêm luật mới thành công.");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            ruleset[dongChonLuat] = luatMoi;
            MessageBox.Show("Sửa luật số " + (dongChonLuat + 1) + " thành công.");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            ruleset.RemoveAt(dongChonLuat);
            MessageBox.Show("Xóa luật số " + (dongChonLuat + 1) + " thành công.");
        }

        private void dgvThuocTinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MacDinh();

            //kiểm tra cột vế phải
            if (e.ColumnIndex == 1)
            {
                foreach (DataGridViewRow row in dgvThuocTinh.Rows)
                {
                    row.Cells[1].Value = false;
                }
            }
        }

        private void dgvLuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dongChonLuat = e.RowIndex;
            btnThem.Enabled = false;
            btnSua.Enabled = false;

            if (dongChonLuat >= 0)
            {
                btnXoa.Enabled = true;

                txtLuat.Text = dgvLuat.Rows[dongChonLuat].Cells[0].Value.ToString();

                TRule luat = ruleset[dongChonLuat];

                string tam;

                //duyệt dgvThuocTinh
                foreach (DataGridViewRow row in dgvThuocTinh.Rows)
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

        private void themLuat(TRule luat)
        {
            int kt_vt = 0, kt_vp = 0;

            foreach (DataGridViewRow row in dgvThuocTinh.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    if ((Boolean)row.Cells[0].Value == true)
                    {
                        if ((Boolean)row.Cells[1].Value == true)
                        {
                            kt_vt = -1;
                            break;
                        }
                        else
                        {
                            string tt = row.Cells[2].Value.ToString();
                            luat.Rule.Add(tt);
                            kt_vt++;
                        }
                    }
                }
            }

            foreach (DataGridViewRow row in dgvThuocTinh.Rows)
            {
                if (row.Cells[1].Value != null)
                {
                    if ((Boolean)row.Cells[1].Value == true)
                    {
                        string tt = row.Cells[2].Value.ToString();
                        luat.Rule.Add(tt);
                        kt_vp = 1;
                    }
                }
            }

            if (kt_vt > 0 && kt_vp == 1)
            {
                txtLuat.Text = luat.RuleText;
                btnThem.Enabled = true;
            }
            else
            {
                txtLuat.Text = "Lỗi: ";
                if (kt_vp == 0)
                {
                    txtLuat.Text += "chưa thêm vế phải của luật; ";
                }
                if (kt_vt == -1)
                {
                    txtLuat.Text += "2 vế có 1 thuộc tính giống nhau; ";
                }
                if (kt_vt == 0)
                {
                    txtLuat.Text += "chưa thêm vế trái của luật; ";
                }
            }

            if (dongChonLuat != -1)
            {
                btnSua.Enabled = true;
            }
            btnThem.Enabled = true;
        }

        private void dgvAttributes1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvThuocTinh.Rows.Clear();
            dsTT.AddRange(attributeValues[e.RowIndex]);
            dgvThuocTinhSource.ResetBindings(false);
        }

        // </Generate ruleset>
        #endregion

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvAttributes1Source.ResetBindings(false);
        }

        
    }
}
