// Copyright Jordan Maxwell. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace PrivacyNet.Models.Options
{
    /// <summary>
    /// Options for configuring the Privacy.com api.
    /// </summary>
    public sealed class PrivacyApiOptions
    {
        /// <summary>
        /// The api key to use when accessing the Privacy.com api.
        /// </summary>
        public string ApiKey { get; set; } = string.Empty;
    }
}
