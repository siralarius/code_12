using Microsoft.EntityFrameworkCore;
using code_12.Models;

namespace code_12.Models
{
    public class SymbolContext : DbContext
    {
        public SymbolContext (DbContextOptions<SymbolContext> options)
            : base(options)
        {
        }

        public DbSet<code_12.Models.Symbol> Symbol { get; set; }

        public DbSet<code_12.Models.Bitcoin> Bitcoin { get; set; }
    }
}