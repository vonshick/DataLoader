using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Text;
using System.Xml.Linq;

namespace DataImportApp
{
    public class DataLoader
    {
        private List<Criterion> CriterionList { get; set; }
        private List<Alternative> AlternativeList { get; set; }

        public void LoadCSV()
        {
            string file = "Lab7_bus.csv";
            using (var reader = new StreamReader(@file))
            {
                string[] criterionTypeArray = reader.ReadLine().Split(';');
                string[] criterionNamesArray = reader.ReadLine().Split(';');
                CriterionList = new List<Criterion>();
                // iterating from 1 because first column is empty
                for (int i = 1; i < criterionTypeArray.Length; i++)
                {
                    CriterionList.Add(new Criterion(criterionNamesArray[i], criterionTypeArray[i]));
                }

                AlternativeList = new List<Alternative>();

                while (!reader.EndOfStream)
                {
                    var values = reader.ReadLine().Split(';');
                    Alternative alternative = new Alternative {Name = values[0]};

                    Dictionary<string, float> criterionValueDictionary = new Dictionary<string, float>();
                    for (int i = 1; i < values.Length; i++)
                    {
                        Console.WriteLine(criterionNamesArray[i] + " : " + values[i]);
                        criterionValueDictionary.Add(criterionNamesArray[i], Convert.ToSingle(values[i]));
                    }

                    alternative.CriteriaValues = criterionValueDictionary;
                    AlternativeList.Add(alternative);

                    Console.WriteLine("");
                }
            }
        }

        public void LoadXML()
        {
            CriterionList = new List<Criterion>();

            //load XML
            string file = "sample.xml";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@file);

            // iterate on its nodes
            foreach (XmlNode xmlNode in xmlDoc.DocumentElement.ChildNodes)
            {
                Criterion criterion = new Criterion();
                string nameAttributeId = "";
                string descriptionAttributeId = "";

                // first group of nodes are attributes
                // second - Electre meta data
                // third - objects
                if (xmlNode.Name == "ATTRIBUTES")
                {
                    foreach (XmlNode attribute in xmlNode)
                    {
                        criterion.ID = attribute.Attributes["AttrID"].Value;
                        // two specific groups of nodes may appear in attributes - name and description
                        // we don't want to save it as criterion
                        bool saveCriterion = true;

                        foreach (XmlNode attributePart in attribute)
                        {
                            var value = attributePart.Attributes["Value"].Value;

                            switch (attributePart.Name)
                            {
                                case "NAME":
                                    criterion.Name = value;
                                    break;
                                case "DESCRIPTION":
                                    criterion.Description = value;
                                    break;
                                case "CRITERION":
                                    criterion.CriterionType = value == "Cost" ? "c" : "g";
                                    break;
                                case "ROLE":
                                    if (value == "Name")
                                    {
                                        saveCriterion = false;
                                        nameAttributeId = criterion.ID;
                                    } else if (value == "Description")
                                    {
                                        saveCriterion = false;
                                        descriptionAttributeId = criterion.ID;
                                    }
                                    else
                                    {
                                        saveCriterion = true;
                                    }
                                    break;
                                case "TYPE":
                                    break;
                                default:
                                    Console.WriteLine("Improper XML structure");
                                    return;
                            }
                        }
                        if (saveCriterion)
                        {
                            CriterionList.Add(criterion);
                        }
                    }
                } else if (xmlNode.Name == "OBJECTS")
                {
                    foreach(XmlNode object in xmlNode)
                    {
                        
                    }
                }
            }
        }
    }
}
