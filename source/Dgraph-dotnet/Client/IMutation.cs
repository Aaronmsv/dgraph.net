using System.Collections.Generic;
using DgraphDotNet.Graph;

namespace DgraphDotNet
{

    /// <summary>
    /// Encapsulates  mutations to be sent to the backend Dgraph store.  A mutation must be made
    /// as part of a transaction.  Mutationsations are not
    /// sent to the store until the request is executed with <see cref="Transaction.Submit()"/>.  
    /// </summary>
    public interface IMutation {
        /// <summary>
        /// Schedules the given edge to be added as part of the request.
        /// </summary>
        /// <remarks>If <c>edge == null</c>, this call has no effect.</remarks> 
        void AddEdge(Edge edge);

        /// <summary>
        /// Schedules the given edge to be deleted as part of the request.
        /// </summary>
        /// <remarks>If <c>edge == null</c>, this call has no effect.</remarks> 
        void DeleteEdge(Edge edge);

        /// <summary>
        /// Schedules the given property to be added as part of the request.
        /// </summary>
        /// <remarks>If <c>property == null</c>, this call has no effect.</remarks> 
        void AddProperty(Property property);

        /// <summary>
        /// Schedules the given property to be deleted as part of the request.
        /// </summary>
        /// <remarks>If <c>property == null</c>, this call has no effect.</remarks> 
        void DeleteProperty(Property property);

        /// <summary>
        /// How many additions (edges and properties) are currently in this request.
        /// </summary>
        int NumAdditions { get; }

        /// <summary>
        /// How many deletions (edges and properties) are currently in this request.
        /// </summary>
        int NumDeletions { get; }

        /// <summary>
        /// Submit the mutation (in the context of the current transaction).  Returns
        /// a result with IsSuccess == true and and a map of blank node name -> UID
        /// for any allocated nodes, or a failed result and error if there is an error.
        /// </summary>
        FluentResults.Result<IDictionary<string, string>> Submit();
    }
}