using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("Comment", Schema = "FinShark")]
    public class Comment
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("title")]
        public string Title { get; set; } = string.Empty;

        [Column("content")]
        public string Content { get; set; } = string.Empty;

        [Column("createdOn")]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public Guid? StockId { get; set; }

        // nav property
        public Stock? Stock { get; set; }
    }
}