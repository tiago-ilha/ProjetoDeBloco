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
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("Usuario");

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Email).HasColumnType("varchar").HasMaxLength(100).IsRequired();
            Property(x => x.Login).HasColumnType("varchar").HasMaxLength(80).IsRequired();
            Property(x => x.Senha).HasColumnType("varchar").HasMaxLength(250).IsRequired();
        }
    }
}
