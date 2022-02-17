using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using TestTask.Abstractions;
using TestTask.Contract;
using TestTask.Entities;

namespace TestTask.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ExchangeInstrumentController : ControllerBase
    {
        private readonly IService _service;
        private readonly IMapper _mapper;

        public ExchangeInstrumentController(IService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Получение перечня всех эмитентов.
        /// </summary>
        /// <response code="404">В случае если документ не был найден.</response>
        [HttpGet("emitents")]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(List<Emitent>), (int)HttpStatusCode.OK)]
        public async Task<List<Emitent>> Emitents()
        {
            return await _service.GetEmitents();
        }

        /// <summary>
        /// Получение перечня всех активов эмитента по его id.
        /// </summary>
        /// <remarks>
        /// - единый перечень
        /// - без группировки
        /// - только доступные для покупки на бирже активы;
        /// - упорядочить по дате начала обращения;
        /// - только краткая информация.
        /// </remarks>
        /// <param name="emitentId">Идентификатор эмитента.</param>
        /// <response code="404">В случае если документ не был найден.</response>
        [HttpGet("assetsByEmitentId/{emitentId:Guid}")]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(List<ExchangeTradedAssetItem>), (int)HttpStatusCode.OK)]
        public async Task<List<ExchangeTradedAssetItem>> Assets([FromRoute] Guid emitentId)
        {
            return await _service.GetAssetsByEmitentId(emitentId);
        }

        /// <summary>
        /// Получение полной информации об активе акций по его id.
        /// </summary>
        /// <param name="id">Идентификатор актива акций.</param>
        /// <response code="404">В случае если документ не был найден.</response>
        [HttpGet("stockAssetById/{id:Guid}")]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(StockExchangeTradedAsset), (int)HttpStatusCode.OK)]
        public async Task<StockExchangeTradedAsset> StockAssetById([FromRoute] Guid id)
        {
            return await _service.GetStockAssetById(id);
        }

        /// <summary>
        /// Получение полной информации об активе облигаций по его id.
        /// </summary>
        /// <param name="id">Идентификатор актива облигаций.</param>
        /// <response code="404">В случае если документ не был найден.</response>
        [HttpGet("bondAssetById/{id:Guid}")]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BondExchangeTradedAsset), (int)HttpStatusCode.OK)]
        public async Task<BondExchangeTradedAsset> BondAssetById([FromRoute] Guid id)
        {
            return await _service.GetBondAssetById(id);
        }

        /// <summary>
        /// Получение полной информации об активе акций по его isin.
        /// </summary>
        /// <param name="isin">Международный код ISO-6166.</param>
        /// <response code="404">В случае если документ не был найден.</response>
        [HttpGet("stockAssetByIsin")]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(StockExchangeTradedAsset), (int)HttpStatusCode.OK)]
        public async Task<StockExchangeTradedAsset> StockAssetByIsin([FromHeader, Required] string isin)
        {
            return await _service.GetStockAssetByIsin(isin);
        }

        /// <summary>
        /// Получение полной информации об активе облигаций по его isin.
        /// </summary>
        /// <param name="isin">Международный код ISO-6166.</param>
        /// <response code="404">В случае если документ не был найден.</response>
        [HttpGet("bondAssetByIsin")]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BondExchangeTradedAsset), (int)HttpStatusCode.OK)]
        public async Task<BondExchangeTradedAsset> BondAssetByIsin([FromHeader, Required] string isin)
        {
            return await _service.GetBondAssetByIsin(isin);
        }

        /// <summary>
        /// Получение отфильтрованных активов.
        /// </summary>
        /// <remarks>
        /// - по части названия или части ticker'а или части isin-кода;
        /// - в параметре запроса не менее 3 символов;
        /// - дополнительный необязательный параметр - класс актива(для выборки только по заданному классу);
        /// - результаты сгруппированы по классу актива;
        /// - только краткая информация.
        /// </remarks>
        /// <param name="filter">Параметры поиска.</param>
        /// <response code="404">В случае если документ не был найден.</response>
        [HttpPost("assetsbyfilter")]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BondExchangeTradedAsset), (int)HttpStatusCode.OK)]
        public async Task<List<ExchangeTradedAssetItem>> FilteredAssetByParameters([FromBody] AssetFilterParameters filter)
        {
            var settings = _mapper.Map<AssetFilterSettings>(filter);
            return await _service.GetFilteredAssets(settings);
        }
    }
}
