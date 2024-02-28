//using System.Reflection.Metadata.Ecma335;

//namespace Toolbox
//{
//    public class Command
//    {
//        internal string Query { get; set; }
//        internal bool IStoredProcedure { get; init; }
//        internal Dictionary<string, object> Parameters { get; init; }

//        public Command(string query, bool iStoredProcedure)
//        {
//            Query = query;
//            IStoredProcedure = iStoredProcedure;
//            Parameters = new Dictionary<string, object>();
//        }
//    }
//    public void AddParameter(string parameterName, object? value)
//    {
//        Parameters.Add(parameterName, value ?? DBNull.Value);
//    }
//}