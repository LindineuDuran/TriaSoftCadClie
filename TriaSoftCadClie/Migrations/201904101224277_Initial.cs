namespace TriaSoftCadClie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NomeEmpresa = c.String(),
                        NomeCliente = c.String(),
                        Telefone = c.String(),
                        Email = c.String(),
                        Atendimento = c.String(),
                        DataCadastro = c.DateTime(nullable: false),
                        DataAtend = c.DateTime(nullable: false),
                        ProdServID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ProdServ", t => t.ProdServID, cascadeDelete: true)
                .Index(t => t.ProdServID);
            
            CreateTable(
                "dbo.ProdServ",
                c => new
                    {
                        ProdServID = c.Int(nullable: false, identity: true),
                        NomeProdServ = c.String(),
                    })
                .PrimaryKey(t => t.ProdServID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cliente", "ProdServID", "dbo.ProdServ");
            DropIndex("dbo.Cliente", new[] { "ProdServID" });
            DropTable("dbo.ProdServ");
            DropTable("dbo.Cliente");
        }
    }
}
