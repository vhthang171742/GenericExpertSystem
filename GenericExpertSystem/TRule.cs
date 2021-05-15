using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMining
{
    public class TRule
    {
        private List<String> rule;
        public List<String> Rule {
            get { return rule; }
            set {
                rule = value;
            } 
        }
        public String RuleText {
            get
            {
                string s = "";
                for (int i = 0; i < Rule.Count; i++)
                {
                    if (i < Rule.Count - 2)
                    {
                        s += (Rule[i] + " ^ ");
                    }
                    else if (i == Rule.Count - 2)
                    {
                        s += (Rule[i] + " -> ");
                    }
                    else
                        s += (Rule[i]);
                }
                return s;
            }
        }

        public TRule()
        {

        }

        public TRule(List<String> rule)
        {
            this.rule = rule;
        }
    }
}
