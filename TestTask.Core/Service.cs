using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Abstractions;
using TestTask.Contract;
using TestTask.Entities;

namespace TestTask.Core
{
    public class Service : IService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public Service(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<Emitent>> GetEmitents()
        {
            var emitets = await _repository.GetEmitents();
            return _mapper.Map<List<Emitent>>(emitets);

        }
        public async Task<List<ExchangeTradedAssetItem>> GetAssetsByEmitentId(Guid emitentId)
        {
            var stockAssetsEntities = await _repository.GetStockAssetsByEmitentId(emitentId);
            var stockAssets = _mapper.Map<List<ExchangeTradedAssetItem>>(stockAssetsEntities
                .OrderBy(x => x.StartDate));

            var bondAssetsEntities = await _repository.GetBondAssetsByEmitentId(emitentId);
            var bondAssets = _mapper.Map<List<ExchangeTradedAssetItem>>(bondAssetsEntities
                .OrderBy(x => x.StartDate));

            return stockAssets.Concat(bondAssets).ToList();
        }

        public async Task<BondExchangeTradedAsset> GetBondAssetById(Guid id)
        {
            var bondAsset = await _repository.GetBondAssetById(id);
            return _mapper.Map<BondExchangeTradedAsset>(bondAsset);
        }

        public async Task<BondExchangeTradedAsset> GetBondAssetByIsin(string isin)
        {
            var bondAsset = await _repository.GetBondAssetByIsin(isin);
            return _mapper.Map<BondExchangeTradedAsset>(bondAsset);
        }

        public async Task<StockExchangeTradedAsset> GetStockAssetById(Guid id)
        {
            var stockAsset = await _repository.GetBondAssetById(id);
            return _mapper.Map<StockExchangeTradedAsset>(stockAsset);
        }

        public async Task<StockExchangeTradedAsset> GetStockAssetByIsin(string isin)
        {
            var stockAsset = await _repository.GetBondAssetByIsin(isin);
            return _mapper.Map<StockExchangeTradedAsset>(stockAsset);
        }

        public async Task<List<ExchangeTradedAssetItem>> GetFilteredAssets(AssetFilterSettings filter)
        {
            if (filter.Name.Length < 3 || filter.Ticker.Length < 3 || filter.Isin.Length < 3)
                return null;

            var stockAssetsEntities = await _repository.GetFilteredStockAssets(filter);
            var stockAssets = _mapper.Map<List<ExchangeTradedAssetItem>>(stockAssetsEntities);

            var bondAssetsEntities = await _repository.GetFilteredBondAssets(filter);
            var bondAssets = _mapper.Map<List<ExchangeTradedAssetItem>>(bondAssetsEntities);

            return stockAssets.Concat(bondAssets)
                .OrderBy(x => x.AssetClass)
                .ToList();
        }
    }
}