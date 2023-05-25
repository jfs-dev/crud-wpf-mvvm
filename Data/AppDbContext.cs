using crud_wpf_mvvm.Models;
using Microsoft.EntityFrameworkCore;

namespace crud_wpf_mvvm.Data;

public class AppDbContext : DbContext
{
    public DbSet<Cliente> Clientes { get; set; } = null!;
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("crud-wpf-mvvm");
    }    
}