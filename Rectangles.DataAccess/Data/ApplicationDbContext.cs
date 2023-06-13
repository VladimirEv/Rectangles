using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Rectangles.Models;

namespace Rectangles.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<ColorBody> ColorBodies { get; set; }
        public DbSet<ColorLine> ColorLines { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<Rectangle> Rectangles { get; set; }        
    }
}

