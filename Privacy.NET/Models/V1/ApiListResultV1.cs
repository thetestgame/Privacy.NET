// Copyright Jordan Maxwell. All rights reserved.
// See LICENSE file in the project root for full license information.

using Newtonsoft.Json;

namespace PrivacyNet.Models.V1
{
    /// <summary>Contains a list of paged data from the privacy api.</summary>
    /// <typeparam name="TDatatype"></typeparam>
    public class ApiListResultV1<TDatatype> where TDatatype : class
    {
        /// <summary>Data contained on the current page</summary>
        [JsonProperty("data")]
        public List<TDatatype> Data { get; set; } = new List<TDatatype>();

        /// <summary>
        /// Total number of entries returned from the api
        /// </summary>
        [JsonProperty("total_entries")]
        public int TotalEntries { get; set; }

        /// <summary>
        /// Total number of pages returned from the api
        /// </summary>
        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        /// <summary>
        /// Current page number returned from the api
        /// </summary>
        [JsonProperty("page")]
        public int Page { get; set; }
    }
}
