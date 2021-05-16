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
        public List<AttributeValue> Rule {
            get { return rule; }
            set {
                rule = value;
            } 
        }
        public String RuleText {
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

        public TRule()
        {
            this.Rule = new List<AttributeValue>();
        }

        public TRule(List<String> rule)
        {
            foreach(String s in rule)
            {
                AttributeValue av = new AttributeValue();
                av.Label = s;
                this.rule.Add(av);
            }
        }
    }
}
