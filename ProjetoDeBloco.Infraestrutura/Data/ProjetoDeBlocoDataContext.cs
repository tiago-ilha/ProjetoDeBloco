using ProjetoDeBloco.Dominio.Entidades.Administracao;
using ProjetoDeBloco.Dominio.Entidades.AvaliacaoInstitucional;
using ProjetoDeBloco.Dominio.Entidades.Instituicao.Estrutura;
using ProjetoDeBloco.Dominio.Entidades.Instituicao.Pessoas;
using ProjetoDeBloco.Infraestrutura.Mapeamento;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ProjetoDeBloco.Infraestrutura.Data
{
    public class ProjetoDeBlocoDataContext : DbContext
    {
        public ProjetoDeBlocoDataContext()
			: base("name=ProjetoDeBloco") { }

        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Bloco> Blocos { get; set; }
        public DbSet<Modulo> Modulos { get; set; }
        public DbSet<Turma> Turmas { get; set; }

        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Professor> Professores { get; set; }

        public DbSet<Avaliacao> Avaliacao { get; set; }
        public DbSet<Questao> Questao { get; set; }

        public DbSet<Autorizacao> Autorizacao { get; set; }
		public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<Recurso> Recurso { get; set; }
        public DbSet<RecursoFilho> RecursoFilho { get; set; }
       

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

            modelBuilder.Configurations.Add(new ModuloMap());
            modelBuilder.Configurations.Add(new AvaliacaoMap());
            modelBuilder.Configurations.Add(new QuestaoMap());

            modelBuilder.Configurations.Add(new AutorizacaoMap());
			modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new PerfilMap());
            modelBuilder.Configurations.Add(new RecursoMap());
            modelBuilder.Configurations.Add(new RecursoFilhoMap());

            modelBuilder.Entity<Turma>().Ignore(x => x.Professor);			
        }
    }    
}
