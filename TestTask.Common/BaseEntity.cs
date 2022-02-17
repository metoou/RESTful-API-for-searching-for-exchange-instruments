using System;
using System.ComponentModel.DataAnnotations;

namespace TestTask.Common
{
    public class BaseEntity
    {
        [Key]
        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public Guid EntityId { get; set; }
    }
}
