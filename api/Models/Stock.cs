using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("Stock", Schema = "FinShark")]
    public class Stock
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("symbol")]
        public string Symbol { get; set; } = string.Empty;

        [Column("companyName")]
        public string CompanyName { get; set; } = string.Empty;

        [Column("purchase", TypeName = "decimal(18,2)")]
        public decimal Purchase { get; set; }

        [Column("lastDiv")]
        public decimal LastDiv { get; set; }

        [Column("industry")]
        public string Industry { get; set; } = string.Empty;

        [Column("marketCap")]
        public long MarketCap { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}