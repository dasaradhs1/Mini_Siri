using NUnit.Framework;
using ProgrammingAssignment.Interface;
using ProgrammingAssignment;
using Shouldly;
using System.Collections.Generic;


namespace Tests
{
    public class Tests
    {
        private IDataService _dataService;
        private IAnalyserService _analyseService;
        private List<string> _matches;

        [SetUp]
        public void Setup()
        {
            IDataService data = new DataService();
            IAnalyserService analyzer = new AnalyzerService(data);

            _analyseService = analyzer;
            _dataService = data;
            _matches = new List<string>{"match_one"};
        }

        [Test]
        public void Tokenize_PassUtterance_ReturnsWords()
        {
           var passResult = "Input: This should show two results for matches | matches: match_one";
           var utterance = "one    !?!two THREE";
           var result = _analyseService.Tokenize(utterance);

           result.ShouldContain("one");
           result.ShouldContain("two");
           result.ShouldContain("THREE");

           result.ShouldNotContain("!?!");
           result.ShouldNotContain("");
        }

        [Test]
        public void ShowResults_PassInputs_ReturnMatches()
        {

           var passResult = "Input: This should show two results for matches | matches: match_one";
           var test = "This should show match_one results for matches";
           var result = _analyseService.ShowResults(_matches, test);

           result.ShouldMatch(passResult);
        }

        [Test]
        public void Match_PassLowercaseInput_Match()
        {
           var passResult = "East Asian";
           var result = _analyseService.Match("east asian");

           result.ShouldMatch(passResult);
        }
    }
}