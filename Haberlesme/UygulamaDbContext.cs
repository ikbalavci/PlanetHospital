using Microsoft.EntityFrameworkCore;
using udemyWeb1.Models;

namespace udemyWeb1.Haberlesme
{
    public class UygulamaDbContext : DbContext
    {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options) : base(options) { }

        public DbSet<PoliklinikTuru> PoliklinikTurleri { get; set; }
        
        public DbSet<Doktor> Doktorlar {  get; set; }

    }
}
