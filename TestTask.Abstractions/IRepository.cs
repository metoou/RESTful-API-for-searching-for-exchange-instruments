using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Entities;

namespace TestTask.Abstractions
{
    public interface IRepository
    {
        /// <summary>
        /// Возвращает список всех эмитентов.
        /// </summary>
        Task<List<EmitentEntity>> GetEmitents();

        /// <summary>
        /// Возвращает список всех акций эмитента по его id.
        /// </summary>
        Task<List<StockExchangeTradedAssetEntity>> GetStockAssetsByEmitentId(Guid emitentId);

        /// <summary>
        /// Возвращает список всех облигаций эмитента по его id.
        /// </summary>
        Task<List<BondExchangeTradedAssetEntity>> GetBondAssetsByEmitentId(Guid emitentId);

        /// <summary>
        /// Получение полной информации об активе акций по id.
        /// </summary>
        Task<StockExchangeTradedAssetEntity> GetStockAssetById(Guid id);

        /// <summary>
        /// Получение полной информации об активе облигаций по id.
        /// </summary>
        Task<BondExchangeTradedAssetEntity> GetBondAssetById(Guid id);

        /// <summary>
        /// Получение полной информации об активе акций по isin.
        /// </summary>
        Task<StockExchangeTradedAssetEntity> GetStockAssetByIsin(string isin);

        /// <summary>
        /// Получение полной информации об активе облигаций по isin.
        /// </summary>
        Task<BondExchangeTradedAssetEntity> GetBondAssetByIsin(string isin);

        /// <summary>
        /// Возвращает список отфильтрованных акций.
        /// </summary>
        Task<List<StockExchangeTradedAssetEntity>> GetFilteredStockAssets(AssetFilterSettings filter);

        /// <summary>
        /// Возвращает список отфильтрованных облигаций.
        /// </summary>
        Task<List<BondExchangeTradedAssetEntity>> GetFilteredBondAssets(AssetFilterSettings filter);
    }
}
