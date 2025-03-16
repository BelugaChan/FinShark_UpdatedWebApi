using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Interfaces.Services;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/stock")]
    public class StockController : ControllerBase
    {
        private IStockService stockService;
        public StockController(IStockService stockService) => this.stockService = stockService;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stocks = await stockService.GetAllAsync();
            if (stocks is not null)
                return Ok(stocks);
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            try
            {
                var stock = await stockService.GetByIdAsync(id);
                return Ok(stock);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto requestStockDto)
        {
            var stockDto = await stockService.AddAsync(requestStockDto);
            return CreatedAtAction(nameof(GetById), new { id = stockDto.Id }, stockDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateStockRequestDto requestDto)
        {
            try
            {
                await stockService.UpdateAsync(requestDto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                await stockService.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}