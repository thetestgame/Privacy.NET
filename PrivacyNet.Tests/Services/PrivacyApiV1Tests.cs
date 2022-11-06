// Copyright Jordan Maxwell. All rights reserved.
// See LICENSE file in the project root for full license information.

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PrivacyNet.Models;
using PrivacyNet.Models.V1;
using PrivacyNet.Services;
using PrivacyNet.Tests.Utils;
using PrivacyNet.Utils;

namespace PrivacyNet.Tests.Services
{
    /// <summary>
    /// Tests for <see cref="IPrivacyApiV1"/>.
    /// </summary>
    [TestClass]
    public class PrivacyApiV1Tests
    {
        IConfigurationRoot configuration = null!;

        [TestInitialize]
        public void TestInitialize()
        {
            configuration = ConfigUtil.Get();
        }

        private IServiceProvider CreateServiceProvider()
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IConfiguration>(this.configuration)
                .ConfigurePrivacyApi(this.configuration)
                .AddPrivacyApiV1(ApiEnvironment.Sandbox)
                .BuildServiceProvider();

            return serviceProvider;
        }

        [TestMethod]
        public async Task CreateCardTestAsync()
        {
            var serviceProvider = this.CreateServiceProvider();
            var api = serviceProvider.GetRequiredService<IPrivacyApiV1>();

            var card = new CardV1
            {
                Type = "SINGLE_USE",
                Memo = "New Card",
                SpendLimit = 1000,
                SpendLimitDuration = "TRANSACTION",
                State = "OPEN"
            };

            var createdCard = await api.CreateCardAsync(card);
            Assert.IsNotNull(createdCard);
        }

        [TestMethod]
        public async Task GetCardsTestAsync()
        {
            var serviceProvider = this.CreateServiceProvider();
            var api = serviceProvider.GetRequiredService<IPrivacyApiV1>();
            var cards = await api.GetCardsAsync();
            Assert.IsNotNull(cards);
        }

        [TestMethod]
        public async Task GetCardTestAsync()
        {
            var serviceProvider = this.CreateServiceProvider();
            var api = serviceProvider.GetRequiredService<IPrivacyApiV1>();
            var card = await api.GetCardAsync("8e323b8c-9d18-45fb-9c31-bd1bf80909fb");
            Assert.IsNotNull(card);
        }
    }
}
