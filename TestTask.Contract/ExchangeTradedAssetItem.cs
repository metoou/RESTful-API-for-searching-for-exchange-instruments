using TestTask.Common;

namespace TestTask.Contract
{
    public class ExchangeTradedAssetItem : BaseContractResponse
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Класс актива.
        /// </summary>
        public AssetClass AssetClass { get; set; }

        /// <summary>
        /// Isin (международный код ISO-6166).
        /// </summary>
        public string Isin { get; set; }

        /// <summary>
        /// Буквенный идентификатор актива.
        /// </summary>
        public char Ticker { get; set; }

        /// <summary>
        /// Код биржи.
        /// </summary>
        public string ExchangeCode { get; set; }

        /// <summary>
        /// Название эмитента.
        /// </summary>
        public string EmitentName { get; set; }

    }
}
