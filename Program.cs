using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.AccessControl;

namespace DataImportApp
{
    class Program
    {
        static void Main()
        {
            DataLoader dataLoader = new DataLoader();
//            dataLoader.LoadCSV("Lab7_bus.csv");
//            dataLoader.LoadXML("sample.xml");
            dataLoader.LoadUTX("sample.utx");
            dataLoader.setMinAndMaxCriterionValues();

            Console.WriteLine("Criteria:");
            for (int i = 0; i < dataLoader.CriterionList.Count; i++)
            {
                Console.WriteLine(dataLoader.CriterionList[i].Name);
            }
            Console.WriteLine();

            Console.WriteLine("Alternatives:");
            for (int i = 0; i < dataLoader.AlternativeList.Count; i++)
            {
                Dictionary<string, float> dictionary = dataLoader.AlternativeList[i].CriteriaValues;
                foreach (KeyValuePair<string, float> kvp in dictionary)
                {
                    Console.WriteLine("{0} = {1}", kvp.Key, kvp.Value);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }

    }
}
