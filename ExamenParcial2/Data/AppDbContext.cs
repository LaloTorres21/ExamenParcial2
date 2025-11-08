using ExamenParcial2.Model;
using Microsoft.EntityFrameworkCore;

namespace ExamenParcial2.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    } 
    
    public DbSet<Participante> Participantes { get; set; }
}