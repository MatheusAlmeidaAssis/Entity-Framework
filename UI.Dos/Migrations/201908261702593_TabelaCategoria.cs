namespace UI.Dos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabelaCategoria : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Produtoes", "Categoria_Id", c => c.Int());
            CreateIndex("dbo.Produtoes", "Categoria_Id");
            AddForeignKey("dbo.Produtoes", "Categoria_Id", "dbo.Categorias", "Id");
            DropColumn("dbo.Produtoes", "Categoria");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produtoes", "Categoria", c => c.String());
            DropForeignKey("dbo.Produtoes", "Categoria_Id", "dbo.Categorias");
            DropIndex("dbo.Produtoes", new[] { "Categoria_Id" });
            DropColumn("dbo.Produtoes", "Categoria_Id");
            DropTable("dbo.Categorias");
        }
    }
}
