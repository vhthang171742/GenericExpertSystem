using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMining
{
    /// <summary>
    /// Attribute class
    /// </summary>
    /// Created by VHTHANG{02/05/2021}
    public class Attribute
    {
        #region Declare
        public bool Enabled { get; set; }
        public String Name { get; set; }
        public bool IsClassAttribute { get; set; }
        #endregion
        #region Constructor
        public Attribute()
        {

        }
        public Attribute(String name, bool enabled)
        {
            this.Name = name;
            this.Enabled = enabled;
        }
        #endregion
    }
}
