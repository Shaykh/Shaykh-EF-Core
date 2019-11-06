using Microsoft.EntityFrameworkCore;
// Add the ShaykhCoreEF.Domain.Models using statement

namespace ShaykhCoreEF.DataAccess.Data
{
    public partial class ShaykhCoreEFContext : DbContext
    {
        public ShaykhCoreEFContext(DbContextOptions<ShaykhCoreEFContext> options)
            : base(options)
        {
        }

        // Add the DbSet<T> properties
    }
}
