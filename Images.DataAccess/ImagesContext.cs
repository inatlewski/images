using Images.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Images.DataAccess
{
    public class ImagesContext : DbContext
    {
        public DbSet<Image> Images { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public ImagesContext(DbContextOptions<ImagesContext> options)
            : base(options)
        { }
    }
}
