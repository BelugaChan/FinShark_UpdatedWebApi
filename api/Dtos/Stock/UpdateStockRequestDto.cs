using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Dtos.Stock
{
    public class UpdateStockRequestDto
    {
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Symbol { get; set; } = string.Empty;

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string CompanyName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public decimal Purchase { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public decimal LastDiv { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Industry { get; set; } = string.Empty;

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public long MarketCap { get; set; }
    }
}