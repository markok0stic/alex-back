using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MusiciansAbilities.Models;

public sealed class DbResultsContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<ExperimentResult> ExperimentResults { get; set; }

    public DbResultsContext()
    {
        
    }
    
    public DbResultsContext(DbContextOptions options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>().HasIndex(u => u.SecretId).IsUnique();
    }
}