// Copyright Jordan Maxwell. All rights reserved.
// See LICENSE file in the project root for full license information.

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PrivacyNet.Models;
using PrivacyNet.Models.Options;
using PrivacyNet.Services;
using Refit;

namespace PrivacyNet.Utils
{
    /// <summary>
    /// Extension methods for <see cref="IServiceCollection"/> for adding Privacy.com api support.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        private const string PrivacySandboxApiUrl = "https://sandbox.privacy.com";
        private const string PrivacyProductionApiUrl = "https://api.privacy.com";

        /// <summary>Configures the api options used by privacy api clients.</summary>
        /// <param name="services">Service collection to configure privacy support for.</param>
        /// <param name="section">Configuration section containing the details used by privacy.</param>
        public static IServiceCollection ConfigurePrivacyApi(this IServiceCollection services, IConfigurationSection section)
        {
            services.Configure<PrivacyApiOptions>(section);
            return services;
        }

        /// <inheritdoc cref="ConfigurePrivacyApi(IServiceCollection, IConfigurationSection)"/>
        /// <param name="configuration">Root configuration section. A subsection named "Privacy" will be used to populate the <see cref="PrivacyApiOptions"/> options.</param>
        public static IServiceCollection ConfigurePrivacyApi(this IServiceCollection services, IConfiguration configuration) =>
            services.ConfigurePrivacyApi(configuration.GetSection("Privacy"));

        /// <summary>Configures a privacy Refit interface for use in a service collection.</summary>
        /// <typeparam name="TInterface">Interface type to configure</typeparam>
        /// <param name="services">Service collection to configure privacy support for.</param>
        /// <param name="environment">Environment to configure privacy support against.</param>
        static IServiceCollection AddPrivacyApiRefit<TInterface>(IServiceCollection services, ApiEnvironment environment) where TInterface : class
        {
            var url = environment == ApiEnvironment.Sandbox ? PrivacySandboxApiUrl : PrivacyProductionApiUrl;
            services
                .AddTransient<ApiKeyHeaderHandler>()
                .AddRefitClient<TInterface>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(url))
                .AddHttpMessageHandler<ApiKeyHeaderHandler>();

            return services;
        }

        /// <summary>Configures an api client for accessing V1 of the privacy.com api</summary>
        /// <inheritdoc cref="AddPrivacyApiRefit{TInterface}(IServiceCollection, ApiEnvironment)"/>
        public static IServiceCollection AddPrivacyApiV1(this IServiceCollection services, ApiEnvironment environment) => 
            AddPrivacyApiRefit<IPrivacyApiV1>(services, environment);
    }
}
