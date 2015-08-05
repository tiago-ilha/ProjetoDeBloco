using ProjetoDeBloco.Dominio.Entidades.AvaliacaoInstitucional;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Infraestrutura.Mapeamento
{
    public class AvaliacaoMap : EntityTypeConfiguration<Avaliacao>
    {
        public AvaliacaoMap()
        {
            ToTable("Avaliacao");

            Property(avaliacao => avaliacao.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(avaliacao => avaliacao.dtInicio);

            Property(avaliacao => avaliacao.dtFim);

            Property(avaliacao => avaliacao.objAvaliacao);

            HasRequired(avaliacao => avaliacao.turma)
               .WithMany().HasForeignKey(avaliacao => avaliacao.IdTurma);
        }
    }
}
