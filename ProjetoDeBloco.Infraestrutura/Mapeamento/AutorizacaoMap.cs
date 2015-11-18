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
    public class AutorizacaoMap : EntityTypeConfiguration<Autorizacao>
    {
        public AutorizacaoMap()
        {
            ToTable("Autorizacao");

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(x => x.Usuario).WithMany().HasForeignKey(x => x.IdUsuario);
            HasRequired(x => x.Perfil).WithMany().HasForeignKey(x => x.IdPerfil);
        }
    }
}
