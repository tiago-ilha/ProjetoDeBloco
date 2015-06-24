using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoDeBloco.Dominio.Entidades.Instituicao.Estrutura;
using ProjetoDeBloco.Dominio.Entidades.Instituicao.Pessoas;
using System.Data.Entity.ModelConfiguration.Conventions;
using ProjetoDeBloco.Infraestrutura.Mapeamento;

namespace ProjetoDeBloco.Infraestrutura.Data
{
    public class ProjetoDeBlocoDataContext : DbContext
    {
        public ProjetoDeBlocoDataContext()
            : base("name=ProjetoDeBloco") { }

        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Bloco> Blocos { get; set; }
        public DbSet<Modulo> Modulos { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Professor> Professores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();            

            modelBuilder.Configurations.Add(new CursoMap());
            modelBuilder.Configurations.Add(new BlocoMap());

            modelBuilder.Configurations.Add(new PessoaMap());
            modelBuilder.Configurations.Add(new AlunoMap());
            modelBuilder.Configurations.Add(new AdministradorMap());
            modelBuilder.Configurations.Add(new ProfessorMap());
        }
    }
}
