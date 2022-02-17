using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Contract;
using TestTask.Entities;

namespace TestTask.Abstractions
{
    public interface IService
    {
        /// <summary>
        /// Возвращает список всех эмитентов.
        /// </summary>
        Task<List<Emitent>> GetEmitents();

        /// <summary>
        /// Возвращает список всех активов эмитента по его id.
        /// </summary>
        Task<List<ExchangeTradedAssetItem>> GetAssetsByEmitentId(Guid emitentId);

        /// <summary>
        /// Получение полной информации об активе акций по id.
        /// </summary>
        Task<StockExchangeTradedAsset> GetStockAssetById(Guid id);

        /// <summary>
        /// Получение полной информации об активе облегаций по id.
        /// </summary>
        Task<BondExchangeTradedAsset> GetBondAssetById(Guid id);

        /// <summary>
        /// Получение полной информации об активе акций по isin.
        /// </summary>
        Task<StockExchangeTradedAsset> GetStockAssetByIsin(string isin);

        /// <summary>
        /// Получение полной информации об активе облегаций по isin.
        /// </summary>
        Task<BondExchangeTradedAsset> GetBondAssetByIsin(string isin);

        /// <summary>
        /// Возвращает список отфильтрованных активов.
        /// </summary>
        Task<List<ExchangeTradedAssetItem>> GetFilteredAssets(AssetFilterSettings filter);

    }
}
