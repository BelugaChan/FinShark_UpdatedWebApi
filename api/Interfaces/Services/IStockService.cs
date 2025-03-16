using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Stock;
using api.Models;

namespace api.Interfaces.Services
{
    public interface IStockService
    {
        Task<StockDto?> GetByIdAsync(Guid id);

        Task<List<StockDto>> GetAllAsync();

        Task<StockDto> AddAsync(CreateStockRequestDto stockDto);

        Task UpdateAsync(UpdateStockRequestDto stockDto);

        Task DeleteAsync(Guid id);
    }
}