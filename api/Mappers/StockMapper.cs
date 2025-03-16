using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Stock;
using api.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace api.Mappers
{
    public static class StockMapper
    {
        /*
        'this' in params 
        means that you can call
        MyClass myClass = new MyClass();
        int i = myClass.Foo();
        */
        public static StockDto ToStockDto(this Stock stockModel)
        {
            return new StockDto
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Purchase = stockModel.Purchase,
                LastDiv = stockModel.LastDiv,
                Industry = stockModel.Industry,
                MarketCap = stockModel.MarketCap
            };
        }

        public static List<StockDto> ToListStockDto(this List<Stock> stockModels)
        {
            var stockDtos = new List<StockDto>();
            foreach (var item in stockModels)
            {
                stockDtos.Add(item.ToStockDto());
            }
            return stockDtos;
        }

        public static Stock ToStockFromCreateDto(this CreateStockRequestDto requestDto)
        {
            return new Stock
            {
                Id = Guid.NewGuid(),
                Symbol = requestDto.Symbol,
                CompanyName = requestDto.CompanyName,
                Purchase = requestDto.Purchase,
                LastDiv = requestDto.LastDiv,
                Industry = requestDto.Industry,
                MarketCap = requestDto.MarketCap
            };
        }

        public static Stock ToStockFromUpdateDto(this UpdateStockRequestDto updateDto)
        {
            return new Stock
            {
                Id = updateDto.Id,
                Symbol = updateDto.Symbol,
                CompanyName = updateDto.CompanyName,
                Purchase = updateDto.Purchase,
                LastDiv = updateDto.LastDiv,
                Industry = updateDto.Industry,
                MarketCap = updateDto.MarketCap
            };
        }
    }
}