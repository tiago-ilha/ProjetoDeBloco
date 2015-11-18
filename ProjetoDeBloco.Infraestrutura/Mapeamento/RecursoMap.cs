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
    public class RecursoMap : EntityTypeConfiguration<Recurso>
    {
        public RecursoMap()
        {
            ToTable("Recurso");

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Nome).HasColumnType("varchar").HasMaxLength(80).IsRequired();

            HasRequired(x => x.Perfil).WithMany(x => x.Recursos).HasForeignKey(x => x.IdPerfil);
        }
    }
}
