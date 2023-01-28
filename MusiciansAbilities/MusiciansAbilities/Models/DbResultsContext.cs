using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MusiciansAbilities.Models;

internal sealed class DbResultsContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<ExperimentResult> ExperimentResults { get; set; }

    public DbResultsContext(DbContextOptions options) : base(options)
    {
        
    }
}