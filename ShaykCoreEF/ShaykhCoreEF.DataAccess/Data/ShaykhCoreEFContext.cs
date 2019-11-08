using Microsoft.EntityFrameworkCore;
using ShaykhCoreEF.Domain.Models;

namespace ShaykhCoreEF.DataAccess.Data
{
    public partial class ShaykhCoreEFContext : DbContext
    {
        public ShaykhCoreEFContext(DbContextOptions<ShaykhCoreEFContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }
    }
}
