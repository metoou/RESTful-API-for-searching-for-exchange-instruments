using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Abstractions;
using TestTask.Entities;

namespace TestTask.Sql
{
    public class Repository : IRepository
    {
        private readonly DatabaseContext _dbContext;
        public Repository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<EmitentEntity>> GetEmitents()
        {
            return await _dbContext.Emitents
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<StockExchangeTradedAssetEntity>> GetStockAssetsByEmitentId(Guid emitentId)
        {
            return await _dbContext.StockExchangeTradedAssets
                .AsNoTracking()
                .Where(x => x.EmitentId == emitentId &&
                            x.EndDate == null)
                .ToListAsync();
        }

        public async Task<List<BondExchangeTradedAssetEntity>> GetBondAssetsByEmitentId(Guid emitentId)
        {
            return await _dbContext.BondExchangeTradedAssets
                .AsNoTracking()
                .Where(x => x.EmitentId == emitentId &&
                            x.EndDate == null)
                .ToListAsync();
        }

        public async Task<StockExchangeTradedAssetEntity> GetStockAssetById(Guid id)
        {
            return await _dbContext.StockExchangeTradedAssets
                .AsNoTracking()
                .Where(x => x.EntityId == id)
                .FirstOrDefaultAsync();
        }

        public async Task<BondExchangeTradedAssetEntity> GetBondAssetById(Guid id)
        {
            return await _dbContext.BondExchangeTradedAssets
                .AsNoTracking()
                .Where(x => x.EntityId == id)
                .FirstOrDefaultAsync();
        }

        public async Task<StockExchangeTradedAssetEntity> GetStockAssetByIsin(string isin)
        {
            return await _dbContext.StockExchangeTradedAssets
                .AsNoTracking()
                .Where(x => x.Isin == isin)
                .FirstOrDefaultAsync();
        }

        public async Task<BondExchangeTradedAssetEntity> GetBondAssetByIsin(string isin)
        {
            return await _dbContext.BondExchangeTradedAssets
                .AsNoTracking()
                .Where(x => x.Isin == isin)
                .FirstOrDefaultAsync();
        }

        public async Task<List<StockExchangeTradedAssetEntity>> GetFilteredStockAssets(AssetFilterSettings filter)
        {
            return await _dbContext.StockExchangeTradedAssets
                .AsNoTracking()
                .Where(x => x.Name == filter.Name ||
                            x.Ticker == filter.Ticker ||
                            x.Isin == filter.Isin ||
                            x.AssetClass == filter.AssetClass.Value)
                .ToListAsync();
        }

        public async Task<List<BondExchangeTradedAssetEntity>> GetFilteredBondAssets(AssetFilterSettings filter)
        {
            return await _dbContext.BondExchangeTradedAssets
                .AsNoTracking()
                .Where(x => x.Name == filter.Name ||
                            x.Ticker == filter.Ticker ||
                            x.Isin == filter.Isin ||
                            x.AssetClass == filter.AssetClass.Value)
                .ToListAsync();
        }
    }
}
