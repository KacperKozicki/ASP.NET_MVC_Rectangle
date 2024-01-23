using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Rectangle.Data
{
    public class KKRectangleDbContext : DbContext
    {
        public DbSet<KKRectangleEntity> Rectangles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=rectangles.db");
        }
    }
}
