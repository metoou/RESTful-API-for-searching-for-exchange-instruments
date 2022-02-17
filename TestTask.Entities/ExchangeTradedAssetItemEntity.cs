using System;
using TestTask.Common;

namespace TestTask.Entities
{
    public class ExchangeTradedAssetItemEntity : BaseEntity
    {
        /// <summary>
        /// Идентификатор компании-эмитент.
        /// </summary>
        public Guid EmitentId { get; set; }

        /// <summary>
        /// Идентификатор биржи.
        /// </summary>
        public Guid ExchangeId { get; set; }

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