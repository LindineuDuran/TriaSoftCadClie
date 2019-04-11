using System.Data.Entity;

namespace TriaSoftCadClie.Models
{
    public class TriaSoftCadClieContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TriaSoftCadClieContext() : base("name=TriaSoftCadClieContext"){}

        public System.Data.Entity.DbSet<TriaSoftCadClie.Models.ProdServ> ProdServs { get; set; }
        public System.Data.Entity.DbSet<TriaSoftCadClie.Models.Cliente> Clientes { get; set; }
    }
}
