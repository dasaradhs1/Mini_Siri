using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ProgrammingAssignment.Interface;

namespace ProgrammingAssignment
{
    public class AnalyzerService : IAnalyserService
    {
        private static IDataService _dataService;

        public AnalyzerService(IDataService dataService)
        {
            _dataService = dataService;
        }

        public void Parse(string utterance)
        {
            if (utterance == null) Console.WriteLine("The user did not pass an utterance");

            var matches = new List<string>();
            var words = Tokenize(utterance);

            try
            {
                for (var i = 0; i < words.Count(); i++)
                {
                    var head = words.ElementAt(i);
                    if (_dataService.Directions().Contains(head))
                    {
                        var word = head + " " + words.ElementAt(i + 1);
                        matches.Add(Match(word));
                    }

                    matches.Add(Match(head));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            ShowResults(matches, utterance);
        }

        public IEnumerable<string> Tokenize(string utterance)
        {
            IEnumerable<string> wordTokens = null;
            if (utterance == null) Console.WriteLine("No utterance were passed to tokenize");

            try
            {
                wordTokens = Regex.Split(utterance, @"[\-\?\!\,\.\&\s+]").Where(s => s != String.Empty);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return wordTokens;
        }

        public string Match(string word)
        {
            var result = "";
            if (word == null)
                Console.WriteLine("No words where passed for Matching");

            try
            {
                result = _dataService.Concepts()
                    .FirstOrDefault(x => String.Equals(x.Key, word, StringComparison.InvariantCultureIgnoreCase))
                    .Value;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return result;
        }

        public string ShowResults(List<string> matches, string utterance)
        {
            if (matches == null || utterance == null)
                Console.WriteLine("No matches or utterance were calculated");

            foreach (var match in matches){
                if (match != null){
                    Console.WriteLine("Input: " + utterance + " | matches: " + match);
                    return "Input: " + utterance + " | matches: " + match;
                }
            }
                    
              Console.WriteLine("Input: " + utterance + " | matches: none");
              return "Input: " + utterance + " | matches: none";
        }
    }
}