using Microsoft.EntityFrameworkCore;
using TestAPI.Models;

namespace TestAPI.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
 ErvinBranch
    public DbSet<SupportTicket> SupportTickets { get; set; }

 GaelBranch
    public DbSet<Event> Events { get; set; } = null!;


 main
 main
}