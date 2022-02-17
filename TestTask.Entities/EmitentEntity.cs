using System;
using TestTask.Common;

namespace TestTask.Entities
{
    public class EmitentEntity : BaseEntity
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Страна.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Отрасль.
        /// </summary>
        public BranchType Branch { get; set; }
    }
}
