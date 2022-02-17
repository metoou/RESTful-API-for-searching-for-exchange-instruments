using System;
using TestTask.Common;

namespace TestTask.Entities
{
    public class ExchangeEntity : BaseEntity
    {
        /// <summary>
        /// Код биржи.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }
    }
}