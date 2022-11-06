// Copyright Jordan Maxwell. All rights reserved.
// See LICENSE file in the project root for full license information.

using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace PrivacyNet.Tests.Utils
{
    /// <summary>
    /// Configuration utilities for handling configuration in tests.
    /// </summary>
    public static class ConfigUtil
    {
        public static IConfigurationRoot Get()
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .AddUserSecrets<Program>();
            return configBuilder.Build();
        }
    }
}
