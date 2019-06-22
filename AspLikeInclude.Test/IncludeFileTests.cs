using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AspLikeInclude;
using System.Collections.Generic;
using System.Text;

namespace AspLikeInclude.Test
{
    [TestClass]
    public class IncludeFileTests
    {
        [TestMethod]
        public void IncludeOneSymbol()
        {
            string command = "file";
            string path = @"c:\path\foo.txt";
            string fullSymbol = string.Format(Globals.REPLACEMENT_PATTERN, command, path);
            StringBuilder sbDocument = new StringBuilder();
            sbDocument.AppendLine("   Text before symbol ");
            sbDocument.AppendLine(fullSymbol);
            sbDocument.AppendLine("   Text after symbol ");

            List<ReplaceSymbol> matches = Replacer.getMatches(sbDocument.ToString());

            Assert.AreEqual(1, matches.Count);

            Assert.AreEqual(fullSymbol, matches[0].searchString);
            Assert.AreEqual(command, matches[0].command);
            Assert.AreEqual(path, matches[0].path);
        }

        [TestMethod]
        public void IncludeTwoSymbol()
        {
            string command1 = "file";
            string path1 = @"c:\path\foo.txt";
            string fullSymbol1 = string.Format(Globals.REPLACEMENT_PATTERN, command1, path1);

            string command2 = "file";
            string path2 = @"c:\path\foo.txt";
            string fullSymbol2 = string.Format(Globals.REPLACEMENT_PATTERN, command2, path2);

            StringBuilder sbDocument = new StringBuilder();
            sbDocument.AppendLine("   Text before symbol ");
            sbDocument.AppendLine(fullSymbol1);
            sbDocument.AppendLine(fullSymbol2);
            sbDocument.AppendLine("   Text after symbol ");

            List<ReplaceSymbol> matches = Replacer.getMatches(sbDocument.ToString());

            Assert.AreEqual(2, matches.Count);
            Assert.AreEqual(fullSymbol1, matches[0].searchString);
            Assert.AreEqual(command1, matches[0].command);
            Assert.AreEqual(path1, matches[0].path);

            Assert.AreEqual(fullSymbol2, matches[1].searchString);
            Assert.AreEqual(command2, matches[1].command);
            Assert.AreEqual(path2, matches[1].path);
        }

    }
}
