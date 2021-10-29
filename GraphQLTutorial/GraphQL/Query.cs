namespace GraphQLTutorial.GraphQL
{
    public class Query
    {
        //can be used as a base class for generic calls
        public string GetApplicationName() => System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
    }
}