using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMining
{
    // tập luật
    public class Rule
    {
        public List<RuleItem> rules;
        public List<string> gt;
        public string kl;

        public bool ketQua;
        public List<String> TG;
        public List<RuleItem> VET = new List<RuleItem>();
        public Rule()
        {

        }

        public Rule(List<RuleItem> rules, List<string> gt, string kl)
        {
            this.rules = rules;
            this.gt = gt;
            this.kl = kl;
        }

        public void writeGT()
        {
            string str = "GT = { ";
            foreach (string item in gt)
            {
                str += item + " , ";
            }
            str += " }\n";
            Console.WriteLine("\n " + str);
        }
        public void writeRules()
        {
            string str = "Tap luat R : \n";
            foreach (RuleItem item in rules)
            {
                str += item.Name + ": ";
                foreach (var itemLeft in item.Left)
                {
                    str += itemLeft + " ^ ";
                }
                str += " --> " + item.Right;
                str += "\n";
            }
            str += "\n";
            Console.WriteLine(str);
        }
        public RuleItem minItemQueue(Queue<RuleItem> SAT)
        {
            RuleItem rule = new RuleItem();
            List<double> valueHeuristic = new List<double>();
            foreach (var item in SAT)
            {
                valueHeuristic.Add(item.Heuristic);
            }
            double min = valueHeuristic.Min();
            rule = SAT.ToList().Find(x => x.Heuristic == min);
            return rule;
        }
        public void SuyDienTien(List<RuleItem> rules, String kl)
        {
            String str = "";
            List<double> valueHeuristic = new List<double>();
            foreach (RuleItem rule in rules)
            {
                rule.Heuristic = executeHeuristic(rules, rule.Right, kl);
                //     Console.WriteLine(rule.Right+ " đến đích : "+ rule.Heuristic);
                valueHeuristic.Add(rule.Heuristic);
            }
            List<String> TG = gt;
            Queue<RuleItem> SAT = new Queue<RuleItem>();
            SAT = Loc(gt, rules);
            Console.WriteLine("SAT ban đầu: ");
            foreach (var item in SAT)
            {
                Console.WriteLine(item.Name);
            }

            List<RuleItem> VET = new List<RuleItem>();

            while (SAT.Count > 0 && !KL_to_GT(TG))
            {
                int i = 1;
                if (TG.IndexOf(minItemQueue(SAT).Right) < 0)
                {
                    TG.Add(minItemQueue(SAT).Right.Trim().ToString());
                }
                rules.Remove(minItemQueue(SAT));
                if (!VET.Contains(minItemQueue(SAT)))
                {
                    VET.Add(minItemQueue(SAT));
                }
                SAT.Clear();
                SAT = Loc(TG, rules);
                Console.WriteLine("SAT: ");
                foreach (var item in SAT)
                {
                    Console.WriteLine(item.Name);
                }
                i++;
            }
            this.ketQua = KL_to_GT(TG);
            this.VET = VET;
            this.TG = TG;
            /*Console.WriteLine("TG: ");
            foreach (var item in TG)
            {
                Console.WriteLine(item + "\t");
            }

            Console.WriteLine("Ket qua: " + KL_to_GT(TG));*/
        }
        private Queue<RuleItem> Loc(List<String> gt, List<RuleItem> rulesClone)
        {
            Queue<RuleItem> SAT = new Queue<RuleItem>();
            foreach (RuleItem r in rulesClone)
            {
                if (r.Left.Count <= gt.Count)
                {
                    int count = 0;
                    foreach (string tt in gt)
                    {
                        if (r.Left.Contains(tt))
                        {
                            count++;
                        }
                    }
                    if (count == r.Left.Count)
                    {
                        SAT.Enqueue(r);
                    }
                }
            }
            return SAT;
            //  throw new NotImplementedException();
        }
        public bool KL_to_GT(List<String> TG)
        {
            if (TG.Contains(kl))
            {
                return true;
            }
            return false;
        }

        // vẽ đồ thị FPG
        // 1 vẽ đỉnh
        public List<Vert> createVertex(List<RuleItem> rules)
        {
            List<string> verts = new List<string>();
            foreach (var ruleItem in rules)
            {
                foreach (var item in ruleItem.Left)
                {
                    if (!verts.Contains(item))
                    {
                        verts.Add(item);
                    }
                }
                if (!verts.Contains(ruleItem.Right))
                {
                    verts.Add(ruleItem.Right);
                }
            }
            List<Vert> vertsList = new List<Vert>();
            foreach (var item in verts)
            {
                Vert vert = new Vert(item);
                vertsList.Add(vert);
            }
            return vertsList;
        }
        //2 vẽ cạnh và tính hr
        public double executeHeuristic(List<RuleItem> rules, String nameBeginVert, String nameTargetVert)
        {
            // nối đỉnh thành cạnh
            List<Vert> vertsList = new List<Vert>();
            vertsList = createVertex(rules);
            foreach (RuleItem ruleItem in rules)
            {
                Vert vertC = new Vert(ruleItem.Right);
                int vt = vertsList.FindIndex(r => r.name.Equals(vertC.name));
                foreach (string item in ruleItem.Left)
                {
                    Vert vert = new Vert(item);
                    //  int vtd= vertsList.IndexOf(vert);
                    int vtd = vertsList.FindIndex(r => r.name.Equals(vert.name));
                    //  vertsList[vtd] = new Vert();
                    vertsList[vtd].addNeighbour(new Edge(1, vertsList[vtd], vertsList[vt]));// nối đoạn thẳng
                                                                                            //      Console.WriteLine("canh: " + vertsList[vtd].name + ".addNeighbour() " + vertsList[vt]);

                    // Console.WriteLine("\t"+ vertsList[vtd].ToString());
                }

                // Console.WriteLine("*****"+vertsList[vt].ToString());

            }
            // tính hàm đánh giá
            Vert beginVert = new Vert(nameBeginVert);
            int vt1 = vertsList.FindIndex(v => v.name.Equals(beginVert.name));
            Vert targetVert = new Vert(nameTargetVert);
            int vt2 = vertsList.FindIndex(v => v.name.Equals(targetVert.name));

            PathFinder shortestPath = new PathFinder();
            shortestPath.ShortestP(vertsList[vt1]);
            try {
                double a = vertsList[vt2].getDist();
                return a;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Double.MaxValue;
            }
            
        }
       
    }
}
