using System;

namespace DataImportApp
{
    class Program
    {
        static void Main()
        {
            DataLoader dataLoader = new DataLoader();
//            dataLoader.LoadCSV();
            dataLoader.LoadXML();
            Console.ReadKey();
        }

    }
}
