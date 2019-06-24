using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AspLikeInclude
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = args[0];
            string outFile = args[1];
            string basePath = Directory.GetCurrentDirectory();
            string fileContent = File.ReadAllText(Path.Combine(basePath, fileName), Encoding.UTF8);
            var replaceSymbols = Replacer.getReplaceSymbols(fileContent);

            string actual = Replacer.DoReplace(replaceSymbols, fileContent, basePath);

            File.WriteAllText(Path.Combine(basePath, outFile), actual);
        }
    }
}
