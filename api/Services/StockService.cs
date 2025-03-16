using System.Text.Json;
using api.Dtos.Stock;
using api.Interfaces;
using api.Interfaces.Cache;
using api.Interfaces.Services;
using api.Mappers;
using api.Models;

namespace api.Services
{
    public class StockService : IStockService
    {
        private readonly IStockRepository stockRepository;
        private readonly ICacheService cacheService;

        private static readonly string HashKey = "stockHash";
        public StockService(IStockRepository stockRepository, ICacheService cacheService)
        {
            this.stockRepository = stockRepository;
            this.cacheService = cacheService;
        }
        public async Task<StockDto> AddAsync(CreateStockRequestDto stockDto)
        {
            var stock = stockDto.ToStockFromCreateDto();
            await stockRepository.AddAsync(stock); //добавление новой записи в БД

            //кэширование отдельной записи
            string field = $"stock:{stock.Id}";
            await cacheService.SetToHashTableAsync<Stock>(HashKey, field, stock);

            return stock.ToStockDto();
        }

        public async Task DeleteAsync(Guid id)
        {
            string field = $"stock:{id}";

            await stockRepository.DeleteAsync(id);
            await cacheService.RemoveFromHashTableAsync(HashKey, field);
        }

        public async Task<List<StockDto>> GetAllAsync()
        {
            var stocks = await cacheService.GetAllFromHashTableAsync(HashKey);
            List<Stock> stockList = new();

            if (stocks is not null)
            {
                foreach (var item in stocks)
                {
                    stockList.Add(JsonSerializer.Deserialize<Stock>(item.Value));
                }
                return stockList.ToListStockDto();
            }
            else
            {
                stockList = await stockRepository.GetAllAsync();
                if (stockList is not null && stockList.Count != 0)
                {
                    foreach (var item in stockList)
                    {
                        await cacheService.SetToHashTableAsync<Stock>(HashKey, $"stock:{item.Id}", item);
                    }
                }
                return stockList.ToListStockDto() ?? default;
            }
        }

        public async Task<StockDto?> GetByIdAsync(Guid id)
        {
            string field = $"stock:{id}";
            var stock = await cacheService.GetFromHashTableAsync<Stock>(HashKey, field);
            if (stock is null)
            {
                stock = await stockRepository.GetByIdAsync(id);

                if (stock is not null)
                    await cacheService.SetToHashTableAsync<Stock>(HashKey, field, stock);
                else
                    return default;
            }
            return stock.ToStockDto();
        }

        public async Task UpdateAsync(UpdateStockRequestDto stockDto)
        {
            var stock = stockDto.ToStockFromUpdateDto();
            var currentStock = await stockRepository.GetByIdAsync(stock.Id);
            if (currentStock is not null)
                await stockRepository.UpdateAsync(stock);
            else
                await stockRepository.AddAsync(stock);

            string field = $"stock:{stock.Id}";
            await cacheService.SetToHashTableAsync<Stock>(HashKey, field, stock);
        }
    }
}