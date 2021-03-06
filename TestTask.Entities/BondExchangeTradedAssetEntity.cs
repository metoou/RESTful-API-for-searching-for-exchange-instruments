using System;
using TestTask.Common;

namespace TestTask.Entities
{
    public class BondExchangeTradedAssetEntity : BaseEntity
    {
        /// <summary>
        /// Класс актива.
        /// </summary>
        public AssetClass AssetClass { get; set; }

        /// <summary>
        /// Буквенный идентификатор актива.
        /// </summary>
        public string Ticker { get; set; }

        /// <summary>
        /// Isin (международный код ISO-6166).
        /// </summary>
        public string Isin { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }

        // <summary>
        /// Компания-эмитент.
        /// </summary>
        public Guid EmitentId { get; set; }

        // <summary>
        /// Биржа (на которой торгуется актив).
        /// </summary>
        public Guid ExchangeId { get; set; }

        // <summary>
        /// Период обращения (начало).
        /// </summary>
        public DateTime StartDate { get; set; }

        // <summary>
        /// Период обращения (окончание).
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Базовая валюта.
        /// </summary>
        public string CurrencyBase { get; set; }

        /// <summary>
        /// Размер лота.
        /// </summary>
        public int LotSize { get; set; }

        /// <summary>
        /// Тип облигации.
        /// </summary>
        public BondType BondType { get; set; }
    }
}
