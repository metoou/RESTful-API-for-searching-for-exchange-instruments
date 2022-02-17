namespace TestTask.Common
{
    /// <summary>
    /// Типы облигаций.
    /// </summary>
    public enum BondType : byte
    {
        /// <summary>
        /// Государственная.
        /// </summary>
        State = 1,

        /// <summary>
        /// Муниципальная.
        /// </summary>
        Municipal = 2,

        /// <summary>
        /// Корпоративная.
        /// </summary>
        Corporate = 3
    }
}
