using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TriaSoftCadClie.Models;

namespace TriaSoftCadClie.DAL
{
    public class CadClieContext : DbContext
    {
        public CadClieContext() : base("TriaSoftCadClieContext") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ProdServ> ProdServs { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
    }
}