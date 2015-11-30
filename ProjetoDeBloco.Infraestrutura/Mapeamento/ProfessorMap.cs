using ProjetoDeBloco.Dominio.Entidades.Instituicao.Pessoas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Infraestrutura.Mapeamento
{
    public class ProfessorMap : EntityTypeConfiguration<Professor>
    {
        public ProfessorMap()
        {
            ToTable("Professor");
           
            Property(professor => professor.AreaDeFormacao).HasColumnType("varchar").HasMaxLength(120).IsRequired();
            Property(professor => professor.AnoDeFormacao).HasColumnType("int").IsRequired();

            HasMany(x => x.Turmas);
        }
    }
}
