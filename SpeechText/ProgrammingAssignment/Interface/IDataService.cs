using System.Collections.Generic;

namespace ProgrammingAssignment.Interface
{
    public interface IDataService
    {
        List<string> GetData();
        HashSet<string> Directions();
        Dictionary<string, string> Concepts();
    }
}