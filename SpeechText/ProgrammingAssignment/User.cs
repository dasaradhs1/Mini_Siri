using ProgrammingAssignment.Interface;

namespace ProgrammingAssignment
{
    internal class User
    {
        private static void Main(string[] args)
        {
            IDataService data = new DataService();
            IAnalyserService service = new AnalyzerService(data);
            var userInput = data.GetData();

            if (userInput != null)
                foreach (var utterance in userInput)
                    service.Parse(utterance);
        }
    }
}