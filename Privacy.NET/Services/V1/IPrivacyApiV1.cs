// Copyright Jordan Maxwell. All rights reserved.
// See LICENSE file in the project root for full license information.

using PrivacyNet.Models.V1;
using Refit;

namespace PrivacyNet.Services
{
    /// <summary>Interface for accessing the V1 interface of the privacy.com api.</summary>
    /// <remarks>https://privacy-com.readme.io/docs/getting-started</remarks>
    public interface IPrivacyApiV1
    {
        /// <summary>
        /// Create either a virtual or physical card.
        /// </summary>
        /// <remarks>
        /// Before physical cards can be issued, there are a few onboarding steps with external party dependencies that must be completed.
        /// Reach out to api@privacy.com or your Customer Success rep for more information. Steps required include:
        /// <list type="bullet">
        /// <item>Establish and validate new BINs with the network and card manufacturer; this ensures that BINs are set up correctly and are ready for use, that transactional data will be sent securely, and that physical cards can be issued by the manufacturer</item>
        /// <item>Set up requirements for card manufacturing (e.g., card art)</item>
        /// <item>Test and confirm card configurations (e.g., spend testing, shipping) for final approval</item>
        /// </list>
        /// See https://privacy-com.readme.io/docs/cards#create-card-issuing
        /// </remarks>
        /// <param name="card">Card instance to be created</param>
        /// <returns>Newly created card instance.</returns>
        [Post("/v1/cards")]
        Task<CardV1> CreateCardAsync([Body(BodySerializationMethod.Serialized)] CardV1 card);

        /// <summary>Update the specified properties of the card. Unsupplied properties will remain unchanged.</summary>
        /// <remarks>See https://privacy-com.readme.io/docs/cards#update-card-issuing</remarks>
        /// <param name="cardId">Card id to update</param>
        /// <param name="card">Details of the new updated card</param>
        /// <returns>Updated card instance.</returns>
        [Patch("/v1/cards/{cardId}")]
        Task<CardV1> UpdateCardAsync([AliasAs("cardId")] int cardId, [Body(BodySerializationMethod.Serialized)] CardV1 card);

        /// <summary>
        /// Get details for all cards. This endpoint can only be used for cards that are managed by the program associated with the calling API key. 
        /// If card_token is passed in as a path parameter, the endpoint returns a single object representing the card specified. 
        /// Otherwise, a list of objects is returned.
        /// </summary>
        /// <param name="accountToken">
        /// Globally unique identifier for an account. This endpoint will return cards associated with this account if included in the request.
        /// String. Permitted values: 36-digit version 4 UUID (including hyphens).
        /// </param>
        /// <param name="begin">Cards created on or after the specified date will be included.
        /// String. Permitted values: Date string in the form YYYY-MM-DD.
        /// </param>
        /// <param name="end">Cards created before the specified date will be included (i.e., cards created on the specified date will not be included).
        /// String. Permitted values: Date string in the form YYYY-MM-DD.
        /// </param>
        /// <param name="pageSize">
        /// For pagination - specifies the number of entries to be included on each page in the response. Default value is 50.
        /// Integer. Permitted values: 1-1000.
        /// </param>
        /// <param name="page">
        /// For pagination - specifies the desired page to be included in the response. For example, if there are 3 total entries, and page_size is 2 (i.e., 2 entries per page), 
        /// then entering the value 2 for page would return the second page and only the third entry. The default is one.
        /// Integer. Permitted values: 1 or greater.
        /// </param>
        /// <remarks>See https://privacy-com.readme.io/docs/cards#list-cards</remarks>
        [Get("/v1/cards")]
        Task<ApiListResultV1<CardV1>> GetCardsAsync(
            [Query("account_token")] string? accountToken = null,
            [Query] string? begin = null,
            [Query] string? end = null,
            [AliasAs("page_size")] int pageSize = 50,
            [Query] int page = 1);

        /// <summary>
        /// Get details for a specified card. This endpoint can only be used for cards that are managed by the program associated with the calling API key. 
        /// If card_token is passed in as a path parameter, the endpoint returns a single object representing the card specified. 
        /// Otherwise, a list of objects is returned.
        /// </summary>
        /// <param name="cardToken">
        /// Globally unique identifier for the card. If using this parameter, do not include other parameters in the request.   
        /// String. Permitted values: 36-digit version 4 UUID (including hyphens).
        /// </param>
        /// <inheritdoc cref="GetCardsAsync"/>
        /// <returns></returns>
        [Get("/v1/cards/{cardToken}")]
        Task<ApiListResultV1<CardV1>> GetCardAsync(
            [AliasAs("cardToken")] string? cardToken = null,
            [Query("account_token")] string? accountToken = null, 
            [Query] string? begin = null, 
            [Query] string? end = null, 
            [AliasAs("page_size")] int pageSize = 50,
            [Query] int page = 1);
    }
}