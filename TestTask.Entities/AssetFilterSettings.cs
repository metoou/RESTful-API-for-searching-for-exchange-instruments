using TestTask.Common;

namespace TestTask.Entities
{
    public class AssetFilterSettings
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Буквенный идентификатор актива.
        /// </summary>
        public string Ticker { get; set; }

        /// <summary>
        /// Isin (международный код ISO-6166).
        /// </summary>
        public string Isin { get; set; }

        /// <summary>
        /// Класс актива.
        /// </summary>
        public AssetClass? AssetClass { get; set; }
    }
}
