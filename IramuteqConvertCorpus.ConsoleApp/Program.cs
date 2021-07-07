using System;
using IramuteqConvertCorpus.Lib.Business;
using IramuteqConvertCorpus.Lib.Models;

namespace IramuteqConvertCorpus.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
                throw new ArgumentException($"Missed argument 1 [CSV File].");
            if (args.Length == 1)
                throw new ArgumentException($"Missed argument 2 [Corpus File].");

            if (args.Length >= 2)
            {
                string csvFile = args[0];
                string corpusFile = args[1];

                if (!System.IO.File.Exists(csvFile))
                    throw new ArgumentException($"Csv File Not Found '{csvFile}'.");

                if (System.IO.File.Exists(corpusFile))
                    System.IO.File.Delete(corpusFile);

                if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(corpusFile)))
                    System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(corpusFile));

                CsvReaderGoogleForms c = new CsvReaderGoogleForms(csvFile);
                SearchModel x = c.Read();
                
            }
        }
    }
}
