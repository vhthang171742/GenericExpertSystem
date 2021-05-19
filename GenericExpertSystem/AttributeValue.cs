using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMining
{
    /// <summary>
    /// Attribute values class
    /// </summary>
    /// /// Created by VHTHANG{02/05/2021}
    public class AttributeValue
    {
        #region Declare
        public String Attribute{get; set;}
        public string Label { get; set; }
        public int Count { get; set; }
        public Dictionary<string, int> Statistic { get; set; }
        public String Text
        {
            get
            {
                if (Attribute != "")
                    return Attribute + " = " + Label;
                else
                    return Label;
            }
        }
        #endregion

        #region Constructor
        public AttributeValue()
        {
            Statistic = new Dictionary<string, int>();
        }
        public AttributeValue(String attribute, string label)
        {
            this.Attribute = attribute;
            this.Label = label;
            this.Count = 0;
            Statistic = new Dictionary<string, int>();
        }
        #endregion

        public override bool Equals(object obj)
        {
            // If the passed object is null
            if (obj == null)
            {
                return false;
            }
            if (!(obj is AttributeValue))
            {
                return false;
            }
            return (this.Label == ((AttributeValue)obj).Label)
                && (this.Attribute == ((AttributeValue)obj).Attribute);
        }
    }
}
