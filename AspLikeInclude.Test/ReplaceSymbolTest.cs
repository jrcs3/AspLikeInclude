using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AspLikeInclude;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace AspLikeInclude.Test
{
    [TestClass]
    public class ReplaceSymbolTest
    {
        const string REPLACEMENT_PATTERN = "<!--#include {0}=\"{1}\"-->";
        [TestMethod]
        public void DoReplaceWithOneReplacement()
        {
            string command = "file";
            string path = "one-line.txt";
            string fullSymbol = string.Format(Globals.REPLACEMENT_PATTERN, command, path);
            List<ReplaceSymbol> replaceSymbols = new List<ReplaceSymbol>()
            {
                new ReplaceSymbol(command, path, fullSymbol)
            };
            string basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); 
            string before = string.Format("Before{0}{1}{0}After", Environment.NewLine, fullSymbol);
            string after = string.Format("Before{0}{1}{0}After", Environment.NewLine, "This contains one line");

            string actual = Replacer.DoReplace(replaceSymbols, before, basePath);

            Assert.AreEqual(after, actual);
        }
    }
}
