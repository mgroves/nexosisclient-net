using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Nexosis.Api.Client.Model;

namespace Nexosis.Api.Client
{
    /// <summary>
    /// The primary interface to the Nexosis API.
    /// </summary>
    public interface INexosisClient
    {

        Action<HttpRequestMessage, HttpResponseMessage> HttpMessageTransformer { get; set; }

        /// <summary>Gets the current account balance.</summary>
        /// <exception cref="NexosisClientException">Thrown when 4xx or 5xx response is received from server, or errors in parsing the response.</exception>
        /// <remarks>GET of https://ml.nexosis.com/api/sessions</remarks>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<AccountBalance> GetAccountBalance(CancellationToken cancellationToken = default(CancellationToken));


        /// <summary>
        /// Access to the Session based operations in the API.
        /// </summary>
        ISessionClient Sessions { get; }

        /// <summary>
        /// Access to the DataSet based operations in the API.
        /// </summary>
        IDataSetClient DataSets { get; }
        
        /// <summary>
        /// Access to the Import operations in the API
        /// </summary>
        IImportClient Imports { get; }
        
        /// <summary>
        /// Access to the View operations in the API
        /// </summary>
        IViewClient Views { get; }

        /// <summary>
        /// Access to the Models operations in the API
        /// </summary>
        IModelClient Models { get; }

        /// <summary>
        /// A client for getting NLP vocabularies built by sessions.
        /// <remarks>For each column in your DataSource with type Text, Nexosis builds a vocabulary and engineers features from the words in that column</remarks>
        /// </summary>
        IVocabularyClient Vocabularies { get; }
    }
}
