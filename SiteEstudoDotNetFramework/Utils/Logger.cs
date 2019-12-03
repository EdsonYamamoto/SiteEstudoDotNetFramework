using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SiteEstudoDotNetFramework.Utils
{
    public class Logger
    {
        public static void LoggerArquivo(string relato)
        {
            // Set a variable to the Documents path.
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Write the string array to a new file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, DateTime.Now.ToString("ddMMyyyy HHmmss") + ".txt")))
            {
                outputFile.WriteLine(relato);
            }

        }
    }
}