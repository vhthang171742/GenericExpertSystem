using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataMining
{
    public partial class FormAddAttributes : Form
    {
        private List<Attribute> newAttributes;
        private List<List<AttributeValue>> newAttributeValues;
        FrmMain frmMaster;

        public FormAddAttributes(FrmMain master)
        {
            InitializeComponent();
            this.frmMaster = master;
            newAttributes = new List<Attribute>();
            newAttributeValues = new List<List<AttributeValue>>();
        }

        private void btnAddAttribute_Click(object sender, EventArgs e)
        {
            if (txtNewAttribute.Text == "")
            {
                MessageBox.Show("Please enter name of the new attribute");
                txtNewAttribute.Focus();
                return;
            }
            if ((from x in newAttributes select x.Name).ToList().Contains(txtNewAttribute.Text) || (from x in frmMaster.attributes select x.Name).ToList().Contains(txtNewAttribute.Text))
            {
                MessageBox.Show("There is already an attribute named \""+txtNewAttribute.Text+"\"");
                txtNewAttribute.Focus();
                return;
            }
            if (dgvNewAttributeValues.Rows.Count <= 1)
            {
                MessageBox.Show("At least one value is required for attribute "+ txtNewAttribute.Text);
                return;
            }

            dgvNewAttributes.Rows.Add();
            dgvNewAttributes.Rows[dgvNewAttributes.Rows.Count - 1].Cells[0].Value = txtNewAttribute.Text;
            Attribute tempAttr = new Attribute(txtNewAttribute.Text, true);
            newAttributes.Add(tempAttr);
            List<AttributeValue> lav = new List<AttributeValue>();
            for(int i=0; i< dgvNewAttributeValues.Rows.Count-1; i++)
            {
                lav.Add(new AttributeValue(txtNewAttribute.Text, dgvNewAttributeValues.Rows[i].Cells[0].Value.ToString()));
            }
            newAttributeValues.Add(lav);
            txtNewAttribute.Clear();
            dgvNewAttributeValues.Rows.Clear();
        }
        
        private void btnClearInput_Click(object sender, EventArgs e)
        {
            txtNewAttribute.Clear();
            dgvNewAttributeValues.Rows.Clear();
        }

        private void btnFinishAdding_Click(object sender, EventArgs e)
        {
            frmMaster.AddNewAttribute(newAttributes, newAttributeValues);
            this.Dispose();
        }
    }
}
