// Copyright Jordan Maxwell. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace PrivacyNet.Models.V1
{
    /// <summary>
    /// Virtual credit card managed by Privacy.com
    /// </summary>
    /// <remarks>See https://privacy-com.readme.io/docs/cards#card-schema</remarks>
    public sealed class CardV1
    {
        /// <summary>
        /// An ISO 8601 timestamp (yyyy-MM-ddThh:mm:ssZ) for when the card was created.
        /// </summary>
        public string Created { get; set; } = string.Empty;

        /// <summary>
        /// Three digit CVV printed on the back of the card.
        /// </summary>
        public string CVV { get; set; }

        /// <summary>Funding source associated with this card.</summary>
        /// <seealso cref="FundingSourceV1"/>
        /// <remarks>See https://privacy-com.readme.io/docs/funding-sources#funding-source-schema</remarks>
        public FundingSourceV1 Funding { get; set; } = null!;

        /// <summary>
        /// Two digit (MM) expiry month.
        /// </summary>
        public string ExpMonth { get; set; } = string.Empty;

        /// <summary>
        /// Four digit (yyyy) expiry year.
        /// </summary>
        public string ExpYear { get; set; } = string.Empty;

        /// <summary>
        /// Hostname of card’s locked merchant (will be empty if not applicable).
        /// </summary>
        public string Hostname { get; set; } = string.Empty;

        /// <summary>
        /// Last four digits of the card number.
        /// </summary>
        public string LastFour { get; set; } = string.Empty;

        /// <summary>
        /// Customizable name to identify the card.
        /// </summary>
        public string Memo { get; set; } = string.Empty;

        /// <summary>
        /// Sixteen digit card number. Only available in production for customers who have verified PCI compliance. Available in Sandbox for all users.
        /// </summary>
        public string Pan { get; set; } = string.Empty;

        /// <summary>
        /// Amount (in cents) to limit approved authorizations. Transaction requests above the spend limit will be declined.
        /// </summary>
        public int SpendLimit { get; set; } = 0;

        /// <summary>
        /// Can represent one of the following values: ANNUALLY, FOREVER, MONTHLY, or TRANSACTION.
        /// </summary>
        public string SpendLimitDuration { get; set; } = string.Empty;

        /// <summary>
        /// Can represent one of the following values: CLOSED, OPEN, PAUSED, PENDING_ACTIVATION, or PENDING_FULFILLMENT.
        /// </summary>
        public string State { get; set; } = string.Empty;

        /// <summary>
        /// Globally unique identifier for the card.
        /// </summary>
        public string Token { get; set; } = string.Empty;

        /// <summary>
        /// Type this card represents. Can represent one of the following values: MERCHANT_LOCKED, PHYSICAL, SINGLE_USE, UNLOCKED, or DIGITAL_WALLET.
        /// </summary>
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// List of tokens identifying any Auth Rules that apply to the card. 
        /// Any Auth Rules that apply either at the card, account, or program level will appear.
        /// </summary>
        public List<string> AuthRuleTokens { get; set; } = new List<string>();
    }
}
