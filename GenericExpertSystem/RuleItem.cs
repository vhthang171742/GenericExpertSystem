using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMining
{
    // luật
    public class RuleItem
    {
        private String name;
        private List<string> left = new List<string>();
        private string right;
        private double heuristic = Double.MaxValue;

        public double Heuristic
        {
            get { return heuristic; }
            set { heuristic = value; }
        }

        public RuleItem()
        {
        }

        public RuleItem(String name, List<string> left, string right)
        {
            this.name = name;
            this.left = left;
            this.right = right;
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public List<String> Left
        {
            get
            {
                return left;
            }
            set
            {
                left = value;
            }
        }
        public String Right {
            get 
            {
                return right;
            }
            set
            {
               right = value ;
            }
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < left.Count-1; i++)
            {
                str += left[i] + " ^ ";
            }
            str += left[left.Count - 1]+" ---> "+right;

            return str;
        }




        /*public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }*/
    }
}
