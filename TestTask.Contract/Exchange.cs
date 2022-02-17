using TestTask.Common;

namespace TestTask.Contract
{
    /// <summary>
    /// Биржа.
    /// </summary>
    public class Exchange : BaseContractResponse
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
