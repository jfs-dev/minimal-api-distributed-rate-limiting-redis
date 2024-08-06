using Microsoft.EntityFrameworkCore;
using minimal_api_distributed_rate_limiting_redis.Models;

namespace minimal_api_distributed_rate_limiting_redis.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Customer> Customers { get; set; }
}
