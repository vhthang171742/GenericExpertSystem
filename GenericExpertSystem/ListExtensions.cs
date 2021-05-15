using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMining
{
    static class ListExtensions
    {
        public static DataTable ToDataTable(this List<List<string>> list)
        {
            DataTable tmp = new DataTable();
            foreach (List<string> row in list)
            {
                tmp.Rows.Add(row.ToArray());
            }
            return tmp;
        }
    }
}
