using SisoDb.Lambdas.Parsers;

namespace SisoDb.Querying
{
    public class CommandBuilderFactory : ICommandBuilderFactory
    {
        public IGetCommandBuilder<T> CreateGetCommandBuilder<T>() where T : class
        {
            return new GetCommandBuilder<T>(
                new SortingParser(),
                new IncludeParser());
        }

        public IQueryCommandBuilder<T> CreateQueryCommandBuilder<T>() where T : class
        {
            return new QueryCommandBuilder<T>(
                new SelectorParser(),
                new SortingParser(),
                new IncludeParser());
        }
    }
}