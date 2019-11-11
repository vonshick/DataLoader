using System;

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
            Console.ReadKey();
        }

    }
}
