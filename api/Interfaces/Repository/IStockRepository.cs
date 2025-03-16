using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IStockRepository
    {
        Task<Stock?> GetByIdAsync(Guid id);

        Task<List<Stock>> GetAllAsync();

        Task AddAsync(Stock stock);

        Task UpdateAsync(Stock stock);

        Task DeleteAsync(Guid id);
    }
}