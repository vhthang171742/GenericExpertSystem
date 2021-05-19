using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMining
{
    // tập luật
    public class InferEngine
    {
        public List<TRule> rules;
        public List<AttributeValue> assumptions;
        public AttributeValue conclusion;

        public bool result;
        public List<AttributeValue> TG;
        public List<TRule> VET = new List<TRule>();

        public InferEngine()
        {

        }

        public InferEngine(List<TRule> rules, List<AttributeValue> gt, AttributeValue kl)
        {
            this.rules = rules;
            this.assumptions = gt;
            this.conclusion = kl;
        }

        public TRule minItemQueue(Queue<TRule> SAT)
        {
            TRule rule = new TRule();
            List<double> valueHeuristic = new List<double>();
            foreach (var item in SAT)
            {
                valueHeuristic.Add(item.Heuristic);
            }
            double min = valueHeuristic.Min();
            rule = SAT.ToList().Find(x => x.Heuristic == min);
            return rule;
        }
        public void ForwardInfer(List<TRule> rules, AttributeValue kl)
        {
            List<double> valueHeuristic = new List<double>();
            foreach (TRule rule in rules)
            {
                rule.Heuristic = executeHeuristic(rules, rule.Right, kl);
                valueHeuristic.Add(rule.Heuristic);
            }
            for(int i=0; i<this.rules.Count; i++)
            {
                this.rules[i].Heuristic = rules[i].Heuristic;
            }

            List<AttributeValue> TG = assumptions;
            Queue<TRule> SAT = new Queue<TRule>();
            SAT = Filter(assumptions, rules);

            List<TRule> VET = new List<TRule>();

            while (SAT.Count > 0 && !KL_to_GT(TG))
            {
                int i = 1;
                if (TG.IndexOf(minItemQueue(SAT).Right) < 0)
                {
                    TG.Add(minItemQueue(SAT).Right);
                }
                rules.Remove(minItemQueue(SAT));
                if (!VET.Contains(minItemQueue(SAT)))
                {
                    VET.Add(minItemQueue(SAT));
                }
                SAT.Clear();
                SAT = Filter(TG, rules);
                i++;
            }
            this.result = KL_to_GT(TG);
            this.VET = VET;
            this.TG = TG;

        }
        private Queue<TRule> Filter(List<AttributeValue> gt, List<TRule> rulesClone)
        {
            Queue<TRule> SAT = new Queue<TRule>();
            foreach (TRule r in rulesClone)
            {
                if (r.Left.Count <= gt.Count)
                {
                    int count = 0;
                    foreach (AttributeValue tt in gt)
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
        }
        public bool KL_to_GT(List<AttributeValue> TG)
        {
            if (TG.Contains(conclusion))
            {
                return true;
            }
            return false;
        }

        // vẽ đồ thị FPG
        // 1 vẽ đỉnh
        public List<Vert> createVertex(List<TRule> rules)
        {
            List<AttributeValue> verts = new List<AttributeValue>();
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
        public double executeHeuristic(List<TRule> rules, AttributeValue nameBeginVert, AttributeValue nameTargetVert)
        {
            // nối đỉnh thành cạnh
            List<Vert> vertsList = new List<Vert>();
            vertsList = createVertex(rules);
            foreach (TRule ruleItem in rules)
            {
                Vert vertC = new Vert(ruleItem.Right);
                int vt = vertsList.FindIndex(r => r.name.Equals(vertC.name));
                foreach (AttributeValue item in ruleItem.Left)
                {
                    Vert vert = new Vert(item);
                    //  int vtd= vertsList.IndexOf(vert);
                    int vtd = vertsList.FindIndex(r => r.name.Equals(vert.name));
                    //  vertsList[vtd] = new Vert();
                    vertsList[vtd].addNeighbour(new Edge(1, vertsList[vtd], vertsList[vt]));// nối đoạn thẳng                                                                                         
                }
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
