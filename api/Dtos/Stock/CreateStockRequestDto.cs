using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Stock
{
    public class CreateStockRequestDto
    {
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [StringLength(10, ErrorMessage = "Длина строки не должна превышать 10 символов")]
        public string Symbol { get; set; } = string.Empty;

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [StringLength(30, ErrorMessage = "Длина строки не должна превышать 30 символов")]
        public string CompanyName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Range(0, int.MaxValue)]
        public decimal Purchase { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public decimal LastDiv { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Industry { get; set; } = string.Empty;

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public long MarketCap { get; set; }
    }
}