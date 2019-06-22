using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AspLikeInclude;

namespace AspLikeInclude.Test
{
    [TestClass]
    public class ReplaceSymbolTest
    {
        const string REPLACEMENT_PATTERN = "<!--#include {0}=\"{1}\"-->";
        [TestMethod]
        public void ShouldFindOneItem()
        {
            string command = "file";
            string path = @"c:\path\foo.txt";
            string fullSymbol = string.Format(Globals.REPLACEMENT_PATTERN, command, path);

            var item = new ReplaceSymbol(fullSymbol);

            Assert.AreEqual(fullSymbol, item.searchString);
            Assert.AreEqual(command, item.command);
            Assert.AreEqual(path, item.path);
        }
    }
}
