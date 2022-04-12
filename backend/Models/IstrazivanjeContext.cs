using System;
using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class IstrazivanjeContext:DbContext
    {
       public DbSet<Korisnik> Korisnici {get;set;}

        public DbSet<RezultatiTesta> RezultatiTesta { get; set; }

        public IstrazivanjeContext(DbContextOptions options):base(options)
        {
            
        }
    }
}
