﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AspLikeInclude
{
    public class Replacer
    {
        public static List<ReplaceSymbol> getReplaceSymbols(string fullSymbol)
        {
            List<ReplaceSymbol> rVal = new List<ReplaceSymbol>();
            Regex regex = new Regex("<!--#include (\\w*)=\"([\\w\\s\\.\\\\:]*)\"-->", RegexOptions.Multiline);

            Match match = regex.Match(fullSymbol);
            while (match.Success)
            {
                string searchString = match.Groups[0].Value;
                string command = match.Groups[1].Value;
                string path = match.Groups[2].Value;
                rVal.Add(new ReplaceSymbol(command, path, searchString));

                match = match.NextMatch();
            }
            return rVal;
        }

        public static string DoReplace(List<ReplaceSymbol> replaceSymbols, string before, string basePath)
        {
            string rVal = before;
            foreach(var item in replaceSymbols)
            {
                string text = File.ReadAllText(Path.Combine(basePath, item.path), Encoding.UTF8);
                rVal = rVal.Replace( item.searchString, text);
            }
            return rVal;
        }
    }
}
