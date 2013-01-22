using System;
using System.Text.RegularExpressions;

namespace MappingExample
{
    /// <summary>
    /// represents a UK postcode, e.g. G4 
    /// </summary>
    public class PostCode
    {
        public string Area{ get; set; }

        public string Property{ get; set; }

        public string FullCode
        {
            get { return String.Format("{0} {1}", Area, Property); }
        }

    }
}
