using System.Collections.Generic;

namespace DataImportApp
{
    public class Alternative
    {
        public string Name { get; set; }
        public string Description { get; set; }

        /// <summary> pairs: (criterion name, value) </summary>
        public Dictionary<string, float> CriteriaValues { get; set; }

    }
}
