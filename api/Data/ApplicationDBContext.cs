using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : DbContext
    {
        //base passes options into DbContext
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Stock)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.StockId)
                .HasConstraintName("FK_Comment_Stock");

            modelBuilder.Entity<Comment>()
                .Property(c => c.StockId)
                .HasColumnName("stockId");
        }
    }
}