using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AspLikeInclude
{
    public class ReplaceSymbol
    {
        public string command { get; set; }
        public string path { get; set; }
        public string searchString { get; set; }
        public ReplaceSymbol (string command,string path, string searchString)
        {
            this.command = command;
            this.path = path;
            this.searchString = searchString;
        }
        public ReplaceSymbol(string fullSymbol)
        {
            Regex regex = new Regex("<!--#include (\\w*)=\"([\\w\\s\\.\\\\:]*)\"-->");
            Match match = regex.Match(fullSymbol);
            if (match.Success)
            {
                searchString = match.Groups[0].Value;
                command = match.Groups[1].Value;
                path = match.Groups[2].Value;
            }
            this.searchString = fullSymbol;
        }
    }
}
