using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StockRepository : IStockRepository
    {

        private readonly ApplicationDBContext context;
        public StockRepository(ApplicationDBContext context) => this.context = context;

        public async Task AddAsync(Stock stock)
        {
            context.Stocks.Add(stock);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var stock = await context.Stocks.FindAsync(id);
            if (stock is not null)
            {
                context.Stocks.Remove(stock);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Stock>> GetAllAsync()
         => await context.Stocks.ToListAsync();

        public async Task<Stock?> GetByIdAsync(Guid id)
            => await context.Stocks.FindAsync(id);

        public async Task UpdateAsync(Stock stock)
        {
            context.Stocks.Update(stock);
            await context.SaveChangesAsync();
        }
    }
}