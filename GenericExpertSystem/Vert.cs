using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMining
{
    // class này để tạo các đỉnh trong đồ thị FPG
    public class Vert /*: IComparable<Vert>*/
    {
        public  bool visited;
        public AttributeValue name;
        public ArrayList List = new ArrayList();
        public double dist = Double.MaxValue;
        public Vert pr;

        public Vert()
        {
        }

        public Vert(AttributeValue name)
        {
            this.name = name;
        }

        public ArrayList getList()
        {
            return List;
        }

        public AttributeValue getName()
        {
            return name;
        }

        public void setName(AttributeValue name)
        {
            this.name = name;
        }

        public void setList(ArrayList List)
        {
            this.List = List;
        }

        public void addNeighbour(Edge edge)
        {
            this.List.Add(edge);
            
        }

        public bool Visited()
        {
            return visited;
        }

        public void setVisited(bool visited)
        {
            this.visited = visited;
        }

        public Vert getPr()
        {
            return pr;
        }

        public void setPr(Vert pr)
        {
            this.pr = pr;
        }

        public double getDist()
        {
            return dist;
        }

        public void setDist(double dist)
        {
            this.dist = dist;
        }

        //public int CompareTo(Vert other)
        //{
        //    return (this.name).CompareTo(other.name);
        //}

        public override string ToString()
        {
            return name+"------";
        }
    }
}
