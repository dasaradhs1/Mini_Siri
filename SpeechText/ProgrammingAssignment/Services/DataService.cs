using System.Collections.Generic;
using System.Threading.Tasks;
using ProgrammingAssignment.Interface;

namespace ProgrammingAssignment
{
    public class DataService : IDataService{

        public List<string> GetData()
        {
            return new List<string>
            {
                "I would like some thai? food!", 
                "Where can I find good sushi !", 
                "Find me a place that does tapas", 
                "Which restaurants do East Asian food", 
                "Which restaurants  do West-Indian food", 
                "What is the weather like today ?", 
                "Where is!@The    nearest East-asian restaunt?",
                "Where  is!@The  west!asian diner!",
                "Is there a nice fish food, in Central ireland"

            };
        }

        public HashSet<string> Directions()
        {
            return new HashSet<string>
            {
                "North",
                "East",
                "West",
                "South",
                "Central"
            };
        }

        public Dictionary<string, string> Concepts()
        {
            return new Dictionary<string, string>
            {
                {"Indian","Indian"},
                {"Thai","Thai"},
                {"Sushi","Sushi"},
                {"Caribbean","Caribbean"},
                {"Italian","Italian"},
                {"West Indian","West Indian"},
                {"Pub","Pub"},
                {"East Asian","East Asian"},
                {"BBQ","BBQ"},
                {"Chinese","Chinese"},
                {"Portuguese","Portuguese"},
                {"Spanish","Spanish"},
                {"French","French"},
                {"East European","East European"},
                {"Central Ireland", "Central Ireland"}
            };

        }
    }
}