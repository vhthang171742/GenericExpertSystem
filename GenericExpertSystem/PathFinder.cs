
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMining
{
    // lớp xây dựng giải thuật tìm đường đi ngắn nhất từ 1 đỉnh đến đỉnh khác trên đồ thị FPG
    public class PathFinder
    {
        public void ShortestP(Vert sourseV)
        {
            sourseV.setDist(0);
            Queue<Vert> queue = new Queue<Vert>();
            queue.Enqueue(sourseV);
            sourseV.setVisited(true);

            while (queue.Count != 0)
            {
                Vert actualVertex = queue.Dequeue();
                foreach (Edge edge in actualVertex.getList())
                {
                    Vert v = edge.getTargetVert();
                    if (!v.Visited())
                    {
                        double newDistance = actualVertex.getDist()
+ edge.getWeight();
                        if (newDistance < v.getDist())
                        {
                            Queue<Vert> myQueue = new Queue<Vert>(queue.Where(x => x != v));
                            queue = myQueue;
                            v.setDist(newDistance);
                            v.setPr(actualVertex);
                            queue.Enqueue(v);
                        }
                    }
                }
                actualVertex.setVisited(true);
            }
        }
        public List<Vert> getShortestP(Vert targetVertex)
        {
            
            List<Vert> list = new List<Vert>();
            for (Vert vertex = targetVertex; vertex != null; vertex = vertex.getPr())
            {
                list.Add(vertex);
            }
            list.Reverse();
            return list;
        }

    }
}
