using Images.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Images.DataAccess
{
    /// <summary>
    /// Represents a database context.
    /// Implements the <see cref="Microsoft.EntityFrameworkCore.DbContext" />
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class ImagesContext : DbContext
    {
        /// <summary>
        /// Gets or sets the image set.
        /// </summary>
        /// <value>The image set.</value>
        public DbSet<Image> Images { get; set; }

        /// <summary>
        /// Gets or sets the comment set.
        /// </summary>
        /// <value>The comment set.</value>
        public DbSet<Comment> Comments { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImagesContext"/> class.
        /// </summary>
        /// <param name="options">The database context options.</param>
        public ImagesContext(DbContextOptions<ImagesContext> options)
            : base(options)
        { }
    }
}
