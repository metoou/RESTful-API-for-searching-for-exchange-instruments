using TestTask.Common;

namespace TestTask.Contract
{
    /// <summary>
    /// Компания-эмитент.
    /// </summary>
    public class Emitent : BaseContractResponse
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
