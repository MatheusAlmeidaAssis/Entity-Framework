namespace UI.Dos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoriaProduto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produtoes", "Categoria", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Produtoes", "Categoria");
        }
    }
}
