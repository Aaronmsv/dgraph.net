using System.Collections.Generic;
using DgraphDotNet.Schema;

namespace DgraphDotNet
{
    public interface IQuery
    {
        /// <summary>
        /// Returns all predicates in the Dgraph schema.
        /// </summary>
        FluentResults.Result<DgraphSchema> SchemaQuery();

        /// <summary>
        /// Returns predicates in the Dgraph schema returned by the given schema query.
        /// </summary>
        FluentResults.Result<DgraphSchema> SchemaQuery(string schemaQuery);

        /// <summary>
        /// Run a query.
        /// </summary>
        FluentResults.Result<string> Query(string queryString);

        /// <summary>
        /// Run a query with variables.
        /// </summary>
        FluentResults.Result<string> QueryWithVars(string queryString, Dictionary<string, string> varMap);
    }
}