using System.Collections.Generic;

namespace ProgrammingAssignment.Interface
{
    public interface IAnalyserService
    {
        void Parse(string utterance);

        IEnumerable<string> Tokenize(string utterance);

        string Match(string word);

        string ShowResults(List<string> matches, string utterance);
    }
}