// Copyright Jordan Maxwell. All rights reserved.
// See LICENSE file in the project root for full license information.

using Microsoft.Extensions.Options;
using PrivacyNet.Models.Options;
using System.Net.Http.Headers;

namespace PrivacyNet.Services
{
    /// <summary>
    /// Handler for adding the api key to the request header.
    /// </summary>
    internal sealed class ApiKeyHeaderHandler : DelegatingHandler
    {
        private readonly IOptions<PrivacyApiOptions> options;

        public ApiKeyHeaderHandler(IOptions<PrivacyApiOptions> options)
        {
            this.options = options;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("api-key", options.Value.ApiKey);
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
