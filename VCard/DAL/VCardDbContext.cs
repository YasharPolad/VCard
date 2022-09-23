using Microsoft.EntityFrameworkCore;
using VCard.Models;

namespace VCard.DAL
{
    public class VCardDbContext : DbContext
    {
        public DbSet<Vcard> VCards { get; set; }

        public VCardDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
