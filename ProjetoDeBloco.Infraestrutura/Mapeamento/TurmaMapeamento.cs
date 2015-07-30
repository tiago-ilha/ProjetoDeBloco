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
    public class TurmaMapeamento : EntityTypeConfiguration<Turma>
    {
        public TurmaMapeamento()
        {
            ToTable("Turma");

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(x => x.Modulo).WithMany().HasForeignKey(x => x.IdModulo);
        }
    }
}
