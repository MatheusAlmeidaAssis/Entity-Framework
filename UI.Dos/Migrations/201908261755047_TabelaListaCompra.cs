namespace UI.Dos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabelaListaCompra : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ListaCompras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProdutoListaCompras",
                c => new
                    {
                        Produto_Id = c.Int(nullable: false),
                        ListaCompra_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Produto_Id, t.ListaCompra_Id })
                .ForeignKey("dbo.Produtoes", t => t.Produto_Id, cascadeDelete: true)
                .ForeignKey("dbo.ListaCompras", t => t.ListaCompra_Id, cascadeDelete: true)
                .Index(t => t.Produto_Id)
                .Index(t => t.ListaCompra_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProdutoListaCompras", "ListaCompra_Id", "dbo.ListaCompras");
            DropForeignKey("dbo.ProdutoListaCompras", "Produto_Id", "dbo.Produtoes");
            DropIndex("dbo.ProdutoListaCompras", new[] { "ListaCompra_Id" });
            DropIndex("dbo.ProdutoListaCompras", new[] { "Produto_Id" });
            DropTable("dbo.ProdutoListaCompras");
            DropTable("dbo.ListaCompras");
        }
    }
}
