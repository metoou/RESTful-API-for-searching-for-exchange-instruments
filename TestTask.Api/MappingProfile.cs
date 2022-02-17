using AutoMapper;
using TestTask.Contract;
using TestTask.Entities;

namespace TestTask.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AssetFilterParameters, AssetFilterSettings>().ReverseMap();

            CreateMap<BondExchangeTradedAsset, BondExchangeTradedAssetEntity>().ReverseMap();

            CreateMap<Emitent, EmitentEntity>().ReverseMap();

            CreateMap<Exchange, ExchangeEntity>().ReverseMap(); 

            CreateMap<ExchangeTradedAssetItem, ExchangeTradedAssetItemEntity>().ReverseMap();

            CreateMap<StockExchangeTradedAsset, StockExchangeTradedAssetEntity>().ReverseMap();
        }
    }
}
