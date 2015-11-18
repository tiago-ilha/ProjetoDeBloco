using ProjetoDeBloco.Dominio.Entidades.Administracao;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Infraestrutura.Mapeamento
{
    public class RecursoFilhoMap : EntityTypeConfiguration<RecursoFilho>
    {
        public RecursoFilhoMap()
        {
            ToTable("RecursoFilho");

            Property(recursofilho => recursofilho.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(recursofilho => recursofilho.Nome).HasColumnType("varchar").HasMaxLength(80).IsRequired();

            HasRequired(x => x.RecursoPai).WithMany(x => x.RecursoFilhos).HasForeignKey(x => x.IdRecursoPai);
        }
    }
}
