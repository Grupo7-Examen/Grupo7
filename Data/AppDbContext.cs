using Microsoft.EntityFrameworkCore;
using TestAPI.Models;

namespace TestAPI.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<SupportTicket> SupportTickets { get; set; }
}