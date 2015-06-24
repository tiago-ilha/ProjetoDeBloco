using ProjetoDeBloco.Dominio.Entidades.Instituicao.Estrutura;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Infraestrutura.Mapeamento
{
    public class BlocoMap : EntityTypeConfiguration<Bloco>
    {
        public BlocoMap()
        {
            ToTable("Bloco");

            Property(bloco => bloco.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(bloco => bloco.Nome);

            HasRequired(bloco => bloco.Curso)
               .WithMany().HasForeignKey(bloco => bloco.IdCurso);

        }
    }
}
