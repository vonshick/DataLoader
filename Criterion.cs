﻿using System.Collections.Generic;

namespace DataImportApp
{
    public class Criterion
    {
        public Criterion() { }
        public Criterion(string name, string criterionDirection)
        {
            Name = name;
            CriterionDirection = criterionDirection;
        }

//        public enum Type { Gain, Cost };
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
//        public Type CriterionType { get; set; }
        public string CriterionDirection { get; set; }
        public int LinearSegments { get; set; }
        public float MinValue { get; set; }
        public float MaxValue { get; set; }


    }
}
