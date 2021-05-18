using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMining
{
    public class TRule
    {
        private List<AttributeValue> rule;
        public String Name { get; set; }
        public List<AttributeValue> Rule
        {
            get { return rule; }
            set
            {
                rule = value;
            }
        }
        public List<AttributeValue> Left
        {
            get
            {
                if (rule.Count != 0)
                    return this.rule.GetRange(0, this.rule.Count - 1);
                return null;
            }
        }
        public AttributeValue Right
        {

            get
            {
                if (rule.Count >= 2)
                    return this.rule.Last();
                return null;
            }

        }
        public String RuleText
        {
            get
            {
                string s = "";
                for (int i = 0; i < rule.Count; i++)
                {
                    if (i < rule.Count - 2)
                    {
                        s += (rule[i].Text + " ^ ");
                    }
                    else if (i == rule.Count - 2)
                    {
                        s += (rule[i].Text + " -> ");
                    }
                    else
                        s += (rule[i].Text);
                }
                return s;
            }
        }
        private double heuristic = Double.MaxValue;

        public double Heuristic
        {
            get { return heuristic; }
            set { heuristic = value; }
        }

        public TRule()
        {
            this.Rule = new List<AttributeValue>();
        }

        public TRule(List<String> rule)
        {
            foreach (String s in rule)
            {
                AttributeValue av = new AttributeValue();
                av.Label = s;
                this.rule.Add(av);
            }
        }

        public TRule(List<AttributeValue> rule)
        {
            this.rule = rule;
        }

        public TRule DeepCopy()
        {
            TRule other = (TRule)this.MemberwiseClone();
            other.rule = new List<AttributeValue>(this.rule);
            return other;
        }
    }
}
