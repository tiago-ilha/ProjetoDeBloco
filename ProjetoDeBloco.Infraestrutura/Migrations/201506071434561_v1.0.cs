namespace ProjetoDeBloco.Infraestrutura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bloco",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 80, unicode: false),
                        IdCurso = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Curso", t => t.IdCurso)
                .Index(t => t.IdCurso);
            
            CreateTable(
                "dbo.Curso",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 80, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bloco", "IdCurso", "dbo.Curso");
            DropIndex("dbo.Bloco", new[] { "IdCurso" });
            DropTable("dbo.Curso");
            DropTable("dbo.Bloco");
        }
    }
}
